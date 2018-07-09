using System;
using System.Linq;
using System.Linq.Expressions;
using EjemploPersonas.Models;

namespace EjemploPersonas.DAL
{
    public class Repository<TEntity> : IRepository<TEntity>, IDisposable where TEntity : class
    {
        EjemploPersonasDBEntities Context;

        public Repository()
        {
            Context = new EjemploPersonasDBEntities();
        }

        public TEntity Create(TEntity entity)
        {
            return Context.Set<TEntity>().Add(entity);
        }


        public TEntity Update(TEntity entity)
        {
            Context.Entry<TEntity>(entity).State = System.Data.Entity.EntityState.Modified;
            return entity;
        }


        public void Delete(long id)
        {
            var item = Context.Set<TEntity>().Find(id);
            Context.Set<TEntity>().Remove(item);
        }

        public void Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void Delete(Expression<Func<TEntity, bool>> where)
        {
            var items = Context.Set<TEntity>().Where(where).AsEnumerable();
            foreach (var item in items)
            {
                Context.Set<TEntity>().Remove(item);
            }
        }


        public TEntity Find(long id)
        {
            return Context.Set<TEntity>().Find(id);
        }


        public IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> where = null)
        {
            return null != where ? Context.Set<TEntity>().Where(where) : Context.Set<TEntity>();
        }


        public TEntity Find(Expression<Func<TEntity, bool>> where = null)
        {
            return FindAll(where).FirstOrDefault();
        }



        public bool SaveChanges()
        {
            return 0 < Context.SaveChanges();
        }


        public void Dispose()
        {
            if (null != Context)
            {
                Context.Dispose();
            }
        }
    }
}
