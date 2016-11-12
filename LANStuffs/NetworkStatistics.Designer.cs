namespace LANStuffs
{
    partial class NetworkStatistics
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Name", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("ID", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Type", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Status", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("Speed", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("123");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("222");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("362");
            this.label1 = new System.Windows.Forms.Label();
            this.ddl_nwInterfaces = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_bytes_sent = new System.Windows.Forms.Label();
            this.lbl_bytes_received = new System.Windows.Forms.Label();
            this.lbl_bytes_total = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_total_baud_rate = new System.Windows.Forms.Label();
            this.lbl_sending_baud_rate = new System.Windows.Forms.Label();
            this.lbl_receiving_baud_rate = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.performanceGraph1 = new LANStuffs.PerformanceGraph();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select a network interface";
            // 
            // ddl_nwInterfaces
            // 
            this.ddl_nwInterfaces.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddl_nwInterfaces.FormattingEnabled = true;
            this.ddl_nwInterfaces.Location = new System.Drawing.Point(15, 31);
            this.ddl_nwInterfaces.Name = "ddl_nwInterfaces";
            this.ddl_nwInterfaces.Size = new System.Drawing.Size(314, 21);
            this.ddl_nwInterfaces.TabIndex = 1;
            this.ddl_nwInterfaces.SelectedIndexChanged += new System.EventHandler(this.ddl_nwInterfaces_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(317, 177);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data Transmission Statistics";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.59702F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.40298F));
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_bytes_sent, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_bytes_received, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbl_bytes_total, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbl_total_baud_rate, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.lbl_sending_baud_rate, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbl_receiving_baud_rate, 1, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(305, 152);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Total Bytes (sent + received)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Bytes Received";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Bytes Sent";
            // 
            // lbl_bytes_sent
            // 
            this.lbl_bytes_sent.AutoSize = true;
            this.lbl_bytes_sent.Location = new System.Drawing.Point(187, 0);
            this.lbl_bytes_sent.Name = "lbl_bytes_sent";
            this.lbl_bytes_sent.Size = new System.Drawing.Size(30, 13);
            this.lbl_bytes_sent.TabIndex = 0;
            this.lbl_bytes_sent.Text = "0 KB";
            // 
            // lbl_bytes_received
            // 
            this.lbl_bytes_received.AutoSize = true;
            this.lbl_bytes_received.Location = new System.Drawing.Point(187, 25);
            this.lbl_bytes_received.Name = "lbl_bytes_received";
            this.lbl_bytes_received.Size = new System.Drawing.Size(30, 13);
            this.lbl_bytes_received.TabIndex = 1;
            this.lbl_bytes_received.Text = "0 KB";
            // 
            // lbl_bytes_total
            // 
            this.lbl_bytes_total.AutoSize = true;
            this.lbl_bytes_total.Location = new System.Drawing.Point(187, 50);
            this.lbl_bytes_total.Name = "lbl_bytes_total";
            this.lbl_bytes_total.Size = new System.Drawing.Size(30, 13);
            this.lbl_bytes_total.TabIndex = 2;
            this.lbl_bytes_total.Text = "0 KB";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Current Speed (sending)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Current Speed (total)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Current Speed (receiving)";
            // 
            // lbl_total_baud_rate
            // 
            this.lbl_total_baud_rate.AutoSize = true;
            this.lbl_total_baud_rate.Location = new System.Drawing.Point(187, 125);
            this.lbl_total_baud_rate.Name = "lbl_total_baud_rate";
            this.lbl_total_baud_rate.Size = new System.Drawing.Size(63, 13);
            this.lbl_total_baud_rate.TabIndex = 3;
            this.lbl_total_baud_rate.Text = "0 KB / Sec.";
            // 
            // lbl_sending_baud_rate
            // 
            this.lbl_sending_baud_rate.AutoSize = true;
            this.lbl_sending_baud_rate.Location = new System.Drawing.Point(187, 75);
            this.lbl_sending_baud_rate.Name = "lbl_sending_baud_rate";
            this.lbl_sending_baud_rate.Size = new System.Drawing.Size(63, 13);
            this.lbl_sending_baud_rate.TabIndex = 10;
            this.lbl_sending_baud_rate.Text = "0 KB / Sec.";
            // 
            // lbl_receiving_baud_rate
            // 
            this.lbl_receiving_baud_rate.AutoSize = true;
            this.lbl_receiving_baud_rate.Location = new System.Drawing.Point(187, 100);
            this.lbl_receiving_baud_rate.Name = "lbl_receiving_baud_rate";
            this.lbl_receiving_baud_rate.Size = new System.Drawing.Size(63, 13);
            this.lbl_receiving_baud_rate.TabIndex = 11;
            this.lbl_receiving_baud_rate.Text = "0 KB / Sec.";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 500;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listView1);
            this.groupBox2.Location = new System.Drawing.Point(335, 31);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(270, 404);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Network Information";
            // 
            // listView1
            // 
            listViewGroup1.Header = "Name";
            listViewGroup1.Name = "name";
            listViewGroup2.Header = "ID";
            listViewGroup2.Name = "id";
            listViewGroup3.Header = "Type";
            listViewGroup3.Name = "type";
            listViewGroup4.Header = "Status";
            listViewGroup4.Name = "status";
            listViewGroup5.Header = "Speed";
            listViewGroup5.Name = "speed";
            this.listView1.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3,
            listViewGroup4,
            listViewGroup5});
            listViewItem1.Group = listViewGroup1;
            listViewItem2.Group = listViewGroup1;
            listViewItem3.Group = listViewGroup1;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3});
            this.listView1.Location = new System.Drawing.Point(6, 19);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(258, 379);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.SmallIcon;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Location = new System.Drawing.Point(12, 252);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(317, 183);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.performanceGraph1);
            this.panel1.Location = new System.Drawing.Point(6, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(305, 158);
            this.panel1.TabIndex = 0;
            // 
            // performanceGraph1
            // 
            this.performanceGraph1.BackColor = System.Drawing.Color.Black;
            this.performanceGraph1.CurrentValue = 0;
            this.performanceGraph1.CurrentValueX = 0;
            this.performanceGraph1.Location = new System.Drawing.Point(6, 3);
            this.performanceGraph1.MaxY = 100;
            this.performanceGraph1.MinY = 0;
            this.performanceGraph1.Name = "performanceGraph1";
            this.performanceGraph1.Size = new System.Drawing.Size(296, 152);
            this.performanceGraph1.TabIndex = 0;
            // 
            // NetworkStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 447);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ddl_nwInterfaces);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NetworkStatistics";
            this.Text = "Network Statistics";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NetworkStatistics_FormClosed);
            this.Load += new System.EventHandler(this.NetworkStatistics_Load);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddl_nwInterfaces;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbl_bytes_sent;
        private System.Windows.Forms.Label lbl_bytes_received;
        private System.Windows.Forms.Label lbl_bytes_total;
        private System.Windows.Forms.Label lbl_total_baud_rate;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_sending_baud_rate;
        private System.Windows.Forms.Label lbl_receiving_baud_rate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel1;
        private PerformanceGraph performanceGraph1;

    }
}