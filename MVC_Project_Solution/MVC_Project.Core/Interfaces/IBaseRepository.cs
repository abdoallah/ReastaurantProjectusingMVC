using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MVC_Project.EF.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        T Add(T entity);
        IEnumerable<T> AddRange(IEnumerable<T> entities);
        void Attatch(T entity);
        int Count();
        void Delete(T entity);
        T Find(Expression<Func<T, bool>> Criteria);
        IEnumerable<T> GetAll();
        T GetById(int id);
        T GetById(Expression<Func<T, bool>> filter);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter);

        T Update(T entity);
    }
}