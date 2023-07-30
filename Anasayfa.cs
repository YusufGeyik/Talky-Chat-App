using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace WindowsFormsApp1
{

    public partial class Anasayfa : Form
    {
        int aktifchatsayisi = 0;
        List<FileSystemWatcher> fileWatchers = new List<FileSystemWatcher>();
        int Move;
        int Mouse_X;
        int Mouse_Y;
        public static Dictionary<string, FileSystemWatcher> textboxfilewatcher = new Dictionary<string, FileSystemWatcher>();
        bool swap = false;
        public string ClientName;
        TcpClient Listenersocket;
        TcpClient Sendersocket;

        private static Anasayfa instance;

        // Ana sayfa örneğine erişim sağlayan özellik
        public static Anasayfa Instance
        {
            get { return instance; }
        }
        public  Anasayfa(string Clientname)
        {
            functions.ClientName.Add(1, Clientname);
            instance= this;
            this.ClientName = Clientname;
            //this.Listenersocket = listenersocket;
           // this.Sendersocket = sendersocket;
            InitializeComponent();

            label1.Text = Clientname;




            string newchatPath = @"C:\Users\YUSUF\donem-projesi-YusufGeyik\NewChat.png";
            PictureBox PctBxnewchat = new PictureBox(); //yeni chat başlatma iconu eklendi
            PctBxnewchat.Image = Image.FromFile(newchatPath);
            PctBxnewchat.SizeMode = PictureBoxSizeMode.StretchImage;
            PctBxnewchat.Width = 50;
            PctBxnewchat.Height = 50;
            PctBxnewchat.Location = new Point(530,30);
            PctBxnewchat.Click+=new EventHandler(PctBxnewchat_click);
            PctBxnewchat.BorderStyle = BorderStyle.Fixed3D;
            panel3.Controls.Add(PctBxnewchat);
            pnl_Chats.BorderStyle = BorderStyle.FixedSingle;
            string binpath= @"C:\Users\YUSUF\donem-projesi-YusufGeyik\bin.jpg";
            PictureBox Pctbin=new PictureBox();
            Pctbin.Image = Image.FromFile(binpath);
            Pctbin.SizeMode = PictureBoxSizeMode.StretchImage;
            Pctbin.Location = new Point(550,300); 
            Pctbin.Width = 50;
            Pctbin.Height = 50;
            Pctbin.Click += new EventHandler(Pctbin_click);
            this.Controls.Add(Pctbin);
            this.Controls.Add(pnl_Chats);
          
            functions.CreateExistedContacts(pnl_Chats, aktifchatsayisi,Clientname);



            TcpClient listenersocket = functions.listener[ClientName];


            Task.Run(() => HandleClient(listenersocket, ClientName));
        }




        public static void CreateFileWatchers(string path, TextBox textbox, FlowLayoutPanel panel)
        {

            if (!textboxfilewatcher.ContainsKey(path))
            {

                FileSystemWatcher fileWatcher = new FileSystemWatcher(Path.GetDirectoryName(path), Path.GetFileName(path));
                fileWatcher.NotifyFilter = NotifyFilters.LastWrite;
                fileWatcher.Changed += (s, e) =>
                {

                    textbox.Text=File.ReadAllText(path);
                    //  if (ChatPanel.TalkyDictionary.ContainsKey(path))
                    //{
                    //  TalkySc talky = ChatPanel.TalkyDictionary[path];
                    //TextBox messages = talky.messages;
                    // Thread thread2 = new Thread(() => Update(messages, path, panel, TagID));
                    // thread2.Start();

                    //}


                };
                fileWatcher.EnableRaisingEvents = true;

                textboxfilewatcher.Add(path, fileWatcher);
            }
        }


        private async void PctBxnewchat_click(object sender, EventArgs e)
        {

            if (txtbTargetID.Visible == false)
            {
                txtbxID.Visible = true;
                txtbxInfo.Visible = true;
                txtbTargetID.Visible = true;
                btStartChat.Visible = true;

            }
            else
            {

                txtbxID.Visible = false;
                txtbxInfo.Visible = false;
                txtbTargetID.Visible = false;
                btStartChat.Visible = false;

            }


           


        }




       
       

        private async void HandleClient(TcpClient listenersocket,string ClientName)
        {
            
            NetworkStream stream = listenersocket.GetStream();
            byte[] data = new byte[1024];
            string response;
            string func;
            string[] arrresponse;
            string arguments;
            string messagefromserver;
          

                while (true)
                {
                    int bytesRead=await stream.ReadAsync(data, 0, data.Length);
                    string message=Encoding.UTF8.GetString(data);
               
                    string[] arrdatafromserver = message.Split('$');
                    arrresponse= arrdatafromserver[0].Split(',');
                    response= arrresponse[1];
                    func = arrresponse[0];
                    arguments = arrdatafromserver[1];
                    messagefromserver = arrdatafromserver[2];

                try
                {
                    if (func == "startachat")
                    {
                        if (response == "true")
                        {
                            int ChatID = Convert.ToInt32(messagefromserver);

                            string documents = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);//mydocuments
                            string talkysc = Path.Combine(documents, "TalkySC");
                            string userdirectory = Path.Combine(talkysc, ClientName);
                            string name = arguments;
                            string nameID = $"{name} {ChatID}.txt";

                            string chatIDpath = Path.Combine(userdirectory, nameID);


                            CreateFileWatchers(chatIDpath, textBox3, pnl_Chats);


                            pnl_Chats.Invoke((MethodInvoker)delegate
                            {

                                

                                ChatPanel newchat = new ChatPanel(ChatID, arguments, pnl_Chats, aktifchatsayisi, "", ClientName);

                            });
                        }//if biter

                        else if (response == "false")
                        {


                            MessageBox.Show("Usernameleri kontorl edin");



                        }//else if biter


                    }//request biter
                }
                catch(Exception e)
                {


                    MessageBox.Show($"Error: {e.Message}  {"client"}"); 

                }
                try
                {
                    if (func == "sendmessage")
                    {

                        string[] idandmessage = messagefromserver.Split('|');
                        int ChatID = Convert.ToInt32(idandmessage[0]);

                        string incomingmessage = idandmessage[1];

                        string documents = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);//mydocuments
                        string talkysc = Path.Combine(documents, "TalkySC");
                        string userdirectory = Path.Combine(talkysc, ClientName);
                        string name = arguments;
                        string nameID = $"{name} {ChatID}.txt";
                        
                        string path = Path.Combine(userdirectory, nameID);

                        object fileLock = Locks.GetFileLock(path);
                        lock (fileLock)
                        {
                            using (StreamWriter writer = new StreamWriter(path, true))
                            {
                                writer.WriteLine(incomingmessage);
                                writer.WriteLine();
                                writer.Close();
                            }
                            //  File.AppendAllLines(path, incomingmessage );
                            textBox3.Text += incomingmessage+"\n";

                        }
                        Thread t = new Thread(() => functions.ChatDividerUpdate(ChatID, pnl_Chats, path));
                        t.Start();
                        
                        if (ChatPanel.TalkyDictionary.ContainsKey(path))
                       {
                            //MessageBox.Show("Güncelleme yapmam gerek");
                           
                                TalkySc talky = ChatPanel.TalkyDictionary[path];

                                TextBox messages = talky.messages;
                                messages.Text += "\n";
                                messages.Text +=incomingmessage;
                            
                            //Thread t1 = new Thread(() => functions.Update(messages, path, pnl_Chats, ChatID));
                           // functions.Update(messages, path, pnl_Chats, ChatID);
                       }


                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }







                   if(func == "logout")
                    {






                    }





                }


         





        }

        public static async void sendmessage(string contactname,int ChatID,string message)
        {
           


               
            


        }
        private void btExit_Click(object sender, EventArgs e)
        {
            functions.listener[ClientName].Close();
            functions.sender[ClientName].Close();
            Application.Exit();

        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            Move = 0;
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            Move = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (Move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }

        private void Start_Chat(object sender, EventArgs e)
        {
            //socket send yap gelen idyle chatdivider oluştur.
            // ChatPanel TagID = new ChatPanel(TagID,Contactname, pnl_Chats, aktifchatsayisi," ");
            
            txtbxID.Visible = false;
            txtbxInfo.Visible = false;
            txtbTargetID.Visible = false;
            btStartChat.Visible = false;
        }

        private void Pctbin_click(object sender, EventArgs e)
        {
            List<Panel> panelsToRemove = new List<Panel>();
            foreach (Panel panel in pnl_Chats.Controls.OfType<Panel>())
            {
                CheckBox checkBox = panel.Controls.OfType<CheckBox>().FirstOrDefault();
                if (checkBox != null && checkBox.Checked)
                {
                    panelsToRemove.Add(panel);
                }
            }

            foreach (Panel panel in panelsToRemove)
            {
                pnl_Chats.Controls.Remove(panel);
            }
        }

       



       




        private void Anasayfa_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            
        }



      

        void CreateFileWatchers(List<string> filePaths,int TagID,FlowLayoutPanel panel)
        {
            foreach (string filePath in filePaths)
            {
                FileSystemWatcher fileWatcher = new FileSystemWatcher(Path.GetDirectoryName(filePath), Path.GetFileName(filePath));
                fileWatcher.NotifyFilter = NotifyFilters.LastWrite;
                fileWatcher.Changed += (s, e) =>
                {
                   functions.ChatDividerUpdate(TagID, panel,filePath);


                };
                fileWatcher.EnableRaisingEvents = true;

                fileWatchers.Add(fileWatcher);
            }
        }

        private async void btStartChat_Click(object sender, EventArgs e)
        {
            byte[] byteresponse;
            bool count = true;
            string arguments = txtbTargetID.Text;
            string response = "";
            try {
                //lock (Locks.senderlock)
                //  {



                // TcpClient tcpClient = Sendersocket;


                // NetworkStream stream = functions.sender[ClientName];
                // StreamWriter writer = new StreamWriter(stream, Encoding.UTF8);
                // StreamWriter streamwriter = new StreamWriter(stream,Encoding.UTF8);

                //NetworkStream stream = Sendersocket.GetStream();

                TcpClient tcpClient = functions.sender[ClientName];
               
               
                NetworkStream stream1 = tcpClient.GetStream();
                byte[] startchatbyte = Encoding.UTF8.GetBytes("startachat$" + ClientName + "," + arguments + "$" + ClientName);
                

                await stream1.WriteAsync(startchatbyte, 0, startchatbyte.Length);
                


            

        }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void Anasayfa_Shown(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
