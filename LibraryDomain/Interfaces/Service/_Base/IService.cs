using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace LibraryDomain._Base.Interfaces.Service
{
    public interface IService<TEntity>
      where TEntity : class
    {
        TEntity Find(int objID);
        IEnumerable<TEntity> GetAll();
        ValidationResult Add(TEntity entity);
        ValidationResult Update(TEntity entity);
        ValidationResult Remove(TEntity entity);
        void Dispose();
    }
}
