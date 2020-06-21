using System.Collections.Generic;
using DataLayer.Interfaces;
using DataLayer.Model;

namespace DataLayer.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IList<User> users) 
            : base(users)
        {
        }
    }
}