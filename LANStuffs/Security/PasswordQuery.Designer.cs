namespace LANStuffs.Security
{
    partial class PasswordQuery
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
            this.txt_password = new System.Windows.Forms.TextBox();
            this.bt_Cancel = new System.Windows.Forms.Button();
            this.bt_OK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ddl_number = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ddl_alphabets = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_recovered_pass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bt_OK2 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_hint = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.bt_more = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(105, 42);
            this.txt_password.Name = "txt_password";
            this.txt_password.PasswordChar = '*';
            this.txt_password.Size = new System.Drawing.Size(306, 20);
            this.txt_password.TabIndex = 1;
            this.txt_password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_password_KeyPress);
            // 
            // bt_Cancel
            // 
            this.bt_Cancel.Location = new System.Drawing.Point(290, 66);
            this.bt_Cancel.Name = "bt_Cancel";
            this.bt_Cancel.Size = new System.Drawing.Size(60, 23);
            this.bt_Cancel.TabIndex = 4;
            this.bt_Cancel.Text = "Cancel";
            this.bt_Cancel.UseVisualStyleBackColor = true;
            this.bt_Cancel.Click += new System.EventHandler(this.bt_Cancel_Click);
            // 
            // bt_OK
            // 
            this.bt_OK.Location = new System.Drawing.Point(221, 66);
            this.bt_OK.Name = "bt_OK";
            this.bt_OK.Size = new System.Drawing.Size(63, 23);
            this.bt_OK.TabIndex = 3;
            this.bt_OK.Text = "OK";
            this.bt_OK.UseVisualStyleBackColor = true;
            this.bt_OK.Click += new System.EventHandler(this.bt_OK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(331, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "This software is password protected. Please enter password to open.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "OR";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_name);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.ddl_number);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.ddl_alphabets);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_recovered_pass);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.bt_OK2);
            this.groupBox1.Location = new System.Drawing.Point(12, 131);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(399, 145);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Provide answers to recover password";
            // 
            // txt_name
            // 
            this.txt_name.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_name.Location = new System.Drawing.Point(209, 25);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(184, 20);
            this.txt_name.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "1. What is your name?";
            // 
            // ddl_number
            // 
            this.ddl_number.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddl_number.FormattingEnabled = true;
            this.ddl_number.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.ddl_number.Location = new System.Drawing.Point(209, 79);
            this.ddl_number.Name = "ddl_number";
            this.ddl_number.Size = new System.Drawing.Size(103, 21);
            this.ddl_number.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "3. What is your favorite number?";
            // 
            // ddl_alphabets
            // 
            this.ddl_alphabets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddl_alphabets.FormattingEnabled = true;
            this.ddl_alphabets.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z"});
            this.ddl_alphabets.Location = new System.Drawing.Point(209, 52);
            this.ddl_alphabets.Name = "ddl_alphabets";
            this.ddl_alphabets.Size = new System.Drawing.Size(103, 21);
            this.ddl_alphabets.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "2. What is your favorite alphabet?";
            // 
            // txt_recovered_pass
            // 
            this.txt_recovered_pass.Location = new System.Drawing.Point(178, 115);
            this.txt_recovered_pass.Name = "txt_recovered_pass";
            this.txt_recovered_pass.ReadOnly = true;
            this.txt_recovered_pass.Size = new System.Drawing.Size(134, 20);
            this.txt_recovered_pass.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(76, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Your password is : ";
            // 
            // bt_OK2
            // 
            this.bt_OK2.Location = new System.Drawing.Point(318, 77);
            this.bt_OK2.Name = "bt_OK2";
            this.bt_OK2.Size = new System.Drawing.Size(75, 23);
            this.bt_OK2.TabIndex = 8;
            this.bt_OK2.Text = "OK";
            this.bt_OK2.UseVisualStyleBackColor = true;
            this.bt_OK2.Click += new System.EventHandler(this.bt_OK2_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Password Hint : ";
            // 
            // txt_hint
            // 
            this.txt_hint.Location = new System.Drawing.Point(105, 68);
            this.txt_hint.Name = "txt_hint";
            this.txt_hint.ReadOnly = true;
            this.txt_hint.Size = new System.Drawing.Size(110, 20);
            this.txt_hint.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Enter Password : ";
            // 
            // bt_more
            // 
            this.bt_more.Location = new System.Drawing.Point(356, 66);
            this.bt_more.Name = "bt_more";
            this.bt_more.Size = new System.Drawing.Size(55, 23);
            this.bt_more.TabIndex = 18;
            this.bt_more.Text = "More =>";
            this.bt_more.UseVisualStyleBackColor = true;
            this.bt_more.Click += new System.EventHandler(this.bt_more_Click);
            // 
            // PasswordQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 103);
            this.Controls.Add(this.bt_more);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_hint);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bt_Cancel);
            this.Controls.Add(this.bt_OK);
            this.Controls.Add(this.txt_password);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PasswordQuery";
            this.Text = "Password Query";
            this.Load += new System.EventHandler(this.PasswordQuery_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Button bt_Cancel;
        private System.Windows.Forms.Button bt_OK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bt_OK2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_recovered_pass;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_hint;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox ddl_number;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ddl_alphabets;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bt_more;
    }
}