using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Commons {
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity {
        private readonly DbContext _context;

        protected BaseRepository(DbContext context) {
            _context = context;
        }

        public IQueryable<TEntity> GetAll() {
            return _context.Set<TEntity>().AsNoTracking();
        }

        public TEntity GetById(Guid id) {
            return _context.Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefault(e => e.Id == id);
        }

        public void Add(TEntity entity) {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Update(TEntity entity) {
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
        }

        public void Delete(Guid id) {
            var entity = GetById(id);
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }
    }
}