using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btRegister_Click(object sender, EventArgs e)
        {  TcpClient inclient= new TcpClient();

           
            IPAddress IP = IPAddress.Parse("127.0.0.1");
            try
            {

                string ipclient = Iptxtbx.Text;
                int port=Convert.ToInt32(Porttxtbx.Text);
                string Username=txtbxID.Text;
                string pass=txtbxpass.Text;
                string answer = "";
             
                // şifreler birbiriyle uyuşuyor mu kontrol et
                //Bir soket oluşturup register komutu yolla 
                //benzer id yoksa sana true dönecek kayıt gerçekleşmiş olacak.


                if (txtbxpass.Text == txtbxpass2.Text && txtbxID != null && Iptxtbx!=null && Porttxtbx!=null )
                {

                    TcpClient outclient = new TcpClient();
                    await outclient.ConnectAsync(IP, 10000);
                    NetworkStream stream = outclient.GetStream();
                    byte[] data = Encoding.UTF8.GetBytes("register$" + Username + "," + pass + ("$") + ipclient + "," + port);
                    await stream.WriteAsync(data, 0, data.Length);
                    
                    
                    

                    bool count = true;



                    TcpListener listener = new TcpListener(IP, port);
                    listener.Start();

                    while (true)
                    {
                        inclient = await listener.AcceptTcpClientAsync();
                       
                        NetworkStream instream = inclient.GetStream();
                        byte[] inmessage = new byte[1024];
                        int bytesRead;
                        bytesRead = await instream.ReadAsync(inmessage, 0, inmessage.Length);

                        answer = Encoding.UTF8.GetString(inmessage, 0, bytesRead);
                      

                        



                        break; // Döngüyü sonlandır
                    }
                    listener.Stop();
                    outclient.Dispose();
                    inclient.Dispose();
                    if (answer == "true")
                    {

                        MessageBox.Show(Username + "   Kayıt tamamlandı. Giriş yapabilirsiniz.");
                        Login login = new Login();
                        login.Show();
                        this.Close();



                    }

                    else if (answer == "false")
                    {

                        MessageBox.Show("Bu kullanıcı adı kullanımda");

                    }
                }
                else if(txtbxpass!=txtbxpass2)
                {
                    MessageBox.Show("Şifreler uyuşmuyor");
                }
                else
                {
                    MessageBox.Show("Bütün alanları doldurduğunuzdan emin olun");
                }
                

            }
            catch (Exception ex)
            {


                MessageBox.Show(ex.Message);

                                
            }
           
        }

            
        
       
    }
}
