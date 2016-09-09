using MailOnRails.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace MailOnRails.Repository
{
    public abstract class RepositoryBase<T> where T : class, new()
    {
        #region Private Members

        private readonly IDbSet<T> dbset;

        #endregion

        #region Protected Properties

        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        protected ApplicationDbContext DbContext
        {
            get { return DatabaseFactory.Get(); }
        }

        #endregion

        #region CTOR

        protected RepositoryBase(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            dbset = DbContext.Set<T>();
        }

        #endregion

        #region Public Methods

        public virtual T Add(T entity)
        {
            dbset.Add(entity);
            return entity;
        }

        public virtual void Delete(T entity)
        {
            dbset.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbset.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                dbset.Remove(obj);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }

        public virtual T GetById(int id)
        {
            return dbset.Find(id);
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbset.Where(where).ToList();
        }

        public virtual IQueryable<T> Query(Expression<Func<T, bool>> where)
        {
            return dbset.Where(where);
        }

        public virtual void Update(T entity)
        {
            dbset.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        #endregion
    }
}
