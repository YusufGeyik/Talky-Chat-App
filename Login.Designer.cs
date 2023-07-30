namespace WindowsFormsApp1
{
    partial class Login
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
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btExit = new System.Windows.Forms.Button();
            this.lblId = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.txtbxID = new System.Windows.Forms.TextBox();
            this.txtbxPass = new System.Windows.Forms.TextBox();
            this.btLogin = new System.Windows.Forms.Button();
            this.iptxtbx = new System.Windows.Forms.TextBox();
            this.iplbl = new System.Windows.Forms.Label();
            this.portlbl = new System.Windows.Forms.Label();
            this.txtbxport = new System.Windows.Forms.TextBox();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.DarkCyan;
            this.pnlFooter.Location = new System.Drawing.Point(-1, 383);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(452, 69);
            this.pnlFooter.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.DarkCyan;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox1.Location = new System.Drawing.Point(196, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(159, 24);
            this.textBox1.TabIndex = 15;
            this.textBox1.Text = "𝒯𝒶𝓁𝓀𝓎";
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.DarkCyan;
            this.pnlTop.Controls.Add(this.btExit);
            this.pnlTop.Controls.Add(this.textBox1);
            this.pnlTop.Location = new System.Drawing.Point(-1, -1);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(452, 69);
            this.pnlTop.TabIndex = 2;
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
            this.btExit.Location = new System.Drawing.Point(435, 0);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(17, 23);
            this.btExit.TabIndex = 20;
            this.btExit.Text = "X";
            this.btExit.UseVisualStyleBackColor = false;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.BackColor = System.Drawing.Color.DarkCyan;
            this.lblId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblId.Location = new System.Drawing.Point(94, 151);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(79, 16);
            this.lblId.TabIndex = 4;
            this.lblId.Text = "Kullanıcı Adı";
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.BackColor = System.Drawing.Color.DarkCyan;
            this.lblPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblPass.Location = new System.Drawing.Point(94, 172);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(34, 16);
            this.lblPass.TabIndex = 5;
            this.lblPass.Text = "Şifre";
            // 
            // txtbxID
            // 
            this.txtbxID.BackColor = System.Drawing.Color.DarkCyan;
            this.txtbxID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtbxID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtbxID.Location = new System.Drawing.Point(195, 151);
            this.txtbxID.Name = "txtbxID";
            this.txtbxID.Size = new System.Drawing.Size(100, 15);
            this.txtbxID.TabIndex = 1;
            // 
            // txtbxPass
            // 
            this.txtbxPass.BackColor = System.Drawing.Color.DarkCyan;
            this.txtbxPass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtbxPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtbxPass.Location = new System.Drawing.Point(195, 172);
            this.txtbxPass.Name = "txtbxPass";
            this.txtbxPass.PasswordChar = '*';
            this.txtbxPass.Size = new System.Drawing.Size(100, 15);
            this.txtbxPass.TabIndex = 2;
            // 
            // btLogin
            // 
            this.btLogin.BackColor = System.Drawing.Color.DarkCyan;
            this.btLogin.FlatAppearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.btLogin.FlatAppearance.BorderSize = 0;
            this.btLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkCyan;
            this.btLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkCyan;
            this.btLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btLogin.Location = new System.Drawing.Point(195, 267);
            this.btLogin.Name = "btLogin";
            this.btLogin.Size = new System.Drawing.Size(100, 23);
            this.btLogin.TabIndex = 5;
            this.btLogin.Text = "Giriş Yap";
            this.btLogin.UseVisualStyleBackColor = false;
            this.btLogin.Click += new System.EventHandler(this.btLogin_Click);
            // 
            // iptxtbx
            // 
            this.iptxtbx.BackColor = System.Drawing.Color.DarkCyan;
            this.iptxtbx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.iptxtbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.iptxtbx.Location = new System.Drawing.Point(195, 193);
            this.iptxtbx.Name = "iptxtbx";
            this.iptxtbx.Size = new System.Drawing.Size(100, 15);
            this.iptxtbx.TabIndex = 3;
            // 
            // iplbl
            // 
            this.iplbl.AutoSize = true;
            this.iplbl.BackColor = System.Drawing.Color.DarkCyan;
            this.iplbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.iplbl.Location = new System.Drawing.Point(94, 193);
            this.iplbl.Name = "iplbl";
            this.iplbl.Size = new System.Drawing.Size(19, 16);
            this.iplbl.TabIndex = 10;
            this.iplbl.Text = "IP";
            // 
            // portlbl
            // 
            this.portlbl.AutoSize = true;
            this.portlbl.BackColor = System.Drawing.Color.DarkCyan;
            this.portlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.portlbl.Location = new System.Drawing.Point(76, 219);
            this.portlbl.Name = "portlbl";
            this.portlbl.Size = new System.Drawing.Size(113, 16);
            this.portlbl.TabIndex = 11;
            this.portlbl.Text = "Tercih Edilen Port";
            // 
            // txtbxport
            // 
            this.txtbxport.BackColor = System.Drawing.Color.DarkCyan;
            this.txtbxport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtbxport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtbxport.Location = new System.Drawing.Point(195, 219);
            this.txtbxport.Name = "txtbxport";
            this.txtbxport.Size = new System.Drawing.Size(100, 15);
            this.txtbxport.TabIndex = 4;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 450);
            this.Controls.Add(this.txtbxport);
            this.Controls.Add(this.portlbl);
            this.Controls.Add(this.iplbl);
            this.Controls.Add(this.iptxtbx);
            this.Controls.Add(this.btLogin);
            this.Controls.Add(this.txtbxPass);
            this.Controls.Add(this.txtbxID);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlTop);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(450, 450);
            this.MinimumSize = new System.Drawing.Size(450, 450);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Login_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox txtbxID;
        private System.Windows.Forms.TextBox txtbxPass;
        private System.Windows.Forms.Button btLogin;
        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.TextBox iptxtbx;
        private System.Windows.Forms.Label iplbl;
        private System.Windows.Forms.Label portlbl;
        private System.Windows.Forms.TextBox txtbxport;
    }
}