using DataLayer.Model;
using LogicLayer.DataTransferObjects;
using LogicLayer.Services;
using NUnit.Framework;
using System;

namespace IntegrationTest.LogicLayer
{
    public class FoodServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddFood_ItemCountIsValid()
        {
            FoodService foodService = new FoodService();
            int foodCount = foodService.GetFoods().Count;
            int expectedFoodCountAfterAddOperation = foodCount + 1;

            FoodDto foodDto = new FoodDto()
            {
                Id = new Guid("0f8fad5b-d9cb-469f-a165-70867728950e")
            };

            foodService.AddFood(foodDto);
            int foodCountAfterAddOperation = foodService.GetFoods().Count;

            Assert.AreEqual(expectedFoodCountAfterAddOperation, foodCountAfterAddOperation, "AddFood operation end unsuccessfully");
        }
    }
}