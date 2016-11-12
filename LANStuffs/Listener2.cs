using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace LANStuffs
{
    class Listener2
    {
        IPAddress add;
        IPEndPoint ep;
        Socket sc;

        public Listener2(String ipadd, String port)
        {
            add = IPAddress.Parse(ipadd);
            ep = new IPEndPoint(add, Int32.Parse(port));
            DataManager.listener_address = ipadd + ":" + port;
        }

        public void Connect()
        {
            sc = new Socket(ep.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            if (sc == null)
            { return; }

            try
            {
                sc.Bind(ep);
                while (true)
                {
                    DataManager.ListenerDone = true;
                    sc.Listen(10);
                    Socket accept_sc = sc.Accept();
                    byte[] byteReceive = new byte[1024 * 4];
                    int bytes_received = 1;


                    String str = "";
                    bytes_received = accept_sc.Receive(byteReceive, byteReceive.Length, 0);

                    str = Encoding.ASCII.GetString(byteReceive);
                    str = str.Trim("\0".ToCharArray());
                    new Parser().parseHeader2(str);

                    bytes_received = 1;
                    byteReceive.Initialize();
                    FileStream fs = new FileStream("a.txt", FileMode.Append);
                    while (bytes_received > 0)
                    {
                        bytes_received = accept_sc.Receive(byteReceive, byteReceive.ToString().Trim().Length, 0);
                        fs.Write(byteReceive, 0, bytes_received);
                    }
                    fs.Close();
                    DataManager.ValueChanged = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        public void Exit()
        {
            sc = new Socket(ep.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            sc.Connect(ep);
            Byte[] bytesSend = Encoding.ASCII.GetBytes("temp");
            sc.Send(bytesSend, bytesSend.Length, 0);
            sc.Close();
        }
    }
}
