using PresentationLayer;
using PresentationLayer.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebsocketServer;

namespace Shell
{
    internal class RunManager
    {
        private static readonly Action<string> Log = Console.WriteLine;
        private static readonly string _address = "http://localhost:9000/api/";

        public async static Task RunApplication(string mode)
        {
            if (mode == null)
            {
                RunServer();
                RunClient();
            }
            else if (mode == "1")
            {
                RunServer();
            }
            else if (mode == "2")
            {
                RunClient();
            }
        }

        private async static Task RunServer()
        {
            try
            {
                using WebSocketServer websocketServer = new WebSocketServer(Log, _address);
                await websocketServer.Listen();

                Console.ReadKey();
            }
            catch (Exception e)
            {
                Log("Unexpected error");
                Log(e.Message);
            }
        }

        private static void RunClient()
        {
            LoginWindow client = new LoginWindow();
            client.ShowDialog();
        }
    }
}
