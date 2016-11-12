using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Principal;
using System.Security.AccessControl;

namespace LANStuffs.Security
{
    class FileSecuritySettings
    {
        static string path = DataManager.AppDataPath + "\\" + DataManager.ProductName;
        public FileSecuritySettings()
        {

        }

        public static void applySecurity(string filepath)
        {
            FileSecurity fsecurity = File.GetAccessControl(filepath);

            string domain_name = Environment.UserDomainName;
            string account_name = Environment.UserName;
            string account = domain_name + "\\" + account_name;
            FileSystemAccessRule rule = new FileSystemAccessRule(account, FileSystemRights.Read, AccessControlType.Allow);
            fsecurity.ResetAccessRule(rule);
            File.SetAccessControl(filepath, fsecurity);
            File.SetAttributes(filepath, FileAttributes.ReadOnly | FileAttributes.System);

        }


        public static void allowReadAccess(string filepath)
        {
            FileSecurity fsecurity = File.GetAccessControl(filepath);

            string domain_name = Environment.UserDomainName;
            string account_name = Environment.UserName;
            string account = domain_name + "\\" + account_name;
            FileSystemAccessRule rule = new FileSystemAccessRule(account, FileSystemRights.Read, AccessControlType.Allow);

            fsecurity.ResetAccessRule(rule);
            File.SetAccessControl(filepath, fsecurity);
            File.SetAttributes(filepath, FileAttributes.ReadOnly);
        }

        public static void allowWriteAccess(string filepath)
        {
            FileSecurity fsecurity = File.GetAccessControl(filepath);

            string domain_name = Environment.UserDomainName;
            string account_name = Environment.UserName;
            string account = domain_name + "\\" + account_name;
            FileSystemAccessRule rule = new FileSystemAccessRule(account, FileSystemRights.Write, AccessControlType.Allow);

            fsecurity.ResetAccessRule(rule);
            File.SetAccessControl(filepath, fsecurity);
            File.SetAttributes(filepath, FileAttributes.Normal);
        }

        public static string timeStamp(string filepath)
        {
            string str = File.GetCreationTime(filepath).ToString();
            str += " : ";
            str += File.GetCreationTime(filepath).Millisecond.ToString();
            return str;
        }

        public static void EncryptUserFiles()
        {
            /*
            //Encryption for AddedConnections.xml//
            FileStream acxml = File.Open(path + "\\AddedConnections.xml", FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[acxml.Length];
            acxml.Read(buffer, 0, buffer.Length);
            byte[] cryptedbuffer = Crypto.Encrypt1(buffer);
            acxml.Close();
            acxml = File.Open(path + "\\AddedConnections.xml", FileMode.Create, FileAccess.Write);
            acxml.Write(cryptedbuffer, 0, cryptedbuffer.Length);
            acxml.Close();
            //////////////////////////////////////
            */
        }

        public static void DecryptUserFiles()
        {
            /*
            //Decrypting AddedConnections.xml //
            FileStream acxml = File.Open(path + "\\AddedConnections.xml", FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[acxml.Length];
            acxml.Read(buffer, 0, buffer.Length);
            acxml.Close();
            byte[] decryptedbuffer = Crypto.Decrypt1(buffer);
            acxml = File.Open(path + "\\AddedConnections.xml", FileMode.Create, FileAccess.Write);
            acxml.Write(decryptedbuffer, 0, decryptedbuffer.Length);
            acxml.Close();
            ////////////////////////////////////
             */
        }
    }
}
