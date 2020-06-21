using System;
using DataLayer.Model;
using LogicLayer.DataTransferObjects;

namespace LogicLayer.Interfaces
{
    public interface ICartService
    {
        CartDto AddFoodToCart(Guid foodId, Guid userId);

        CartDto RemoveFoodFromCart(Guid foodId, Guid userId);

        int CalculateTotalKcal(Guid userId);

        CartDto GetCart(Guid userId);
    }
}