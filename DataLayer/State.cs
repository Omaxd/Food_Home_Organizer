using System.Collections.Generic;
using DataLayer.Model;

namespace DataLayer
{
    public class State
    {
        public readonly IList<Food> Foods;

        public readonly IList<User> Users;

        public readonly IList<Information> Informations;

        public State(IList<Food> foods, IList<User> users, IList<Information> informations)
        {
            Foods = foods;
            Users = users;
            Informations = informations;
        }
    }
}
