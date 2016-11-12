using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace LANStuffs.Security
{
    public partial class PasswordQuery : Form
    {
        string message = "";
        string password = "";
        bool is_more = true;
        int passwords_tried = 1;
        string path = "";
        public PasswordQuery()
        {
            this.message = "This software is password protected. Please enter password to open.";
            InitializeComponent();
            path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\LanStuffs";
            loadPassword();
        }
        public PasswordQuery(string message)
        {
            this.message = message;
            InitializeComponent();
            path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\LanStuffs";
            loadPassword();
        }

        private void bt_OK_Click(object sender, EventArgs e)
        {
            if (password.Equals(txt_password.Text))
            {
                this.Close();
                DataManager.Authenticated = true;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                DataManager.Authenticated = false;
                string str = "Please enter correct password.\n [Note : If you forgot your password";
                str += " you can recover it by providing answers to sequrity questions.]";
                MessageBox.Show(str,"Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                if (passwords_tried < 3)
                {
                    passwords_tried++;
                }
                else
                {
                    this.DialogResult = DialogResult.Cancel;
                }
            }
            
        }

        private void bt_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PasswordQuery_Load(object sender, EventArgs e)
        {
            label1.Text = message;
            txt_hint.Text = Properties.Settings.Default.PasswordHint;
        }

        private void bt_OK2_Click(object sender, EventArgs e)
        {
            int fav_alpha = -1;
            int fav_num = -1;
            string name = "";
            string file_path = path + "\\passrecovery.crypted";
            if (File.Exists(file_path))
            {
                FileSecuritySettings.allowReadAccess(file_path);
                FileStream passkey = File.Open(file_path , FileMode.Open, FileAccess.Read);
                byte[] pass_string_bytes = new byte[passkey.Length];
                passkey.Read(pass_string_bytes, 0, pass_string_bytes.Length);
                byte[] password_bytes = Crypto.Decrypt1(pass_string_bytes);
                string rec_password = Encoding.ASCII.GetString(password_bytes);

                rec_password = rec_password.Substring(rec_password.IndexOf("</FileCreationTime>") + "</FileCreationTime>".Length);
                char[] ch = rec_password.ToCharArray();
                int i = 0;
                string str = "";
                foreach (char c in ch)
                {
                    if (c.Equals(','))
                    {
                        if (i.Equals(0))
                        {
                            fav_alpha = Convert.ToInt32(str);
                            str = "";
                        }
                        else if (i.Equals(1))
                        {
                            fav_num = Convert.ToInt32(str);
                            str = "";
                        }
                        i++;
                    }
                    else
                    {
                        str += c.ToString();
                    }
                }
                name = rec_password.Substring(rec_password.IndexOf("</FileCreationTime>") + rec_password.LastIndexOf(',') + 2);

                passkey.Close();

                FileSecuritySettings.applySecurity(file_path);
            }
            bool correct = ddl_alphabets.SelectedIndex.Equals(fav_alpha);
            correct = correct & ddl_number.SelectedIndex.Equals(fav_num);
            correct = correct & txt_name.Text.Equals(name);

            if (correct)
            {
                txt_recovered_pass.Text = password;
            }
            else
            {
                MessageBox.Show("Please enter correct information.","Password Recovery", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void txt_password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar.Equals(Convert.ToChar(Keys.Return)))
            {
                bt_OK.PerformClick();
            }
        }

        private void loadPassword()
        {
            string file_path = path + "\\passkey.crypted";
            if (File.Exists(file_path))
            {
                FileSecuritySettings.allowReadAccess(file_path);
                FileStream passkey = File.Open(file_path , FileMode.Open, FileAccess.Read);
                byte[] pass_string_bytes = new byte[passkey.Length];
                passkey.Read(pass_string_bytes, 0, pass_string_bytes.Length);
                passkey.Close();
                byte[] password_bytes = Crypto.Decrypt1(pass_string_bytes);
                password = Encoding.ASCII.GetString(password_bytes);
                password = password.Substring(password.IndexOf("</FileCreationTime>") + "</FileCreationTime>".Length + 12);
                FileSecuritySettings.applySecurity(file_path);
                if (!getPassKeyTimeStamp(file_path).Equals(FileSecuritySettings.timeStamp(file_path)))
                {
                    string error = "Error : The password file has been tampered.\nYou can not open the application";
                    MessageBox.Show(error,"Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    this.DialogResult = DialogResult.Cancel;
                    DataManager.Authenticated = false;
                    return;
                }
                else if (password.Equals(""))
                {
                    DataManager.IsSecurityEnabled = false;
                }
                else
                {
                    DataManager.IsSecurityEnabled = true;
                }
            }
            else
            {
                string error = "Error : The password file is not found.\nYou can not open the application";
                MessageBox.Show(error, "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                this.DialogResult = DialogResult.Cancel;
                DataManager.Authenticated = false;
                return;
            }

            if (password.Equals(""))
            {
                this.DialogResult = DialogResult.OK;
                DataManager.Authenticated = true;
            }
        }

        private string getPassKeyTimeStamp(string path)
        {
            string str = "";
            if (File.Exists(path))
            {
                FileSecuritySettings.allowReadAccess(path);
                FileStream passkey = File.Open(path, FileMode.Open, FileAccess.Read);
                byte[] pass_string_bytes = new byte[passkey.Length];
                passkey.Read(pass_string_bytes, 0, pass_string_bytes.Length);
                passkey.Close();
                byte[] password_bytes = Crypto.Decrypt1(pass_string_bytes);
                str = Encoding.ASCII.GetString(password_bytes);
                FileSecuritySettings.applySecurity(path);
            }
            int start_index = "<FileCreationTime>".Length;
            string ms = str.Substring(start_index, str.IndexOf("</FileCreationTime>") - (start_index));
            return ms;
        }

        private void bt_more_Click(object sender, EventArgs e)
        {
            if (is_more)
            {
                this.Height = 316;
                bt_more.Text = "Less <=";
                is_more = false;
            }
            else
            {
                this.Height = 135;
                bt_more.Text = "More =>";
                is_more = true;
            }
        }
        
    }
}