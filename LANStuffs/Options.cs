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
    public partial class Options : Form
    {

        
        public Options()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Name.Equals("ManageConnections") && e.Action == TreeViewAction.ByMouse)
            {
                //MessageBox.Show("ManageConnections");
                panel1.Controls[0].Visible = true;
                panel1.Controls[0].Dock = DockStyle.Fill;
                panel1.Controls[1].Visible = false;
            }
            if (e.Node.Name.Equals("UISkin") && e.Action == TreeViewAction.ByMouse)
            {
                //MessageBox.Show("ManageConnections");
                panel1.Controls[1].Visible = true;
                panel1.Controls[1].Dock = DockStyle.Fill;
                panel1.Controls[0].Visible = false;
            }
        }

        private void treeView1_Click(object sender, EventArgs e)
        {
            
        }

        private void Options_Load(object sender, EventArgs e)
        {
            if (!Properties.Settings.Default.SkinFile.Equals("Default.xml"))
            {
                this.SuspendLayout();
                applySkin();
                this.ResumeLayout();
            }

            panel1.Controls.Add(new ManageConnections());
            panel1.Controls[0].Dock = DockStyle.Fill;
            panel1.Controls.Add(new Skin());
            Properties.Settings.Default.PropertyChanged += new PropertyChangedEventHandler(Default_PropertyChanged);
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

        private void bt_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void applySkin()
        {

            this.BackColor = Color.FromName(SkinFileParser.Form_BackColor);
            this.ForeColor = Color.FromName(SkinFileParser.Form_Font_Color);

            Font button_font = new Font(SkinFileParser.Button_Font_Name, (float)Convert.ToDouble(SkinFileParser.Button_Font_Size));

            foreach (Control c in this.Controls)
            {
                if (c.GetType().Equals(typeof(Panel)))
                {
                    ((Panel)c).BackColor = Color.FromName(SkinFileParser.Groupbox_BackColor);
                    ((Panel)c).ForeColor = Color.FromName(SkinFileParser.Groupbox_ForeColor);
                }

                if (c.GetType().Equals(typeof(TreeView)))
                {
                    ((TreeView)c).BackColor = Color.FromName(SkinFileParser.Listbox_BackColor);
                    ((TreeView)c).ForeColor = Color.FromName(SkinFileParser.Listbox_ForeColor);
                }

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
                if (c.GetType().Equals(typeof(Panel)))
                {
                    ((Panel)c).BackColor = System.Drawing.SystemColors.Control;
                    ((Panel)c).ForeColor = System.Drawing.SystemColors.ControlText;
                }

                if (c.GetType().Equals(typeof(TreeView)))
                {
                    ((TreeView)c).BackColor = System.Drawing.SystemColors.Window;
                    ((TreeView)c).ForeColor = System.Drawing.SystemColors.WindowText;
                }

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