using LogicLayer.DataTransferObjects;
using System;

namespace LogicLayer.Classes
{
    public class HotShotMessage : EventArgs
    {
        public InformationDto DiscountCode { get; private set; }

        public HotShotMessage(InformationDto discountCode)
        {
            DiscountCode = discountCode;
        }
    }
}
