using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace LANStuffs.Option
{
    public partial class Skin : UserControl
    {
        public Skin()
        {
            InitializeComponent();
            lbl_Name.Text = "";
            lbl_Author.Text = "";
        }

        private void bt_apply_Click(object sender, EventArgs e)
        {
            if (listSkin.SelectedItem.Equals("Default"))
            {
                Properties.Settings.Default.SkinFile = "Default.xml";
            }
            else
            {
                Properties.Settings.Default.SkinFile = listSkin.SelectedItem.ToString();
            }

        }

        private void listSkin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!listSkin.SelectedItem.Equals("Default"))
            {
                SkinFileParser.parseSkinFileDescription(DataManager.GetPath + "\\Option\\Skins\\" + listSkin.SelectedItem.ToString());
                lbl_Name.Text = SkinFileParser.Name;
                lbl_Author.Text = SkinFileParser.Author_Name;
            }
            else
            {
                lbl_Name.Text = "Default";
                lbl_Author.Text = "Satya Prakash Jugran";
            }
        }

        private void Skin_Load(object sender, EventArgs e)
        {
            if (!Properties.Settings.Default.SkinFile.Equals("Default.xml"))
            {
                this.SuspendLayout();
                applySkin();
                this.ResumeLayout();
            }
            Properties.Settings.Default.PropertyChanged += new PropertyChangedEventHandler(Default_PropertyChanged);

            string[] files = Directory.GetFiles(DataManager.GetPath + "\\Option\\Skins");
            foreach (string file in files)
            {
                listSkin.Items.Add(file.Substring(file.LastIndexOf("\\") + 1));
            }
        }

        void Default_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //throw new Exception("The method or operation is not implemented.");
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
                if (c.GetType().Equals(typeof(GroupBox)))
                {
                    ((GroupBox)c).BackColor = Color.FromName(SkinFileParser.Groupbox_BackColor);
                    ((GroupBox)c).ForeColor = Color.FromName(SkinFileParser.Groupbox_ForeColor);
                    foreach (Control gp in c.Controls)
                    {
                        if (gp.GetType().Equals(typeof(ListBox)))
                        {
                            ((ListBox)gp).BackColor = Color.FromName(SkinFileParser.Listbox_BackColor);
                            ((ListBox)gp).ForeColor = Color.FromName(SkinFileParser.Listbox_ForeColor);
                        }
                        else if (gp.GetType().Equals(typeof(Button)))
                        {
                            ((Button)gp).BackColor = Color.FromName(SkinFileParser.Button_BackColor);
                            ((Button)gp).ForeColor = Color.FromName(SkinFileParser.Button_Font_Color);
                            ((Button)gp).Font = button_font;
                        }
                    }
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
                if (c.GetType().Equals(typeof(GroupBox)))
                {
                    ((GroupBox)c).BackColor = System.Drawing.SystemColors.Control;
                    ((GroupBox)c).ForeColor = System.Drawing.SystemColors.ControlText;
                    foreach (Control gp in c.Controls)
                    {
                        if (gp.GetType().Equals(typeof(ListBox)))
                        {
                            ((ListBox)gp).BackColor = System.Drawing.SystemColors.Window;
                            ((ListBox)gp).ForeColor = System.Drawing.SystemColors.WindowText;
                        }
                        else if (gp.GetType().Equals(typeof(Button)))
                        {
                            //((Button)gp).BackColor = Color.Empty;
                            ((Button)gp).ForeColor = Color.Black;
                            ((Button)gp).Font = button_font;
                        }
                    }
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
