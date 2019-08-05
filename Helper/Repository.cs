using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace AnywayStore.Helper
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ISession _session;

        public Repository(ISession session)
        {
            _session = session;
        }

        #region Implementation of IRepository<T>

        public bool Add(T entity)
        {
            _session.Save(entity);

            return true;
        }

        public bool Add(IList<T> items)
        {
            foreach (T item in items)
            {
                _session.Save(item);
            }

            return true;
        }

        public bool Update(T entity)
        {
            _session.Update(entity);

            return true;
        }

        public bool Update(IList<T> items)
        {
            foreach (T item in items)
            {
                _session.Update(item);
            }

            return true;
        }

        public bool Delete(T entity)
        {
            _session.Delete(entity);

            return true;
        }

        public bool Delete(IList<T> entities)
        {
            foreach (T entity in entities)
            {
                _session.Delete(entity);
            }

            return true;
        }

        public IList<T> All()
        {
            return _session.Query<T>().ToList();
        }

        public IList<T> FindBy(Expression<Func<T, bool>> expression)
        {
            return FilterBy(expression).ToList();
        }

        public T FindBy(int id)
        {
            return _session.Get<T>(id);
        }

        public IList<T> FilterBy(Expression<Func<T, bool>> expression)
        {
            return All().AsQueryable().Where(expression).ToList();
        }

        #endregion
    }
}