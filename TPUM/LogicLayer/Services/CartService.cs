using System;
using System.Linq;
using DataLayer;
using DataLayer.Model;
using LogicLayer.DataTransferObjects;
using LogicLayer.ModelMapper;
using DataLayer.Interfaces;
using LogicLayer.Interfaces;
using DataLayer.Repositories;

namespace LogicLayer.Services
{
    public class CartService : ICartService
    {
        private readonly IUserRepository _userRepository;
        private readonly IFoodRepository _foodRepository;

        private readonly DtoModelMapper _dtoModelMapper;

        public CartService()
        {
            _userRepository = new UserRepository(DataStore.Instance.State.Users);
            _foodRepository = new FoodRepository(DataStore.Instance.State.Foods);

            _dtoModelMapper = new DtoModelMapper();
        }

        public CartService(IFoodRepository foodRepository, IUserRepository userRepository, DtoModelMapper dtoModelMapper)
        {
            _userRepository = userRepository;
            _foodRepository = foodRepository;

            _dtoModelMapper = dtoModelMapper;
        }

        public CartDto AddFoodToCart(Guid foodId, Guid userId)
        {
            User user = _userRepository.GetById(userId);
            Food food = _foodRepository.GetById(foodId);

            user.Cart.Foods.Add(food);
            CartDto cartDto = _dtoModelMapper.ToCartDto(user.Cart);

            return cartDto;
        }

        public CartDto RemoveFoodFromCart(Guid foodId, Guid userId)
        {
            User user = _userRepository.GetById(userId);
            Food food = _foodRepository.GetById(foodId);

            user.Cart.Foods.Remove(food);
            CartDto cartDto = _dtoModelMapper.ToCartDto(user.Cart);

            return cartDto;
        }

        public int CalculateTotalKcal(Guid userId)
        {
            User user = _userRepository.GetById(userId);

            int totalKcal = user.Cart.Foods
                .Sum(f => f.Kcal);

            return totalKcal;
        }

        public CartDto GetCart(Guid userId)
        {
            User user = _userRepository.GetById(userId);
            CartDto cartDto = _dtoModelMapper.ToCartDto(user.Cart);

            return cartDto;
        }
    }
}