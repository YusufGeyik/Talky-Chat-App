namespace WindowsFormsApp1
{
    partial class Anasayfa
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnl_Chats = new System.Windows.Forms.FlowLayoutPanel();
            this.btExit = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtbxID = new System.Windows.Forms.TextBox();
            this.txtbTargetID = new System.Windows.Forms.TextBox();
            this.btStartChat = new System.Windows.Forms.Button();
            this.txtbxInfo = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.DarkCyan;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox1.Location = new System.Drawing.Point(265, 38);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(159, 24);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "𝒯𝒶𝓁𝓀𝓎";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkCyan;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.pnl_Chats);
            this.panel2.Controls.Add(this.btExit);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Location = new System.Drawing.Point(-3, -7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(590, 103);
            this.panel2.TabIndex = 2;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(262, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 21;
            this.label1.Text = "label1";
            // 
            // pnl_Chats
            // 
            this.pnl_Chats.AutoSize = true;
            this.pnl_Chats.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnl_Chats.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnl_Chats.Location = new System.Drawing.Point(0, 104);
            this.pnl_Chats.Name = "pnl_Chats";
            this.pnl_Chats.Size = new System.Drawing.Size(0, 0);
            this.pnl_Chats.TabIndex = 4;
            // 
            // btExit
            // 
            this.btExit.BackColor = System.Drawing.Color.DarkCyan;
            this.btExit.FlatAppearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.btExit.FlatAppearance.BorderSize = 0;
            this.btExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkCyan;
            this.btExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkCyan;
            this.btExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btExit.Location = new System.Drawing.Point(556, 19);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(31, 23);
            this.btExit.TabIndex = 20;
            this.btExit.Text = "X";
            this.btExit.UseVisualStyleBackColor = false;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkCyan;
            this.panel3.Controls.Add(this.txtbxID);
            this.panel3.Controls.Add(this.txtbTargetID);
            this.panel3.Controls.Add(this.btStartChat);
            this.panel3.Controls.Add(this.txtbxInfo);
            this.panel3.Location = new System.Drawing.Point(-3, 487);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(590, 97);
            this.panel3.TabIndex = 3;
            // 
            // txtbxID
            // 
            this.txtbxID.BackColor = System.Drawing.Color.DarkCyan;
            this.txtbxID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtbxID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtbxID.Location = new System.Drawing.Point(90, 30);
            this.txtbxID.Multiline = true;
            this.txtbxID.Name = "txtbxID";
            this.txtbxID.Size = new System.Drawing.Size(93, 20);
            this.txtbxID.TabIndex = 30;
            this.txtbxID.Text = "Kullanıcı Adı";
            this.txtbxID.Visible = false;
            // 
            // txtbTargetID
            // 
            this.txtbTargetID.BackColor = System.Drawing.Color.White;
            this.txtbTargetID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtbTargetID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtbTargetID.Location = new System.Drawing.Point(189, 28);
            this.txtbTargetID.Multiline = true;
            this.txtbTargetID.Name = "txtbTargetID";
            this.txtbTargetID.Size = new System.Drawing.Size(139, 20);
            this.txtbTargetID.TabIndex = 27;
            this.txtbTargetID.Visible = false;
            // 
            // btStartChat
            // 
            this.btStartChat.BackColor = System.Drawing.Color.White;
            this.btStartChat.FlatAppearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.btStartChat.FlatAppearance.BorderSize = 0;
            this.btStartChat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkCyan;
            this.btStartChat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkCyan;
            this.btStartChat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btStartChat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btStartChat.Location = new System.Drawing.Point(358, 28);
            this.btStartChat.Name = "btStartChat";
            this.btStartChat.Size = new System.Drawing.Size(100, 20);
            this.btStartChat.TabIndex = 28;
            this.btStartChat.Text = "Chati Başlat";
            this.btStartChat.UseVisualStyleBackColor = false;
            this.btStartChat.Visible = false;
            this.btStartChat.Click += new System.EventHandler(this.btStartChat_Click);
            // 
            // txtbxInfo
            // 
            this.txtbxInfo.BackColor = System.Drawing.Color.DarkCyan;
            this.txtbxInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtbxInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtbxInfo.Location = new System.Drawing.Point(3, 60);
            this.txtbxInfo.Multiline = true;
            this.txtbxInfo.Name = "txtbxInfo";
            this.txtbxInfo.ReadOnly = true;
            this.txtbxInfo.Size = new System.Drawing.Size(455, 34);
            this.txtbxInfo.TabIndex = 29;
            this.txtbxInfo.Text = "Birden fazla kullanıcı içeren bir chat başlatmak için kullanıcı adları arasına vi" +
    "rgül koyunuz.";
            this.txtbxInfo.Visible = false;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.InfoText;
            this.textBox3.ForeColor = System.Drawing.SystemColors.Info;
            this.textBox3.Location = new System.Drawing.Point(590, 14);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(537, 454);
            this.textBox3.TabIndex = 4;
            // 
            // Anasayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 584);
            this.ControlBox = false;
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Anasayfa";
            this.Load += new System.EventHandler(this.Anasayfa_Load);
            this.Shown += new System.EventHandler(this.Anasayfa_Shown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.TextBox txtbTargetID;
        private System.Windows.Forms.Button btStartChat;
        private System.Windows.Forms.TextBox txtbxInfo;
        private System.Windows.Forms.TextBox txtbxID;
        private System.Windows.Forms.FlowLayoutPanel pnl_Chats;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label1;
    }
}

