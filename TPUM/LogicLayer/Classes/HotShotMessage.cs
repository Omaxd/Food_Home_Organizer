using LogicLayer.DataTransferObjects;
using System;

namespace LogicLayer.Classes
{
    public class HotShotMessage : EventArgs
    {
        public InformationDto Information { get; private set; }

        public HotShotMessage(InformationDto information)
        {
            Information = information;
        }
    }
}
