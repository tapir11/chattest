using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;
using System.Net;

namespace chattest
{





    class Program
    {
        static void Main(string[] args)
        {

                Console.WriteLine("choose mode: 1.Client  2.Server");
                int mode = int.Parse(Console.ReadLine());
                switch (mode)
                {
                    case 1: 
                        {
                            bool tryagain = true;
                            while (tryagain)
                            {
                                try
                                {   
                                    
                                    Console.WriteLine("enter server ip");
                                    string servip = Console.ReadLine();
                                    TcpClient client = new TcpClient(servip, 911);
                                    StreamWriter sw = new StreamWriter(client.GetStream());
                                    StreamReader sr = new StreamReader(client.GetStream());
                                    sw.WriteLine("hello");
                                    sw.Flush();
                                    string data = sr.ReadLine();
                                    Console.WriteLine(data);
                                    if (data == "hello")
                                        Console.WriteLine("polaczono");
                                    string msg;
                                    do
                                    {

                                        Console.WriteLine("wpisz wiadomosc lub \"exit\" aby zakonczyc");
                                        msg = Console.ReadLine();
                                        sw.WriteLine(msg);
                                        sw.Flush();


                                    } while (msg != "exit");
                                    tryagain = false;
                                }
                                catch (System.Net.Sockets.SocketException e)
                                {
                                    Console.WriteLine("server is not responding\n");
                                    tryagain = true;
                                }
                                
                            }


                            
                            


                            break;
                        };
                        

                    case 2: 
                        
                        {
                            Console.WriteLine("waiting for connection with client\n");
                            TcpListener listener = new TcpListener(IPAddress.Any,911);
                            listener.Start();
                            TcpClient client = listener.AcceptTcpClient();


                            StreamWriter sw = new StreamWriter(client.GetStream());
                            StreamReader sr = new StreamReader(client.GetStream());
                            try
                            {
                                String data = sr.ReadLine();
                                Console.WriteLine(data);
                                if (data == "hello")
                                {
                                    sw.WriteLine("hello");
                                    sw.Flush();
                                    Console.WriteLine("ustanowiono polaczenie z: {0}\n\n", client.Client.RemoteEndPoint.ToString());
                                }

                                while (client.Connected)
                                {

                                    data = sr.ReadLine();
                                    if (data == "exit")
                                    {
                                        client.Close();
                                        Console.WriteLine("user disconnected");
                                        break;
                                    }
                                        
                                    Console.WriteLine(data);

                                }
                            }
                            catch(System.IO.IOException e)
                            {
                                Console.WriteLine("user disconnected");
                            }

                            break;
                        };


                }

            Console.ReadLine();
        }
    }
}
