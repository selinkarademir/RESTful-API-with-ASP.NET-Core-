using dbContext.Entities;
using dbContext.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace dbContext.Repository.Base
{
   public class BaseRepository<TEntity,TContext>:IRepository<TEntity> 
        where TEntity:class,IEntity,new() 
       where TContext:DbContext,new()
    {
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }
        public int GetCount(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().Where(filter).Count();
            }
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }
        public void AddRange(IEnumerable<TEntity> entities)
        {
            using (var context = new TContext())
            {
                context.AddRange(entities);
                context.SaveChanges();
            }
        }
        public void Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deleteEntity = context.Entry(entity);
                deleteEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            using (var context = new TContext())
            {
                context.RemoveRange(entities);
                context.SaveChanges();
            }
        }
        public void DeleteWithCond(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                var retVal = filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();

                DeleteRange(retVal);
            }
        }
        public List<TEntity> TakeCount(int count, Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().Take(count).ToList()
                    : context.Set<TEntity>().Where(filter).Take(count).ToList();
            }
        }

        public void AddRangeWithDelete(IEnumerable<TEntity> Addentities, IEnumerable<TEntity> Deleteentities)
        {
            using (var context = new TContext())
            {
                context.RemoveRange(Deleteentities);
                context.AddRange(Addentities);
                context.SaveChanges();
            }
        }

    }
}
