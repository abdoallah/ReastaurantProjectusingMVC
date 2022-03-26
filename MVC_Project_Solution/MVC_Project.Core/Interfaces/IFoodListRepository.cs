using Restaurant.Models;
using System.Collections.Generic;

namespace MVC_Project.EF.Repositories
{
    public interface IFoodListRepository : IBaseRepository<Food>
    {
        public IEnumerable<Food> GetFood();
    }
}