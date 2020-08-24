using LogicLayer.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.StaticResources
{
    public class ApplicationInfo
    {
        public static UserDto User { get; set; }
        public static string WebSocketAddress { get; set; }
    }
}
