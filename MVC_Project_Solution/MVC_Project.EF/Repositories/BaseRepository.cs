using Microsoft.EntityFrameworkCore;
using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MVC_Project.EF.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected RestaurantService _Context;
        private DbSet<T> _dbSet;
        public BaseRepository(RestaurantService Context)
        {
            _Context = Context;
            _dbSet = _Context.Set<T>();
        }

        //GetById method 
        public T GetById(int id)
        {

            return _dbSet.Find(id);
        }
        //overload of GetById method to get by Expression
        public T GetById(Expression<Func<T, bool>> filter)
        {
            return _dbSet.FirstOrDefault(filter);
        }
        //return all items in selected model of <T>
        public IEnumerable<T> GetAll()
        {
            return _Context.Set<T>().ToList();
        }
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter)
        {
            return _Context.Set<T>().Where(filter).ToList();
        }
        //Add method
        public T Add(T entity)
        {
            _Context.Set<T>().Add(entity);
            return entity;
        }
        //update method
        public T Update(T entity)
        {
            _Context.Entry(entity).State = EntityState.Modified;
            return entity;

        }
        //delete method
        public void Delete(T entity)
        {
            _Context.Set<T>().Remove(entity);
        }

        public IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            _Context.Set<T>().AddRange(entities);
            _Context.SaveChanges();
            return entities;
        }

        //return matched item not by id by name for example  
        public T Find(Expression<Func<T, bool>> Criteria)
        {

            return _Context.Set<T>().SingleOrDefault(Criteria);
        }


        //attatch method
        public void Attatch(T entity)
        {
            _Context.Set<T>().Attach(entity);
        }
        //count method
        public int Count()
        {
            return _Context.Set<T>().Count();
        }


    }
}
