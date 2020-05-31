using Microsoft.EntityFrameworkCore;
using ServiceMesh.Accounts.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace ServiceMesh.Accounts.Repositories
{
    using ServiceMesh.Framework;

    public class GenericRepository<TEntity> where TEntity : EntityBase
    {

        private readonly ServiceContext _context;

        public GenericRepository(ServiceContext context)
        {
            _context = context;
        }

        public TEntity GetById(Guid id)
        {
            return _context.Set<TEntity>().FirstOrDefault(e => e.Id == id);
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> expression)
        {
            return _context.Set<TEntity>().Where(expression);
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }

        public void Create(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Added;
        }

        public EntityState GetEntityState(TEntity entity)
        {
            return _context.Entry(entity).State;
        }

    }
}
