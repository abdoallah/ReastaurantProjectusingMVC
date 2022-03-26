using Microsoft.EntityFrameworkCore;
using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Project.EF.Repositories
{
    public class OrderItemRepository : BaseRepository<OrderItem>, IOrderItemRepository
    {
        private RestaurantService _context;
        public OrderItemRepository(RestaurantService context) : base(context)
        {
            _context = context;
        }
        public IEnumerable<OrderItem> GetOrderItems(Expression<Func<OrderItem, bool>> filter)
        {
            return _context.OrderItems.Include(s => s.Food).Include(s => s.Order).Where(filter).ToList();
        }
    }
}
