using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Threading;
using System.Runtime.Remoting.Messaging;

using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Net.Sockets;
using System.Timers;

namespace WindowsFormsApp1
{
    public partial class TalkySc : Form
    {
        public static object lockObject = new object();
        int Move;
        int Mouse_X;
        int Mouse_Y;
        static object kilit = new object();
        public TextBox messages = new TextBox();
        string ClientName;
        string contactname;
        string path;
        int TagID;
        private System.Windows.Forms.Timer timer;

        public TalkySc(string contactname,int TagID,string path,FlowLayoutPanel panel,string Clientname)
        {
            InitializeComponent();
            this.TagID=TagID;
            this.ClientName = ClientName;
            Control.CheckForIllegalCrossThreadCalls = false;

            this.contactname = contactname;

            this.path=path;
            

            this.Text = "";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ControlBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Width = 590;
            this.Height = 570;
            this.BackColor = Color.DarkCyan;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            Label TargetLabel = new Label();
            TargetLabel.Text = contactname;
            TargetLabel.Location = new Point(260, 40);
            TargetLabel.Font = new Font("Arial", 5);
            this.Controls.Add(TargetLabel);
            
            



            Button sendMessage = new Button();
            sendMessage.Text = "Gönder";
            sendMessage.Font = new Font("Arial", 15, FontStyle.Bold);
            sendMessage.Height = 70;
            sendMessage.Width = 95;
           sendMessage.Location = new Point(499, 499);
            sendMessage.BackColor = Color.DarkCyan;
            sendMessage.FlatStyle = FlatStyle.Flat;
            sendMessage.FlatAppearance.BorderSize = 0;
           
            this.Controls.Add(sendMessage);
          

            
            messages.Location = new Point(0, 80);
            messages.Width = 589;
            messages.Height = 420;
            messages.Multiline = true;
            messages.BackColor = Color.White;
            messages.BorderStyle = BorderStyle.FixedSingle;
            messages.Enabled = false;
            messages.Font= new Font(messages.Font.FontFamily,12f,FontStyle.Regular);
            this.Controls.Add(messages);
            functions.Bringlogs(messages,path);





            Button back = new Button();
            back.Location = new Point(0, 5);
            back.Click += new EventHandler(back_click);
            back.Text = "⇐";
            back.Height = 70;
            back.Width = 50;
            back.FlatStyle = FlatStyle.Flat;
            back.FlatAppearance.BorderSize = 0;
            back.Font = new Font("Arial", 25, FontStyle.Bold);
            this.Controls.Add(back);



            TextBox message = new TextBox();
            message.Location = new Point(0, 500);
            message.Font= new Font("Microsoft Sans Serif",10);
            message.Height = 70;
            message.Width = 498;
            message.Multiline = true;
            message.BackColor = Color.White;
            this.Controls.Add(message);
            
           



            Button close = new Button();
            close.Text = "X";
            close.Font = new Font("Arial", 10, FontStyle.Bold);
            close.Height = 30;
            close.Width = 30;
            close.Location = new Point(550, 10);
            close.Click += new EventHandler(close_click);
            close.FlatStyle = FlatStyle.Flat;
            close.FlatAppearance.BorderSize = 0;
            this.Controls.Add(close);


            sendMessage.Click += new EventHandler((sender, e) => sendMessage_click(sender, e, path, message,Clientname));

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // Timer aralığı 1 saniye (1000 milisaniye)
            timer.Tick += TimerTick;
            timer.Start();
            functions.Bringlogs(messages, path);
            Uptext(path);
           
        }
        

      private void Uptext(string path)
        {

            object fileLock = Locks.GetFileLock(path);
            lock (fileLock)
            {
                
            }


        }


        private void TimerTick(object sender, EventArgs e)
        {
            Uptext(path);
        }


        


        private void close_click(object sender, EventArgs e)
        {
            this.Hide();
            
            

        }
        private void TalkySc_Load(object sender, EventArgs e)
        {
            this.Text = "";
            Control.CheckForIllegalCrossThreadCalls = false;
        }


        private void back_click(object sender, EventArgs e)
        {

            this.Hide();


        }
        public async void sendMessage_click(object sender, EventArgs e,string path,TextBox input,string clientname)
        {
           

            string message = functions.ClientName[1] + ":" + input.Text;
            TcpClient outclient = functions.sender[functions.ClientName[1]];
            NetworkStream stream = outclient.GetStream();
            byte[] data=new byte[1024];
            data = Encoding.UTF8.GetBytes("sendmessage$" + contactname + "$" + TagID + "," + message);
            await stream.WriteAsync(data, 0, data.Length);
            


            input.Text = "";

        }

        private void TalkySc_MouseDown(object sender, MouseEventArgs e)
        {

            Move = 1;
            Mouse_Y = e.Y;
            Mouse_X = e.X;
            
        }

        private void TalkySc_MouseUp(object sender, MouseEventArgs e)
        {
            Move = 0;
        }

        private void TalkySc_MouseMove(object sender, MouseEventArgs e)
        {
            if (Move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }

        private void TalkySc_Load_1(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
        }

       
    }
}
