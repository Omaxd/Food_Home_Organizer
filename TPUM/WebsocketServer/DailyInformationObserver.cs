using System;
using DataLayer.Observer;
using LogicLayer.DataTransferObjects;
using LogicLayer.ModelMapper;
using Newtonsoft.Json;

namespace WebSocketServerLayer
{
    public class DailyInformationObserver : IObserver<InformationEvent>
    {
        private WebSocketConnection _connection;
        private DtoModelMapper mapper = new DtoModelMapper();
        public DailyInformationObserver(WebSocketConnection connection)
        {
            _connection = connection;
        }

        public void OnCompleted()
        {

        }

        public async void OnError(Exception error)
        {
            await _connection.SendAsync($"Error occured. Failed to fetch current promotion: {error.Message}");
        }

        public async void OnNext(InformationEvent value)
        {
            Console.WriteLine("Cyclic message:", value);
            InformationDto code = mapper.ToInformationDto(value.Information);
            string body = JsonConvert.SerializeObject(code);
            Message message = new Message() { Action = EndpointAction.PUBLISH_INFORMATION.GetString(), Type = "DailyInfoDto", Body = body };
            Console.WriteLine($"Promotion: {message}");
            await _connection.SendAsync(JsonConvert.SerializeObject(message));
        }
    }
}
