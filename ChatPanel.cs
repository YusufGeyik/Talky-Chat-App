using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    

    public class ChatPanel
    {
        
       public static Dictionary<string, TalkySc> TalkyDictionary = new Dictionary<string, TalkySc>();


        private Action<int, string, int> invokeChatPanelMethod;

        private Panel chatdivider;
        private Label labelMessage;
        private Label labelContactName;
        private PictureBox johnsmith;
        private PictureBox pctbin;
        private CheckBox chckbxSil;
        private int TagID;
        private string contactname;
        private FlowLayoutPanel parentPanel;
        private string lastMessage;
        private string chatIDpath;

        public ChatPanel(int tagID, String contactname, FlowLayoutPanel parentPanel, int aktifchatsayisi, string lastMessage,string Clientname)
        {
           
                // ChatPanel TagID = new ChatPanel(TagID,contactname,pnl_Chats,aktifchatsayisi,lastMessage);

                this.TagID = tagID;
            this.contactname = contactname;
            this.parentPanel = parentPanel;
            this.lastMessage = lastMessage;

            Panel chatdivider = new Panel();// her chat için bir panel oluştur.
            chatdivider.Location = new Point(0, 55 * aktifchatsayisi);
            chatdivider.Height = 50;
            chatdivider.Width = 580;
            chatdivider.Padding = new System.Windows.Forms.Padding(1);
            chatdivider.BorderStyle = BorderStyle.Fixed3D;
            chatdivider.Tag = tagID;//değişkenle atanacak
            chatdivider.Click += (sender, e) => chatdivider_click(Clientname);
           // chatdivider.Click += new EventHandler(chatdivider_click);
           chatdivider.Name=tagID.ToString();
            // chatdivider.Name = aktifchatsayisi.ToString();




            Label LabelMessage = new Label();//Mesaj Labelini oluştur.
            LabelMessage.Text = lastMessage;
            LabelMessage.Location = new Point(50, 20);
            LabelMessage.Font = new Font("Microsoft Sans Serif", 10);
            LabelMessage.Width = 3;
            LabelMessage.Height = 30;
            LabelMessage.AutoSize = true;
            LabelMessage.Tag = tagID;
            chatdivider.Controls.Add(LabelMessage);  //labelı ilgili panele ekle
            LabelMessage.Name = tagID.ToString();
            //LabelMessage.Name = aktifchatsayisi.ToString();



            Label LabelContactName = new Label();//kişi ismi için label oluştur.
            LabelContactName.Text = contactname;  // kişi ismi değişkenle atanacak****.
           //LabelContactName.AutoSize = true;
             LabelContactName.Width = 500;
            LabelContactName.Height = 20;
            LabelContactName.Location = new Point(50, 0);
            LabelContactName.Font = new Font("Microsoft Sans Serif", 8);
            LabelContactName.Tag = tagID;
            chatdivider.Controls.Add(LabelContactName);
           LabelContactName.Name = tagID.ToString();
            // LabelContactName.Name = aktifchatsayisi.ToString();



            string johnsmithPath = @"C:\Users\YUSUF\donem-projesi-YusufGeyik\blue.png"; // standart icon ekleme
            PictureBox johnsmith = new PictureBox();
            johnsmith.Image = Image.FromFile(johnsmithPath);
            johnsmith.SizeMode = PictureBoxSizeMode.StretchImage;
            johnsmith.Width = 40;
            johnsmith.Height = 40;
            johnsmith.Location = new Point(0, 0);
            johnsmith.Tag = tagID;
            chatdivider.Controls.Add(johnsmith);

            //johnsmith.Name = aktifchatsayisi.ToString();

            CheckBox chckbxSil = new CheckBox();
            chckbxSil.Location = new Point(450, 20);
            chckbxSil.Tag = tagID;
            chatdivider.Controls.Add(chckbxSil);



            parentPanel.Controls.Add(chatdivider);

            
            int ChatID = tagID;
            string documents = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);//mydocuments
            string talkysc = Path.Combine(documents, "TalkySC");
            string userdirectory = Path.Combine(talkysc, Clientname);
            string name = contactname;
            string nameID = $"{name} {TagID}.txt";

            string chatIDpath = Path.Combine(userdirectory, nameID);

            
        

            if (File.Exists(chatIDpath))
            {
              
            }
            else
            {
                try
                {
                    File.Create(chatIDpath).Close();
                    
                   // using (StreamWriter sw = File.AppendText(chatIDpath))
                 //   {
                   //     sw.WriteLine(lastMessage);
                  //  }

                  


                }
                catch(Exception e)
                { 
                 
                }
                

               
                 
            }
           Thread thread1 = new Thread(() => functions.CreateFileWatchers(chatIDpath, TagID, parentPanel));
           thread1.Start();
           

            ////////////////////////////////////
          
                // Invoke ile yapılması gereken işlemler burada yer alır
              
                // Diğer kontrollerin oluşturulması ve eklenmesi...
            

        }
        public ChatPanel()
        {
            

        


        }
        private void chatdivider_click(string Clientname)
        {
            string documents = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);///mydocuments
            string talkysc = Path.Combine(documents, "TalkySC");
            string userpath = Path.Combine(talkysc, Clientname);
            string name = contactname; 
            string nameID=$"{name} {TagID}.txt";

            string path = Path.Combine (userpath,nameID);

            if (!TalkyDictionary.ContainsKey(path))
            {

                TalkySc talky = new TalkySc(contactname, TagID, path, parentPanel,Clientname); // bir tanede dosya ismi ver txt için gerekli parametreler mesaj alınıyorsa serverdan, mesaj başlatılıyorsa internal olarak alınacak.
                TalkyDictionary.Add(path, talky);
                talky.Show();

            }
            else if (TalkyDictionary.ContainsKey(path))
            {
                TalkySc talky = TalkyDictionary[path]; 
                talky.Show();

            }
        }


    }





}
    
    
