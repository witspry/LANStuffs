namespace LANStuffs
{
    partial class PrivateChatWindow
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("TicToe");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Play a Game", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.button1 = new System.Windows.Forms.Button();
            this.txtReceive = new System.Windows.Forms.RichTextBox();
            this.txtSend = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bt_SendFile = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(270, 168);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtReceive
            // 
            this.txtReceive.Location = new System.Drawing.Point(6, 19);
            this.txtReceive.Name = "txtReceive";
            this.txtReceive.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtReceive.Size = new System.Drawing.Size(335, 102);
            this.txtReceive.TabIndex = 1;
            this.txtReceive.Text = "";
            this.txtReceive.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(6, 133);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(258, 58);
            this.txtSend.TabIndex = 2;
            this.txtSend.Text = "";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtReceive);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtSend);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(351, 199);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Private communication messages";
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(369, 21);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "TicToe";
            treeNode1.Text = "TicToe";
            treeNode2.Name = "PlayGame";
            treeNode2.Text = "Play a Game";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.treeView1.Size = new System.Drawing.Size(144, 112);
            this.treeView1.TabIndex = 4;
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bt_SendFile);
            this.groupBox2.Location = new System.Drawing.Point(369, 139);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(144, 72);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Other Tasks";
            // 
            // bt_SendFile
            // 
            this.bt_SendFile.Location = new System.Drawing.Point(6, 41);
            this.bt_SendFile.Name = "bt_SendFile";
            this.bt_SendFile.Size = new System.Drawing.Size(75, 23);
            this.bt_SendFile.TabIndex = 0;
            this.bt_SendFile.Text = "Send File";
            this.bt_SendFile.UseVisualStyleBackColor = true;
            this.bt_SendFile.Click += new System.EventHandler(this.bt_SendFile_Click);
            // 
            // PrivateChatWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 228);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.groupBox1);
            this.Name = "PrivateChatWindow";
            this.Load += new System.EventHandler(this.PrivateChatWindow_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox txtReceive;
        private System.Windows.Forms.RichTextBox txtSend;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bt_SendFile;
    }
}