using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace HTTPWebServer
{
    public class HTTPServer
    {
        // CREATE VARIABLE TO CHECK IF SERVER IS RUNNING | DEFAULT: false
        private bool RUNNING = false;
        // Declare a private field "listener" of type "TCPListener"
        // to listen for incoming TCP/IP connections
        private TcpListener? listener;

        public HTTPServer(int PORT)
        {
            // CREATE NEW TCPListener instance
            listener = new TcpListener(IPAddress.Any, PORT);
        }

        /////////////////////////////////////
        // METHOD FOR STARTING THE SERVER //
        /////////////////////////////////////
        public void START()
        {
            // CREATE NEW THREAD
            Thread serverThread = new Thread(new ThreadStart(RUN));
            serverThread.Start();
        }

        // CREATE RUN LOOP
        public void RUN()
        {
            // SET RUNNING TO true
            RUNNING = true;
            listener?.Start();

            while (RUNNING)
            {
                Console.WriteLine("Waiting for connection...");

                TcpClient? client = listener?.AcceptTcpClient();

                Console.WriteLine("Client connected!");

                // CALL METHOD TO HANDLE client and PASS IN THE client
                HandleClient(client);
                client?.Close();
            }

            RUNNING = false;
            listener?.Stop();

        }

        public void HandleClient(TcpClient? client)
        {
            // CREATE READ STREAM
            StreamReader reader = new StreamReader(client.GetStream());

            String msg = "";
            while (reader.Peek() != -1)
            {
                msg += reader.ReadLine() + "|\n";
            }

            Console.WriteLine("Request: \n" + msg);
        }
    }
}