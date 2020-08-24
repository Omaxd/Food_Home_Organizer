using LogicLayer.Classes;
using LogicLayer.DataTransferObjects;
using Newtonsoft.Json;
using PresentationLayer.StaticResources;
using PresentationLayer.Websockets;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace PresentationLayer.ViewModel
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected WebSocketClient webSocketClient = new WebSocketClient(ApplicationInfo.WebSocketAddress);
        protected static SocketConnection connection;

        public BaseViewModel()
        {
            if (connection == null)
                CreateConnection();
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected async void CreateConnection()
        {
            connection = await webSocketClient.Connect(OnMessageReceived);
        }

        protected virtual void OnMessageReceived(string data)
        {

        }
    }
}
