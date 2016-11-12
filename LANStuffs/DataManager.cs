using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Reflection;

namespace LANStuffs
{
    class DataManager
    {
        static String str = "";
        static String pvt_str = "";

        static Byte[] databytes = new Byte[1000];
        static SendType type = 0;
        static SendDataType data_type = 0;

        static bool listener_done = false;
        static bool value_changed = false;
        static bool private_value_changed = false;
        static bool has_more_data = false;
        public static bool listener_failed = false;
        public static int data_after_index = 0;
        public static string listener_address = "";
        static int total_files_in_queue = -1;
        static bool authenticated = false;
        static bool is_security_enabled = false;

        static String file_name = "";
        static String address = "";
        static String[][] xml_elements;

        public static String[][] XMLElements
        {
            get
            {
                return xml_elements;
            }
        }

        public static void getXMLElements(string filename)
        {
            String[][] str;
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(filename);
            XmlElement xelement = xmldoc.DocumentElement;
            XmlNodeList xnode_list = xelement.ChildNodes;
            str = new String[xnode_list.Count][];
            for (int i = 0; i < xnode_list.Count; i++)
            {
                XmlNode xnode = xnode_list.Item(i);
                XmlNodeList xnode_inner1_list = xnode.ChildNodes;
                for (int j = 0; j < xnode_inner1_list.Count; j++)
                {
                    if(j==0)
                        str[i] = new String[xnode_inner1_list.Count];
                    XmlNode xnode_inner1 = xnode_inner1_list.Item(j);
                    str[i][j] = xnode_inner1.InnerText.Trim();
                }
            }
            xml_elements = str;
            //return str;
        }

        public static void insertElement(String filename, String ename, String eaddreess, String eport)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(filename);
            XmlNode connections = xmldoc.DocumentElement;
            
            XmlElement connection = xmldoc.CreateElement("Connection");
            connection.InnerXml = "<Name>" + ename + "</Name>" +
                                    "<Address>" + eaddreess + ":" + eport + "</Address>";

            connections.AppendChild(connection);
            xmldoc.Save(filename);
        }

        public static void deleteElement(String filename,String element_name)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(filename);
            XmlElement connections = xmldoc.DocumentElement;
            XmlNodeList list_connection = connections.ChildNodes;
            for (int i = 0; i < list_connection.Count; i++)
            {
                XmlNode connection = list_connection.Item(i);
                XmlNode name = connection.FirstChild;
                if(name.InnerText.Trim().Equals(element_name))
                {
                    connections.RemoveChild(connection);
                    xmldoc.Save(filename);
                    break;
                }
            }
        }

        public static void editElement(String filename,String prev_name, String ename, String eaddreess, String eport)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(filename);
            XmlElement connections = xmldoc.DocumentElement;
            XmlNodeList list_connection = connections.ChildNodes;
            for (int i = 0; i < list_connection.Count; i++)
            {
                XmlNode connection = list_connection.Item(i);
                XmlNode name = connection.FirstChild;
                if (name.InnerText.Trim().Equals(prev_name))
                {
                    XmlElement connection1 = xmldoc.CreateElement("Connection");
                    connection1.InnerXml = "<Name>" + ename + "</Name>" +
                                          "<Address>" + eaddreess + ":" + eport + "</Address>";
                    connections.ReplaceChild(connection1, connection);
                    xmldoc.Save(filename);
                    break;
                }
            }
        }

        public static String Data
        {
            get
            {
                return str;
            }
            set
            {
                str = value;
            }
        }
        public static Byte[] DataBytes
        {
            get
            {
                return databytes;
            }
            set
            {
                databytes = value;
            }
        }
        public static String Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }
        public static String PrivateData
        {
            get
            {
                return pvt_str;
            }
            set
            {
                pvt_str = value;
            }
        }

        public static String FileName
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

        public static bool ListenerDone
        {
            get
            {
                return listener_done;
            }
            set
            {
                listener_done = value;
            }
        }
        public static bool ValueChanged
        {
            get
            {
                return value_changed;
            }
            set
            {
                value_changed = value;
            }
        }
        public static bool PrivateValueChanged
        {
            get
            {
                return private_value_changed;
            }
            set
            {
                private_value_changed = value;
            }
        }

        public static bool HasMoreData
        {
            get
            {
                return has_more_data;
            }
            set
            {
                has_more_data = value;
            }
        }

        public static SendType Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }
        public enum SendType
        {
            Broadcast = 1,
            Private = 2,
        }
        public static SendDataType DataType
        {
            get
            {
                return data_type;
            }
            set
            {
                data_type = value;
            }
        }
        public enum SendDataType
        {
            Message = 1,
            File = 2,
            Image = 3,
            Sound = 4,
            Game = 5,
        }
        public static string GetPath
        {
            get
            {
                string app_path = Properties.Settings.Default.ApplicationPath;
                string path;
                try
                {
                    path = app_path.Substring(0, app_path.LastIndexOf("\\bin"));
                }
                catch
                {
                    path = app_path;
                }
                return path;
            }
        }

        public static string AppDataPath
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            }
        }

        public static int TotalFilesInQueue
        {
            get
            {
                return total_files_in_queue;
            }
            set
            {
                total_files_in_queue = value;
            }
        }
        public static bool Authenticated
        {
            get
            {
                return authenticated;
            }
            set
            {
                authenticated = value;
            }
        }

        public static bool IsSecurityEnabled
        {
            get
            {
                return is_security_enabled;
            }
            set
            {
                is_security_enabled = value;
            }
        }

        public static string ProductName
        {
            get
            {
                object[] obj = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                return ((AssemblyProductAttribute)obj[0]).Product;
            }
        }
    }
}
