using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using LANStuffs.Games;
using LANStuffs.Option;

namespace LANStuffs
{
    public partial class PrivateChatWindow : Form
    {
        IPAddress add;
        IPEndPoint ep;
        Socket sc;
        String address;
        String laddress;
        public PrivateChatWindow()
        {
            InitializeComponent();
        }
        public PrivateChatWindow(String title, String listener_address)
        {
            InitializeComponent();
            for (int i = 0; i < DataManager.XMLElements.Length; i++)
            {
                if (DataManager.XMLElements[i][1].Equals(title))
                {
                    this.Text = DataManager.XMLElements[i][0];
                }
            }
            address = title;
            laddress = listener_address;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (sc.Connected == false)
            {
                String address = this.address;
                add = IPAddress.Parse(address.Substring(0, address.ToString().LastIndexOf(":")));
                ep = new IPEndPoint(add, Int32.Parse(address.Substring(address.LastIndexOf(":") + 1)));
                sc = new Socket(ep.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                sc.Connect(ep);

                if (sc == null)
                {
                    MessageBox.Show("Connection Failed");
                }

            }
            Byte[] bytesSent = Encoding.ASCII.GetBytes("<2,1,true," + laddress + "> [");
            DataManager.PrivateData = txtSend.Text;
            sc.Send(bytesSent, bytesSent.Length, 0);

            Byte[] ack = new Byte[64];
            sc.Receive(ack, ack.Length, 0);
            String ack_string = Encoding.ASCII.GetString(ack).Trim("\0".ToCharArray());
            if (ack_string.Equals("HeaderReceived"))
            {
                Byte[] sent = Crypto.Encrypt1(Encoding.UTF32.GetBytes(txtSend.Text));
                sc.Send(sent, sent.Length, 0);
            }
            sc.Close();
            receiver_method();
        }

        private void PrivateChatWindow_Load(object sender, EventArgs e)
        {

            if (!Properties.Settings.Default.SkinFile.Equals("Default.xml"))
            {
                this.SuspendLayout();
                applySkin();
                this.ResumeLayout();
            }
            Properties.Settings.Default.PropertyChanged += new PropertyChangedEventHandler(Default_PropertyChanged);

            add = IPAddress.Parse(address.Substring(0, address.ToString().LastIndexOf(":")));
            ep = new IPEndPoint(add, Int32.Parse(address.Substring(address.LastIndexOf(":") + 1)));
            sc = new Socket(ep.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            //sc.Connect(ep);
            timer1.Start();
        }

        void Default_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //throw new Exception("The method or operation is not implemented.");
            if (e.PropertyName.Equals("SkinFile"))
            {
                if (!Properties.Settings.Default.SkinFile.Equals("Default.xml"))
                {
                    this.SuspendLayout();
                    applySkin(DataManager.GetPath + "\\Option\\Skins\\" + Properties.Settings.Default.SkinFile);
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

        private void receiver_method()
        {
            txtSend.Text = "";
            txtReceive.Text += "Me" + " : " + DataManager.PrivateData;
            txtReceive.Text += "\n"; //Convert.ToString((Char)Keys.Return);
            txtReceive.Select(txtReceive.Text.Length, txtReceive.Text.Length);
            txtReceive.ScrollToCaret();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (DataManager.ValueChanged && DataManager.Type == DataManager.SendType.Private && DataManager.DataType == DataManager.SendDataType.Message)
            {
                txtReceive.Text += DataManager.Address + " : " + DataManager.Data;
                txtReceive.Text += "\n";
                txtReceive.Select(txtReceive.Text.Length, txtReceive.Text.Length);
                txtReceive.ScrollToCaret();
                DataManager.ValueChanged = false;
                DataManager.Data = "";
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Equals(treeView1.Nodes[0].Nodes[0]))
            {
                if (TicToeStateManager.opened.Equals(false))
                {
                    new Games.TicToe(address, laddress).Show();
                }
            }
        }

        private void applySkin()
        {
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
                    }
                }
                if (c.GetType().Equals(typeof(Button)))
                {
                    ((Button)c).BackColor = Color.FromName(SkinFileParser.Button_BackColor);
                    ((Button)c).ForeColor = Color.FromName(SkinFileParser.Button_Font_Color);
                    ((Button)c).Font = button_font;
                }

                if (c.GetType().Equals(typeof(TreeView)))
                {
                    ((TreeView)c).BackColor = Color.FromName(SkinFileParser.Listbox_BackColor);
                    ((TreeView)c).ForeColor = Color.FromName(SkinFileParser.Listbox_ForeColor);
                }
            }
        }

        private void applySkin(string filename)
        {
            SkinFileParser.parseSkinFile(filename);
            applySkin();
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
                    }
                }
                if (c.GetType().Equals(typeof(Button)))
                {
                    //((Button)c).BackColor = Color.Empty;
                    ((Button)c).ForeColor = Color.Black;
                    ((Button)c).Font = button_font;
                }

                if (c.GetType().Equals(typeof(TreeView)))
                {
                    ((TreeView)c).BackColor = System.Drawing.SystemColors.Window;
                    ((TreeView)c).ForeColor = System.Drawing.SystemColors.WindowText;
                }
            }
        }

        private void bt_SendFile_Click(object sender, EventArgs e)
        {

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
                    Byte[] bytesSent = Encoding.ASCII.GetBytes("<1,3," + f_name + "," + laddress + "> [");
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
                            byte[] st = new byte[bytes_read];
                            for (int i = 0; i < bytes_read; i++)
                            {
                                st[i] = filebytes[i];
                            }
                            byte[] s = Crypto.Encrypt1(st);
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
    }
}