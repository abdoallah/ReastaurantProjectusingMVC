using Microsoft.EntityFrameworkCore;
using Restaurant.Models;
using System.Collections.Generic;
using System.Linq;

namespace MVC_Project.EF.Repositories
{
    public class FoodListRepository : BaseRepository<Food>, IFoodListRepository
    {
        private readonly RestaurantService _context;

        public FoodListRepository(RestaurantService context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Food> GetFood()
        {
            return _context.Foods.Include(s => s.Category).ToList();
        }
    }
}
//protected RestaurantService _Context;
//public FoodListRepository(RestaurantService Context)
//{
//    _Context = Context;
//}
//public Food Add(Food entity)
//{
//    _Context.Add(entity);
//    _Context.SaveChanges();
//    return entity;

//}

//public IEnumerable<Food> AddRange(IEnumerable<Food> entities)
//{
//    throw new NotImplementedException();
//}

//public void Attatch(Food entity)
//{
//    throw new NotImplementedException();
//}

//public int Count()
//{
//    return _Context.Foods.Count();
//}

//public void Delete(Food entity)
//{
//    _Context.Remove(entity);
//    _Context.SaveChanges();
//}

//public Food Find(Expression<Func<Food, bool>> Criteria)
//{
//    throw new NotImplementedException();
//}

//public IEnumerable<Food> GetAll()
//{
//    return _Context.Foods.Include(s => s.Category).ToList();
//}

//public Food GetById(int id)
//{
//    return _Context.Foods.Find(id);
//}

//public Food Update(Food entity)
//{

//    _Context.Entry(entity).State = EntityState.Modified;
//    _Context.SaveChanges();
//    return entity;
//}