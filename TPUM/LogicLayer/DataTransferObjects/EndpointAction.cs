using System;

namespace LogicLayer.DataTransferObjects
{
    public enum EndpointAction
    {
        GET_FOODS,
        GET_USERS,
        GET_INFORMATIONS,
        PUBLISH_INFORMATION,

    }
    public static class EndpointActionMethods
    {

        public static string GetString(this EndpointAction endpointAction)
        {
            return Enum.GetName(typeof(EndpointAction), endpointAction);
        }
    }
}