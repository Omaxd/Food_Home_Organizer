using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using DataLayer.Model;
using LogicLayer.DataTransferObjects;

namespace LogicLayer.ModelMapper
{
    public class DtoModelMapper
    {
        public Food FromFoodDto(FoodDto dto)
        {
            return MapObject<Food>(dto);
        }

        public FoodDto ToFoodDto(Food food)
        {
            return MapObject<FoodDto>(food);
        }

        public User FromUserDto(UserDto dto)
        {
            return MapObject<User>(dto);
        }

        public UserDto ToUserDto(User user)
        {
            return MapObject<UserDto>(user);
        }

        public CartDto ToCartDto(Cart cart)
        {
            return MapObject<CartDto>(cart);
        }

        public Cart FromCartDto(CartDto dto)
        {
            return MapObject<Cart>(dto);
        }

        public InformationDto ToInformationDto(Information information)
        {
            return MapObject<InformationDto>(information);
        }

        public Information FromInformationDto(InformationDto dto)
        {
            return MapObject<Information>(dto);
        }

        private T MapObject<T>(object item)
            where T : new()
        {
            T mappedObject = new T();

            PropertyInfo[] properties = item.GetType().GetProperties();
            PropertyInfo[] mappedProperties = mappedObject.GetType().GetProperties();

            foreach (PropertyInfo property in properties)
            {
                PropertyInfo mappedProperty = mappedProperties
                    .FirstOrDefault(mp => mp.Name == property.Name);

                if (mappedProperty == null)
                    continue;

                var value = property.GetValue(item);
                mappedProperty.SetValue(mappedObject, value);
            }

            return mappedObject;
        }
    }
}