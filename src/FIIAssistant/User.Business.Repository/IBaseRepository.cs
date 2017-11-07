using System;
using System.Linq;
using User.Data.Model.Common;

namespace User.Business.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : Entity
    {
        IQueryable<TEntity> GetAll();
        TEntity GetById(Guid id);
        void Add(TEntity student);
        void Update(TEntity student);
        void Delete(Guid id);
    }
}
