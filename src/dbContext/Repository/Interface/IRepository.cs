using dbContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace dbContext.Repository.Interface
{
   public interface IRepository<T> where T:class,IEntity,new ()
    {
        T Get(Expression<Func<T, bool>> filter = null);
        int GetCount(Expression<Func<T, bool>> filter = null);

        List<T> GetList(Expression<Func<T, bool>> filter = null);
        List<T> TakeCount(int count, Expression<Func<T, bool>> filter = null);
        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void AddRange(IEnumerable<T> entities);
        void AddRangeWithDelete(IEnumerable<T> Addentities, IEnumerable<T> Deleteentities);
        void DeleteRange(IEnumerable<T> entities);
        void DeleteWithCond(Expression<Func<T, bool>> filter = null);
    }
}
