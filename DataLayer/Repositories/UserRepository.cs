using System.Collections.Generic;
using System.Linq;
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

        public User GetUserByLoginAndPassword(string login, string password)
        {
            User user = database
                .Where(u => u.Login == login)
                .Where(u => u.Password == password)
                .FirstOrDefault();

            return user;
        }
    }
}