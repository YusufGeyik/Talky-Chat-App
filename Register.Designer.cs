namespace WindowsFormsApp1
{
    partial class Register
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
            this.txtbxpass = new System.Windows.Forms.TextBox();
            this.txtbxID = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btExit = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtbxpass2 = new System.Windows.Forms.TextBox();
            this.lblPass2 = new System.Windows.Forms.Label();
            this.Iptxtbx = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Porttxtbx = new System.Windows.Forms.TextBox();
            this.portlbl = new System.Windows.Forms.Label();
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
            this.btRegister.Location = new System.Drawing.Point(195, 280);
            this.btRegister.Name = "btRegister";
            this.btRegister.Size = new System.Drawing.Size(100, 23);
            this.btRegister.TabIndex = 6;
            this.btRegister.Text = "Kayıt Ol";
            this.btRegister.UseVisualStyleBackColor = false;
            this.btRegister.Click += new System.EventHandler(this.btRegister_Click);
            // 
            // txtbxpass
            // 
            this.txtbxpass.BackColor = System.Drawing.Color.DarkCyan;
            this.txtbxpass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtbxpass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtbxpass.Location = new System.Drawing.Point(195, 162);
            this.txtbxpass.Name = "txtbxpass";
            this.txtbxpass.Size = new System.Drawing.Size(100, 15);
            this.txtbxpass.TabIndex = 2;
            // 
            // txtbxID
            // 
            this.txtbxID.BackColor = System.Drawing.Color.DarkCyan;
            this.txtbxID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtbxID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtbxID.Location = new System.Drawing.Point(195, 136);
            this.txtbxID.Name = "txtbxID";
            this.txtbxID.Size = new System.Drawing.Size(100, 15);
            this.txtbxID.TabIndex = 1;
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.BackColor = System.Drawing.Color.DarkCyan;
            this.lblPass.Enabled = false;
            this.lblPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblPass.Location = new System.Drawing.Point(94, 161);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(34, 16);
            this.lblPass.TabIndex = 12;
            this.lblPass.Text = "Şifre";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.BackColor = System.Drawing.Color.DarkCyan;
            this.lblId.Enabled = false;
            this.lblId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblId.Location = new System.Drawing.Point(94, 136);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(79, 16);
            this.lblId.TabIndex = 11;
            this.lblId.Text = "Kullanıcı Adı";
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.DarkCyan;
            this.pnlFooter.Location = new System.Drawing.Point(-1, 383);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(452, 69);
            this.pnlFooter.TabIndex = 10;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.DarkCyan;
            this.pnlTop.Controls.Add(this.btExit);
            this.pnlTop.Controls.Add(this.textBox1);
            this.pnlTop.Location = new System.Drawing.Point(-1, -1);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(452, 69);
            this.pnlTop.TabIndex = 9;
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
            this.btExit.Location = new System.Drawing.Point(435, 3);
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
            // txtbxpass2
            // 
            this.txtbxpass2.BackColor = System.Drawing.Color.DarkCyan;
            this.txtbxpass2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtbxpass2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtbxpass2.Location = new System.Drawing.Point(195, 189);
            this.txtbxpass2.Name = "txtbxpass2";
            this.txtbxpass2.Size = new System.Drawing.Size(100, 15);
            this.txtbxpass2.TabIndex = 3;
            // 
            // lblPass2
            // 
            this.lblPass2.AutoSize = true;
            this.lblPass2.BackColor = System.Drawing.Color.DarkCyan;
            this.lblPass2.Enabled = false;
            this.lblPass2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblPass2.Location = new System.Drawing.Point(94, 188);
            this.lblPass2.Name = "lblPass2";
            this.lblPass2.Size = new System.Drawing.Size(97, 16);
            this.lblPass2.TabIndex = 16;
            this.lblPass2.Text = "Şifre(TEKRAR)";
            // 
            // Iptxtbx
            // 
            this.Iptxtbx.BackColor = System.Drawing.Color.DarkCyan;
            this.Iptxtbx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Iptxtbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Iptxtbx.Location = new System.Drawing.Point(195, 236);
            this.Iptxtbx.Name = "Iptxtbx";
            this.Iptxtbx.Size = new System.Drawing.Size(100, 15);
            this.Iptxtbx.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkCyan;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(94, 235);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 16);
            this.label1.TabIndex = 18;
            this.label1.Text = "IP";
            // 
            // Porttxtbx
            // 
            this.Porttxtbx.BackColor = System.Drawing.Color.DarkCyan;
            this.Porttxtbx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Porttxtbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Porttxtbx.Location = new System.Drawing.Point(195, 254);
            this.Porttxtbx.Name = "Porttxtbx";
            this.Porttxtbx.Size = new System.Drawing.Size(100, 15);
            this.Porttxtbx.TabIndex = 5;
            // 
            // portlbl
            // 
            this.portlbl.AutoSize = true;
            this.portlbl.BackColor = System.Drawing.Color.DarkCyan;
            this.portlbl.Enabled = false;
            this.portlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.portlbl.Location = new System.Drawing.Point(94, 256);
            this.portlbl.Name = "portlbl";
            this.portlbl.Size = new System.Drawing.Size(91, 13);
            this.portlbl.TabIndex = 20;
            this.portlbl.Text = "Tercih Edilen Port";
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 450);
            this.Controls.Add(this.Porttxtbx);
            this.Controls.Add(this.portlbl);
            this.Controls.Add(this.Iptxtbx);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtbxpass2);
            this.Controls.Add(this.lblPass2);
            this.Controls.Add(this.btRegister);
            this.Controls.Add(this.txtbxpass);
            this.Controls.Add(this.txtbxID);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(450, 450);
            this.MinimumSize = new System.Drawing.Size(450, 450);
            this.Name = "Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btRegister;
        private System.Windows.Forms.TextBox txtbxpass;
        private System.Windows.Forms.TextBox txtbxID;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtbxpass2;
        private System.Windows.Forms.Label lblPass2;
        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.TextBox Iptxtbx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Porttxtbx;
        private System.Windows.Forms.Label portlbl;
    }
}