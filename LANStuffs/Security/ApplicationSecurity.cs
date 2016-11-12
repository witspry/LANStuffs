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
    public partial class ApplicationSecurity : Form
    {
        string path;
        public ApplicationSecurity()
        {
            InitializeComponent();
            path = DataManager.AppDataPath + "\\" + DataManager.ProductName;
        }

        private void bt_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_OK_Click(object sender, EventArgs e)
        {

            if (!txt_password.Text.Equals(txt_repeat_password.Text))
            {
                string msg = "The text in the password and repeat password fields\n";
                msg += "does not match.";
                MessageBox.Show(msg, "Incorrect details", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }

            
            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }


            //Encryption for Password//
            if (!File.Exists(path + "\\passkey.crypted"))
            {
                FileStream f = File.Create(path + "\\passkey.crypted");
                f.Close();
            }
            FileSecuritySettings.allowWriteAccess(path + "\\passkey.crypted");
            FileStream passkey = File.Open(path + "\\passkey.crypted", FileMode.Create, FileAccess.ReadWrite);
            string pass_string;
            pass_string = "<FileCreationTime>" + FileSecuritySettings.timeStamp(path + "\\passkey.crypted") + "</FileCreationTime>";
            pass_string += "a&#$dlf0948!" + txt_password.Text.Trim();
            byte[] pass_string_bytes = Encoding.ASCII.GetBytes(pass_string);
            byte[] crypted_pass = Crypto.Encrypt1(pass_string_bytes);
            passkey.Write(crypted_pass, 0, crypted_pass.Length);
            passkey.Close();

            //Encryption for Password Recovery Information//
            if (!File.Exists(path + "\\passrecovery.crypted"))
            {
                FileStream f = File.Create(path + "\\passrecovery.crypted");
                f.Close();
            }
            FileSecuritySettings.allowWriteAccess(path + "\\passrecovery.crypted");
            FileStream passrecovery = File.Open(path + "\\passrecovery.crypted", FileMode.Create, FileAccess.ReadWrite);
            string recovery_string;
            recovery_string = "<FileCreationTime>" + FileSecuritySettings.timeStamp(path + "\\passrecovery.crypted") + "</FileCreationTime>";
            recovery_string += ddl_alphabets.SelectedIndex + ",";
            recovery_string += ddl_number.SelectedIndex + ",";
            recovery_string += txt_name.Text.Trim();
            byte[] recovery_string_bytes = Encoding.ASCII.GetBytes(recovery_string);
            byte[] crypted_recovery = Crypto.Encrypt1(recovery_string_bytes);
            passrecovery.Write(crypted_recovery, 0, crypted_recovery.Length);
            passrecovery.Close();

            //Applying ACL Security Permissions//
            FileSecuritySettings.applySecurity(path + "\\passkey.crypted");
            FileSecuritySettings.applySecurity(path + "\\passrecovery.crypted");
            Properties.Settings.Default.PasswordHint = txt_hint.Text;

            if (txt_password.Text.Equals(""))
            {
                DataManager.IsSecurityEnabled = false;
            }
            else
            {
                DataManager.IsSecurityEnabled = true;
            }
            
            this.Close();
        }

        private void ApplicationSecurity_Load(object sender, EventArgs e)
        {
            //loadInformation();
        }

        private void loadInformation()
        {
            string message = "Please enter password to change the application security settings.";

            //********* Password query dialog *******//
            PasswordQuery pquery = new PasswordQuery(message);
            if (pquery.DialogResult == DialogResult.OK)
            { }
            else
            {
                if (!(pquery.ShowDialog(this) == DialogResult.OK && DataManager.Authenticated.Equals(true)))
                {
                    this.Close();
                }
            }
            //

            try
            {
                if (File.Exists(path + "\\passkey.crypted"))
                {
                    FileSecuritySettings.allowReadAccess(path + "\\passkey.crypted");
                    FileStream passkey = File.Open(path + "\\passkey.crypted", FileMode.Open, FileAccess.Read);
                    byte[] pass_string_bytes = new byte[passkey.Length];
                    passkey.Read(pass_string_bytes, 0, pass_string_bytes.Length);
                    byte[] password_bytes = Crypto.Decrypt1(pass_string_bytes);
                    string password = Encoding.ASCII.GetString(password_bytes);
                    password = password.Substring(password.IndexOf("</FileCreationTime>") + "</FileCreationTime>".Length + 12);
                    txt_password.Text = password;
                    passkey.Close();
                }
                if (File.Exists(path + "\\passrecovery.crypted"))
                {
                    FileSecuritySettings.allowReadAccess(path + "\\passrecovery.crypted");

                    FileStream passkey = File.Open(path + "\\passrecovery.crypted", FileMode.Open, FileAccess.Read);

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
                                ddl_alphabets.SelectedIndex = Convert.ToInt32(str);
                                str = "";
                            }
                            else if (i.Equals(1))
                            {
                                ddl_number.SelectedIndex = Convert.ToInt32(str);
                                str = "";
                            }
                            i++;
                        }
                        else
                        {
                            str += c.ToString();
                        }
                    }
                    txt_name.Text = rec_password.Substring(rec_password.LastIndexOf(',') + 1);

                    passkey.Close();
                }
                FileSecuritySettings.applySecurity(path + "\\passkey.crypted");
                FileSecuritySettings.applySecurity(path + "\\passrecovery.crypted");
            }
            catch { }
            txt_hint.Text = Properties.Settings.Default.PasswordHint;
        }
    }
}