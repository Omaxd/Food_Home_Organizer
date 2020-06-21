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
    public class FoodService : IFoodService
    {
        private readonly IFoodRepository _foodRepository;

        private readonly DtoModelMapper _modelMapper;

        public FoodService()
        {
            _foodRepository = new FoodRepository(DataStore.Instance.State.Foods);

            _modelMapper = new DtoModelMapper();
        }

        public FoodService(IFoodRepository foodRepository, DtoModelMapper modelMapper)
        {
            _foodRepository = foodRepository;
            _modelMapper = modelMapper;
        }

        public FoodDto GetFoodById(Guid id)
        {
            Food food = _foodRepository.GetById(id);
            FoodDto foodDto = _modelMapper.ToFoodDto(food);

            return foodDto;
        }

        public IList<FoodDto> GetFoods()
        {
            IList<Food> foods = _foodRepository.GetAll();
            IList<FoodDto> foodDtos = foods
                .Select(s => _modelMapper.ToFoodDto(s))
                .ToList();

            return foodDtos;
        }

        public FoodDto AddFood(FoodDto dto)
        {
            Food food = _modelMapper.FromFoodDto(dto);
            Food createdFood =  _foodRepository.Add(food);
            FoodDto createdFoodDto = _modelMapper.ToFoodDto(createdFood);

            return createdFoodDto;
        }

        public void DeleteFood(Guid food)
        {
            _foodRepository.Delete(food);
        }

        public FoodDto UpdateFood(FoodDto dto)
        {
            Food food = _modelMapper.FromFoodDto(dto);
            Food updatedFood = _foodRepository.Update(food);

            return _modelMapper.ToFoodDto(updatedFood);
        }

        public FoodDto Save(FoodDto foodDto)
        {
            Food food = _modelMapper.FromFoodDto(foodDto);
            Food updated = _foodRepository.CreateOrUpdate(food);
            FoodDto updatedDto = _modelMapper.ToFoodDto(updated);

            return updatedDto;
        }

    }
}