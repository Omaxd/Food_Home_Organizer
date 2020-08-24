using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByLoginAndPassword(string login, string password);
    }
}
