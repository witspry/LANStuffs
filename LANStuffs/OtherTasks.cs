using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Threading;

namespace LANStuffs
{
    sealed class OtherTasks
    {
        string laddress;
        string address;
        System.Windows.Forms.Timer timer1;


        public OtherTasks(string laddress, string address)
        {
            this.laddress = laddress;
            this.address = address;
            timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 5000;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
        }


        decimal sent = 0;
        void timer1_Tick(object sender, EventArgs e)
        {

            sent = total_sent;
        }


        decimal file_size = 1;
        string file_name = "";
        string file_path_n_name = "";
        decimal total_sent = 0;
        int progress_maximum = 100;
        bool sent_started = false;


        public decimal FileSize
        {
            get
            {
                return file_size;
            }
            set
            {
                file_size = value;
            }
        }
        public string FileName
        {
            get
            {
                return file_name;
            }
            set
            {
                file_name = value;
            }
        }
        public string FilePathAndName
        {
            get
            {
                return file_path_n_name;
            }
            set
            {
                file_path_n_name = value;
            }
        }
        public decimal TotalSent
        {
            get
            {
                return total_sent;
            }
            set
            {
                total_sent = value;
            }
        }
        public int ProgressMaximum
        {
            get
            {
                return progress_maximum;
            }
            set
            {
                progress_maximum = value;
            }
        }
        public bool SentStarted
        {
            get
            {
                return sent_started;
            }
            set
            {
                sent_started = value;
            }
        }

        public void sendFile()
        {
            String address = "";

            address = DataManager.XMLElements[0][1];
            string ip = address.Substring(0, address.IndexOf(":"));
            IPAddress add = IPAddress.Parse(ip);
            string endp = address.Substring(address.IndexOf(":") + 1, address.Length - address.IndexOf(":") - 1);
            EndPoint ep1 = new IPEndPoint(add, Int32.Parse(endp));
            try
            {
                string filename = FilePathAndName;
                FileStream fs = new FileStream(filename, FileMode.Open);
                //
                FileSize = Math.Round((decimal)fs.Length / 1024);
                //
                Socket sc1 = new Socket(ep1.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                sc1.Connect(ep1);
                string f_name = filename.Substring(filename.LastIndexOf("\\") + 1);
                //
                FileName = f_name;
                //
                Byte[] bytesSent = Encoding.ASCII.GetBytes("<1,3," + f_name + "," + "127.0.0.1:1234" + "> [");
                sc1.Send(bytesSent, bytesSent.Length, 0);
                Byte[] ack = new Byte[64];
                sc1.Receive(ack, ack.Length, 0);
                String ack_string = Encoding.ASCII.GetString(ack).Trim("\0".ToCharArray());
                if (ack_string.Equals("HeaderReceived"))
                {
                    Byte[] filebytes = new Byte[1024 * 4];
                    int bytes_read;
                    //
                    ProgressMaximum = Convert.ToInt32(Math.Round((decimal)fs.Length / 1024));
                    SentStarted = true;
                    //
                    while ((bytes_read = fs.Read(filebytes, 0, (int)fs.Length < 1024 * 4 ? (int)fs.Length : 1024 * 4)) > 0)
                    {
                        //
                        TotalSent += Math.Round((decimal)bytes_read / 1024);
                        //
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
            catch (Exception ex)
            {
                MessageBox.Show("OtherTasks.cs : " + ex.Message);
            }
        }


        public decimal baudRate()
        {
            decimal r_sent = total_sent - sent;
            r_sent /= 5;
            return r_sent;
        }
    }
}
