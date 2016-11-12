using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LANStuffs.Games;
using System.Net;
using System.Net.Sockets;

namespace LANStuffs.Games
{
    public partial class TicToe : Form
    {
        IPAddress add;
        IPEndPoint ep;
        Socket sc;
        String address,laddress,character;
        
        public TicToe()
        {
            InitializeComponent();
        }

        public TicToe(String title, String listener_address)
        {
            InitializeComponent();
            character = "cross";
            address = title;
            laddress = listener_address;

            initializeSeries();
        }

        private void TicToe_Load(object sender, EventArgs e)
        {
            add = IPAddress.Parse(address.Substring(0, address.ToString().LastIndexOf(":")));
            ep = new IPEndPoint(add, Int32.Parse(address.Substring(address.LastIndexOf(":") + 1)));
            sc = new Socket(ep.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            sc.Connect(ep);
            TicToeStateManager.opened = true;
            TicToeStateManager.Turn = TicToeStateManager.Turns.Mine;
            this.Text = "Your turn";
            lbl_result.Text = "";
            bt_Done.Enabled = false;
            timer1.Start();
        }

        private void rbt_cross_CheckedChanged(object sender, EventArgs e)
        {
            character = "cross";
            invertImages();
        }

        private void rbt_circle_CheckedChanged(object sender, EventArgs e)
        {
            character = "circle";
        }

        //************ Click events of all pictureboxes *************//

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (TicToeStateManager.Turn == TicToeStateManager.Turns.Mine)
            {                
                if (!TicToeStateManager.getHasImage(0, 0))
                {
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (!TicToeStateManager.getHasImage(i, j))
                            {
                                if (i == 0 && j == 0)
                                    pictureBox1.Image = null;
                                else if (i == 0 && j == 1)
                                    pictureBox2.Image = null;
                                else if (i == 0 && j == 2)
                                    pictureBox3.Image = null;
                                else if (i == 1 && j == 0)
                                    pictureBox4.Image = null;
                                else if (i == 1 && j == 1)
                                    pictureBox5.Image = null;
                                else if (i == 1 && j == 2)
                                    pictureBox6.Image = null;
                                else if (i == 2 && j == 0)
                                    pictureBox7.Image = null;
                                else if (i == 2 && j == 1)
                                    pictureBox8.Image = null;
                                else if (i == 2 && j == 2)
                                    pictureBox9.Image = null;
                            }
                        }
                    }
                    if (character.Equals("cross"))
                    {
                        pictureBox1.Image = Properties.Resources.cross;
                    }
                    else
                    {
                        pictureBox1.Image = Properties.Resources.circle;
                    }
                    TicToeStateManager.row = 0;
                    TicToeStateManager.col = 0;
                    bt_Done.Enabled = true;
                }
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (TicToeStateManager.Turn == TicToeStateManager.Turns.Mine)
            {
                if (!TicToeStateManager.getHasImage(0, 1))
                {
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (!TicToeStateManager.getHasImage(i, j))
                            {
                                if (i == 0 && j == 0)
                                    pictureBox1.Image = null;
                                else if (i == 0 && j == 1)
                                    pictureBox2.Image = null;
                                else if (i == 0 && j == 2)
                                    pictureBox3.Image = null;
                                else if (i == 1 && j == 0)
                                    pictureBox4.Image = null;
                                else if (i == 1 && j == 1)
                                    pictureBox5.Image = null;
                                else if (i == 1 && j == 2)
                                    pictureBox6.Image = null;
                                else if (i == 2 && j == 0)
                                    pictureBox7.Image = null;
                                else if (i == 2 && j == 1)
                                    pictureBox8.Image = null;
                                else if (i == 2 && j == 2)
                                    pictureBox9.Image = null;
                            }
                        }
                    }
                    if (character.Equals("cross"))
                    {
                        pictureBox2.Image = Properties.Resources.cross;
                    }
                    else
                    {
                        pictureBox2.Image = Properties.Resources.circle;
                    }
                    TicToeStateManager.row = 0;
                    TicToeStateManager.col = 1;
                    bt_Done.Enabled = true;
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (TicToeStateManager.Turn == TicToeStateManager.Turns.Mine)
            {
                if (!TicToeStateManager.getHasImage(0, 2))
                {
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (!TicToeStateManager.getHasImage(i, j))
                            {
                                if (i == 0 && j == 0)
                                    pictureBox1.Image = null;
                                else if (i == 0 && j == 1)
                                    pictureBox2.Image = null;
                                else if (i == 0 && j == 2)
                                    pictureBox3.Image = null;
                                else if (i == 1 && j == 0)
                                    pictureBox4.Image = null;
                                else if (i == 1 && j == 1)
                                    pictureBox5.Image = null;
                                else if (i == 1 && j == 2)
                                    pictureBox6.Image = null;
                                else if (i == 2 && j == 0)
                                    pictureBox7.Image = null;
                                else if (i == 2 && j == 1)
                                    pictureBox8.Image = null;
                                else if (i == 2 && j == 2)
                                    pictureBox9.Image = null;
                            }
                        }
                    }
                    if (character.Equals("cross"))
                    {
                        pictureBox3.Image = Properties.Resources.cross;
                    }
                    else
                    {
                        pictureBox3.Image = Properties.Resources.circle;
                    }
                    TicToeStateManager.row = 0;
                    TicToeStateManager.col = 2;
                    bt_Done.Enabled = true;
                }
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (TicToeStateManager.Turn == TicToeStateManager.Turns.Mine)
            {
                if (!TicToeStateManager.getHasImage(1, 0))
                {
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (!TicToeStateManager.getHasImage(i, j))
                            {
                                if (i == 0 && j == 0)
                                    pictureBox1.Image = null;
                                else if (i == 0 && j == 1)
                                    pictureBox2.Image = null;
                                else if (i == 0 && j == 2)
                                    pictureBox3.Image = null;
                                else if (i == 1 && j == 0)
                                    pictureBox4.Image = null;
                                else if (i == 1 && j == 1)
                                    pictureBox5.Image = null;
                                else if (i == 1 && j == 2)
                                    pictureBox6.Image = null;
                                else if (i == 2 && j == 0)
                                    pictureBox7.Image = null;
                                else if (i == 2 && j == 1)
                                    pictureBox8.Image = null;
                                else if (i == 2 && j == 2)
                                    pictureBox9.Image = null;
                            }
                        }
                    }
                    if (character.Equals("cross"))
                    {
                        pictureBox4.Image = Properties.Resources.cross;
                    }
                    else
                    {
                        pictureBox4.Image = Properties.Resources.circle;
                    }
                    TicToeStateManager.row = 1;
                    TicToeStateManager.col = 0;
                    bt_Done.Enabled = true;
                }
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (TicToeStateManager.Turn == TicToeStateManager.Turns.Mine)
            {
                if (!TicToeStateManager.getHasImage(1, 1))
                {
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (!TicToeStateManager.getHasImage(i, j))
                            {
                                if (i == 0 && j == 0)
                                    pictureBox1.Image = null;
                                else if (i == 0 && j == 1)
                                    pictureBox2.Image = null;
                                else if (i == 0 && j == 2)
                                    pictureBox3.Image = null;
                                else if (i == 1 && j == 0)
                                    pictureBox4.Image = null;
                                else if (i == 1 && j == 1)
                                    pictureBox5.Image = null;
                                else if (i == 1 && j == 2)
                                    pictureBox6.Image = null;
                                else if (i == 2 && j == 0)
                                    pictureBox7.Image = null;
                                else if (i == 2 && j == 1)
                                    pictureBox8.Image = null;
                                else if (i == 2 && j == 2)
                                    pictureBox9.Image = null;
                            }
                        }
                    }
                    if (character.Equals("cross"))
                    {
                        pictureBox5.Image = Properties.Resources.cross;
                    }
                    else
                    {
                        pictureBox5.Image = Properties.Resources.circle;
                    }
                    TicToeStateManager.row = 1;
                    TicToeStateManager.col = 1;
                    bt_Done.Enabled = true;
                }
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (TicToeStateManager.Turn == TicToeStateManager.Turns.Mine)
            {
                if (!TicToeStateManager.getHasImage(1, 2))
                {
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (!TicToeStateManager.getHasImage(i, j))
                            {
                                if (i == 0 && j == 0)
                                    pictureBox1.Image = null;
                                else if (i == 0 && j == 1)
                                    pictureBox2.Image = null;
                                else if (i == 0 && j == 2)
                                    pictureBox3.Image = null;
                                else if (i == 1 && j == 0)
                                    pictureBox4.Image = null;
                                else if (i == 1 && j == 1)
                                    pictureBox5.Image = null;
                                else if (i == 1 && j == 2)
                                    pictureBox6.Image = null;
                                else if (i == 2 && j == 0)
                                    pictureBox7.Image = null;
                                else if (i == 2 && j == 1)
                                    pictureBox8.Image = null;
                                else if (i == 2 && j == 2)
                                    pictureBox9.Image = null;
                            }
                        }
                    }
                    if (character.Equals("cross"))
                    {
                        pictureBox6.Image = Properties.Resources.cross;
                    }
                    else
                    {
                        pictureBox6.Image = Properties.Resources.circle;
                    }
                    TicToeStateManager.row = 1;
                    TicToeStateManager.col = 2;
                    bt_Done.Enabled = true;
                }
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (TicToeStateManager.Turn == TicToeStateManager.Turns.Mine)
            {
                if (!TicToeStateManager.getHasImage(2, 0))
                {
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (!TicToeStateManager.getHasImage(i, j))
                            {
                                if (i == 0 && j == 0)
                                    pictureBox1.Image = null;
                                else if (i == 0 && j == 1)
                                    pictureBox2.Image = null;
                                else if (i == 0 && j == 2)
                                    pictureBox3.Image = null;
                                else if (i == 1 && j == 0)
                                    pictureBox4.Image = null;
                                else if (i == 1 && j == 1)
                                    pictureBox5.Image = null;
                                else if (i == 1 && j == 2)
                                    pictureBox6.Image = null;
                                else if (i == 2 && j == 0)
                                    pictureBox7.Image = null;
                                else if (i == 2 && j == 1)
                                    pictureBox8.Image = null;
                                else if (i == 2 && j == 2)
                                    pictureBox9.Image = null;
                            }
                        }
                    }
                    if (character.Equals("cross"))
                    {
                        pictureBox7.Image = Properties.Resources.cross;
                    }
                    else
                    {
                        pictureBox7.Image = Properties.Resources.circle;
                    }
                    TicToeStateManager.row = 2;
                    TicToeStateManager.col = 0;
                    bt_Done.Enabled = true;
                }
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (TicToeStateManager.Turn == TicToeStateManager.Turns.Mine)
            {
                if (!TicToeStateManager.getHasImage(2, 1))
                {
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (!TicToeStateManager.getHasImage(i, j))
                            {
                                if (i == 0 && j == 0)
                                    pictureBox1.Image = null;
                                else if (i == 0 && j == 1)
                                    pictureBox2.Image = null;
                                else if (i == 0 && j == 2)
                                    pictureBox3.Image = null;
                                else if (i == 1 && j == 0)
                                    pictureBox4.Image = null;
                                else if (i == 1 && j == 1)
                                    pictureBox5.Image = null;
                                else if (i == 1 && j == 2)
                                    pictureBox6.Image = null;
                                else if (i == 2 && j == 0)
                                    pictureBox7.Image = null;
                                else if (i == 2 && j == 1)
                                    pictureBox8.Image = null;
                                else if (i == 2 && j == 2)
                                    pictureBox9.Image = null;
                            }
                        }
                    }
                    if (character.Equals("cross"))
                    {
                        pictureBox8.Image = Properties.Resources.cross;
                    }
                    else
                    {
                        pictureBox8.Image = Properties.Resources.circle;
                    }
                    TicToeStateManager.row = 2;
                    TicToeStateManager.col = 1;
                    bt_Done.Enabled = true;
                }
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            if (TicToeStateManager.Turn == TicToeStateManager.Turns.Mine)
            {
                if (!TicToeStateManager.getHasImage(2, 2))
                {
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (!TicToeStateManager.getHasImage(i, j))
                            {
                                if (i == 0 && j == 0)
                                    pictureBox1.Image = null;
                                else if (i == 0 && j == 1)
                                    pictureBox2.Image = null;
                                else if (i == 0 && j == 2)
                                    pictureBox3.Image = null;
                                else if (i == 1 && j == 0)
                                    pictureBox4.Image = null;
                                else if (i == 1 && j == 1)
                                    pictureBox5.Image = null;
                                else if (i == 1 && j == 2)
                                    pictureBox6.Image = null;
                                else if (i == 2 && j == 0)
                                    pictureBox7.Image = null;
                                else if (i == 2 && j == 1)
                                    pictureBox8.Image = null;
                                else if (i == 2 && j == 2)
                                    pictureBox9.Image = null;
                            }
                        }
                    }
                    if (character.Equals("cross"))
                    {
                        pictureBox9.Image = Properties.Resources.cross;
                    }
                    else
                    {
                        pictureBox9.Image = Properties.Resources.circle;
                    }
                    TicToeStateManager.row = 2;
                    TicToeStateManager.col = 2;
                    bt_Done.Enabled = true;
                }
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (DataManager.ValueChanged && DataManager.Type == DataManager.SendType.Private && DataManager.DataType == DataManager.SendDataType.Game)
            {
                this.Text = "Your turn";

                #region
                if (TicToeStateManager.received_row.Equals(0) && TicToeStateManager.received_col.Equals(0))
                {
                    if (!character.Equals("cross"))
                    {
                        pictureBox1.Image = Properties.Resources.cross;
                    }
                    else
                    {
                        pictureBox1.Image = Properties.Resources.circle;
                    }
                    TicToeStateManager.row = 0;
                    TicToeStateManager.col = 0;
                    TicToeStateManager.setHasImage();
                }
                else if (TicToeStateManager.received_row.Equals(0) && TicToeStateManager.received_col.Equals(1))
                {
                    if (!character.Equals("cross"))
                    {
                        pictureBox2.Image = Properties.Resources.cross;
                    }
                    else
                    {
                        pictureBox2.Image = Properties.Resources.circle;
                    }
                    TicToeStateManager.row = 0;
                    TicToeStateManager.col = 1;
                    TicToeStateManager.setHasImage();
                }
                else if (TicToeStateManager.received_row.Equals(0) && TicToeStateManager.received_col.Equals(2))
                {
                    if (!character.Equals("cross"))
                    {
                        pictureBox3.Image = Properties.Resources.cross;
                    }
                    else
                    {
                        pictureBox3.Image = Properties.Resources.circle;
                    }
                    TicToeStateManager.row = 0;
                    TicToeStateManager.col = 2;
                    TicToeStateManager.setHasImage();
                }
                else if (TicToeStateManager.received_row.Equals(1) && TicToeStateManager.received_col.Equals(0))
                {
                    if (!character.Equals("cross"))
                    {
                        pictureBox4.Image = Properties.Resources.cross;
                    }
                    else
                    {
                        pictureBox4.Image = Properties.Resources.circle;
                    }
                    TicToeStateManager.row = 1;
                    TicToeStateManager.col = 0;
                    TicToeStateManager.setHasImage();
                }
                else if (TicToeStateManager.received_row.Equals(1) && TicToeStateManager.received_col.Equals(1))
                {
                    if (!character.Equals("cross"))
                    {
                        pictureBox5.Image = Properties.Resources.cross;
                    }
                    else
                    {
                        pictureBox5.Image = Properties.Resources.circle;
                    }
                    TicToeStateManager.row = 1;
                    TicToeStateManager.col = 1;
                    TicToeStateManager.setHasImage();
                }
                else if (TicToeStateManager.received_row.Equals(1) && TicToeStateManager.received_col.Equals(2))
                {
                    if (!character.Equals("cross"))
                    {
                        pictureBox6.Image = Properties.Resources.cross;
                    }
                    else
                    {
                        pictureBox6.Image = Properties.Resources.circle;
                    }
                    TicToeStateManager.row = 1;
                    TicToeStateManager.col = 2;
                    TicToeStateManager.setHasImage();
                }
                else if (TicToeStateManager.received_row.Equals(2) && TicToeStateManager.received_col.Equals(0))
                {
                    if (!character.Equals("cross"))
                    {
                        pictureBox7.Image = Properties.Resources.cross;
                    }
                    else
                    {
                        pictureBox7.Image = Properties.Resources.circle;
                    }
                    TicToeStateManager.row = 2;
                    TicToeStateManager.col = 0;
                    TicToeStateManager.setHasImage();
                }
                else if (TicToeStateManager.received_row.Equals(2) && TicToeStateManager.received_col.Equals(1))
                {
                    if (!character.Equals("cross"))
                    {
                        pictureBox8.Image = Properties.Resources.cross;
                    }
                    else
                    {
                        pictureBox8.Image = Properties.Resources.circle;
                    }
                    TicToeStateManager.row = 2;
                    TicToeStateManager.col = 1;
                    TicToeStateManager.setHasImage();
                }
                else if (TicToeStateManager.received_row.Equals(2) && TicToeStateManager.received_col.Equals(2))
                {
                    if (!character.Equals("cross"))
                    {
                        pictureBox9.Image = Properties.Resources.cross;
                    }
                    else
                    {
                        pictureBox9.Image = Properties.Resources.circle;
                    }
                    TicToeStateManager.row = 2;
                    TicToeStateManager.col = 2;
                    TicToeStateManager.setHasImage();
                }
                #endregion

                numericUpDown1.Value = TicToeStateManager.ReceivedNumberOfMatches;
                TicToeStateManager.NumberOfMatches = TicToeStateManager.ReceivedNumberOfMatches;
                TicToeStateManager.ReceivedNumberOfMatches = 1;
                numericUpDown1.Enabled = false;
                bt_Set.Enabled = false;

                DataManager.ValueChanged = false;
            }

            evaluateResult();
        }

        private void bt_Done_Click(object sender, EventArgs e)
        {
            lbl_result.Text = "";
            if (numericUpDown1.Enabled.Equals(true))
            {
                MessageBox.Show("Please, First set the number of matches to be played");
                return;
            }
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
            Byte[] bytesSent = Encoding.ASCII.GetBytes("<2,5,true," + laddress + "> [");
            //DataManager.PrivateData = txtSend.Text;
            sc.Send(bytesSent, bytesSent.Length, 0);

            Byte[] ack = new Byte[64];
            sc.Receive(ack, ack.Length, 0);
            String ack_string = Encoding.ASCII.GetString(ack).Trim("\0".ToCharArray());
            if (ack_string.Equals("HeaderReceived"))
            {
                Byte[] sent = Crypto.Encrypt1(Encoding.UTF32.GetBytes(TicToeStateManager.row.ToString() + "," + TicToeStateManager.col.ToString() + "," + TicToeStateManager.NumberOfMatches.ToString()));
                sc.Send(sent, sent.Length, 0);
                TicToeStateManager.Turn = TicToeStateManager.Turns.His;
            }
            sc.Close();
            TicToeStateManager.setImage("cross");
            TicToeStateManager.setHasImage();
            if (TicToeStateManager.StartingTurn == 0)
            {
                setWhoStarts();
            }
            bt_Done.Enabled = false;
            this.Text = "Opponent's turn : Please wait...";
        }

        private void TicToe_FormClosed(object sender, FormClosedEventArgs e)
        {
            TicToeStateManager.opened = false;
        }

        private void invertImages()
        {
            //For inverting picture1 image
            if (!TicToeStateManager.getImage(0, 0).Equals("none"))
            {
                if (rbt_cross.Checked)
                {
                    if (TicToeStateManager.getImage(0, 0).Equals("cross"))
                        pictureBox1.Image = Properties.Resources.cross;
                    else if (TicToeStateManager.getImage(0, 0).Equals("circle"))
                        pictureBox1.Image = Properties.Resources.circle;
                }
                else if (rbt_circle.Checked)
                {
                    if (TicToeStateManager.getImage(0, 0).Equals("cross"))
                        pictureBox1.Image = Properties.Resources.circle;
                    else if (TicToeStateManager.getImage(0, 0).Equals("circle"))
                        pictureBox1.Image = Properties.Resources.cross;
                }
            }
            else
            {
                if (TicToeStateManager.row.Equals(0) && TicToeStateManager.col.Equals(0) && rbt_cross.Checked)
                {
                    pictureBox1.Image = Properties.Resources.cross;
                }
                else if(TicToeStateManager.row.Equals(0) && TicToeStateManager.col.Equals(0))
                {
                    pictureBox1.Image = Properties.Resources.circle;
                }
            }

            //For inverting picture2 image
            if (!TicToeStateManager.getImage(0, 1).Equals("none"))
            {
                if (rbt_cross.Checked)
                {
                    if (TicToeStateManager.getImage(0, 1).Equals("cross"))
                        pictureBox2.Image = Properties.Resources.cross;
                    else if (TicToeStateManager.getImage(0, 1).Equals("circle"))
                        pictureBox2.Image = Properties.Resources.circle;                    
                }
                else if (rbt_circle.Checked)
                {
                    if (TicToeStateManager.getImage(0, 1).Equals("cross"))
                        pictureBox2.Image = Properties.Resources.circle;
                    else if (TicToeStateManager.getImage(0, 1).Equals("circle"))
                        pictureBox2.Image = Properties.Resources.cross;
                }
                
            }
            else
            {
                if (TicToeStateManager.row.Equals(0) && TicToeStateManager.col.Equals(1) && rbt_cross.Checked)
                {
                    pictureBox2.Image = Properties.Resources.cross;
                }
                else if (TicToeStateManager.row.Equals(0) && TicToeStateManager.col.Equals(1))
                {
                    pictureBox2.Image = Properties.Resources.circle;
                }
            }

            //For inverting picture3 image
            if (!TicToeStateManager.getImage(0, 2).Equals("none"))
            {
                if (rbt_cross.Checked)
                {
                    if (TicToeStateManager.getImage(0, 2).Equals("cross"))
                        pictureBox3.Image = Properties.Resources.cross;
                    else if (TicToeStateManager.getImage(0, 2).Equals("circle"))
                        pictureBox3.Image = Properties.Resources.circle;
                }
                else if (rbt_circle.Checked)
                {
                    if (TicToeStateManager.getImage(0, 2).Equals("cross"))
                        pictureBox3.Image = Properties.Resources.circle;
                    else if (TicToeStateManager.getImage(0, 2).Equals("circle"))
                        pictureBox3.Image = Properties.Resources.cross;
                }

            }
            else
            {
                if (TicToeStateManager.row.Equals(0) && TicToeStateManager.col.Equals(2) && rbt_cross.Checked)
                {
                    pictureBox3.Image = Properties.Resources.cross;
                }
                else if (TicToeStateManager.row.Equals(0) && TicToeStateManager.col.Equals(2))
                {
                    pictureBox3.Image = Properties.Resources.circle;
                }
            }

            //For inverting picture4 image
            if (!TicToeStateManager.getImage(1, 0).Equals("none"))
            {
                if (rbt_cross.Checked)
                {
                    if (TicToeStateManager.getImage(1, 0).Equals("cross"))
                        pictureBox4.Image = Properties.Resources.cross;
                    else if (TicToeStateManager.getImage(1, 0).Equals("circle"))
                        pictureBox4.Image = Properties.Resources.circle;
                }
                else if (rbt_circle.Checked)
                {
                    if (TicToeStateManager.getImage(1, 0).Equals("cross"))
                        pictureBox4.Image = Properties.Resources.circle;
                    else if (TicToeStateManager.getImage(1, 0).Equals("circle"))
                        pictureBox4.Image = Properties.Resources.cross;
                }

            }
            else
            {
                if (TicToeStateManager.row.Equals(1) && TicToeStateManager.col.Equals(0) && rbt_cross.Checked)
                {
                    pictureBox4.Image = Properties.Resources.cross;
                }
                else if (TicToeStateManager.row.Equals(1) && TicToeStateManager.col.Equals(0))
                {
                    pictureBox4.Image = Properties.Resources.circle;
                }
            }

            //For inverting picture5 image
            if (!TicToeStateManager.getImage(1, 1).Equals("none"))
            {
                if (rbt_cross.Checked)
                {
                    if (TicToeStateManager.getImage(1, 1).Equals("cross"))
                        pictureBox5.Image = Properties.Resources.cross;
                    else if (TicToeStateManager.getImage(1, 1).Equals("circle"))
                        pictureBox5.Image = Properties.Resources.circle;
                }
                else if (rbt_circle.Checked)
                {
                    if (TicToeStateManager.getImage(1, 1).Equals("cross"))
                        pictureBox5.Image = Properties.Resources.circle;
                    else if (TicToeStateManager.getImage(1, 1).Equals("circle"))
                        pictureBox5.Image = Properties.Resources.cross;
                }

            }
            else
            {
                if (TicToeStateManager.row.Equals(1) && TicToeStateManager.col.Equals(1) && rbt_cross.Checked)
                {
                    pictureBox5.Image = Properties.Resources.cross;
                }
                else if (TicToeStateManager.row.Equals(1) && TicToeStateManager.col.Equals(1))
                {
                    pictureBox5.Image = Properties.Resources.circle;
                }
            }

            //For inverting picture6 image
            if (!TicToeStateManager.getImage(1, 2).Equals("none"))
            {
                if (rbt_cross.Checked)
                {
                    if (TicToeStateManager.getImage(1, 2).Equals("cross"))
                        pictureBox6.Image = Properties.Resources.cross;
                    else if (TicToeStateManager.getImage(1, 2).Equals("circle"))
                        pictureBox6.Image = Properties.Resources.circle;
                }
                else if (rbt_circle.Checked)
                {
                    if (TicToeStateManager.getImage(1, 2).Equals("cross"))
                        pictureBox6.Image = Properties.Resources.circle;
                    else if (TicToeStateManager.getImage(1, 2).Equals("circle"))
                        pictureBox6.Image = Properties.Resources.cross;
                }

            }
            else
            {
                if (TicToeStateManager.row.Equals(1) && TicToeStateManager.col.Equals(2) && rbt_cross.Checked)
                {
                    pictureBox6.Image = Properties.Resources.cross;
                }
                else if (TicToeStateManager.row.Equals(1) && TicToeStateManager.col.Equals(2))
                {
                    pictureBox6.Image = Properties.Resources.circle;
                }
            }

            //For inverting picture7 image
            if (!TicToeStateManager.getImage(2, 0).Equals("none"))
            {
                if (rbt_cross.Checked)
                {
                    if (TicToeStateManager.getImage(2, 0).Equals("cross"))
                        pictureBox7.Image = Properties.Resources.cross;
                    else if (TicToeStateManager.getImage(2, 0).Equals("circle"))
                        pictureBox7.Image = Properties.Resources.circle;
                }
                else if (rbt_circle.Checked)
                {
                    if (TicToeStateManager.getImage(2, 0).Equals("cross"))
                        pictureBox7.Image = Properties.Resources.circle;
                    else if (TicToeStateManager.getImage(2, 0).Equals("circle"))
                        pictureBox7.Image = Properties.Resources.cross;
                }

            }
            else
            {
                if (TicToeStateManager.row.Equals(2) && TicToeStateManager.col.Equals(0) && rbt_cross.Checked)
                {
                    pictureBox7.Image = Properties.Resources.cross;
                }
                else if (TicToeStateManager.row.Equals(2) && TicToeStateManager.col.Equals(0))
                {
                    pictureBox7.Image = Properties.Resources.circle;
                }
            }

            //For inverting picture8 image
            if (!TicToeStateManager.getImage(2, 1).Equals("none"))
            {
                if (rbt_cross.Checked)
                {
                    if (TicToeStateManager.getImage(2, 1).Equals("cross"))
                        pictureBox8.Image = Properties.Resources.cross;
                    else if (TicToeStateManager.getImage(2, 1).Equals("circle"))
                        pictureBox8.Image = Properties.Resources.circle;
                }
                else if (rbt_circle.Checked)
                {
                    if (TicToeStateManager.getImage(2, 1).Equals("cross"))
                        pictureBox8.Image = Properties.Resources.circle;
                    else if (TicToeStateManager.getImage(2, 1).Equals("circle"))
                        pictureBox8.Image = Properties.Resources.cross;
                }

            }
            else
            {
                if (TicToeStateManager.row.Equals(2) && TicToeStateManager.col.Equals(1) && rbt_cross.Checked)
                {
                    pictureBox8.Image = Properties.Resources.cross;
                }
                else if (TicToeStateManager.row.Equals(2) && TicToeStateManager.col.Equals(1))
                {
                    pictureBox8.Image = Properties.Resources.circle;
                }
            }

            //For inverting picture9 image
            if (!TicToeStateManager.getImage(2, 2).Equals("none"))
            {
                if (rbt_cross.Checked)
                {
                    if (TicToeStateManager.getImage(2, 2).Equals("cross"))
                        pictureBox9.Image = Properties.Resources.cross;
                    else if (TicToeStateManager.getImage(2, 2).Equals("circle"))
                        pictureBox9.Image = Properties.Resources.circle;
                }
                else if (rbt_circle.Checked)
                {
                    if (TicToeStateManager.getImage(2, 2).Equals("cross"))
                        pictureBox9.Image = Properties.Resources.circle;
                    else if (TicToeStateManager.getImage(2, 2).Equals("circle"))
                        pictureBox9.Image = Properties.Resources.cross;
                }

            }
            else
            {
                if (TicToeStateManager.row.Equals(2) && TicToeStateManager.col.Equals(2) && rbt_cross.Checked)
                {
                    pictureBox9.Image = Properties.Resources.cross;
                }
                else if (TicToeStateManager.row.Equals(2) && TicToeStateManager.col.Equals(2))
                {
                    pictureBox9.Image = Properties.Resources.circle;
                }
            }
        }

        private void setWhoStarts()
        {
            int count = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (TicToeStateManager.getImage(i, j).Equals("circle"))
                    {
                        count++;
                    }
                }
            }
            if (count.Equals(0))
            {
                TicToeStateManager.StartingTurn = TicToeStateManager.Turns.Mine;
            }
            else
            {
                TicToeStateManager.StartingTurn = TicToeStateManager.Turns.His;
            }
        }

        private void initializeAll()
        {
            TicToeStateManager.WinState = TicToeStateManager.WinStates.None;
            TicToeStateManager.initialize();
            foreach (Control c in this.Controls)
            {
                if (c.GetType().Equals(pictureBox1.GetType()))
                {
                    ((PictureBox)c).Image = null;
                }
            }

            if (TicToeStateManager.StartingTurn == TicToeStateManager.Turns.Mine)
            {
                TicToeStateManager.StartingTurn = TicToeStateManager.Turns.His;
                TicToeStateManager.Turn = TicToeStateManager.Turns.His;
                this.Text = "Opponent's turn : Please wait...";
            }
            else
            {
                TicToeStateManager.StartingTurn = TicToeStateManager.Turns.Mine;
                TicToeStateManager.Turn = TicToeStateManager.Turns.Mine;
                this.Text = "Your turn";
            }

        }

        private void initializeSeries()
        {
            TicToeStateManager.initialize();
            foreach (Control c in this.Controls)
            {
                if (c.GetType().Equals(pictureBox1.GetType()))
                {
                    ((PictureBox)c).Image = null;
                }
            }

            this.numericUpDown1.Enabled = true;
            this.numericUpDown1.Value = 1;
            this.bt_Set.Enabled = true;

            TicToeStateManager.MatchesPlayed = 0;
            TicToeStateManager.NumberOfMatches = 1;
            TicToeStateManager.Turn = TicToeStateManager.Turns.Mine;
            TicToeStateManager.StartingTurn = 0;

            TicToeStateManager.TotalDraw = 0;
            TicToeStateManager.TotalLose = 0;
            TicToeStateManager.TotalWins = 0;
            TicToeStateManager.WinState = TicToeStateManager.WinStates.None;

            lbl_opp_draw.Text = "0";
            lbl_opp_lose.Text = "0";
            lbl_opp_total.Text = "0";
            lbl_opp_win.Text = "0";
            lbl_you_draw.Text = "0";
            lbl_you_lose.Text = "0";
            lbl_you_total.Text = "0";
            lbl_you_win.Text = "0";

            this.Text = "Your Turn";
        }

        public void evaluateResult()
        {
            bool[] mycondition = new bool[8];
            bool[] hiscondition = new bool[8];
            bool drawcondition = false;
            for (int i = 0; i < 8; i++)
            {
                mycondition[i] = true;
                hiscondition[i] = true;
            }
            for (int i = 0; i < 3; i++)
            {
                mycondition[0] = mycondition[0] && TicToeStateManager.getImage(i, i).Equals("cross");
                hiscondition[0] = hiscondition[0] && TicToeStateManager.getImage(i, i).Equals("circle");
                mycondition[1] = mycondition[1] && TicToeStateManager.getImage(0, i).Equals("cross");
                hiscondition[1] = hiscondition[1] && TicToeStateManager.getImage(0, i).Equals("circle");
                mycondition[2] = mycondition[2] && TicToeStateManager.getImage(1, i).Equals("cross");
                hiscondition[2] = hiscondition[2] && TicToeStateManager.getImage(1, i).Equals("circle");
                mycondition[3] = mycondition[3] && TicToeStateManager.getImage(2, i).Equals("cross");
                hiscondition[3] = hiscondition[3] && TicToeStateManager.getImage(2, i).Equals("circle");
                mycondition[4] = mycondition[4] && TicToeStateManager.getImage(i, 0).Equals("cross");
                hiscondition[4] = hiscondition[4] && TicToeStateManager.getImage(i, 0).Equals("circle");
                mycondition[5] = mycondition[5] && TicToeStateManager.getImage(i, 1).Equals("cross");
                hiscondition[5] = hiscondition[5] && TicToeStateManager.getImage(i, 1).Equals("circle");
                mycondition[6] = mycondition[6] && TicToeStateManager.getImage(i, 2).Equals("cross");
                hiscondition[6] = hiscondition[6] && TicToeStateManager.getImage(i, 2).Equals("circle");
                mycondition[7] = mycondition[7] && TicToeStateManager.getImage(i, 2 - i).Equals("cross");
                hiscondition[7] = hiscondition[7] && TicToeStateManager.getImage(i, 2 - i).Equals("circle");
            }
            int count = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (!TicToeStateManager.getImage(i, j).Equals("none"))
                    {
                        count++;
                    }
                }
            }
            if (count.Equals(9))
            {
                drawcondition = true;
            }
            for (int i = 0; i < 8; i++)
            {
                if (mycondition[i].Equals(true))
                    TicToeStateManager.WinState = TicToeStateManager.WinStates.Win;
                else if (hiscondition[i].Equals(true))
                    TicToeStateManager.WinState = TicToeStateManager.WinStates.Lose;
                
            }
            if (TicToeStateManager.WinState == TicToeStateManager.WinStates.None && drawcondition.Equals(true))
                TicToeStateManager.WinState = TicToeStateManager.WinStates.Draw;

            if (TicToeStateManager.WinState == TicToeStateManager.WinStates.Win)
            {
                timer1.Stop();

                //MessageBox.Show("Congratulations - You Win!!!");
                lbl_result.ForeColor = Color.DarkGreen;
                lbl_result.Text = "Congratulations - You Win!!!";
                TicToeStateManager.TotalWins++;
                TicToeStateManager.MatchesPlayed++;
                lbl_you_win.Text = TicToeStateManager.TotalWins.ToString();
                lbl_opp_lose.Text = TicToeStateManager.TotalWins.ToString();
                int total = 2 * TicToeStateManager.TotalWins - TicToeStateManager.TotalLose;
                int op_total = 2 * TicToeStateManager.TotalLose - TicToeStateManager.TotalWins;
                lbl_you_total.Text = total.ToString();
                lbl_opp_total.Text = op_total.ToString();
                
                initializeAll();

                timer1.Start();
            }
            else if (TicToeStateManager.WinState == TicToeStateManager.WinStates.Lose)
            {
                timer1.Stop();

                //MessageBox.Show("Sorry - You Lose...");
                lbl_result.ForeColor = Color.Red;
                lbl_result.Text = "Sorry - You Lose...";
                TicToeStateManager.TotalLose++;
                TicToeStateManager.MatchesPlayed++;
                lbl_you_lose.Text = TicToeStateManager.TotalLose.ToString();
                lbl_opp_win.Text = TicToeStateManager.TotalLose.ToString();
                int total = 2 * TicToeStateManager.TotalWins - TicToeStateManager.TotalLose;
                int op_total = 2 * TicToeStateManager.TotalLose - TicToeStateManager.TotalWins;
                lbl_you_total.Text = total.ToString();
                lbl_opp_total.Text = op_total.ToString();
                initializeAll();

                timer1.Start();
            }
            else if (TicToeStateManager.WinState == TicToeStateManager.WinStates.Draw)
            {
                timer1.Stop();

                //MessageBox.Show("No result - The match is drawn");
                lbl_result.ForeColor = Color.Blue;
                lbl_result.Text = "No result - The match is drawn";
                TicToeStateManager.TotalDraw++;
                TicToeStateManager.MatchesPlayed++;
                lbl_you_draw.Text = TicToeStateManager.TotalDraw.ToString();
                lbl_opp_draw.Text = TicToeStateManager.TotalDraw.ToString();
                
                initializeAll();

                timer1.Start();
            }
            if (TicToeStateManager.MatchesPlayed.Equals(TicToeStateManager.NumberOfMatches))
            {
                timer1.Stop();

                int total = 2 * TicToeStateManager.TotalWins - TicToeStateManager.TotalLose;
                int op_total = 2 * TicToeStateManager.TotalLose - TicToeStateManager.TotalWins;
                if (total > op_total)
                {
                    String str = "Congratulations - You win the ";
                    str += numericUpDown1.Value.ToString();
                    str += " match series by ";
                    str += TicToeStateManager.TotalWins.ToString() + "-" + TicToeStateManager.TotalLose.ToString();
                    //MessageBox.Show(str);
                    lbl_result.ForeColor = Color.DarkGreen;
                    lbl_result.Text = str;
                }
                else if (total < op_total)
                {
                    String str = "Sorry - You lose the ";
                    str += numericUpDown1.Value.ToString();
                    str += " match series by ";
                    str += TicToeStateManager.TotalWins.ToString() + "-" + TicToeStateManager.TotalLose.ToString();
                    //MessageBox.Show(str);
                    lbl_result.ForeColor = Color.Red;
                    lbl_result.Text = str;
                }
                else
                {
                    String str = "The ";
                    str += numericUpDown1.Value.ToString();
                    str += " match series is drawn by ";
                    str += TicToeStateManager.TotalWins.ToString() + "-" + TicToeStateManager.TotalLose.ToString();
                    //MessageBox.Show(str);
                    lbl_result.ForeColor = Color.Blue;
                    lbl_result.Text = str;
                }
                initializeSeries();

                timer1.Start();
            }
        }

        private void bt_Set_Click(object sender, EventArgs e)
        {
            TicToeStateManager.NumberOfMatches = Convert.ToInt32(numericUpDown1.Value);
            bt_Set.Enabled = false;
            numericUpDown1.Enabled = false;
        }


    }
}