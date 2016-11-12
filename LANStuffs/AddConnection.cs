using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LANStuffs.Option;

namespace LANStuffs
{
    public partial class AddConnection : Form
    {
        string path = DataManager.AppDataPath + "\\" + DataManager.ProductName + "\\";
        public AddConnection()
        {
            InitializeComponent();
        }

        private void bt_OK_Click(object sender, EventArgs e)
        {
            
        }

        public String address()
        {
            DataManager.insertElement(path + "AddedConnections.xml", txt_Name.Text, textBox1.Text, textBox2.Text);
            DataManager.getXMLElements(path + "AddedConnections.xml");
            return txt_Name.Text;
        }

        private void AddConnection_Load(object sender, EventArgs e)
        {
            if (!Properties.Settings.Default.SkinFile.Equals("Default.xml"))
            {
                this.SuspendLayout();
                applySkin();
                this.ResumeLayout();
            }
            Properties.Settings.Default.PropertyChanged += new PropertyChangedEventHandler(Default_PropertyChanged);
        }

        void Default_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("SkinFile"))
            {
                if (!Properties.Settings.Default.SkinFile.Equals("Default.xml"))
                {
                    this.SuspendLayout();
                    applySkin(DataManager.GetPath + "\\Option\\Skins\\" + Properties.Settings.Default.SkinFile);
                    this.ResumeLayout();
                }
                else
                {
                    this.SuspendLayout();
                    applyDefaultSkin();
                    this.ResumeLayout();
                }
            }
        }

        private void applySkin()
        {
            this.BackColor = Color.FromName(SkinFileParser.Form_BackColor);
            this.ForeColor = Color.FromName(SkinFileParser.Form_Font_Color);

            Font button_font = new Font(SkinFileParser.Button_Font_Name, (float)Convert.ToDouble(SkinFileParser.Button_Font_Size));

            foreach (Control c in this.Controls)
            {
                if (c.GetType().Equals(typeof(Button)))
                {
                    ((Button)c).BackColor = Color.FromName(SkinFileParser.Button_BackColor);
                    ((Button)c).ForeColor = Color.FromName(SkinFileParser.Button_Font_Color);
                    ((Button)c).Font = button_font;
                }                                    
            }
        }

        private void applySkin(string filename)
        {
            SkinFileParser.parseSkinFile(filename);
            applySkin();
        }

        private void applyDefaultSkin()
        {
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ForeColor = System.Drawing.SystemColors.ControlText;

            Font button_font = Button.DefaultFont;

            foreach (Control c in this.Controls)
            {
                if (c.GetType().Equals(typeof(Button)))
                {
                    //((Button)c).BackColor = Color.Empty;
                    ((Button)c).ForeColor = Color.Black;
                    ((Button)c).Font = button_font;
                }
            }
        }
    }
}