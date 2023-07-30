using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Net;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.CompilerServices;
using System.Linq.Expressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Runtime.Remoting.Messaging;

namespace WindowsFormsApp1
{

    public partial class serverapp : Form
    {
        public static object listenerlock=new object();
        public static object senderlocklock=new object();
       public TcpListener server;
       public List<TcpClient> clients;
        public Dictionary<string, TcpClient> instreamclientsDictionary;
        public Dictionary<string, TcpClient> outstreamclientsDictionary;
        private static object databaselock = new object();

        //  TcpListener serversocket = new TcpListener(IPAddress.Any,10000);


        //  TcpClient clientsocket = default(TcpClient);


        static Dictionary<int,string> chats = new Dictionary<int,string>();
        public serverapp()
        {
            InitializeComponent();
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                Exception ex = e.ExceptionObject as Exception;
                // Hata durumunda yapılması gereken işlemler burada yer alır
                Console.WriteLine("Beklenmedik bir hata oluştu: " + ex.Message);
            };


           outstreamclientsDictionary = new Dictionary<string, TcpClient>();
            instreamclientsDictionary = new Dictionary<String,TcpClient>();
            




        }



        private async void HandleClient(TcpClient client, TextBox serverlogs)
        {
          
            TcpClient inclient = new TcpClient();
            TcpClient outclient = new TcpClient();
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            string username = string.Empty;
            string request = string.Empty;
            string arguments = string.Empty;
            string messagefromclient = string.Empty;
            serverlogs.Text += Environment.NewLine + "Yeni bir istemci ile bağlantı kuruldu";
            try
            {

                while (true)
                {
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    string[] arrdatafromclient = message.Split('$');
                    request = arrdatafromclient[0];
                    arguments = arrdatafromclient[1];
                    messagefromclient = arrdatafromclient[2];

                    serverlogs.Text += Environment.NewLine + "Bir " + request + " isteği alındı";


                    if (request == "login")
                    {
                        string[] idandpass = arguments.Split(',');
                        string enteredUsername = idandpass[0];
                        string enteredPassword = idandpass[1];

                        string[] ipandport = messagefromclient.Split(',');
                        string ip = ipandport[0];
                        int port = Convert.ToInt32(ipandport[1]);
                        bool isAuthenticated = false;

                        lock (databaselock)
                        {

                            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-ONDVNQK\SQLEXPRESS;Initial Catalog=talkyydb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
                            {
                                connection.Open();
                                string selectQuery = "SELECT COUNT(*) FROM UserTable WHERE Username = @enteredUsername AND Userpass = @enteredPassword";
                                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                                {
                                    command.Parameters.AddWithValue("@enteredUsername", enteredUsername);
                                    command.Parameters.AddWithValue("@enteredPassword", enteredPassword);

                                    int count = (int)command.ExecuteScalar();
                                    if (count > 0)
                                    {

                                        isAuthenticated = true;


                                    }//count>0 biter
                                    else
                                    {

                                        isAuthenticated = false;


                                    }//count else


                                }//login sqlcommand biter




                            }//login connection using biter




                        }//login database lock biter


                        if (isAuthenticated)
                        {
                            if (!instreamclientsDictionary.ContainsKey(enteredUsername))
                            {
                                instreamclientsDictionary.Add(enteredUsername, client);
                            }

                            outclient = new TcpClient();
                            await outclient.ConnectAsync(ip, port);
                            NetworkStream outsream = outclient.GetStream();
                            byte[] outmessage = Encoding.UTF8.GetBytes("true");

                            if (!outstreamclientsDictionary.ContainsKey(enteredUsername))
                            {
                                outstreamclientsDictionary.Add(enteredUsername, outclient);
                            }
                            await outsream.WriteAsync(outmessage, 0, outmessage.Length);
                            serverlogs.Text += enteredUsername + " logged in";









                        }//if true biter
                        else
                        {


                            outclient = new TcpClient();
                            await outclient.ConnectAsync(ip, port);
                            NetworkStream outsream = outclient.GetStream();
                            byte[] outmessage = Encoding.UTF8.GetBytes("false");
                            await outsream.WriteAsync(outmessage, 0, outmessage.Length);
                        
                            client.Close();
                            outclient.Close();
                            serverlogs.Text += Environment.NewLine + enteredUsername + " failed to login";


                        }//else biter





                    }//login request biterr
                    if (request == "register")
                    {
                        try
                        {
                            string[] rusernameandpass = arguments.Split(',');
                            string rusern = rusernameandpass[0];
                            string rpassw = rusernameandpass[1];
                            string risavailable = "false";
                            string[] ripandport = messagefromclient.Split(',');
                            string rip = ripandport[0];
                            int rport = Convert.ToInt32(ripandport[1]);

                            lock(databaselock)
                            {


                                string insertQuery = "INSERT INTO Usertable (Username,Userpass) VALUES (@newUsername,@password)";
                                string connectionString = @"Data Source=DESKTOP-ONDVNQK\SQLEXPRESS;Initial Catalog=talkyydb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                                string selectQuery = "SELECT * FROM Usertable WHERE Username = @newUsername";
                                using (SqlConnection connection = new SqlConnection(connectionString))
                                {
                                    connection.Open();
                                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("newUsername", rusernameandpass[0]);
                                        using (SqlDataReader reader = command.ExecuteReader())
                                        {
                                            if(reader.HasRows)
                                            {
                                                risavailable = "false";


                                            }//if biter 
                                            else
                                            {

                                                risavailable = "true";


                                            }//else biter




                                        }//register reader using biter




                                    }//register command using biter


                                    if(risavailable == "true") 
                                    {

                                        using (SqlCommand insertcommand = new SqlCommand(insertQuery, connection))
                                        {
                                            insertcommand.Parameters.AddWithValue("newUsername", rusern);
                                            insertcommand.Parameters.AddWithValue("password", rpassw);
                                            insertcommand.ExecuteNonQuery();
                                            risavailable = "true";



                                        }//insert command biter

                                        serverlogs.Text += Environment.NewLine + rusern + " kaydedildi";


                                    }//isavailable if biter

                                    else if(risavailable == "false") 
                                    {


                                        serverlogs.Text += Environment.NewLine + rusern + " kayıt başarısız";




                                    }//else biter
                                    






                                }//register connection using biter





                            }//register databaselock biter


                            TcpClient outclient1 = new TcpClient();

                            await outclient1.ConnectAsync(rip, rport);
                            NetworkStream ns = outclient1.GetStream();
                            byte[] outmessage = Encoding.UTF8.GetBytes(risavailable);
                            await ns.WriteAsync(outmessage, 0, outmessage.Length);
                            outclient1.Close();
                            client.Close();



                        } catch(Exception e) //register try biter
                        {
                        
                        
                        
                        }//register catch biter


                    }//request register biter




                    if (request == "sendmessage")
                    {


                        serverlogs.Text += " sendmessage girdi";
                        string[] sparticipants = arguments.Split(',');




                        string[] data = messagefromclient.Split(',');



                        string clientmessage = data[1];

                        string[] Clientnameandmessage = clientmessage.Split(':');
                        string Clientname = Clientnameandmessage[0];
                        int ChatID = Convert.ToInt32(data[0]);
                       
                        // sendmessage$Yusuf,Yakup$ChatID,Yusuf:lorem ipsum     
                        // gelen data

                        //sendmessage$Yusuf,Yakup$ChatID|Yusuf:Lorem Ipsum
                        //giden data

                       
                        lock (databaselock)
                        {
                            string connectionstring = @"Data Source=DESKTOP-ONDVNQK\SQLEXPRESS;Initial Catalog=talkyydb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                            

                            // SQL sorgusu - Satırı bulmak için ChatID'ye göre filtreleme yapılıyor
                            string selectQuery = "SELECT ChatHistory FROM Chatstable WHERE ChatID = @ChatID";

                            // SQL sorgusu - Güncelleme yapmak için ChatHistory alanını güncelle
                            string updateQuery ="UPDATE Chatstable SET ChatHistory = @ChatHistory WHERE ChatID = @ChatID";



                            using (SqlConnection connection = new SqlConnection(connectionstring))
                            {
                                connection.Open();
                                
                                SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
                                selectCommand.Parameters.AddWithValue("@ChatID", ChatID);
                                string existingChatHistory = selectCommand.ExecuteScalar()?.ToString();

                               // if (!string.IsNullOrEmpty(existingChatHistory))
                              //  {

                                    string updatedChatHistory = existingChatHistory + clientmessage + ","; // Güncellenmiş chat history

                                    SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                                    updateCommand.Parameters.AddWithValue("@ChatHistory", updatedChatHistory);
                                    updateCommand.Parameters.AddWithValue("@ChatID", ChatID);
                                    updateCommand.ExecuteNonQuery();

                                   



                              //  }//if biter

                                connection.Close();
                               
                            }//connection biter
                             ///////////
                            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-ONDVNQK\SQLEXPRESS;Initial Catalog=talkyydb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
                            {
                                connection.Open();

                                string deleteQuery = "DELETE FROM Chatstable WHERE Username IN (SELECT Username FROM Chatstable GROUP BY Username HAVING COUNT(*) > 1) AND ChatHistory = ''";

                                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                                {
                                    command.ExecuteNonQuery();
                                }
                            }




                        }// lock biter

                        serverlogs.Text += Environment.NewLine + Clientnameandmessage + "==>" + arguments + ChatID;

                        foreach (string s in sparticipants)
                        {
                            if (outstreamclientsDictionary.ContainsKey(s))
                            {

                                TcpClient tcp = outstreamclientsDictionary[s];
                                if (tcp.Connected)
                                {

                                    NetworkStream sns = tcp.GetStream();
                                    byte[] bytedata = new byte[1024];
                                    bytedata = Encoding.UTF8.GetBytes("sendmessage,true$" + arguments + "$" + ChatID + "|" + clientmessage);
                                    await sns.WriteAsync(bytedata, 0, bytedata.Length);
                                  


                                }//if connected biter
                                else
                                {

                                  


                                }


                            }//if biter




                        }//sendmessageforeach biter









                    }//request sendmessage biter




                    if (request == "startachat")
                    {
                       

                        string[] participants = arguments.Split((','));
                      


                        int ChatID = 0;
                        string control = "false";
                        try
                        {


                            lock (databaselock)
                            {




                                using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-ONDVNQK\SQLEXPRESS;Initial Catalog=talkyydb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
                                {
                                    connection.Open();


                                    string insertQuery1 = "INSERT INTO Chatstable (Username,ChatHistory) VALUES (@newUsername,@chathistory); SELECT SCOPE_IDENTITY();";
                                    string controlquery = "SELECT COUNT(*) FROM Usertable WHERE Username = @username";
                                    string selectIdentityQuery = "SELECT SCOPE_IDENTITY()";
                                    string insertQuery = "INSERT INTO Chatstable (Username) VALUES (@newUsername)";

                                    foreach (string participant in participants)
                                    {

                                        using (SqlCommand command = new SqlCommand(controlquery, connection))
                                        {

                                            command.Parameters.AddWithValue("@username", participant);
                                            int count = (int)command.ExecuteScalar();
                                            if (count == 0)
                                            {
                                                serverlogs.Text += Environment.NewLine + " chat başlatma isteği reddedildi: Yanlış kullanıcı ismi";


                                                control = "false";
                                                break;

                                            }// if biter

                                            else
                                            {

                                                control = "true";
                                            }//else biter



                                        }//command biter








                                    }//foreach biter

                                    if (control == "true")
                                    {



                                        using (SqlCommand command1 = new SqlCommand(insertQuery1, connection)) //1
                                        {


                                            command1.Parameters.AddWithValue("@newUsername", arguments);
                                            command1.Parameters.AddWithValue("@chathistory", "");
                                            command1.ExecuteNonQuery();
                                            MessageBox.Show("ekledi");

                                            //command1.CommandText = selectIdentityQuery;
                                            if (command1.ExecuteScalar() != null)
                                            {
                                                ChatID = Convert.ToInt32(command1.ExecuteScalar());
                                            }






                                        }//insertquery biter




                                    }//if biter



                                }//connection biter





                            }//databaselock biter

                            if (control == "true")
                            {


                                foreach (string participant in participants)
                                {
                                    if (outstreamclientsDictionary.ContainsKey(participant) && outstreamclientsDictionary[participant].Connected)
                                    {

                                        TcpClient outclient1 = outstreamclientsDictionary[participant];
                                        NetworkStream networkStream1 = outclient1.GetStream();
                                        byte[] startchatbyte = Encoding.UTF8.GetBytes("startachat," + control + "$" + arguments + "$" + ChatID.ToString());
                                        await networkStream1.WriteAsync(startchatbyte, 0, startchatbyte.Length);
                                        
                                       
                                    }



                                }
                                serverlogs.Text += Environment.NewLine + " chat başlatma isteği kabul edildi." + arguments + " " + ChatID + "  chat odası oluşturuldu";


                            }//control true biter


                            else if (control == "false")
                            {
                                if (outstreamclientsDictionary.ContainsKey(participants[0]) && outstreamclientsDictionary[participants[0]].Connected)
                                {
                                    TcpClient outclient1 = outstreamclientsDictionary[participants[0]];
                                    NetworkStream networkStream2 = outclient1.GetStream();
                                    byte[] startchatbyte = Encoding.UTF8.GetBytes("startachat," + control + "$" + arguments + "$" + ChatID.ToString());
                                    await networkStream2.WriteAsync(startchatbyte, 0, startchatbyte.Length);
                                    serverlogs.Text += Environment.NewLine + participants[0] + " Tarafından istenilen chat başlatma isteği reddedildi: Yanlış kullanıcı ismi";
                                }


                            } //else biter



                        }//try biter
                        catch (Exception ex) 
                        {
                        
                        
                        
                        
                        }//catch biter











                    }//request startachat biter











                }//while biter



            }
            catch (Exception e)// büyüktry biter
            {

                



            }//büyük  catch biter


        
            
            
            
            
            
            
            /*try
            {

                while (true)
                {
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    string[] arrdatafromclient = message.Split('$');
                    request = arrdatafromclient[0];
                    arguments = arrdatafromclient[1];
                    messagefromclient = arrdatafromclient[2];
                    MessageBox.Show(message + "vardı");

                    if (request == "login")
                    {
                        string[] idandpass = arguments.Split(',');
                        string enteredUsername = idandpass[0];
                        string enteredPassword = idandpass[1];

                        string[] ipandport = messagefromclient.Split(',');
                        string ip = ipandport[0];
                        int port = Convert.ToInt32(ipandport[1]);
                        bool isAuthenticated = false;

                        lock (databaselock)
                        {
                            try
                            {
                                using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-ONDVNQK;Initial Catalog=TalkyDatabaseee;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
                                {
                                    connection.Open();

                                    string selectQuery = "SELECT COUNT(*) FROM UserTable WHERE Username = @enteredUsername AND Userpass = @enteredPassword";
                                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@enteredUsername", enteredUsername);
                                        command.Parameters.AddWithValue("@enteredPassword", enteredPassword);

                                        int count = (int)command.ExecuteScalar();

                                        if (count > 0)
                                        {
                                            // Kullanıcı adı ve şifre doğru, kimlik doğrulama başarılı
                                            isAuthenticated = true;


                                        }
                                        else
                                        {
                                            // Kullanıcı adı veya şifre hatalı, kimlik doğrulama başarısız
                                            isAuthenticated = false;
                                        }
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(e.Message);
                            }





                        }


                        if (isAuthenticated)
                        {
                            if (!instreamclientsDictionary.ContainsKey(enteredUsername))
                            {
                                instreamclientsDictionary.Add(enteredUsername, client);
                            }

                            outclient = new TcpClient();
                            await outclient.ConnectAsync(ip, port);
                            NetworkStream outsream = outclient.GetStream();
                            byte[] outmessage = Encoding.UTF8.GetBytes("true");
                            if (!outstreamclientsDictionary.ContainsKey(enteredUsername))
                            {
                                outstreamclientsDictionary.Add(enteredUsername, outclient);
                            }
                            await outsream.WriteAsync(outmessage, 0, outmessage.Length);
                            serverlogs.Text += enteredUsername + "logged in";
                        }

                        else
                        {

                            outclient = new TcpClient();
                            await outclient.ConnectAsync(ip, port);
                            NetworkStream outsream = outclient.GetStream();
                            byte[] outmessage = Encoding.UTF8.GetBytes("false");
                            await outsream.WriteAsync(outmessage, 0, outmessage.Length);
                            serverlogs.Text += enteredUsername + "failed to login";
                            client.Close();
                            outclient.Close();
                        }

                    }





                    if (request == "register")
                    {
                        string[] usernameandpass = arguments.Split(',');
                        string usern = usernameandpass[0];
                        string passw = usernameandpass[1];
                        string isavailable = "false";
                        string[] ipandport = messagefromclient.Split(',');
                        string ip = ipandport[0];
                        int port = Convert.ToInt32(ipandport[1]);

                        try
                        {
                            lock (databaselock)
                            {


                                string insertQuery = "INSERT INTO Usertable (Username,Userpass) VALUES (@newUsername,@password)";
                                string connectionString = @"Data Source=DESKTOP-ONDVNQK;Initial Catalog=TalkyDatabaseee;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                                string selectQuery = "SELECT * FROM Usertable WHERE Username = @newUsername";
                                using (SqlConnection connection = new SqlConnection(connectionString))
                                {
                                    connection.Open();

                                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("newUsername", usernameandpass[0]);
                                        using (SqlDataReader reader = command.ExecuteReader())
                                        {

                                            if (reader.HasRows)
                                            {

                                                isavailable = "false";

                                            }//if biter
                                            else
                                            {
                                                isavailable = "true";
                                            }//else biter


                                        }//reader biter




                                    }//command biter

                                    if (isavailable == "true")
                                    {

                                        using (SqlCommand insertcommand = new SqlCommand(insertQuery, connection))
                                        {
                                            insertcommand.Parameters.AddWithValue("newUsername", usern);
                                            insertcommand.Parameters.AddWithValue("password", passw);
                                            insertcommand.ExecuteNonQuery();
                                            isavailable = "true";



                                        }//command biter


                                    }//if biter

                                }//connection biter





                            }//database lock biter



                            TcpClient outclient1 = new TcpClient();

                            await outclient1.ConnectAsync(ip, port);
                            NetworkStream ns = outclient1.GetStream();
                            byte[] outmessage = Encoding.UTF8.GetBytes(isavailable);
                            await ns.WriteAsync(outmessage, 0, outmessage.Length);




                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message);
                        }//catch biter



                    }


                    if (request == "startachat")
                    {
                        MessageBox.Show("");

                        string[] participants = arguments.Split((','));



                        int ChatID = 0;
                        string control = "false";
                        try
                        {
                            lock (databaselock)
                            {
                                using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-ONDVNQK;Initial Catalog=TalkyDatabaseee;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
                                {

                                    connection.Open();
                                    string insertQuery1 = "INSERT INTO Chatstable (Username) VALUES (@newUsername); SELECT SCOPE_IDENTITY();";
                                    string controlquery = "SELECT COUNT(*) FROM Usertable WHERE Username = @username";
                                    string selectIdentityQuery = "SELECT SCOPE_IDENTITY()";
                                    string insertQuery = "INSERT INTO Chatstable (Username) VALUES (@newUsername)";



                                    foreach (string participant in participants)
                                    {
                                        using (SqlCommand command = new SqlCommand(controlquery, connection))
                                        {
                                            command.Parameters.AddWithValue("@username", participant);
                                            int count = (int)command.ExecuteScalar();

                                            if (count == 0)
                                            {


                                                control = "false";
                                                break;


                                            }//count==0 biter
                                            else
                                            {

                                                control = "true";




                                            }// count 0dan farklı biter else



                                        } //command biter


                                    }  //foreach biter


                                    using (SqlCommand command1 = new SqlCommand(insertQuery1, connection)) //1
                                    {


                                        command1.Parameters.AddWithValue("@newUsername", arguments);
                                        //command1.ExecuteNonQuery();

                                        // command1.CommandText = selectIdentityQuery;
                                        // if (command1.ExecuteScalar() != null)
                                        // {
                                        ChatID = Convert.ToInt32(command1.ExecuteScalar());
                                        //}





                                    }//insertquery biter







                                }  //connection biter






                            } //lock biter


                            if (control == "true")
                            {


                                foreach (string participant in participants)
                                {
                                    if (outstreamclientsDictionary.ContainsKey(participant) && outstreamclientsDictionary[participant].Connected)
                                    {

                                        TcpClient outclient1 = outstreamclientsDictionary[participant];
                                        NetworkStream networkStream1 = outclient1.GetStream();
                                        byte[] startchatbyte = Encoding.UTF8.GetBytes("startachat," + control + "$" + arguments + "$" + ChatID.ToString());
                                        await networkStream1.WriteAsync(startchatbyte, 0, startchatbyte.Length);
                                        serverlogs.Text += "startachat," + control + "$" + arguments + "$" + ChatID.ToString();

                                    }



                                }



                            }//control true biter
                            else if (control == "false")
                            {
                                if (outstreamclientsDictionary.ContainsKey(participants[0]) && outstreamclientsDictionary[participants[0]].Connected)
                                {
                                    TcpClient outclient1 = outstreamclientsDictionary[participants[0]];
                                    NetworkStream networkStream2 = outclient1.GetStream();
                                    byte[] startchatbyte = Encoding.UTF8.GetBytes("startachat," + control + "$" + arguments + "$" + ChatID.ToString());
                                    await networkStream2.WriteAsync(startchatbyte, 0, startchatbyte.Length);
                                }


                            } //else biter



                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message);
                        }





                    } // request biter

                    if (request == "sendmessage")
                    {
                        MessageBox.Show("sendmessage girdi");
                        string[] participants = arguments.Split(',');




                        string[] data = messagefromclient.Split(',');



                        string messagee = data[1];
                        ;
                        string[] messageparts = message.Split(':');
                        string[] Clientnameandmessage = messagee.Split(':');
                        string Clientname = Clientnameandmessage[0];
                        int ChatID = Convert.ToInt32(data[0]);
                        serverlogs.Text += messagefromclient + Environment.NewLine;
                        serverlogs.Text += messagee + Environment.NewLine;
                        serverlogs.Text += Clientname + Environment.NewLine;

                        // sendmessage$Yusuf,Yakup$ChatID,Yusuf:lorem ipsum     
                        // gelen data

                        //sendmessage$Yusuf,Yakup$ChatID|Yusuf:Lorem Ipsum
                        //giden data






                        foreach (string participant in participants)
                        {
                            if (outstreamclientsDictionary.ContainsKey(participant))
                            {



                                TcpClient tcp = outstreamclientsDictionary[participant];
                                if (tcp.Connected)
                                {
                                    NetworkStream ns = tcp.GetStream();
                                    byte[] bytedata = new byte[1024];
                                    bytedata = Encoding.UTF8.GetBytes("sendmessage,true$" + arguments + "$" + ChatID + "|" + messagee);
                                    await ns.WriteAsync(bytedata, 0, bytedata.Length);

                                }
                            }
                            else
                            {
                                serverlogs.Text += "not exist" + participant;

                            }
                        }
                        arguments = "";
                        ChatID = 0;
                        messagee = "";


                    }
                
                

                    if (request == "logout")
                    {





                    }



                }





            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "server");


            }*/
        

        }
        private void btExit_Click(object sender, EventArgs e)
        {
            
            Application.Exit();
            //clientsocket.Close();
            //serversocket.Stop();
            
        }

        private void serverapp_Load(object sender, EventArgs e)
        {

        }

        private async void Start_Click(object sender, EventArgs e)
        {
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            server = new TcpListener(ipAddress, 10000);
            server.Start();
            serverlogs.Text += "Server Started";


            while (true)
            {
                TcpClient client = await server.AcceptTcpClientAsync();
                //clients.Add(client);
                NetworkStream stream =client.GetStream();


                await Task.Run(() => HandleClient(client, serverlogs)); //await sonradan eklendi dikkatli ol

            }
        }
    }
}
