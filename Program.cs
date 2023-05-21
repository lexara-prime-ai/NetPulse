using System;

namespace HTTPWebServer
{
    class Server
    {
        static void Main(string[] args)
        {
            // CREATE VARIABLE PORT
            int PORT = 4000;
            // PRINT MESSAGE TO CONSOLE
            Console.WriteLine("Starting SERVER on port: " + PORT);
            // CREATE NEW SERVER HTTPServer INSTANCE
            HTTPServer SERVER = new HTTPServer(PORT);
            // CALL START METHOD
            SERVER.START();
        }
    }
}