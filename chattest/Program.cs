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
                            }
                            catch(Exception e) 
                            {
                                Console.WriteLine(e);
                            }
                            


                            
                            


                            break;
                        };


                    case 2: 
                        
                        {                            
                            TcpListener listener = new TcpListener(IPAddress.Any,911);
                            listener.Start();
                            TcpClient client = listener.AcceptTcpClient();


                            StreamWriter sw = new StreamWriter(client.GetStream());
                            StreamReader sr = new StreamReader(client.GetStream());

                            String data = sr.ReadLine();
                            Console.WriteLine(data);
                            if (data == "hello")
                            {
                                sw.WriteLine("hello");
                                sw.Flush();
                                Console.WriteLine("ustanowiono polaczenie z: {0}",client.Client.RemoteEndPoint.ToString());
                            }

                            break;
                        };


                }

            Console.ReadLine();
        }
    }
}
