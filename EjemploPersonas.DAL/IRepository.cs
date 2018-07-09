using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EjemploPersonas.DAL
{
    public interface IRepository<TEntity>
    {
        TEntity Create(TEntity entity);
        TEntity Update(TEntity entity);

        void Delete(long id);
        void Delete(TEntity entity);
        void Delete(Expression<Func<TEntity, bool>> where);

        TEntity Find(long id);
        TEntity Find(Expression<Func<TEntity, bool>> where = null);
        IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> where = null);

        bool SaveChanges();
    }
}
