using DataLayer.Model;
using LogicLayer.DataTransferObjects;
using LogicLayer.ModelMapper;
using NUnit.Framework;
using System;

namespace UnitTest.LogicLayer
{
    public class DtoMapperTest
    {
        [SetUp]
        public void Setup()
        {
        }

        #region From model to DTO
        [Test]
        public void ToFoodDto_MapFoodFromModelToDto()
        {
            Guid id = new Guid("0f8fad5b-d9cb-469f-a165-70867728950e");
            string name = "Test food";
            int kcal = 100;
            float protein = 5.5f;
            bool isVegetarian = true;

            Food food = new Food()
            {
                Id = id,
                Name = name,
                Kcal = kcal,
                Protein = protein,
                IsVegetarian = isVegetarian
            };

            DtoModelMapper mapper = new DtoModelMapper();

            FoodDto foodDto = mapper.ToFoodDto(food);

            Assert.AreEqual(id, foodDto.Id, "Copied 'Id' has invalid value");
            Assert.AreEqual(name, foodDto.Name, "Copied 'name' has invalid value");
            Assert.AreEqual(kcal, foodDto.Kcal, "Copied 'kcal' has invalid value");
            Assert.AreEqual(protein, foodDto.Protein, "Copied 'protein' has invalid value");
            Assert.AreEqual(isVegetarian, foodDto.IsVegetarian, "Copied 'is vegetarian' has invalid value");
        }

        [Test]
        public void ToUserDto_MapUserFromModelToDto()
        {
            Guid id = new Guid("0f8fad5b-d9cb-469f-a165-70867728950e");
            string login = "Login test";
            string firstName = "John";
            string phone = "123123123";

            User user = new User()
            {
                Id = id,
                Login = login,
                FirstName = firstName,
                Phone = phone
            };

            DtoModelMapper mapper = new DtoModelMapper();

            UserDto userDto = mapper.ToUserDto(user);

            Assert.AreEqual(id, userDto.Id, "Copied 'Id' has invalid value");
            Assert.AreEqual(login, userDto.Login, "Copied 'login' has invalid value");
            Assert.AreEqual(firstName, userDto.FirstName, "Copied 'first name' has invalid value");
            Assert.AreEqual(phone, userDto.Phone, "Copied 'phone' has invalid value");
        }

        [Test]
        public void ToInformationDto_MapInformationFromModelToDto()
        {
            Guid id = new Guid("0f8fad5b-d9cb-469f-a165-70867728950e");
            string content = "Content test";
            bool isDeleted = false;

            Information information = new Information()
            {
                Id = id,
                IsDeleted = isDeleted,
                Content = content
            };

            DtoModelMapper mapper = new DtoModelMapper();

            InformationDto informationDto = mapper.ToInformationDto(information);

            Assert.AreEqual(id, informationDto.Id, "Copied 'Id' has invalid value");
            Assert.AreEqual(content, informationDto.Content, "Copied 'content' has invalid value");
            Assert.AreEqual(isDeleted, informationDto.IsDeleted, "Copied 'is deleted' has invalid value");
        }
        #endregion

        #region From DTO to model
        [Test]
        public void FromFoodDto_MapFoodFromDtoToModel()
        {
            Guid id = new Guid("0f8fad5b-d9cb-469f-a165-70867728950e");
            string name = "Test food";
            int kcal = 100;
            float protein = 5.5f;
            bool isVegetarian = true;

            FoodDto foodDto = new FoodDto()
            {
                Id = id,
                Name = name,
                Kcal = kcal,
                Protein = protein,
                IsVegetarian = isVegetarian
            };

            DtoModelMapper mapper = new DtoModelMapper();

            Food food = mapper.FromFoodDto(foodDto);

            Assert.AreEqual(id, food.Id, "Copied 'Id' has invalid value");
            Assert.AreEqual(name, food.Name, "Copied 'name' has invalid value");
            Assert.AreEqual(kcal, food.Kcal, "Copied 'kcal' has invalid value");
            Assert.AreEqual(protein, food.Protein, "Copied 'protein' has invalid value");
            Assert.AreEqual(isVegetarian, food.IsVegetarian, "Copied 'is vegetarian' has invalid value");
        }

        [Test]
        public void FromUserDto_MapUserFromDtoToModel()
        {
            Guid id = new Guid("0f8fad5b-d9cb-469f-a165-70867728950e");
            string login = "Login test";
            string firstName = "John";
            string phone = "123123123";

            UserDto userDto = new UserDto()
            {
                Id = id,
                Login = login,
                FirstName = firstName,
                Phone = phone
            };

            DtoModelMapper mapper = new DtoModelMapper();

            User user = mapper.FromUserDto(userDto);

            Assert.AreEqual(id, user.Id, "Copied 'Id' has invalid value");
            Assert.AreEqual(login, user.Login, "Copied 'login' has invalid value");
            Assert.AreEqual(firstName, user.FirstName, "Copied 'first name' has invalid value");
            Assert.AreEqual(phone, user.Phone, "Copied 'phone' has invalid value");
        }

        [Test]
        public void FromInformationDto_MapInformationFromDtoToModel()
        {
            Guid id = new Guid("0f8fad5b-d9cb-469f-a165-70867728950e");
            string content = "Content test";
            bool isDeleted = false;

            InformationDto informationDto = new InformationDto()
            {
                Id = id,
                IsDeleted = isDeleted,
                Content = content
            };

            DtoModelMapper mapper = new DtoModelMapper();

            Information information = mapper.FromInformationDto(informationDto);

            Assert.AreEqual(id, information.Id, "Copied 'Id' has invalid value");
            Assert.AreEqual(content, information.Content, "Copied 'content' has invalid value");
            Assert.AreEqual(isDeleted, information.IsDeleted, "Copied 'is deleted' has invalid value");
        }
        #endregion
    }
}