using Microsoft.VisualStudio.TestTools.UnitTesting;
using PresentationLayer.StaticResources;
using PresentationLayer.View;
using PresentationLayer.ViewModel;
using System;
using System.Threading;
using System.Threading.Tasks;
using WebsocketServer;

namespace IntegrationTest.WebSocketServerLayer
{
    [TestClass]
    public class WebSocketConnection
    {
        private static readonly Action<string> Log = Console.WriteLine;

        [TestMethod]
        public async Task RunServerAndOneClientWithWrongAddress()
        {
            string serverAddress = "http://localhost:9000/api/5/";
            string clientAddress = "ws://localhost:9000/api/1/";
            int expectedWebSocketConnections = 0;
            int webSocketServerConnections = 0;

            using (WebSocketServer websocketServer = new WebSocketServer(Log, serverAddress))
            {
                ApplicationInfo.WebSocketAddress = clientAddress;
                RunServer(websocketServer);
                RunClient();

                await Task.Delay(1000);

                webSocketServerConnections = websocketServer.Connections.Count;
                websocketServer.Dispose();

                await Task.Delay(1000);
            }

            Assert.AreEqual(expectedWebSocketConnections, webSocketServerConnections, "Too much connection");
        }

        [TestMethod]
        public async Task RunServerAndTwoClients()
        {
            int expectedWebSocketConnections = 2;
            string serverAddress = "http://localhost:9000/api/5/";
            string clientAddress = "ws://localhost:9000/api/5/";

            int webSocketServerConnections = 0;

            using (WebSocketServer websocketServer = new WebSocketServer(Log, serverAddress))
            {
                ApplicationInfo.WebSocketAddress = clientAddress;
                RunServer(websocketServer);
                RunClient();
                RunClient();

                await Task.Delay(1000);

                webSocketServerConnections = websocketServer.Connections.Count;
                websocketServer.Dispose();
            }
           
            Assert.AreNotEqual(0, webSocketServerConnections, "No connections");
            Assert.AreNotEqual(1, webSocketServerConnections, "Only 1 client");
            Assert.AreEqual(expectedWebSocketConnections, webSocketServerConnections, "Too much connection");
        }

        private async static Task RunServer(WebSocketServer websocketServer)
        {
            try
            {
                await websocketServer.Listen();
            }
            catch (Exception e)
            {
                Log("Unexpected error");
                Log(e.Message);
            }
        }

        private static void RunClient()
        {

            LoginWindowViewModel client = new LoginWindowViewModel();

        }
    }
}
