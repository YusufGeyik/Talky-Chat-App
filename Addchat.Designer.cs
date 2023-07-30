namespace WindowsFormsApp1
{
    partial class Addchat
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
            this.btRegister = new System.Windows.Forms.Button();
            this.txtbTargetID = new System.Windows.Forms.TextBox();
            this.lblTargetID = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btExit = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // btRegister
            // 
            this.btRegister.BackColor = System.Drawing.Color.DarkCyan;
            this.btRegister.FlatAppearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.btRegister.FlatAppearance.BorderSize = 0;
            this.btRegister.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkCyan;
            this.btRegister.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkCyan;
            this.btRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btRegister.Location = new System.Drawing.Point(196, 203);
            this.btRegister.Name = "btRegister";
            this.btRegister.Size = new System.Drawing.Size(100, 23);
            this.btRegister.TabIndex = 24;
            this.btRegister.Text = "Chati Başlat";
            this.btRegister.UseVisualStyleBackColor = false;
            this.btRegister.Click += new System.EventHandler(this.btRegister_Click);
            // 
            // txtbTargetID
            // 
            this.txtbTargetID.BackColor = System.Drawing.Color.DarkCyan;
            this.txtbTargetID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtbTargetID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtbTargetID.Location = new System.Drawing.Point(196, 152);
            this.txtbTargetID.Name = "txtbTargetID";
            this.txtbTargetID.Size = new System.Drawing.Size(139, 15);
            this.txtbTargetID.TabIndex = 22;
            // 
            // lblTargetID
            // 
            this.lblTargetID.AutoSize = true;
            this.lblTargetID.BackColor = System.Drawing.Color.DarkCyan;
            this.lblTargetID.Enabled = false;
            this.lblTargetID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTargetID.Location = new System.Drawing.Point(95, 152);
            this.lblTargetID.Name = "lblTargetID";
            this.lblTargetID.Size = new System.Drawing.Size(79, 16);
            this.lblTargetID.TabIndex = 20;
            this.lblTargetID.Text = "Kullanıcı Adı";
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.DarkCyan;
            this.pnlFooter.Location = new System.Drawing.Point(0, 385);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(452, 69);
            this.pnlFooter.TabIndex = 19;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.DarkCyan;
            this.pnlTop.Controls.Add(this.btExit);
            this.pnlTop.Controls.Add(this.textBox1);
            this.pnlTop.Location = new System.Drawing.Point(0, 1);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(452, 69);
            this.pnlTop.TabIndex = 18;
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
            this.btExit.Location = new System.Drawing.Point(432, 3);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(17, 23);
            this.btExit.TabIndex = 18;
            this.btExit.Text = "X";
            this.btExit.UseVisualStyleBackColor = false;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.DarkCyan;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox1.Location = new System.Drawing.Point(196, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(159, 24);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "𝒯𝒶𝓁𝓀𝓎";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.DarkCyan;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox2.Location = new System.Drawing.Point(35, 287);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(389, 34);
            this.textBox2.TabIndex = 25;
            this.textBox2.Text = "Birden fazla kullanıcı içeren bir chat başlatmak için kullanıcı adları arasına vi" +
    "rgül koyunuz.";
            // 
            // Addchat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 450);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.btRegister);
            this.Controls.Add(this.txtbTargetID);
            this.Controls.Add(this.lblTargetID);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(450, 450);
            this.MinimumSize = new System.Drawing.Size(450, 450);
            this.Name = "Addchat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Addchat_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btRegister;
        private System.Windows.Forms.TextBox txtbTargetID;
        private System.Windows.Forms.Label lblTargetID;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
    }
}