namespace WindowsFormsApp1
{
    partial class TalkySc
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
            this.SuspendLayout();
            // 
            // TalkySc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "TalkySc";
            this.Text = "Talkysc";
            this.Load += new System.EventHandler(this.TalkySc_Load_1);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TalkySc_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TalkySc_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TalkySc_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}