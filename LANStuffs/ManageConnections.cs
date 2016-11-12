using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using LANStuffs.Option;

namespace LANStuffs
{
    public partial class ManageConnections : UserControl
    {
        string path = DataManager.AppDataPath + "\\" + DataManager.ProductName + "\\";
        public ManageConnections()
        {
            InitializeComponent();
        }

        private void ManageConnections_Load(object sender, EventArgs e)
        {

            if (!Properties.Settings.Default.SkinFile.Equals("Default.xml"))
            {
                this.SuspendLayout();
                applySkin();
                this.ResumeLayout();
            }
            Properties.Settings.Default.PropertyChanged += new PropertyChangedEventHandler(Default_PropertyChanged);


            for (int i = 0; i < DataManager.XMLElements.Length; i++)
            {
                listView1.Items.Add(DataManager.XMLElements[i][0]);
                listView1.Items[i].SubItems.Add(DataManager.XMLElements[i][1]);                
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

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count.Equals(1) && !DataManager.listener_address.Equals(""))
            {
                for (int i = 0; i < DataManager.XMLElements.Length; i++)
                {
                    if (DataManager.XMLElements[i][0].Equals(listView1.SelectedItems[0].Text))
                    {
                        PrivateChatWindow pcw = new PrivateChatWindow(DataManager.XMLElements[i][1], DataManager.listener_address);
                        pcw.Show(this);
                        break;
                    }
                }
            }
        }

        private void bt_Add_Click(object sender, EventArgs e)
        {
            AddConnection ac = new AddConnection();
            if (ac.ShowDialog(this).Equals(DialogResult.OK))
            {
                String s = ac.address();
                listView1.Items.Add(s);
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(DataManager.XMLElements[listView1.Items.Count - 1][1]);
            }
        }

        private void bt_Delete_Click(object sender, EventArgs e)
        {
            int selectedcount = listView1.SelectedItems.Count; 
            if (!selectedcount.Equals(0))
            {
                string text = "";
                if (selectedcount.Equals(1))
                {
                    text = "Are you sure you want to delete this item?";
                }
                else
                {
                    text = "Are you sure you want to delete these " + selectedcount + " items?";
                }
                if (MessageBox.Show(text, "Delete Saved Connections", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    for (int i = 0; i < selectedcount; i++)
                    {
                        DataManager.deleteElement(path + "AddedConnections.xml", listView1.SelectedItems[i].Text);
                    }
                    int[] ind = new int[selectedcount];
                    for (int i = 0; i < selectedcount; i++)
                    {
                        ind[i] = listView1.SelectedIndices[i];
                    }
                    for (int i = 0; i < selectedcount; i++)
                    {
                        listView1.Items.RemoveAt(ind[i] - i);
                    }
                }
            }
        }

        private void bt_Edit_Click(object sender, EventArgs e)
        {
            int selectedcount = listView1.SelectedItems.Count;
            if (selectedcount.Equals(1))
            {
                EditConnection ec = new EditConnection(listView1.SelectedItems[0].Text, listView1.SelectedItems[0].SubItems[1].Text);
                if (ec.ShowDialog(this).Equals(DialogResult.OK))
                {
                    String s = ec.nameaddress();
                    DataManager.getXMLElements(path + "AddedConnections.xml");
                    listView1.Items.Clear();
                    for (int i = 0; i < DataManager.XMLElements.Length; i++)
                    {
                        listView1.Items.Add(DataManager.XMLElements[i][0]);
                        listView1.Items[i].SubItems.Add(DataManager.XMLElements[i][1]);
                    }
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
                if (c.GetType().Equals(typeof(TableLayoutPanel)))
                {
                    ((TableLayoutPanel)c).BackColor = Color.FromName(SkinFileParser.Groupbox_BackColor);
                    ((TableLayoutPanel)c).ForeColor = Color.FromName(SkinFileParser.Groupbox_ForeColor);
                    foreach (Control tp in c.Controls)
                    {
                        if (tp.GetType().Equals(typeof(ListView)))
                        {
                            ((ListView)tp).BackColor = Color.FromName(SkinFileParser.Listbox_BackColor);
                            ((ListView)tp).ForeColor = Color.FromName(SkinFileParser.Listbox_ForeColor);
                        }
                        else if (tp.GetType().Equals(typeof(Panel)))
                        {
                            ((Panel)tp).ForeColor = Color.FromName(SkinFileParser.Button_Font_Color);
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
                if (c.GetType().Equals(typeof(TableLayoutPanel)))
                {
                    ((TableLayoutPanel)c).BackColor = System.Drawing.SystemColors.Control;
                    ((TableLayoutPanel)c).ForeColor = System.Drawing.SystemColors.ControlText;
                    foreach (Control tp in c.Controls)
                    {
                        if (tp.GetType().Equals(typeof(ListView)))
                        {
                            ((ListView)tp).BackColor = System.Drawing.SystemColors.Window;
                            ((ListView)tp).ForeColor = System.Drawing.SystemColors.WindowText;
                        }
                        else if (tp.GetType().Equals(typeof(Panel)))
                        {
                            ((Panel)tp).ForeColor = Color.Black;
                        }
                    }
                }
            }
        }
    }
}
