using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace VolvoTruck.Data.Interfaces.Base
{
    public interface IRepository<TEntity>
    {
        TEntity GetById(int id);
        void Save(TEntity entity);
        void SaveMany(List<TEntity> entityList);
        List<TEntity> Select(Expression<Func<TEntity, bool>> predicate);
        List<TEntity> SelectAll();
    }
}
