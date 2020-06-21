using System.Collections.Generic;
using DataLayer.Interfaces;
using DataLayer.Model;

namespace DataLayer.Repositories
{
    public class FoodRepository : Repository<Food>, IFoodRepository
    {
        public FoodRepository(IList<Food> foods) 
            : base(foods)
        {
        }
    }
}