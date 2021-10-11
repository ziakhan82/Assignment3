using Assignment1;
using Assignment3.Manager;
using System;
using System.IO;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading.Tasks;


namespace Assignment3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Server");
            TcpListener listener = new TcpListener(System.Net.IPAddress.Loopback, 4646);
           
            //we cant have serval listner
            listener.Start();// starting the server

            //we need to  clint after starting
            while (true)
            {
                TcpClient socket = listener.AcceptTcpClient();
                Task.Run(() => { HandleClient(socket); });

                



            }
            


        }
        public static void HandleClient(TcpClient socket)
        {
            BookManager _manager = new BookManager();
            NetworkStream stream = socket.GetStream();
            StreamReader reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(stream);

            while (true)
            {
                String firstLine = reader.ReadLine();
                Console.WriteLine(firstLine);
                String SecondLine = reader.ReadLine();
                Console.WriteLine(SecondLine);
                

                switch (firstLine)
                {
                    case "Get":
                        var book = _manager.Get(SecondLine);
                        writer.WriteLine( JsonSerializer.Serialize(book));
                        break;

                    case "GetAll":
                        var _books = _manager.GetAll();
                        writer.WriteLine(JsonSerializer.Serialize(_books));
                        break;

                    case "Save":
                        var boook = _manager.Save(JsonSerializer.Deserialize<Book>(SecondLine));
                        if(boook != null)
                        {
                            writer.WriteLine("book was saved");
                        }
                        break;
                        
                }
                writer.Flush();
            }



        }
    }
    }

