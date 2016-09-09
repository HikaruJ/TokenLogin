using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MailOnRails.Repository
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity);
        IEnumerable<T> GetAll();
        T GetById(int id);
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
        IQueryable<T> Query(Expression<Func<T, bool>> where);

        void Delete(T entity);
        void Update(T entity);
    }
}
