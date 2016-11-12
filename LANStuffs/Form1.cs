using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Threading;
using System.IO;
using LANStuffs.Option;

namespace LANStuffs
{
    public partial class Form1 : Form
    {
        IPAddress add;
        Thread listener_thread;
        Listener listener;
        string path;
        public Form1()
        {
            InitializeComponent();
            path = DataManager.AppDataPath + "\\" + DataManager.ProductName;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            // Password Query Dialog //
            //LANStuffs.Security.PasswordQuery pquery = new LANStuffs.Security.PasswordQuery();
            //if (pquery.DialogResult == DialogResult.OK)
            //{

            //}
            //else if (pquery.DialogResult == DialogResult.Cancel)
            //{
            //    //this.Close();
            //}

            //else
            //{
            //    if (!(pquery.ShowDialog(this) == DialogResult.OK && DataManager.Authenticated.Equals(true)))
            //    {
            //        this.Close();
            //    }
            //    else
            //    {
            //        //Decrypting usr files if security is enabled//
            //        if (DataManager.IsSecurityEnabled)
            //        {
            //            LANStuffs.Security.FileSecuritySettings.DecryptUserFiles();
            //        }
            //    }
            //}
            ////////////////

            Properties.Settings.Default.ApplicationPath = Environment.CurrentDirectory;
            if (!Properties.Settings.Default.SkinFile.Equals("Default.xml"))
            {
                this.SuspendLayout();
                applySkin(DataManager.GetPath + "\\Option\\Skins\\" + Properties.Settings.Default.SkinFile);
                this.ResumeLayout();
            }
            Properties.Settings.Default.PropertyChanged += new PropertyChangedEventHandler(Default_PropertyChanged);

            this.Icon = Properties.Resources.group;

            btSend.Enabled = false;
            btDisconnect.Enabled = false;

            timer1.Start();
            DataManager.ListenerDone = false;
            IPAddress[] iadd = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
            for (int i = 0; i < iadd.Length; i++)
            {
                //MessageBox.Show(iadd[i].ToString());
            }
            textBox1.Text = "127.0.0.1";// iadd[0].ToString();
            toolStripStatusLabel2.Text = "About";
            DataManager.getXMLElements(path + "\\AddedConnections.xml");
            for (int i = 0; i < DataManager.XMLElements.Length; i++)
            {
                listBox1.Items.Add(DataManager.XMLElements[i][0].Trim());
            }

            /*byte[] b = Encoding.UTF32.GetBytes("Hello a hjks jjdsdhjh hjh hjhds jskdh jh jhd jkshd");
            byte[] d = Crypto.DecryptWithKey(Crypto.EncryptWithKey(b,"ashishjugran"),"ashishjugran");
            String s = Encoding.UTF32.GetString(d);
            MessageBox.Show(s);*/
        }

        void Default_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //throw new Exception("The method or operation is not implemented.");
            if (e.PropertyName.Equals("SkinFile"))
            {
                string app_path = Properties.Settings.Default.ApplicationPath;
                string path = app_path.Substring(0, app_path.LastIndexOf("\\bin"));
                if (!Properties.Settings.Default.SkinFile.Equals("Default.xml"))
                {
                    this.SuspendLayout();
                    applySkin(path + "\\Option\\Skins\\" + Properties.Settings.Default.SkinFile);
                    this.ResumeLayout();
                }
                else
                {
                    this.SuspendLayout();
                    applyDefaultSkin();
                    this.ResumeLayout();
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            listener = new Listener(textBox1.Text, textBox2.Text);

            listener_thread = new Thread(new ThreadStart(listener.Connect));
            listener_thread.Start();
            
            toolStripStatusLabel1.Text = "Connecting...";

            while (!DataManager.ListenerDone) { }
            

            if (!DataManager.listener_failed)
            {
                toolStripStatusLabel1.Text = "Connected";
                sender_method();
            }
        }

        
        private void sender_method()
        {
            
            IPGlobalProperties igp = IPGlobalProperties.GetIPGlobalProperties();
            TcpConnectionInformation[] tci = igp.GetActiveTcpConnections();
            for (int i = 0; i < tci.Length; i++)
            {
               // listBox1.Items.Add(tci[i].LocalEndPoint.ToString());
                //MessageBox.Show(tci[i].LocalEndPoint.ToString());
                //MessageBox.Show(tci[i].RemoteEndPoint.ToString());
            }

                button1.Enabled = false;
                btSend.Enabled = true;
                btDisconnect.Enabled = true;
        }

        private void btSend_Click(object sender, EventArgs e)
        {
            
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string address = "";
                for (int j = 0; j < DataManager.XMLElements.Length ; j++)
                {
                    if (listBox1.Items[i].ToString().Equals(DataManager.XMLElements[j][0].ToString()))
                    {
                        address = DataManager.XMLElements[j][1];
                        break;
                    }
                }
                
                string ip = address.Substring(0, address.IndexOf(":"));
                add = IPAddress.Parse(ip);
                string endp = address.Substring(address.IndexOf(":") + 1, address.Length - address.IndexOf(":") - 1);
                EndPoint ep1 = new IPEndPoint(add, Int32.Parse(endp));
                Socket sc1 = new Socket(ep1.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    sc1.Connect(ep1);
                    Byte[] bytesSent = Encoding.ASCII.GetBytes("<1,1,true," + DataManager.listener_address + "> [");
                    sc1.Send(bytesSent, bytesSent.Length, 0);
                    Byte[] ack = new Byte[64];
                    sc1.Receive(ack, ack.Length, 0);
                    String ack_string = Encoding.ASCII.GetString(ack).Trim("\0".ToCharArray());
                    if(ack_string.Equals("HeaderReceived"))
                    {
                        Byte[] sent = Crypto.Encrypt1(Encoding.UTF32.GetBytes(txtSend.Text));
                        sc1.Send(sent, sent.Length, 0);
                    }
                    sc1.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
            receiver_method();
        }

        private void receiver_method()
        {
            txtReceive.Text += "Me" + " : " +txtSend.Text;
            txtReceive.Text += "\n";
            txtReceive.Select(txtReceive.Text.Length, txtReceive.Text.Length);
            txtReceive.ScrollToCaret();
            txtSend.Clear();
        }

        private void btDisconnect_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Not Connected";
            btDisconnect.Enabled = false;
            button1.Enabled = true;
            btSend.Enabled = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (listener != null)
            {
                listener.Exit();
                listener_thread.Abort();
            }

            //Encrypting user files on closing of program//
            if (DataManager.IsSecurityEnabled)
            {
                LANStuffs.Security.FileSecuritySettings.EncryptUserFiles();
            }


            Properties.Settings.Default.Save();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //receiver_method();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (DataManager.ValueChanged && DataManager.Type == DataManager.SendType.Broadcast && DataManager.DataType == DataManager.SendDataType.Message)
            {
                txtReceive.Text += DataManager.Address + " : " + DataManager.Data;
                txtReceive.Text += "\n";
                txtReceive.Select(txtReceive.Text.Length, txtReceive.Text.Length);
                txtReceive.ScrollToCaret();
                DataManager.ValueChanged = false;
                DataManager.Data = "";
            }
            
            if (DataManager.ValueChanged && DataManager.Type == DataManager.SendType.Broadcast && DataManager.DataType == DataManager.SendDataType.Image)
            {
                DataManager.ValueChanged = false;
                //MessageBox.Show(DataManager.Type.ToString());
                //MessageBox.Show(DataManager.DataType.ToString());
                //MessageBox.Show(DataManager.Address);
                //MessageBox.Show("New File received","User Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                notifyIcon1.BalloonTipTitle = "User Information";
                notifyIcon1.BalloonTipText = "New File Received";
                notifyIcon1.ShowBalloonTip(1000);
            }
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                this.Hide();
            }
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null && !DataManager.listener_address.Equals(""))
            {
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    if (DataManager.XMLElements[i][0].Equals(listBox1.SelectedItem.ToString()))
                    {
                        PrivateChatWindow pcw = new PrivateChatWindow(DataManager.XMLElements[i][1], DataManager.listener_address);
                        pcw.Show(this);
                        break;
                    }
                }
                
            }
        }

        
        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog(this);
        }

        private void bt_AddConnection_Click(object sender, EventArgs e)
        {
            AddConnection ac = new AddConnection();
            if (ac.ShowDialog(this).Equals(DialogResult.OK))
            {
                String s = ac.address();
                listBox1.Items.Add(s);
            }
            
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog(this);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_DeleteConnection_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                DataManager.deleteElement(path + "\\AddedConnections.xml", listBox1.SelectedItem.ToString());
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
        }

        private void bt_Image_Click(object sender, EventArgs e)
        {
            String address = "";

            address = DataManager.XMLElements[0][1];
            string ip = address.Substring(0, address.IndexOf(":"));
            add = IPAddress.Parse(ip);
            string endp = address.Substring(address.IndexOf(":") + 1, address.Length - address.IndexOf(":") - 1);
            EndPoint ep1 = new IPEndPoint(add, Int32.Parse(endp));
            try
            {
                OpenFileDialog ofdlg = new OpenFileDialog();
                if (ofdlg.ShowDialog(this) == DialogResult.OK)
                {
                    string filename = ofdlg.FileName;
                    FileStream fs = new FileStream(filename, FileMode.Open);
                    Socket sc1 = new Socket(ep1.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                    sc1.Connect(ep1);
                    string f_name = filename.Substring(filename.LastIndexOf("\\") + 1);
                    Byte[] bytesSent = Encoding.ASCII.GetBytes("<1,3," + f_name + "," + "127.0.0.1:1234" + "> [");
                    sc1.Send(bytesSent, bytesSent.Length, 0);
                    Byte[] ack = new Byte[64];
                    sc1.Receive(ack, ack.Length, 0);
                    String ack_string = Encoding.ASCII.GetString(ack).Trim("\0".ToCharArray());
                    if (ack_string.Equals("HeaderReceived"))
                    {
                        Byte[] filebytes = new Byte[1024 * 4];
                        int bytes_read;
                        while ((bytes_read = fs.Read(filebytes, 0, (int)fs.Length < 1024 * 4 ? (int)fs.Length : 1024 * 4)) > 0)
                        {
                            //byte[] s = Crypto.Encrypt1(filebytes);
                            byte[] st = new byte[bytes_read];
                            for (int i = 0; i < bytes_read; i++)
                            {
                                st[i] = filebytes[i];
                            }
                            byte[] s = Crypto.Encrypt1(st);
                            //sc1.Send(filebytes, (int)fs.Length < 1024 * 4 ? (int)fs.Length : 1024 * 4, 0);
                            //sc1.Send(s, (int)s.Length < 1024 * 4 ? (int)s.Length : 1024 * 4, 0);
                            sc1.Send(s, s.Length, 0);
                        }
                    }
                    fs.Close();
                    sc1.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtSend_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                btSend.PerformClick();
            }
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Options().ShowDialog(this);
        }

        private void helpTopicsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str = Environment.CurrentDirectory;
            str = str.Substring(0,str.LastIndexOf("\\bin"));
            System.Diagnostics.Process.Start(str+ "\\Help Topics\\HelpTopics.htm");
        }

        private void applySkin(string filename)
        {
            SkinFileParser.parseSkinFile(filename);

            this.BackColor = Color.FromName(SkinFileParser.Form_BackColor);
            this.ForeColor = Color.FromName(SkinFileParser.Form_Font_Color);

            Font button_font = new Font(SkinFileParser.Button_Font_Name, (float)Convert.ToDouble(SkinFileParser.Button_Font_Size)); 
            
            foreach (Control c in this.Controls)
            {
                if (c.GetType().Equals(typeof(GroupBox)))
                {
                    ((GroupBox)c).BackColor = Color.FromName(SkinFileParser.Groupbox_BackColor);
                    ((GroupBox)c).ForeColor = Color.FromName(SkinFileParser.Groupbox_ForeColor);
                    foreach (Control gp in c.Controls)
                    {
                        if (gp.GetType().Equals(typeof(Button)))
                        {
                            ((Button)gp).BackColor = Color.FromName(SkinFileParser.Button_BackColor);
                            ((Button)gp).ForeColor = Color.FromName(SkinFileParser.Button_Font_Color);
                            ((Button)gp).Font = button_font;
                        }
                        else if (gp.GetType().Equals(typeof(ListBox)))
                        {
                            ((ListBox)gp).BackColor = Color.FromName(SkinFileParser.Listbox_BackColor);
                            ((ListBox)gp).ForeColor = Color.FromName(SkinFileParser.Listbox_ForeColor);
                            
                        }
                    }
                }
                if(c.GetType().Equals(typeof(Button)))
                {
                    ((Button)c).BackColor = Color.FromName(SkinFileParser.Button_BackColor);
                    ((Button)c).ForeColor = Color.FromName(SkinFileParser.Button_Font_Color);
                    ((Button)c).Font = button_font;
                }

                if (c.GetType().Equals(typeof(MenuStrip)))
                {
                    ((MenuStrip)c).BackColor = Color.FromName(SkinFileParser.Menustrip_BackColor);
                    ((MenuStrip)c).ForeColor = Color.FromName(SkinFileParser.Menustrip_ForeColor);                    
                }

                if (c.GetType().Equals(typeof(StatusStrip)))
                {
                    ((StatusStrip)c).BackColor = Color.FromName(SkinFileParser.StatusStrip_BackColor);
                    ((StatusStrip)c).ForeColor = Color.FromName(SkinFileParser.StatusStrip_ForeColor);
                }

            }
        }

        private void applyDefaultSkin()
        {
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ForeColor = System.Drawing.SystemColors.ControlText;

            Font button_font = Button.DefaultFont;

            foreach (Control c in this.Controls)
            {
                if (c.GetType().Equals(typeof(GroupBox)))
                {
                    ((GroupBox)c).BackColor = System.Drawing.SystemColors.Control;
                    ((GroupBox)c).ForeColor = System.Drawing.SystemColors.ControlText;
                    foreach (Control gp in c.Controls)
                    {
                        if (gp.GetType().Equals(typeof(Button)))
                        {
                            //((Button)gp).BackColor = Color.Empty;
                            ((Button)gp).ForeColor = Color.Black;
                            ((Button)gp).Font = button_font;
                        }
                        else if (gp.GetType().Equals(typeof(ListBox)))
                        {
                            ((ListBox)gp).BackColor = System.Drawing.SystemColors.Window;
                            ((ListBox)gp).ForeColor = System.Drawing.SystemColors.WindowText;
                        }
                    }
                }
                if (c.GetType().Equals(typeof(Button)))
                {
                    //((Button)c).BackColor = Color.Empty;
                    ((Button)c).ForeColor = System.Drawing.SystemColors.ControlText;
                    ((Button)c).Font = button_font;
                }

                if (c.GetType().Equals(typeof(MenuStrip)))
                {
                    ((MenuStrip)c).BackColor = Color.Empty;
                    ((MenuStrip)c).ForeColor = Control.DefaultForeColor;
                }

                if (c.GetType().Equals(typeof(StatusStrip)))
                {
                    ((StatusStrip)c).BackColor = Color.Empty;
                    ((StatusStrip)c).ForeColor = StatusStrip.DefaultForeColor;
                }
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SendingFileProgressDialog sfpd = new SendingFileProgressDialog(textBox1.Text + ":" + textBox2.Text, "127.0.0.1:1234");
            sfpd.Show(this);
            
            //sfpd.sendFile();
        }

        private void protectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new LANStuffs.Security.ApplicationSecurity().ShowDialog(this);
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            if (((MouseEventArgs)e).Button == MouseButtons.Right)
            {
                
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = true;
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void Form1_StyleChanged(object sender, EventArgs e)
        {
            
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void networkStatisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new NetworkStatistics().Show();
        }

    }
}