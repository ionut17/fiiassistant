using System;
using System.Linq;
using EnsureThat;
using Microsoft.EntityFrameworkCore;
using User.Data.Model.Common;

namespace User.Business.Repository
{
    public class BaseRepository<TEntity> where TEntity : Entity
    {
        private readonly DbContext _context;

        protected BaseRepository(DbContext context)
        {
            Ensure.That(context).IsNotNull();

            _context = context;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsNoTracking();
        }

        public TEntity GetById(Guid id)
        {
            return _context.Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefault(e => e.Id == id);
        }

        public void Add(TEntity entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var entity = _context.Set<TEntity>().Single(e => e.Id == id);

            if (entity == null)
            {
                return;
            }

            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }
    }
}