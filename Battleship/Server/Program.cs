// A C# Program for Server 
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{

    class Program
    {
        public static string clientMessageOne;
        public static string clientMessageTwo;

        // Main Method 
        static void Main(string[] args)
        {
            //
            Game game = new Game(20);
            clientMessageOne = game.playerOne.board.GetBoardState() + "\n";
            clientMessageTwo += game.playerTwo.board.GetBoardState() + "\n";
            ExecuteServer();
        }

        public static void ExecuteServer()
        {
            // Establish the local endpoint  
            // for the socket. Dns.GetHostName 
            // returns the name of the host  
            // running the application. 
            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 11111);

            // Creation TCP/IP Socket using  
            // Socket Class Costructor 
            Socket listener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {

                // Using Bind() method we associate a 
                // network address to the Server Socket 
                // All client that will connect to this  
                // Server Socket must know this network 
                // Address 
                listener.Bind(localEndPoint);

                // Using Listen() method we create  
                // the Client list that will want 
                // to connect to Server 
                listener.Listen(10);

                while (true)
                {

                    Console.WriteLine("Waiting connection ... ");

                    // Suspend while waiting for 
                    // incoming connection Using  
                    // Accept() method the server  
                    // will accept connection of client 
                    Socket clientSocketOne = listener.Accept();
                    Console.WriteLine("First client connected.");

                    Socket clientSocketTwo = listener.Accept();
                    Console.WriteLine("Second client connected.");

                    // Data buffer 
                    byte[] bytes = new byte[4096];
                    string dataOne = null;
                    string dataTwo = null;

                    while (true)
                    {

                        int numByteOne = clientSocketOne.Receive(bytes);
                        int numByteTwo = clientSocketTwo.Receive(bytes);

                        dataOne += Encoding.ASCII.GetString(bytes, 0, numByteOne);
                        dataTwo += Encoding.ASCII.GetString(bytes, 0, numByteTwo);

                        if (dataOne.IndexOf("<EOF>") > -1 && dataTwo.IndexOf("<EOF>") > -1)
                            break;
                    }

                    Console.WriteLine("Text received from client 1 -> {0} ", dataOne);
                    Console.WriteLine("Text received from client 2 -> {0} ", dataTwo);

                    byte[] messageOne = Encoding.ASCII.GetBytes(clientMessageOne);
                    byte[] messageTwo = Encoding.ASCII.GetBytes(clientMessageTwo);

                    // Send a message to Client  
                    // using Send() method 
                    clientSocketOne.Send(messageOne);
                    clientSocketTwo.Send(messageTwo);

                    // Close client Socket using the 
                    // Close() method. After closing, 
                    // we can use the closed Socket  
                    // for a new Client Connection 
                    clientSocketOne.Shutdown(SocketShutdown.Both);
                    clientSocketTwo.Shutdown(SocketShutdown.Both);
                    clientSocketOne.Close();
                    clientSocketTwo.Close();
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}