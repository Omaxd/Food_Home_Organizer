using System;
using System.Collections.Generic;
using LogicLayer.Classes;
using LogicLayer.DataTransferObjects;
using LogicLayer.Interfaces;
using LogicLayer.Services;
using Newtonsoft.Json;

namespace WebsocketServer.Resolver
{

    class RequestResolver
    {
        private readonly IUserService _userService;
        private readonly IFoodService _booksService;
        private readonly IInformationService _discountCodeService;

        public RequestResolver()
        {
            _userService = new UserService();
            _booksService = new FoodService();
            _discountCodeService = new InformationService();
        }

        public string Resolve(string message)
        {
            Message messageObject = JsonConvert.DeserializeObject<Message>(message);
            EndpointAction action;
            Message response;

            Enum.TryParse(messageObject.Action, out action);

            switch (action)
            {
                case EndpointAction.GET_FOODS:
                    IEnumerable<FoodDto> foods = _booksService.GetFoods();
                    response = new Message() { Action = EndpointAction.GET_FOODS.GetString(), Body = JsonConvert.SerializeObject(foods), Type = "Array:Food" };
                    break;
          
                case EndpointAction.GET_USERS:
                    IEnumerable<UserDto> users = _userService.GetAllUsers();
                    response = new Message() { Action = EndpointAction.GET_USERS.GetString(), Body = JsonConvert.SerializeObject(users), Type = "Array:User" };
                    break;

                case EndpointAction.GET_INFORMATIONS:
                    IEnumerable<InformationDto> discountCodes = _discountCodeService.GetAllDiscountCodes();
                    response = new Message() { Action = EndpointAction.GET_INFORMATIONS.GetString(), Body = JsonConvert.SerializeObject(discountCodes), Type = "Array:Informations" };
                    break;

                case EndpointAction.LOGIN:
                    UserDto loginAndPassword = JsonConvert.DeserializeObject<UserDto>(messageObject.Body);
                    UserDto user = _userService.GetUserByLoginAndPassword(loginAndPassword.Login, loginAndPassword.Password);
                    response = new Message() { Action = EndpointAction.LOGIN.GetString(), Body = JsonConvert.SerializeObject(user), Type = "UserDto" };
                    break;

                default:
                    throw new NotSupportedException("Requested action is not supported");
            }

            return JsonConvert.SerializeObject(response);
        }
    }
}
