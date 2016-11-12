namespace LANStuffs
{
    partial class PerformanceGraph
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbl_max_y = new System.Windows.Forms.Label();
            this.lbl_min_y = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lbl_max_y
            // 
            this.lbl_max_y.AutoSize = true;
            this.lbl_max_y.ForeColor = System.Drawing.Color.LightGreen;
            this.lbl_max_y.Location = new System.Drawing.Point(15, 15);
            this.lbl_max_y.Name = "lbl_max_y";
            this.lbl_max_y.Size = new System.Drawing.Size(35, 13);
            this.lbl_max_y.TabIndex = 0;
            this.lbl_max_y.Text = "label1";
            this.lbl_max_y.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_min_y
            // 
            this.lbl_min_y.AutoSize = true;
            this.lbl_min_y.ForeColor = System.Drawing.Color.LightGreen;
            this.lbl_min_y.Location = new System.Drawing.Point(15, 133);
            this.lbl_min_y.Name = "lbl_min_y";
            this.lbl_min_y.Size = new System.Drawing.Size(35, 13);
            this.lbl_min_y.TabIndex = 1;
            this.lbl_min_y.Text = "label2";
            this.lbl_min_y.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(56, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(302, 131);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // PerformanceGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbl_min_y);
            this.Controls.Add(this.lbl_max_y);
            this.Name = "PerformanceGraph";
            this.Size = new System.Drawing.Size(404, 235);
            this.Load += new System.EventHandler(this.PerformanceGraph_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PerformanceGraph_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_max_y;
        private System.Windows.Forms.Label lbl_min_y;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
    }
}
