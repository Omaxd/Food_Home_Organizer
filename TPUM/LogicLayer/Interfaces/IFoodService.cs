using System;
using System.Collections.Generic;
using DataLayer.Model;
using LogicLayer.DataTransferObjects;

namespace LogicLayer.Interfaces
{
    public interface IFoodService
    {
        FoodDto GetFoodById(Guid id);

        IList<FoodDto> GetFoods();

        FoodDto AddFood(FoodDto food);

        void DeleteFood(Guid foodId);

        FoodDto UpdateFood(FoodDto food);

        FoodDto Save(FoodDto food);
    }
}