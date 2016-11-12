using System;
using System.Collections.Generic;
using System.Text;

namespace LANStuffs
{
    class Parser
    {
        public void parseHeader(String str)
        {
            int i = 0, j = 0, k = 0;
            char[] c = str.ToCharArray();
            for (i = 0; i < c.Length; i++)
            {
                j = i;
                if (c[i].Equals('<'))
                {
                    k = 0;
                    while (!c[j].Equals(','))
                    {
                        j++;
                        k++;
                    }
                    String type = str.Substring(i + 1, k - 1);
                    DataManager.Type = (DataManager.SendType)Int32.Parse(type);
                    i = j;
                    k = 0;
                    j++;
                    while (!c[j].Equals(','))
                    {
                        j++;
                        k++;
                    }
                    String datatype = str.Substring(i + 1, k);
                    DataManager.DataType = (DataManager.SendDataType)Int32.Parse(datatype);
                    i = j;
                    k = 0;
                    j++;
                    while (!c[j].Equals(','))
                    {
                        j++;
                        k++;
                    }
                    //
                    string more = str.Substring(i + 1, k);
                    if (more.Equals("true"))
                    {
                        DataManager.HasMoreData = true;
                    }
                    else
                    {
                        DataManager.HasMoreData = false;
                    }
                    i = j;
                    k = 0;
                    j++;
                    while (!c[j].Equals('>'))
                    {
                        j++;
                        k++;
                    }
                    DataManager.Address = str.Substring(i + 1, k);
                    i = j;
                    k = 0;
                    j++;
                    while (!c[j].Equals('['))
                    {
                        j++;
                        k++;
                    }
                    //
                    i = j;
                    k = 0;
                    j++;
                    DataManager.data_after_index = j;
                    while (!j.Equals(c.Length - 1))
                    {
                        j++;
                        k++;
                    }
                    DataManager.DataBytes = Encoding.UTF32.GetBytes(str.Substring(i + 1, k));
                    i = j;
                }

            }
        }

        public void parseHeader2(String str)
        {
            int i = 0, j = 0, k = 0;
            char[] c = str.ToCharArray();
            for (i = 0; i < c.Length; i++)
            {
                j = i;
                if (c[i].Equals('<'))
                {
                    k = 0;
                    while (!c[j].Equals(','))
                    {
                        j++;
                        k++;
                    }
                    String type = str.Substring(i + 1, k - 1);
                    DataManager.Type = (DataManager.SendType)Int32.Parse(type);
                    i = j;
                    k = 0;
                    j++;
                    while (!c[j].Equals(','))
                    {
                        j++;
                        k++;
                    }
                    String datatype = str.Substring(i + 1, k);
                    DataManager.DataType = (DataManager.SendDataType)Int32.Parse(datatype);
                    i = j;
                    k = 0;
                    j++;
                    while (!c[j].Equals(','))
                    {
                        j++;
                        k++;
                    }
                    //
                    string filename = str.Substring(i + 1, k);
                    DataManager.FileName = filename;
                    i = j;
                    k = 0;
                    j++;
                    while (!c[j].Equals('>'))
                    {
                        j++;
                        k++;
                    }
                    DataManager.Address = str.Substring(i + 1, k);
                    i = j;
                    k = 0;
                    j++;
                    while (!c[j].Equals('['))
                    {
                        j++;
                        k++;
                    }
                    //
                    i = j;
                    k = 0;
                    j++;
                    DataManager.data_after_index = j;
                }

            }
        }
    }

}
