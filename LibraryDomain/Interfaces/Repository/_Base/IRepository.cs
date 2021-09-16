using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace LibraryDomain.Interfaces.Repository._Base
{
    public interface IRepository<TEntity>
      where TEntity : class
    {
        ValidationResult Add(TEntity entity);
        ValidationResult Update(TEntity entity);
        ValidationResult Remove(TEntity entity);
        TEntity Find(int objID);
        IEnumerable<TEntity> GetAll();
    }
}
