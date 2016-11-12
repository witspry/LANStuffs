namespace LANStuffs.Games
{
    partial class TicToe
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbt_circle = new System.Windows.Forms.RadioButton();
            this.rbt_cross = new System.Windows.Forms.RadioButton();
            this.bt_Done = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_you_draw = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_you_win = new System.Windows.Forms.Label();
            this.lbl_opp_lose = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_you_lose = new System.Windows.Forms.Label();
            this.lbl_opp_win = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_you_total = new System.Windows.Forms.Label();
            this.lbl_opp_draw = new System.Windows.Forms.Label();
            this.lbl_opp_total = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.bt_Set = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lbl_result = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbt_circle);
            this.groupBox1.Controls.Add(this.rbt_cross);
            this.groupBox1.Location = new System.Drawing.Point(170, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(154, 40);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choose character";
            // 
            // rbt_circle
            // 
            this.rbt_circle.AutoSize = true;
            this.rbt_circle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbt_circle.Location = new System.Drawing.Point(79, 19);
            this.rbt_circle.Name = "rbt_circle";
            this.rbt_circle.Size = new System.Drawing.Size(51, 17);
            this.rbt_circle.TabIndex = 1;
            this.rbt_circle.Text = "Circle";
            this.rbt_circle.UseVisualStyleBackColor = true;
            this.rbt_circle.CheckedChanged += new System.EventHandler(this.rbt_circle_CheckedChanged);
            // 
            // rbt_cross
            // 
            this.rbt_cross.AutoSize = true;
            this.rbt_cross.Checked = true;
            this.rbt_cross.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbt_cross.Location = new System.Drawing.Point(6, 19);
            this.rbt_cross.Name = "rbt_cross";
            this.rbt_cross.Size = new System.Drawing.Size(51, 17);
            this.rbt_cross.TabIndex = 0;
            this.rbt_cross.TabStop = true;
            this.rbt_cross.Text = "Cross";
            this.rbt_cross.UseVisualStyleBackColor = true;
            this.rbt_cross.CheckedChanged += new System.EventHandler(this.rbt_cross_CheckedChanged);
            // 
            // bt_Done
            // 
            this.bt_Done.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bt_Done.Location = new System.Drawing.Point(99, 150);
            this.bt_Done.Name = "bt_Done";
            this.bt_Done.Size = new System.Drawing.Size(45, 23);
            this.bt_Done.TabIndex = 10;
            this.bt_Done.Text = "Done";
            this.bt_Done.UseVisualStyleBackColor = true;
            this.bt_Done.Click += new System.EventHandler(this.bt_Done_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel1);
            this.groupBox2.Location = new System.Drawing.Point(12, 179);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(312, 105);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Score Card";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetPartial;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel1.Controls.Add(this.lbl_you_draw, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_you_win, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbl_opp_lose, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_you_lose, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbl_opp_win, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_you_total, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbl_opp_draw, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbl_opp_total, 4, 2);
            this.tableLayoutPanel1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(300, 80);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lbl_you_draw
            // 
            this.lbl_you_draw.AutoSize = true;
            this.lbl_you_draw.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_you_draw.Location = new System.Drawing.Point(193, 33);
            this.lbl_you_draw.Name = "lbl_you_draw";
            this.lbl_you_draw.Size = new System.Drawing.Size(13, 13);
            this.lbl_you_draw.TabIndex = 13;
            this.lbl_you_draw.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(246, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 26);
            this.label6.TabIndex = 12;
            this.label6.Text = "Total Points";
            // 
            // lbl_you_win
            // 
            this.lbl_you_win.AutoSize = true;
            this.lbl_you_win.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_you_win.Location = new System.Drawing.Point(87, 33);
            this.lbl_you_win.Name = "lbl_you_win";
            this.lbl_you_win.Size = new System.Drawing.Size(13, 13);
            this.lbl_you_win.TabIndex = 4;
            this.lbl_you_win.Text = "0";
            // 
            // lbl_opp_lose
            // 
            this.lbl_opp_lose.AutoSize = true;
            this.lbl_opp_lose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_opp_lose.Location = new System.Drawing.Point(140, 56);
            this.lbl_opp_lose.Name = "lbl_opp_lose";
            this.lbl_opp_lose.Size = new System.Drawing.Size(13, 13);
            this.lbl_opp_lose.TabIndex = 7;
            this.lbl_opp_lose.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(87, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "Games Win";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(6, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "You";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(6, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Opponent";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(140, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 26);
            this.label4.TabIndex = 3;
            this.label4.Text = "Games Lose";
            // 
            // lbl_you_lose
            // 
            this.lbl_you_lose.AutoSize = true;
            this.lbl_you_lose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_you_lose.Location = new System.Drawing.Point(140, 33);
            this.lbl_you_lose.Name = "lbl_you_lose";
            this.lbl_you_lose.Size = new System.Drawing.Size(13, 13);
            this.lbl_you_lose.TabIndex = 6;
            this.lbl_you_lose.Text = "0";
            // 
            // lbl_opp_win
            // 
            this.lbl_opp_win.AutoSize = true;
            this.lbl_opp_win.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_opp_win.Location = new System.Drawing.Point(87, 56);
            this.lbl_opp_win.Name = "lbl_opp_win";
            this.lbl_opp_win.Size = new System.Drawing.Size(13, 13);
            this.lbl_opp_win.TabIndex = 5;
            this.lbl_opp_win.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(193, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 26);
            this.label5.TabIndex = 8;
            this.label5.Text = "Games Draw";
            // 
            // lbl_you_total
            // 
            this.lbl_you_total.AutoSize = true;
            this.lbl_you_total.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_you_total.Location = new System.Drawing.Point(246, 33);
            this.lbl_you_total.Name = "lbl_you_total";
            this.lbl_you_total.Size = new System.Drawing.Size(13, 13);
            this.lbl_you_total.TabIndex = 14;
            this.lbl_you_total.Text = "0";
            // 
            // lbl_opp_draw
            // 
            this.lbl_opp_draw.AutoSize = true;
            this.lbl_opp_draw.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_opp_draw.Location = new System.Drawing.Point(193, 56);
            this.lbl_opp_draw.Name = "lbl_opp_draw";
            this.lbl_opp_draw.Size = new System.Drawing.Size(13, 13);
            this.lbl_opp_draw.TabIndex = 15;
            this.lbl_opp_draw.Text = "0";
            // 
            // lbl_opp_total
            // 
            this.lbl_opp_total.AutoSize = true;
            this.lbl_opp_total.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_opp_total.Location = new System.Drawing.Point(246, 56);
            this.lbl_opp_total.Name = "lbl_opp_total";
            this.lbl_opp_total.Size = new System.Drawing.Size(13, 13);
            this.lbl_opp_total.TabIndex = 16;
            this.lbl_opp_total.Text = "0";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.bt_Set);
            this.groupBox3.Controls.Add(this.numericUpDown1);
            this.groupBox3.Location = new System.Drawing.Point(170, 58);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(154, 49);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Set Number of matches";
            // 
            // bt_Set
            // 
            this.bt_Set.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bt_Set.Location = new System.Drawing.Point(95, 17);
            this.bt_Set.Name = "bt_Set";
            this.bt_Set.Size = new System.Drawing.Size(53, 23);
            this.bt_Set.TabIndex = 14;
            this.bt_Set.Text = "Set";
            this.bt_Set.UseVisualStyleBackColor = true;
            this.bt_Set.Click += new System.EventHandler(this.bt_Set_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(6, 20);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(82, 20);
            this.numericUpDown1.TabIndex = 13;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // pictureBox9
            // 
            this.pictureBox9.BackColor = System.Drawing.Color.White;
            this.pictureBox9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox9.Location = new System.Drawing.Point(104, 104);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(40, 40);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox9.TabIndex = 8;
            this.pictureBox9.TabStop = false;
            this.pictureBox9.Click += new System.EventHandler(this.pictureBox9_Click);
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.Color.White;
            this.pictureBox8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox8.Location = new System.Drawing.Point(58, 104);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(40, 40);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 7;
            this.pictureBox8.TabStop = false;
            this.pictureBox8.Click += new System.EventHandler(this.pictureBox8_Click);
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.White;
            this.pictureBox7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox7.Location = new System.Drawing.Point(12, 104);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(40, 40);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 6;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.Click += new System.EventHandler(this.pictureBox7_Click);
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.White;
            this.pictureBox6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox6.Location = new System.Drawing.Point(104, 58);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(40, 40);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 5;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.White;
            this.pictureBox5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox5.Location = new System.Drawing.Point(58, 58);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(40, 40);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 4;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.White;
            this.pictureBox4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox4.Location = new System.Drawing.Point(12, 58);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(40, 40);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.White;
            this.pictureBox3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox3.Location = new System.Drawing.Point(104, 12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(40, 40);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox2.Location = new System.Drawing.Point(58, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lbl_result);
            this.groupBox4.Location = new System.Drawing.Point(170, 113);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(154, 60);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Result";
            // 
            // lbl_result
            // 
            this.lbl_result.Location = new System.Drawing.Point(6, 16);
            this.lbl_result.Name = "lbl_result";
            this.lbl_result.Size = new System.Drawing.Size(142, 41);
            this.lbl_result.TabIndex = 0;
            // 
            // TicToe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(338, 295);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.bt_Done);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TicToe";
            this.Text = "TicToe";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TicToe_FormClosed);
            this.Load += new System.EventHandler(this.TicToe_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbt_cross;
        private System.Windows.Forms.RadioButton rbt_circle;
        private System.Windows.Forms.Button bt_Done;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_you_win;
        private System.Windows.Forms.Label lbl_opp_win;
        private System.Windows.Forms.Label lbl_you_lose;
        private System.Windows.Forms.Label lbl_opp_lose;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lbl_you_draw;
        private System.Windows.Forms.Label lbl_you_total;
        private System.Windows.Forms.Label lbl_opp_draw;
        private System.Windows.Forms.Label lbl_opp_total;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button bt_Set;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lbl_result;
    }
}