using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace WindowsFormsApp1
{
    public class functions
    {
        public static Dictionary<string, FileSystemWatcher> fileWatchers = new Dictionary<string, FileSystemWatcher>();
        public static Dictionary<string,TcpClient> listener=new Dictionary<string,TcpClient>();
        public static Dictionary<string,TcpClient>sender=new Dictionary<string,TcpClient>();
        public static Dictionary<int,string>ClientName=new Dictionary<int,string>();

        public static void CreateFileWatchers(string path, int TagID, FlowLayoutPanel panel)
        {
            
            if (!fileWatchers.ContainsKey(path))
            {

                FileSystemWatcher fileWatcher = new FileSystemWatcher(Path.GetDirectoryName(path), Path.GetFileName(path));
                fileWatcher.NotifyFilter = NotifyFilters.LastWrite;
                fileWatcher.Changed += (s, e) =>
                {


                    Thread thread1 = new Thread(() => ChatDividerUpdate(TagID, panel, path));
                    thread1.Start();
                    
                  //  if (ChatPanel.TalkyDictionary.ContainsKey(path))
                    //{
                      //  TalkySc talky = ChatPanel.TalkyDictionary[path];
                        //TextBox messages = talky.messages;
                       // Thread thread2 = new Thread(() => Update(messages, path, panel, TagID));
                       // thread2.Start();
                        
                    //}


                };
                fileWatcher.EnableRaisingEvents = true;

                fileWatchers.Add(path, fileWatcher);
            }
        }


        public static async void ChatDividerUpdate(int tagID, FlowLayoutPanel pnl_Chats, string path)
        {
            string lastMessage = "";
            
            //  string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), tagID + ".txt");

            object fileLock = Locks.GetFileLock(path);
            lock (fileLock)
            {
                string history = File.ReadAllText(path);
                string[] logs = history.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                if (logs.Length > 0)
                {
                    Array.Reverse(logs);
                    lastMessage = logs[0];

                }
            }


            // txt file dosyasını bulup açan ve sonuna gelen son mesajı ekleyen bir fonksiyon yaz
            foreach (Control control in pnl_Chats.Controls)
            {
                if (control is Panel && Convert.ToUInt32(control.Tag) == tagID)
                {
                    foreach (Control innercontrol in control.Controls)
                    {
                        if (innercontrol is Label && Convert.ToInt32(innercontrol.Tag) == tagID)
                        {
                            try
                            {
                                //string history = File.ReadAllText(path);
                                //string[] arrhistory = history.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                                //if (arrhistory != null)
                                // {
                                innercontrol.Text = lastMessage;

                                // }

                                break;
                            }
                            catch (Exception exception)
                            {

                                MessageBox.Show("Loglar getirilemiyor");

                            }


                            /*kodda kullanırken serverden gelince 
                            tag id ve mesaj gelecek
                            Messagepanelupdate(tagID, "Yusuf");*/

                        }


                    }
                }

            }


        }



        public static async void Bringlogs(TextBox textbx, string path)
        {
           
            object fileLock = Locks.GetFileLock(path);
            lock (fileLock)
            {

                try
                {
                    string[] logs = File.ReadAllLines(path);
                    foreach (string log in logs)
                    {


                        textbx.AppendText(" " + log);
                        textbx.AppendText(Environment.NewLine);




                    }
                }
                catch (Exception e)
                {

                    MessageBox.Show(e.Message);

                }

            }
        }


        static public async void Update(TextBox textbox, string path, FlowLayoutPanel panel, int TagID)
        {



            TalkySc talky = ChatPanel.TalkyDictionary[path];
            


            string Chathistory = "";



            object fileLock = Locks.GetFileLock(path);
            lock (fileLock)
            {

                try
                {

                    Chathistory = File.ReadAllText(path);
                    
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Error");

                }

            }



            if (talky.messages.IsHandleCreated)                   // d gerekte nasıl olcak? kaç tane fonksiyonla atlatıyoruz herbirine mi thread atacam ben
            {
                
                talky.messages.Text = "";
               

                    string content = File.ReadAllText(path);
                    talky.messages.Invoke((MethodInvoker)(() => textbox.Text = content));
                

                 

            }
            else
            {

            }


        }

        public static async void CreateExistedContacts (FlowLayoutPanel panel,int aktifchatsayisi,string Clientname)
          {
           
            string lastmessage = "";
            string documents = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);//mydocuments
            string talkysc = Path.Combine(documents, "TalkySC");
            string path = Path.Combine(talkysc, Clientname);
           
          
         
            if (Directory.Exists(path))
            {
                string[] txtfiles = Directory.GetFiles(path, "*.txt");


                foreach (string file in txtfiles) 
                {
                    string[] pathparts=Path.GetFileNameWithoutExtension(file).Split(' ');
                    string name = pathparts[0]; 
                    int tagID = Convert.ToInt32(pathparts[1]);
                    string history = File.ReadAllText(file);
                    string[] logs = history.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    if(logs.Length > 0)
                    {
                        logs.Reverse();
                        lastmessage = logs[0];
                    }
                    ChatPanel chat = new ChatPanel(tagID,name,panel,aktifchatsayisi,lastmessage,Clientname);


                }



            }

            else
            {
                Directory.CreateDirectory(path);

            }

        }


    }



}
