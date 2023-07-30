using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Decide : Form
    {
        public Decide()
        {
            InitializeComponent();

            Control.CheckForIllegalCrossThreadCalls = false;

        }

        private void btLogin_Click(object sender, EventArgs e)
        {
           Login login = new Login();
           login.Show();
            this.Hide();
        }

        private void btRegister_Click(object sender, EventArgs e)
        {
            Register register = new Register();
           

            register.Show();
            this.Hide();
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Decide_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
        }
    }
}
