namespace LANStuffs
{
    partial class SendingFileProgressDialog
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_filename = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_laddress = new System.Windows.Forms.Label();
            this.lbl_address = new System.Windows.Forms.Label();
            this.lbl_kbSent = new System.Windows.Forms.Label();
            this.lbl_percent = new System.Windows.Forms.Label();
            this.lbl_filesize = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_size_of_file = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_baud_rate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 75);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(340, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sending File : ";
            // 
            // lbl_filename
            // 
            this.lbl_filename.AutoSize = true;
            this.lbl_filename.Location = new System.Drawing.Point(89, 18);
            this.lbl_filename.Name = "lbl_filename";
            this.lbl_filename.Size = new System.Drawing.Size(46, 13);
            this.lbl_filename.TabIndex = 2;
            this.lbl_filename.Text = "filename";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "From : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(188, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "To : ";
            // 
            // lbl_laddress
            // 
            this.lbl_laddress.AutoSize = true;
            this.lbl_laddress.Location = new System.Drawing.Point(233, 34);
            this.lbl_laddress.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.lbl_laddress.Name = "lbl_laddress";
            this.lbl_laddress.Size = new System.Drawing.Size(46, 13);
            this.lbl_laddress.TabIndex = 5;
            this.lbl_laddress.Text = "laddress";
            // 
            // lbl_address
            // 
            this.lbl_address.AutoSize = true;
            this.lbl_address.Location = new System.Drawing.Point(233, 51);
            this.lbl_address.Name = "lbl_address";
            this.lbl_address.Size = new System.Drawing.Size(44, 13);
            this.lbl_address.TabIndex = 6;
            this.lbl_address.Text = "address";
            // 
            // lbl_kbSent
            // 
            this.lbl_kbSent.AutoSize = true;
            this.lbl_kbSent.Location = new System.Drawing.Point(12, 101);
            this.lbl_kbSent.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lbl_kbSent.Name = "lbl_kbSent";
            this.lbl_kbSent.Size = new System.Drawing.Size(31, 13);
            this.lbl_kbSent.TabIndex = 7;
            this.lbl_kbSent.Text = "X KB";
            // 
            // lbl_percent
            // 
            this.lbl_percent.Location = new System.Drawing.Point(226, 101);
            this.lbl_percent.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lbl_percent.Name = "lbl_percent";
            this.lbl_percent.Size = new System.Drawing.Size(58, 13);
            this.lbl_percent.TabIndex = 8;
            this.lbl_percent.Text = "0";
            this.lbl_percent.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_filesize
            // 
            this.lbl_filesize.AutoSize = true;
            this.lbl_filesize.Location = new System.Drawing.Point(43, 101);
            this.lbl_filesize.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lbl_filesize.Name = "lbl_filesize";
            this.lbl_filesize.Size = new System.Drawing.Size(68, 13);
            this.lbl_filesize.TabIndex = 9;
            this.lbl_filesize.Text = "of Y KB Sent";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(284, 101);
            this.label4.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "% Completed";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Size of File :";
            // 
            // lbl_size_of_file
            // 
            this.lbl_size_of_file.AutoSize = true;
            this.lbl_size_of_file.Location = new System.Drawing.Point(89, 34);
            this.lbl_size_of_file.Name = "lbl_size_of_file";
            this.lbl_size_of_file.Size = new System.Drawing.Size(30, 13);
            this.lbl_size_of_file.TabIndex = 12;
            this.lbl_size_of_file.Text = "0 KB";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Baud Rate :";
            // 
            // lbl_baud_rate
            // 
            this.lbl_baud_rate.AutoSize = true;
            this.lbl_baud_rate.Location = new System.Drawing.Point(89, 51);
            this.lbl_baud_rate.Name = "lbl_baud_rate";
            this.lbl_baud_rate.Size = new System.Drawing.Size(57, 13);
            this.lbl_baud_rate.TabIndex = 14;
            this.lbl_baud_rate.Text = "0 KB/Sec.";
            // 
            // SendingFileProgressDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 133);
            this.Controls.Add(this.lbl_baud_rate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbl_size_of_file);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl_filesize);
            this.Controls.Add(this.lbl_percent);
            this.Controls.Add(this.lbl_kbSent);
            this.Controls.Add(this.lbl_address);
            this.Controls.Add(this.lbl_laddress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_filename);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SendingFileProgressDialog";
            this.Text = "SendingFileProgressDialog";
            this.Load += new System.EventHandler(this.SendingFileProgressDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_filename;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_laddress;
        private System.Windows.Forms.Label lbl_address;
        private System.Windows.Forms.Label lbl_kbSent;
        private System.Windows.Forms.Label lbl_percent;
        private System.Windows.Forms.Label lbl_filesize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_size_of_file;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_baud_rate;
    }
}