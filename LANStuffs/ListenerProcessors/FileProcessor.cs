using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.Net.Sockets;

namespace LANStuffs.ListenerProcessors
{
    class FileProcessor
    {
        Socket accept_sc;
        string file_name = "";
        public FileProcessor(Socket accepted_socket)
        {
            accept_sc = accepted_socket;
        }

        public void ProcessFile()
        {
            int bytes_received = 1;
            byte[] byteReceive = new byte[1024 * 4 + 8];
            byteReceive.Initialize();
            string dirpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "LANStuffs";
            if (!Directory.Exists(dirpath))
            {
                Directory.CreateDirectory(dirpath);
            }
            file_name = DataManager.FileName;
            string filepath = dirpath + "\\" + file_name;
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
            DataManager.ValueChanged = true;
        }
        public string FileName
        {
            get
            {
                return file_name;
            }
        }
    }
}
