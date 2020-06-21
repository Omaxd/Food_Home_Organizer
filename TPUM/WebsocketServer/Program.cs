using System;
using System.Net;
using System.Threading.Tasks;

namespace WebsocketServer
{
    internal class Program
    {
        private static readonly Action<string> Log = Console.WriteLine;

        private static readonly string address = "http://localhost:9000/api/";

        static async Task Main(string[] args)
        {
            try
            {
                using WebSocketServer websocketServer = new WebSocketServer(Log, address);
                await websocketServer.Listen();

                Console.ReadKey();
            }
            catch (Exception e)
            {
                Log("Unexpected error");
                Log(e.Message);
            }
        }
    }
}