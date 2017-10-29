﻿using System;
using System.Linq;

namespace Commons {
    public interface IBaseRepository<TEntity> where TEntity : Entity {
        IQueryable<TEntity> GetAll();
        TEntity GetById(Guid id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(Guid id);
    }
}