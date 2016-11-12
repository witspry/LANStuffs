using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using LANStuffs.Games;


namespace LANStuffs
{
    class Listener 
    {
        IPAddress add;
        IPEndPoint ep;
        Socket sc;
        bool listen = true;

        public Listener(String ipadd, String port)
        {
            add = IPAddress.Parse(ipadd);
            ep = new IPEndPoint(add, Int32.Parse(port));
            DataManager.listener_address = ipadd + ":" + port;
        }

        public void Connect()
        {
            sc = new Socket(ep.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            if (sc == null)
            {  return;  }

            try
            {
                sc.Bind(ep);
                while (listen == true)
                {
                    String data = "";
                    String str = "";
                    DataManager.ListenerDone = true;
                    sc.Listen(10);
                    Socket accept_sc = sc.Accept();
                    byte[] byteReceive = new byte[1024 * 4];

                    int bytes_received = 1;

                    bytes_received = accept_sc.Receive(byteReceive, byteReceive.Length, 0);

                    str = Encoding.ASCII.GetString(byteReceive);
                    str = str.Trim("\0".ToCharArray());
                    new Parser().parseHeader2(str + "]");
                    Byte[] ack = Encoding.ASCII.GetBytes("HeaderReceived");
                    accept_sc.Send(ack, ack.Length, 0);

                    #region
                    if (DataManager.DataType == DataManager.SendDataType.Message)
                    {

                        bytes_received = 1;
                        //byteReceive.Initialize();
                        while (bytes_received > 0)
                        {
                            byteReceive = new Byte[1024 * 4];
                            bytes_received = accept_sc.Receive(byteReceive, byteReceive.Length, 0);
                            byte[] rec1 = new byte[bytes_received];
                            for (int i = 0; i < bytes_received; i++)
                            {
                                rec1[i] = byteReceive[i];
                            }
                            string str1 = Encoding.ASCII.GetString(byteReceive, 0, bytes_received);
                            if (!str1.Equals(""))
                            {
                                byte[] rec = Crypto.Decrypt1(rec1);
                                //data += Encoding.ASCII.GetString(byteReceive,0,bytes_received);
                                data += Encoding.UTF32.GetString(rec);
                            }
                        }
                        DataManager.Data = data;
                        if (!data.Equals(""))
                        {
                            DataManager.ValueChanged = true;
                        }
                    }
                    #endregion


                    #region
                    if (DataManager.DataType == DataManager.SendDataType.Image)
                    {
                        ListenerProcessors.FileProcessor fp;
                        fp = new LANStuffs.ListenerProcessors.FileProcessor(accept_sc);
                        Thread socket_thread = new Thread(new ThreadStart(fp.ProcessFile));
                        socket_thread.Start();
                        /* bytes_received = 1;
                        byteReceive = new byte[1024 * 4 + 8];
                        byteReceive.Initialize();
                        string dirpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "LANStuffs";
                        if (!Directory.Exists(dirpath))
                        {
                            Directory.CreateDirectory(dirpath);
                        }
                        string filepath = dirpath + "\\" + DataManager.FileName;
                        FileStream f = File.Create(filepath);
                        f.Close();
                        FileStream fs = new FileStream(filepath, FileMode.Append);
                        while (bytes_received > 0)
                        {
                            //bytes_received = accept_sc.Receive(byteReceive, byteReceive.ToString().Trim().Length, 0);
                            Thread.CurrentThread.Join(10);
                            bytes_received = accept_sc.Receive(byteReceive, byteReceive.Length, 0);
                            byte[] rec1 = new byte[bytes_received];
                            for (int i = 0; i < bytes_received; i++)
                            {
                                rec1[i] = byteReceive[i];
                            }
                            String check = Encoding.ASCII.GetString(rec1);
                            if (!check.Equals(""))
                            {
                                byte[] rec = Crypto.Decrypt1(rec1);
                                fs.Write(rec, 0, rec.Length);
                                //fs.Write(byteReceive, 0, bytes_received);
                            }
                        }
                        fs.Close();
                        DataManager.ValueChanged = true;*/
                    }
                    #endregion


                    #region
                    if (DataManager.DataType == DataManager.SendDataType.Game)
                    {
                        if (TicToeStateManager.opened)
                        {
                            bytes_received = 1;
                            while (bytes_received > 0)
                            {
                                byteReceive = new Byte[1024 * 4];
                                bytes_received = accept_sc.Receive(byteReceive, byteReceive.Length, 0);
                                byte[] rec1 = new byte[bytes_received];
                                for (int i = 0; i < bytes_received; i++)
                                {
                                    rec1[i] = byteReceive[i];
                                }
                                string str1 = Encoding.ASCII.GetString(byteReceive, 0, bytes_received);
                                if (!str1.Equals(""))
                                {
                                    byte[] rec = Crypto.Decrypt1(rec1);
                                    data += Encoding.UTF32.GetString(rec);
                                    TicToeStateManager.parse(data + ",");
                                    TicToeStateManager.Turn = TicToeStateManager.Turns.Mine;
                                }
                            }
                            DataManager.ValueChanged = true;
                        }
                        else
                        {

                        }
                    }
                    #endregion

                }
            }
            catch (SocketException socketex)
            {
                MessageBox.Show("Listener(socket) : " + socketex.Message);
                DataManager.ListenerDone = true;
                DataManager.listener_failed = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Listener(general) : " + ex.Message + " : " + ex.StackTrace);
                DataManager.ListenerDone = true;
                DataManager.listener_failed = true;
            }
        }

        public void Exit()
        {
            listen = false;
            sc = new Socket(ep.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            sc.Connect(ep);
            Byte[] bytesSend = Encoding.ASCII.GetBytes("<1,1,temp,000.0.0.0:0000> [");
            sc.Send(bytesSend,bytesSend.Length,0);
            sc.Close();
        }
    }
}
