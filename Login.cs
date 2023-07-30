using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Net;

namespace WindowsFormsApp1
{ 
    public partial class Login : Form
    {
        TcpClient inclient=new TcpClient();
        IPAddress serverIP = IPAddress.Parse("127.0.0.1");
        TcpClient outclient = new TcpClient();
        public string ClientUser = "";
        public Login()
        {
            InitializeComponent();
           

        }

        private async void btLogin_Click(object sender, EventArgs e)
        {
            string answer = "";
            string enteredusername = txtbxID.Text;
            string enteredpass = txtbxPass.Text;
            string ip = iptxtbx.Text;
            string port = txtbxport.Text;
            int intport = Convert.ToInt32(port);
            string ipandport = ip + "," + port;

            if (enteredusername != "" && enteredpass != "" && ip != "" && port != "")
            {
                 outclient = new TcpClient();
                await outclient.ConnectAsync(serverIP, 10000);

                NetworkStream outsream = outclient.GetStream();
                byte[] outmessage = Encoding.UTF8.GetBytes("login$" + enteredusername + "," + enteredpass + "$" + ipandport + "$");
                if (!functions.sender.ContainsKey(enteredusername))
                {
                    
                    functions.sender.Add(enteredusername, outclient);
                }
                await outsream.WriteAsync(outmessage, 0, outmessage.Length);

                   //


                TcpListener listener = new TcpListener(IPAddress.Any, intport);
                listener.Start();

                while (true)
                {
                    inclient = await listener.AcceptTcpClientAsync();
                    NetworkStream instream = inclient.GetStream();
                    byte[] inmessage = new byte[1024];
                    int bytesRead;
                    bytesRead = await instream.ReadAsync(inmessage, 0, inmessage.Length);
                    
                         answer = Encoding.UTF8.GetString(inmessage, 0, bytesRead);
                        
                    
                       //



                    break; // Döngüyü sonlandır
                }

                
                if (answer == "true")
                {
                    if (!functions.listener.ContainsKey(enteredusername))
                    {
                        functions.listener.Add(enteredusername, inclient);
                    }

                    ClientUser = enteredusername;
                    ;

                 
                    Anasayfa anasayfa = new Anasayfa(enteredusername);
                    anasayfa.Show();
                    this.Hide();
                }
                else if (answer == "false")
                {
                    MessageBox.Show("Hatalı şifre veya kullanıcı adı");
                    outclient.Close();
                    inclient.Close();   

                }
                else
                {
                    MessageBox.Show("Başka bir hata gerçekleşti");
                }
            }
            else
            {
                MessageBox.Show("Bütün alanları doldurun");
            }

        }












            /* bool count = true;
             string answer = "";
             string enteredusername = txtbxID.Text;
             string enteredpass = txtbxPass.Text;
             string ip = iptxtbx.Text;
             string port=txtbxport.Text;
             int intport=Convert.ToInt32(port);
             string ipandport = ip + "," + port;
             MessageBox.Show(ipandport);
             if (enteredusername != "" && enteredpass != "" && ip != "" && port!="")
             {
                 try
                 {





                     NetworkStream networksream = sendersocket.GetStream();
                     StreamWriter streamwriter = new StreamWriter(networksream);
                     functions.sender.Add(enteredusername, networksream);


                     streamwriter.WriteLine("login$" + enteredusername + "," + enteredpass + "$"+ipandport+"$");
                     streamwriter.Flush();

                     TcpListener listener = new TcpListener(IPAddress.Any, intport);
                     listener.Start();

                     while (count)
                     {
                        listenersocket = listener.AcceptTcpClient();

                         StreamReader reader = new StreamReader(listenersocket.GetStream(), Encoding.UTF8);

                         answer = reader.ReadLine();

                         count = false;

                        functions.listener.Add(enteredusername, listenersocket.GetStream());


                     }
                     //listener.Stop();

                     if (answer == "true")
                     {
                         ClientUser = enteredusername;
                         Anasayfa anasayfa = new Anasayfa(ClientUser,listenersocket,sendersocket); // login yapan kullanıcı adı almak gerekir mi?
                         anasayfa.Show();
                         this.Hide();



                     }

                     else if (answer == "false")
                     {
                         MessageBox.Show("Hatalı şifre veya kullanıcı adı");


                     }

                     else
                     {
                         MessageBox.Show("Başka bir hata gerçekleşti");

                     }

                 }
                 catch (Exception ex)
                 {

                 }
             }
             else
             {
                 MessageBox.Show("Bütün alanları doldurun");
             }
            */
        

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
           
            
        }

        private void Login_Load(object sender, EventArgs e)
        {
            //Control.CheckForIllegalCrossThreadCalls = false;
           
           
            
        }
    }
}
