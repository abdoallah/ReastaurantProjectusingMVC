using MVC_Project.EF.Repositories;
using Restaurant.Models;
using System.Collections.Generic;

namespace MVC_Project.Core.Interfaces
{
    public interface Imenu : IBaseRepository<Food>
    {
        //special method for menu model only 
        IEnumerable<Food> menu_getall();
    }
}
