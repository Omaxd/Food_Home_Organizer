using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.WebSockets;
using System.Windows.Input;
using LogicLayer.Classes;
using LogicLayer.DataTransferObjects;
using Newtonsoft.Json;
using PresentationLayer.Commands;
using PresentationLayer.Websockets;

namespace PresentationLayer.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<UserDto> _users;
        private ObservableCollection<FoodDto> _foods;
        private ObservableCollection<InformationDto> _informations;
        private ObservableCollection<FoodDto> _cart = new ObservableCollection<FoodDto>();
        private InformationDto _currentInformation;

   

        #region ObservableCollections
        public ObservableCollection<UserDto> Users
        {
            get => _users;
            set
            {
                _users = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<FoodDto> Foods
        {
            get => _foods;
            set
            {
                _foods = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<InformationDto> Informations
        {
            get => _informations;
            set
            {
                _informations = value;
                OnPropertyChanged();
            }
        } 
        public ObservableCollection<FoodDto> Cart
        {
            get => _cart;
            set
            {
                _cart = value;
                OnPropertyChanged();
            }
        }

        public InformationDto CurrentInformation
        {
            get => _currentInformation;
            set
            {
                _currentInformation = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public ICommand FetchUsersCommand
        {
            get
            {
                return new RelayCommand((x) =>
                {
                    { FetchUsers(); }
                });
            }
        }

        public ICommand FetchFoodsCommand
        {
            get
            {
                return new RelayCommand((x) =>
                {
                    { FetchFoods(); }
                });
            }
        }

        public ICommand FetchInformationsCommand
        {
            get
            {
                return new RelayCommand((x) =>
                {
                    { FetchInformations(); }
                });
            }
        }

        public MainViewModel()
        {
            CreateConnection();
        }

        private async void FetchUsers()
        {
            if (webSocketClient.WebSocket.State == WebSocketState.Open)
            {
                Message messageSent = new Message() {Action = EndpointAction.GET_USERS.GetString()};

                await connection.SendAsync(messageSent.ToString());
            }
        }
        private async void FetchFoods()
        {
            if (webSocketClient.WebSocket.State == WebSocketState.Open)
            {
                Message messageSent = new Message() { Action = EndpointAction.GET_FOODS.GetString() };

                await connection.SendAsync(messageSent.ToString());
            }
        }

        private async void FetchInformations()
        {
            if (webSocketClient.WebSocket.State == WebSocketState.Open)
            {
                Message messageSent = new Message() { Action = EndpointAction.GET_INFORMATIONS.GetString() };

                await connection.SendAsync(messageSent.ToString());
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
                case EndpointAction.GET_FOODS:
                    IList<FoodDto> foods = JsonConvert.DeserializeObject<List<FoodDto>>(message.Body);
                    Foods = new ObservableCollection<FoodDto>(foods);
                    break;

                case EndpointAction.GET_USERS:
                    IList<UserDto> users = JsonConvert.DeserializeObject<List<UserDto>>(message.Body);
                    Users = new ObservableCollection<UserDto>(users);
                    break;

                case EndpointAction.GET_INFORMATIONS:
                    IList<InformationDto> informations = JsonConvert.DeserializeObject<List<InformationDto>>(message.Body);
                    Informations = new ObservableCollection<InformationDto>(informations);
                    break;

                case EndpointAction.PUBLISH_INFORMATION:
                    InformationDto currentInformation = JsonConvert.DeserializeObject<InformationDto>(message.Body);
                    CurrentInformation = currentInformation;
                    break;
            }
        }
    }
}