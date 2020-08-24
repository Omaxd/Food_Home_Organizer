using System;
using System.Collections.Generic;
using DataLayer.Model;
using LogicLayer.DataTransferObjects;

namespace LogicLayer.Interfaces
{
    public interface IUserService
    {
        UserDto GetUserById(Guid id);

        UserDto GetUserByLoginAndPassword(string login, string password);

        IList<UserDto> GetAllUsers();

        UserDto AddUser(UserDto dto);

        void DeleteUser(Guid user);

        UserDto UpdateUser(UserDto dto);

        UserDto Save(UserDto user);
    }
}
