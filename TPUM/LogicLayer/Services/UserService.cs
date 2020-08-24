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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly DtoModelMapper _modelMapper;

        public UserService()
        {
            _userRepository = new UserRepository(DataStore.Instance.State.Users);
            _modelMapper = new DtoModelMapper();
        }

        public UserService(IUserRepository userRepository, DtoModelMapper modelMapper)
        {
            _userRepository = userRepository;
            _modelMapper = modelMapper;
        }

        public UserDto GetUserById(Guid id)
        {
            User user = _userRepository.GetById(id);
            UserDto userDto = _modelMapper.ToUserDto(user);

            return userDto;
        }

        public UserDto GetUserByLoginAndPassword(string login, string password)
        {
            User user = _userRepository.GetUserByLoginAndPassword(login, password);
            UserDto userDto = _modelMapper.ToUserDto(user);

            return userDto;
        }

        public IList<UserDto> GetAllUsers()
        {
            IList<User> users = _userRepository.GetAll();
            IList<UserDto> usersDto = users
                .Select(u => _modelMapper.ToUserDto(u))
                .ToList();

            return usersDto;
        }

        public UserDto AddUser(UserDto dto)
        {
            User user = _modelMapper.FromUserDto(dto);
            User createdUser = _userRepository.Add(user);
            UserDto createdUserDto = _modelMapper.ToUserDto(createdUser);

            return createdUserDto;
        }

        public void DeleteUser(Guid user)
        {
            _userRepository.Delete(user);
        }

        public UserDto UpdateUser(UserDto dto)
        {
            User user = _modelMapper.FromUserDto(dto);
            User updatedUser = _userRepository.Update(user);
            UserDto updatedUserDto = _modelMapper.ToUserDto(updatedUser);

            return updatedUserDto;
        }

        public UserDto Save(UserDto userDTO)
        {
            User user = _modelMapper.FromUserDto(userDTO);
            User updatedUser = _userRepository.CreateOrUpdate(user);
            UserDto updatedUserDto = _modelMapper.ToUserDto(updatedUser);

            return updatedUserDto;
        }
    }
}