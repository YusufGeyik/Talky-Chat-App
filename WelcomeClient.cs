using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class WelcomeClient
    {
       
        static Dictionary<string, TcpClient> Clients= new Dictionary<string, TcpClient>();
        private static object databaselock= new object();
        public string connectionstring = @"Data Source=DESKTOP-ONDVNQK;Initial Catalog=TalkyDatabaseee;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public static  void welcoming (TcpClient welcomedclientsocket,TextBox UIlogs)
        {  

            
     
            string datafromclient = null;
          
            
            string request=null;
            string arguments=null;
            string messagefromclient=null;


           // NetworkStream networkstream = welcomedclientsocket.GetStream();
            //StreamReader sr = new StreamReader(networkstream);


            while (true) 
            {
                
                   using(NetworkStream networkstream = welcomedclientsocket.GetStream())
                {
                    StreamReader sr = new StreamReader(networkstream);
                    datafromclient = sr.ReadLine();
                    string[] arrdatafromclient = datafromclient.Split('$');
                    request = arrdatafromclient[0];
                    arguments = arrdatafromclient[1];
                    messagefromclient = arrdatafromclient[2];
                    MessageBox.Show(arguments);
                    
                }
                    
                    
                    switch (request)
                    {
                        case "login":
                      
                           
                           login(UIlogs,arguments,messagefromclient,welcomedclientsocket);
                            break;
                        

                        
                        case "register":


                        // Thread tregister = new Thread(() => register(UIlogs, welcomedclientsocket, arguments, messagefromclient));
                        //tregister.Start();
                        // tregister.Join();
                        register(UIlogs, welcomedclientsocket, arguments, messagefromclient);


                            break;
                        case "startachat":
                        MessageBox.Show("startachat");
                            startachat(arguments, messagefromclient,UIlogs);
                        //Thread thread=new Thread(()=>startachat(arguments,messagefromclient,UIlogs));
                        //thread.Start();
                       




                            break;
                        /*  case "sendlogs":


                              Thread tsendlogs = new Thread(() => sendlogs( arguments, messagefromclient,));
                              tsendlogs.Start();
                        break;
                        */


                        case "sendmessage":

                            sendmessages(arguments, messagefromclient);
                           

                            break;

                        case "logout":
                            logout(arguments, UIlogs);
                            
                            
                           break;
                        
                       
                        default:
                           
                           break;

                    }

                    //thread ile çağır



                
               
           



            
            }





        }


        private static void login(TextBox UIlogs, string arguments, string messagefromclient,TcpClient welcomedclient)
        {

            string[] idandpass = arguments.Split(',');
            string enteredUsername = idandpass[0];
            string enteredPassword = idandpass[1];

            string[] ipandport = messagefromclient.Split(',');
            string ip = ipandport[0];
            int port = Convert.ToInt32(ipandport[1]);
            MessageBox.Show(port.ToString());
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
                        MessageBox.Show(e.Message+"DATABASE SONU");
                    }


               


                }

            try
            {



              TcpClient tcpClient = new TcpClient();
                tcpClient.Connect(ip, port);

                NetworkStream networkstream = tcpClient.GetStream();
                StreamWriter writer = new StreamWriter(networkstream, Encoding.UTF8);
                UIlogs.Text += ip + port.ToString();
                /* NetworkStream networkstream = tcpClient.GetStream();
                 StreamWriter writer = new StreamWriter(networkstream, Encoding.UTF8);*/


                if (isAuthenticated == true)
                {
                    lock (Clients)
                    {
                        if (!Clients.ContainsKey(enteredUsername))
                        {
                           Clients.Add(enteredUsername, tcpClient);


                        }


                    }
                    UIlogs.Text += enteredUsername + "Logged in\n";

                    lock (Clients)
                    {
                        lock (Clients[enteredUsername])
                        {
                            writer.WriteLine("true");
                            writer.Flush();


                        }
                    }
                  
                    //Thread tsendlogs = new Thread(() => sendlogs(enteredUsername, UIlogs));
                    // tsendlogs.Start();
                }


                else if (isAuthenticated == false)
                {






                   writer.WriteLine("false");
                    writer.Flush();
                   MessageBox.Show("false döndü");

                }
                
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message+"SOM");
            }


            welcoming(Clients[enteredUsername], UIlogs);



        }



        private static void register(TextBox UIlogs,TcpClient client, string arguments, string messagefromclient)
        {
           
            
            

            string[] ipandport = messagefromclient.Split(',');
            string ip = ipandport[0];
            int port = Convert.ToInt32(ipandport[1]);

            string[] idandpass=arguments.Split(',');
            string username = idandpass[0];
            MessageBox.Show(username);
            string password = idandpass[1];
            MessageBox.Show(password);
            UIlogs.Text = username + password + ip + "," + port;
            string newusername = username;
            string isavailable="false";
            try
            {
                try
                {



                    
                                    lock (databaselock)
                                    {

                                        try
                                        {
                            string connectionString = @"Data Source=DESKTOP-ONDVNQK;Initial Catalog=TalkyDatabaseee;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"; // Veritabanı bağlantı dizesini buraya girin
                            string selectQuery = "SELECT * FROM Usertable WHERE Username = @newUsername";

                            using (SqlConnection connection = new SqlConnection(connectionString))
                            {
                                connection.Open();

                                // Kullanıcı adının veritabanında olup olmadığını kontrol et
                                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                                {
                                    command.Parameters.AddWithValue("@newUsername", username);

                                    using (SqlDataReader reader = command.ExecuteReader())
                                    {
                                        if (reader.HasRows)
                                        {
                                            isavailable = "false";
                                        }
                                        else
                                        {
                                            isavailable="true";
                                        }
                                    }
                                }
                            }

                        }
                        catch (Exception e)
                                        {
                                            MessageBox.Show(e.Message + "DATABASE SONU");
                                        }
                                    }


                    if (isavailable == "true")
                    {
                        string connectionString = @"Data Source=DESKTOP-ONDVNQK;Initial Catalog=TalkyDatabaseee;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"; // Veritabanı bağlantı dizesini buraya girin
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open ();
                            string insertQuery = "INSERT INTO Usertable (Username, Userpass) VALUES (@newUsername, @password)";
                            using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                            {
                                insertCommand.Parameters.AddWithValue("@newUsername", username);
                                insertCommand.Parameters.AddWithValue("@password", password);
                                insertCommand.ExecuteNonQuery();
                                isavailable = "true";
                            }
                        }
                    }


                }
                catch (Exception e)
                {

                    MessageBox.Show(e.Message+"Son");



                }

                









                TcpClient tcpClient = new TcpClient();
                tcpClient.Connect(ip, port);
                UIlogs.Text += ip + port.ToString();
                NetworkStream networkstream = tcpClient.GetStream();
                StreamWriter writer = new StreamWriter(networkstream, Encoding.UTF8);


                if (isavailable == "true")
                {
                   
                        UIlogs.Text += username + "Registered";
                        
                       
                     
                        writer.WriteLine(isavailable);
                        writer.Flush();
                    
                    
                }
                else if (isavailable == "false")
                {

                    UIlogs.Text += tcpClient + "Failed to register. This ID not available";
                    
                    
                    writer.WriteLine(isavailable);
                    writer.Flush();
                    

                }

            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);


            }
        }



        private static void startachat(string arguments, string messagefromclient,TextBox UIlogs) 
        {
            // Chats.Add(Id,arguments)
            string[] participants = arguments.Split(',');
            
            int ChatID = 0;
            string control = "false";
            lock (databaselock)
                MessageBox.Show("OLDU");
            {



                using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-ONDVNQK;Initial Catalog=TalkyDatabaseee;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
                {
                    connection.Open();

                    string controlquery = "SELECT COUNT(*) FROM Usertable WHERE Username = @controlname";
                    string selectIdentityQuery = "SELECT SCOPE_IDENTITY()";
                    string insertQuery = "INSERT INTO Chatstable (Username) VALUES (@newUsername)";


                    using (SqlCommand command = new SqlCommand(controlquery, connection))
                    {
                        foreach (string participant in participants)
                        {
                            command.Parameters.AddWithValue("@controlname", participant);
                            int count = (int)command.ExecuteScalar();
                            if (count == 0)
                            {
                                control = "false";
                                break;

                            }
                            else
                            {
                                control = "true";
                            }

                        }

                    }

                    if (control == "true")
                    {



                        using (SqlCommand command = new SqlCommand(insertQuery, connection))
                        {




                            command.Parameters.AddWithValue("@newUsername", arguments);

                            command.ExecuteNonQuery();
                            command.CommandText = selectIdentityQuery;
                            ChatID = Convert.ToInt32(command.ExecuteScalar());

                        }


                    }

                   

                    }


                }


            if (control == "true")
            {



                foreach (string participant in participants)
                {

                    lock (Clients)
                    {
                        lock (Clients[participant])
                        {
                            TcpClient client = Clients[participant];
                            NetworkStream networkStream = client.GetStream();
                            StreamWriter writer = new StreamWriter(networkStream, Encoding.UTF8);
                            writer.WriteLine(control +"$"+ arguments + "$" + ChatID.ToString());
                            writer.Flush();
                            UIlogs.Text += control +"$"+ arguments + "$" + ChatID.ToString();
                        }

                    }
                }

                

            }
            else
            {
                lock (Clients)
                {
                    lock (Clients[participants[0]])
                    {
                        TcpClient client = Clients[participants[0]];
                        NetworkStream networkStream = client.GetStream();
                        StreamWriter writer = new StreamWriter(networkStream, Encoding.UTF8);
                        writer.WriteLine(control);
                        writer.Flush();
                        UIlogs.Text += control+"$";
                    }
                }




            }



        }


        private static void sendlogs(string username,TextBox UIlogs)
        {

            string searchName =username;

            // SQL sorgusu
            string sqlQuery = "SELECT ChatID, Username, ChatHistory FROM Chatstable WHERE Usernames LIKE @SearchName";
            lock (databaselock)
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-ONDVNQK;Initial Catalog=TalkyDatabaseee;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
                {
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        // Parametre ekleme
                        command.Parameters.AddWithValue("@SearchName", "%" + searchName + "%");

                        try
                        {
                            connection.Open();

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    int chatID = reader.GetInt32(0);
                                    string usernames = reader.GetString(1);
                                    string chatHistory = reader.GetString(2);

                                    lock (Clients)
                                    {
                                        lock (Clients[username])
                                        {

                                            TcpClient client = Clients[username];
                                            NetworkStream networkStream = client.GetStream();
                                            StreamWriter writer= new StreamWriter(networkStream, Encoding.UTF8);
                                            writer.Write(chatID + "*" +usernames+"*"+ chatHistory);
                                            writer.Flush();

                                        }
                                        

                                    }

                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Hata oluştu: " + ex.Message);
                        }
                    }
                }
            }
            UIlogs.Text += username + "Chat history has sent";

        }



        private static void sendmessages(string arguments, string messagefromclient)
        {
            string[] chatusers=arguments.Split(',');
            foreach(string user in  chatusers) 
            {
                if (Clients.ContainsKey(user))
                {
                    lock (Clients)
                    {
                        lock (Clients[user])
                        {
                            TcpClient client = Clients[user];

                            NetworkStream networkstream = client.GetStream();
                            StreamWriter sendmessage = new StreamWriter(networkstream, Encoding.UTF8);
                            sendmessage.WriteLine(messagefromclient);
                            sendmessage.Flush();
                        }
                    }
                }

                else
                {

              

                }
            
            }

            lock (databaselock)
            {


                using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-ONDVNQK;Initial Catalog=TalkyDatabaseee;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO Chatstable (ChatHistory) VALUES (@messagefromclient)";
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        

                            
                                command.Parameters.AddWithValue("@messagefromclient", messagefromclient+",");
                                
                                command.ExecuteNonQuery();
                                
                            
                        
                       
                    }
                }



            }




        }

        private static void logout(string arguments,TextBox UIlogs)
        {
          
            string user = arguments;
           lock (Clients)
            {
                lock (Clients[user])
                {
                    TcpClient client = Clients[user];
                    client.Close();
                    Clients.Remove(arguments);
                    UIlogs.Text += arguments + "disconnected";

                }

            }
            
        }

       
    }
}
