using System;
using System.Collections.Generic;
using LogicLayer.DataTransferObjects;
using LogicLayer.Interfaces;
using LogicLayer.Services;
using Newtonsoft.Json;

namespace WebsocketServer.Resolver
{

    class RequestResolver
    {
        private readonly IUserService _userService;
        private readonly IFoodService _foodsService;
        private readonly IInformationService _informationService;

        public RequestResolver()
        {
            _userService = new UserService();
            _foodsService = new FoodService();
            _informationService = new InformationService();
        }

        public string Resolve(string message)
        {
            Message deserializedMessage = JsonConvert.DeserializeObject<Message>(message);
            EndpointAction action;
            Enum.TryParse(deserializedMessage.Action, out action);
            Message response;

            switch (action)
            {
                case EndpointAction.GET_FOODS:
                    IList<FoodDto> foods = _foodsService.GetFoods();
                    response = new Message() { Action = EndpointAction.GET_FOODS.GetString(), Body = JsonConvert.SerializeObject(foods), Type = "Array:Food" };
                    break;
          
                case EndpointAction.GET_USERS:
                    IList<UserDto> users = _userService.GetAllUsers();
                     response = new Message() { Action = EndpointAction.GET_USERS.GetString(), Body = JsonConvert.SerializeObject(users), Type = "Array:User" };
                    break;

                case EndpointAction.GET_INFORMATIONS:
                    IList<InformationDto> informations = _informationService.GetInformations();
                     response = new Message() { Action = EndpointAction.GET_INFORMATIONS.GetString(), Body = JsonConvert.SerializeObject(informations), Type = "Array:Information" };
                    break;

                default:
                    throw new NotSupportedException("Requested action is not supported");
            }

            return JsonConvert.SerializeObject(response);
        }
    }
}
