using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace LANStuffs.Option
{
    sealed class SkinFileParser
    {
        static bool file_loaded = false;
        static XmlDocument xml_file;

        static string name = "";
        static string author_name = "";

        static string form_backcolor = "";
        static string form_backimage = "";
        static string form_font_name = "";
        static string form_font_size = "";
        static string form_font_color = "";

        static string button_backcolor = "";
        static string button_font_name = "";
        static string button_font_size = "";
        static string button_font_color = "";

        static string menustrip_backcolor = "";
        static string menustrip_forecolor = "";

        static string groupbox_backcolor = "";
        static string groupbox_forecolor = "";

        static string listbox_backcolor = "";
        static string listbox_forecolor = "";

        static string statusstrip_backcolor = "";
        static string statusstrip_forecolor = "";

        public static XmlDocument loadFile(string filename)
        {
            xml_file = new XmlDocument();
            xml_file.Load(filename);
            file_loaded = true;
            return xml_file;
        }

        public static void parseSkinFileDescription(string filename)
        {
            XmlDocument file;
            string temp_name = filename.Substring(filename.LastIndexOf("\\") + 1, filename.Length - filename.LastIndexOf("\\") - 1).ToString();
            if (!file_loaded || !Properties.Settings.Default.SkinFile.Equals(temp_name))
            {
                file = loadFile(filename);
            }
            else
            {
                file = xml_file;
            }

            XmlElement skin = file.DocumentElement;

            XmlNodeList description = skin.GetElementsByTagName("Description").Item(0).ChildNodes;
            Name = description[0].InnerText;
            Author_Name = description[1].InnerText;
        }

        public static void parseSkinFile(string filename)
        {
            XmlDocument file;
            string temp_name = filename.Substring(filename.LastIndexOf("\\")+1, filename.Length - filename.LastIndexOf("\\")-1).ToString();
            if (!file_loaded || !Properties.Settings.Default.SkinFile.Equals(temp_name))
            {
                file = loadFile(filename);
            }
            else
            {
                file = xml_file;
            }

            XmlElement skin = file.DocumentElement;

            XmlNodeList form = skin.GetElementsByTagName("Form").Item(0).ChildNodes;
            Form_BackColor = form[0].InnerText;
            Form_BackImage = form[1].InnerText;
            XmlNodeList form_font = form[2].ChildNodes;
                Form_Font_Name = form_font[0].InnerText;
                Form_Font_Size = form_font[1].InnerText;
                Form_Font_Color = form_font[2].InnerText;

            XmlNodeList button = skin.GetElementsByTagName("Button").Item(0).ChildNodes;
            Button_BackColor = button[0].InnerText;
            XmlNodeList button_font = button[1].ChildNodes;
                Button_Font_Name = button_font[0].InnerText;
                Button_Font_Size = button_font[1].InnerText;
                Button_Font_Color = button_font[2].InnerText;

            XmlNodeList menustrip = skin.GetElementsByTagName("MenuStrip").Item(0).ChildNodes;
            Menustrip_BackColor = menustrip[0].InnerText;
            Menustrip_ForeColor = menustrip[1].InnerText;

            XmlNodeList groupbox = skin.GetElementsByTagName("Groupbox").Item(0).ChildNodes;
            Groupbox_BackColor = groupbox[0].InnerText;
            Groupbox_ForeColor = groupbox[1].InnerText;

            XmlNodeList listbox = skin.GetElementsByTagName("Listbox").Item(0).ChildNodes;
            Listbox_BackColor = listbox[0].InnerText;
            Listbox_ForeColor = listbox[1].InnerText;

            XmlNodeList statusstrip = skin.GetElementsByTagName("StatusStrip").Item(0).ChildNodes;
            StatusStrip_BackColor = statusstrip[0].InnerText;
            StatusStrip_ForeColor = statusstrip[1].InnerText;

        }

        //Description Properties
        public static string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public static string Author_Name
        {
            get
            {
                return author_name;
            }
            set
            {
                author_name = value;
            }
        }


        //Form Properties
        public static string Form_BackColor
        {
            get
            {
                return form_backcolor;
            }
            set
            {
                form_backcolor = value;
            }
        }

        public static string Form_BackImage
        {
            get
            {
                return form_backimage;
            }
            set
            {
                form_backimage = value;
            }
        }

        public static string Form_Font_Name
        {
            get
            {
                return form_font_name;
            }
            set
            {
                form_font_name = value;
            }
        }

        public static string Form_Font_Size
        {
            get
            {
                return form_font_size;
            }
            set
            {
                form_font_size = value;
            }
        }

        public static string Form_Font_Color
        {
            get
            {
                return form_font_color;
            }
            set
            {
                form_font_color = value;
            }
        }


        //Button Properties
        public static string Button_BackColor
        {
            get
            {
                return button_backcolor;
            }
            set
            {
                button_backcolor = value;
            }
        }

        public static string Button_Font_Name
        {
            get
            {
                return button_font_name;
            }
            set
            {
                button_font_name = value;
            }
        }

        public static string Button_Font_Size
        {
            get
            {
                return button_font_size;
            }
            set
            {
                button_font_size = value;
            }
        }

        public static string Button_Font_Color
        {
            get
            {
                return button_font_color;
            }
            set
            {
                button_font_color = value;
            }
        }


        //MenuStrip Properties
        public static string Menustrip_BackColor
        {
            get
            {
                return menustrip_backcolor;
            }
            set
            {
                menustrip_backcolor = value;
            }
        }

        public static string Menustrip_ForeColor
        {
            get
            {
                return menustrip_forecolor;
            }
            set
            {
                menustrip_forecolor = value;
            }
        }


        //Groupbox Properties
        public static string Groupbox_BackColor
        {
            get
            {
                return groupbox_backcolor;
            }
            set
            {
                groupbox_backcolor = value;
            }
        }

        public static string Groupbox_ForeColor
        {
            get
            {
                return groupbox_forecolor;
            }
            set
            {
                groupbox_forecolor = value;
            }
        }


        //Listbox Properties
        public static string Listbox_BackColor
        {
            get
            {
                return listbox_backcolor;
            }
            set
            {
                listbox_backcolor = value;
            }
        }

        public static string Listbox_ForeColor
        {
            get
            {
                return listbox_forecolor;
            }
            set
            {
                listbox_forecolor = value;
            }
        }


        //StatusStrip Properties
        public static string StatusStrip_BackColor
        {
            get
            {
                return statusstrip_backcolor;
            }
            set
            {
                statusstrip_backcolor = value;
            }
        }

        public static string StatusStrip_ForeColor
        {
            get
            {
                return statusstrip_forecolor;
            }
            set
            {
                statusstrip_forecolor = value;
            }
        }

    }
}
