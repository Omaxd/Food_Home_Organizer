using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer;
using DataLayer.Interfaces;
using DataLayer.Model;
using DataLayer.Repositories;
using LogicLayer.DataTransferObjects;
using LogicLayer.Interfaces;
using LogicLayer.ModelMapper;

namespace LogicLayer.Services
{
    public class InformationService : IInformationService
    {
        private readonly IInformationRepository _informationRepository;
        private readonly DtoModelMapper _modelMapper;

        public InformationService()
        {
            _informationRepository = new InformationRepository(DataStore.Instance.State.Informations);

            _modelMapper = new DtoModelMapper();
        }

        public InformationService(IInformationRepository informationRepository, DtoModelMapper modelMapper)
        {
            _informationRepository = informationRepository;
            _modelMapper = modelMapper;
        }

        public InformationDto AddInfomation(InformationDto dto)
        {
            Information information = _modelMapper.FromInformationDto(dto);
            Information created = _informationRepository.Add(information);
            InformationDto createdInformationDto = _modelMapper.ToInformationDto(created);

            return createdInformationDto;
        }

        public IList<InformationDto> GetAllDiscountCodes()
        {
            IList<Information> informations = _informationRepository.GetAll();
            IList<InformationDto> informationDtos = informations
                .Select(i => _modelMapper.ToInformationDto(i))
                .ToList();

            return informationDtos;
        }

        public void DeleteInformation(Guid informationId)
        {
            _informationRepository.Delete(informationId);
        }
    }
}
