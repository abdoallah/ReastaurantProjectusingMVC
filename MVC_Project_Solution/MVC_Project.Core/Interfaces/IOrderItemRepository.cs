using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MVC_Project.EF.Repositories
{
    public interface IOrderItemRepository
    {
        IEnumerable<OrderItem> GetOrderItems(Expression<Func<OrderItem, bool>> filter);
    }
}