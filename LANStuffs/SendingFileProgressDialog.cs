using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace LANStuffs
{
    public partial class SendingFileProgressDialog : Form
    {
        string laddress = "";
        string address = "";
        decimal baud_rate = 0;
        static decimal sent_in_ten_sec = 0;
        DateTime started;
        int d;
        Timer timer1;
        System.Threading.Thread sendFileThread;
        OtherTasks oth;
        public SendingFileProgressDialog()
        {
            InitializeComponent();
        }
        public SendingFileProgressDialog(string laddress, string address)
        {
            InitializeComponent();
            this.laddress = laddress;
            this.address = address;
            oth = new OtherTasks(laddress, address);
        }

        private void SendingFileProgressDialog_Load(object sender, EventArgs e)
        {
            this.Text = "Sending File";
            lbl_laddress.Text = laddress;
            lbl_address.Text = address;
            timer1 = new Timer();
            timer1.Interval = 500;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
            started = DateTime.Now.AddSeconds(-1);
            
            OpenFileDialog ofdlg = new OpenFileDialog();
            if (ofdlg.ShowDialog() == DialogResult.OK)
            {
                oth.FilePathAndName = ofdlg.FileName;              

                sendFileThread = new System.Threading.Thread(new System.Threading.ThreadStart(oth.sendFile));
                sendFileThread.Start();
                
            } 
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            //Calculate and refreshes baud rate at every 10 seconds///
            TimeSpan subtracted = DateTime.Now.Subtract(started);
            //baud_rate = (oth.TotalSent - sent_in_ten_sec) / subtracted.Seconds;
            baud_rate = oth.baudRate();
            if (subtracted.Seconds > 10)
            {
                started = DateTime.Now.AddSeconds(-1);
                sent_in_ten_sec = oth.TotalSent;
            }
            lbl_baud_rate.Text = Convert.ToString(Math.Round(baud_rate,2)) + " KB/Sec.";

            decimal sent = oth.TotalSent;
            if (sent <= 1023)
            {
                lbl_kbSent.Text = oth.TotalSent.ToString() + " KB";
            }
            else if (sent >= 1024 && sent < (1024 * 1024 - 1))
            {
                sent = sent / 1024;
                lbl_kbSent.Text = Convert.ToString(Math.Round(sent, 2)) + " MB";
            }
            else if (sent >= (1024 * 1024) && sent < (1024 * 1024 * 1024 - 1))
            {
                sent = sent / (1024 * 1024);
                lbl_kbSent.Text = Convert.ToString(Math.Round(sent, 2)) + " GB";
            }
            lbl_percent.Text = Convert.ToString(Math.Round((decimal)((oth.TotalSent * 100) / oth.FileSize)));

            if (oth.SentStarted)
            {
                started = DateTime.Now.AddSeconds(-1);
                decimal file_size = oth.FileSize;
                if (file_size <= 1023)
                {
                    lbl_size_of_file.Text = file_size.ToString() + " KB";
                }
                else if (file_size >= 1024 && file_size < (1024 * 1024 - 1))
                {
                    file_size = file_size / 1024;
                    lbl_size_of_file.Text = Convert.ToString(Math.Round(file_size,2)) + " MB";
                }
                else if (file_size >= (1024 * 1024) && file_size < (1024 * 1024 * 1024 - 1))
                {
                    file_size = file_size / (1024 * 1024);
                    lbl_size_of_file.Text = Convert.ToString(Math.Round(file_size, 2)) + " GB";
                }
                lbl_filesize.Text = "of " + lbl_size_of_file.Text + " Sent";
                lbl_filename.Text = oth.FileName;
                progressBar1.Maximum = oth.ProgressMaximum;

                oth.SentStarted = false;
            }
            progressBar1.Value = Convert.ToInt32(oth.TotalSent);
            if ((d = lbl_kbSent.Left + lbl_kbSent.Width) > lbl_filesize.Left)
            {
                lbl_filesize.Left = d;
            }
            if (lbl_kbSent.Text.Equals(lbl_size_of_file.Text) && ! lbl_size_of_file.Text.Equals("0 KB"))
            {
                timer1.Stop();
                MessageBox.Show("File sending successfully completed.");
                if (sendFileThread.IsAlive)
                {
                    sendFileThread.Abort();
                }
                this.Close();
            }
        }

    }
}