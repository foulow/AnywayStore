using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace AnywayStore.Helper
{
    public interface IRepository<T> where T : class
    {
        bool Add(T entity);

        bool Add(IList<T> items);

        bool Update(T entity);

        bool Update(IList<T> items);

        bool Delete(T entity);

        bool Delete(IList<T> entities);

        IList<T> All();

        IList<T> FindBy(Expression<Func<T, bool>> expression);

        T FindBy(int id);

        IList<T> FilterBy(Expression<Func<T, bool>> expression);
    }
}