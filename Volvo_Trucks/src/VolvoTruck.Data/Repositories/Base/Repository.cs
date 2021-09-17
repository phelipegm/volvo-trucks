using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VolvoTruck.Data.Interfaces.Base;
using VolvoTruck.Domain.Entities;

namespace VolvoTruck.Data.Repositories.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        private readonly ApplicationDbContext _context;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }
        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().SingleOrDefault(e => e.Id == id);
        }

        public List<TEntity> Select(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate).ToList();
        }

        public List<TEntity> SelectAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public void Save(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }


        public void SaveMany(List<TEntity> entityList)
        {
            _context.Set<TEntity>().AddRange(entityList);
            _context.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
