using System;
using System.Collections;
using System.Collections.Generic;
using DataLayer.Model;
using LogicLayer.DataTransferObjects;

namespace LogicLayer.Interfaces
{
    public interface IInformationService
    {
        InformationDto AddInfomation(InformationDto dto);

        IList<InformationDto> GetAllDiscountCodes();

        void DeleteInformation(Guid informationId);
    }
}