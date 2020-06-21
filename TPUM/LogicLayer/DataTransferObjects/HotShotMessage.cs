using System;

namespace LogicLayer.DataTransferObjects
{
    public class HotShotMessage : EventArgs
    {
        public HotShotMessage(InformationDto discountCode)
        {
            DiscountCode = discountCode;
        }
        public InformationDto DiscountCode { get; private set; }
    }
}
