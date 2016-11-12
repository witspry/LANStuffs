using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Windows.Forms;

namespace LANStuffs
{
    sealed class Crypto
    {
        public Crypto()
        {

        }

        public static byte[] Encrypt1(byte[] cipherblock)
        {
                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                byte[] key = new byte[24];
                key = Encoding.ASCII.GetBytes("a,a;ea4aqa3aaaraa,a3a8aa");
                byte[] IV = new byte[8];
                IV = Encoding.ASCII.GetBytes("a45fr69d");
                System.IO.MemoryStream mstream = new MemoryStream();
                CryptoStream enc = new CryptoStream(mstream, tdes.CreateEncryptor(key, IV), CryptoStreamMode.Write);
                enc.Write(cipherblock, 0, cipherblock.Length);
                enc.FlushFinalBlock();
                byte[] cipher = mstream.ToArray();
                return cipher;
        }
        public static byte[] Decrypt1(byte[] cipherblock)
        {
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            byte[] key = new byte[24];
            key = Encoding.ASCII.GetBytes("a,a;ea4aqa3aaaraa,a3a8aa");
            byte[] IV = new byte[8];
            IV = Encoding.ASCII.GetBytes("a45fr69d");
            System.IO.MemoryStream mstream = new MemoryStream();
            CryptoStream enc = new CryptoStream(mstream, tdes.CreateDecryptor(key, IV), CryptoStreamMode.Write);
            enc.Write(cipherblock, 0, cipherblock.Length);
            enc.FlushFinalBlock();
            byte[] cipher = mstream.ToArray();
            return cipher;
        }
        public static byte[] EncryptWithKey(byte[] cipherblock, string enckey)
        {
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            byte[] key = new byte[24];
            byte[] enckeybytes = Encoding.ASCII.GetBytes(enckey);
            if (enckeybytes.Length < key.Length)
            {
                for (int i = 0; i < enckeybytes.Length; i++)
                {
                    key[i] = enckeybytes[i];
                }

                //Appending padding bits : Password is repeated//                
                for (int i = enckeybytes.Length; i < key.Length; i++)
                {
                    key[i] = enckeybytes[i % (enckeybytes.Length - 1)];
                }
            }
            else if (enckeybytes.Length.Equals(key.Length))
            {
                key = enckeybytes;
            }

            byte[] IV = new byte[8];
            IV = Encoding.ASCII.GetBytes("a45fr69d");
            System.IO.MemoryStream mstream = new MemoryStream();
            CryptoStream enc = new CryptoStream(mstream, tdes.CreateEncryptor(key, IV), CryptoStreamMode.Write);
            enc.Write(cipherblock, 0, cipherblock.Length);
            enc.FlushFinalBlock();
            byte[] cipher = mstream.ToArray();
            return cipher;
        }
        public static byte[] DecryptWithKey(byte[] cipherblock, string enckey)
        {
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            byte[] key = new byte[24];
            byte[] enckeybytes = Encoding.ASCII.GetBytes(enckey);
            if (enckeybytes.Length < key.Length)
            {
                for (int i = 0; i < enckeybytes.Length; i++)
                {
                    key[i] = enckeybytes[i];
                }

                //Appending padding bits : Password is repeated//                
                for (int i = enckeybytes.Length; i < key.Length; i++)
                {
                    key[i] = enckeybytes[i % (enckeybytes.Length - 1)];
                }
            }
            else if (enckeybytes.Length.Equals(key.Length))
            {
                key = enckeybytes;
            }

            byte[] IV = new byte[8];
            IV = Encoding.ASCII.GetBytes("a45fr69d");
            System.IO.MemoryStream mstream = new MemoryStream();
            CryptoStream enc = new CryptoStream(mstream, tdes.CreateDecryptor(key, IV), CryptoStreamMode.Write);
            enc.Write(cipherblock, 0, cipherblock.Length);
            enc.FlushFinalBlock();
            byte[] cipher = mstream.ToArray();
            return cipher;
        }
    }
}
