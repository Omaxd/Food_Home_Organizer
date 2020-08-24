using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.WebSockets;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DataLayer.Model;
using LogicLayer.Classes;
using LogicLayer.DataTransferObjects;
using Newtonsoft.Json;
using PresentationLayer.Commands;
using PresentationLayer.Interfaces;
using PresentationLayer.StaticResources;
using PresentationLayer.View;
using PresentationLayer.Websockets;

namespace PresentationLayer.ViewModel
{
    internal class LoginWindowViewModel : BaseViewModel
    {
        private LoginWindow _window;

        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand((x) =>
                {
                    if (x != null) { Login(x); }
                });
            }
        }

        protected override void OnMessageReceived(string data)
        {
            Trace.WriteLine("RECEIVED:");
            Trace.WriteLine(data);
            Message message = JsonConvert.DeserializeObject<Message>(data);
            Enum.TryParse(message.Action, out EndpointAction action);

            switch (action)
            {
                case EndpointAction.LOGIN:
                    UserDto user = JsonConvert.DeserializeObject<UserDto>(message.Body);

                    if (user.Id != null)
                    {
                        ApplicationInfo.User = user;
                    }
                        
                    break;
            }
        }

        private async void Login(object x)
        {
            var passwordContainer = x as ISecurePassword;
            _window = (LoginWindow)x;

            if (passwordContainer != null && webSocketClient.WebSocket.State == WebSocketState.Open)
            {
                SecureString secureString = passwordContainer.Password;
                string password = ConvertToUnsecureString(secureString);
                UserDto userDto = new UserDto()
                {

                    Login = passwordContainer.Login,
                    Password = password
                };

                Message messageSent = new Message() { Action = EndpointAction.LOGIN.GetString(), Body = JsonConvert.SerializeObject(userDto) };
                await connection.SendAsync(messageSent.ToString());
            }
        }

        private string ConvertToUnsecureString(SecureString securePassword)
        {
            if (securePassword == null)
            {
                return string.Empty;
            }

            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}
