using LogicLayer.Services.Publisher;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace WebSocketServerLayer
{
    public class WebSocketServer : IDisposable
    {
        private readonly Action<string> Log;
        private HttpListener _listener;
        private readonly string _address;
        public List<WebSocketConnection> Connections = new List<WebSocketConnection>();
        private InformationPublisher _informationPublisher;

        public WebSocketServer(Action<string> log, string address)
        {
            Log = log;
            _address = address;
            _listener = new HttpListener();
            _listener.Prefixes.Add(address);
            _informationPublisher = new InformationPublisher(TimeSpan.FromSeconds(10));
            _informationPublisher.Start();
        }

        public async Task Listen()
        {

            try
            {
                _listener.Start();

                Log($"Waiting for connections on {_address} ... ");

            
                while (true)
                {
                    HttpListenerContext httpListenerContext = await _listener.GetContextAsync();

                    if (httpListenerContext.Request.IsWebSocketRequest)
                    {
                        await InitializeConnection(httpListenerContext);
                    }
         
                }
            }

            catch (Exception e)
            {
                Log(e.ToString());
            }
        }
        private async Task InitializeConnection(HttpListenerContext context)
        {
            try
            {
                HttpListenerWebSocketContext webSocketContext = await context.AcceptWebSocketAsync(subProtocol: null);
                WebSocketConnection connection = new WebSocketConnection(webSocketContext.WebSocket, Log);
                Connections.Add(connection);
                SubscribeToPromotions(connection);
                Log($"Maintaining {Connections.Count} active connections.");
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                context.Response.Close();
                Log($"Unable to establish connection: {ex.Message}.");
            }
        }

        private void SubscribeToPromotions(WebSocketConnection connection)
        {
            DailyInformationObserver observer = new DailyInformationObserver(connection);
            _informationPublisher.Subscribe(observer);
        }

        public void Dispose()
        {
           Connections.ForEach(connection => connection?.Dispose());
        }
    }
}
