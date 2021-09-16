
using FluentValidation.Results;
using LibraryDomain.Interfaces.Repository._Base;
using LibraryInfraData.Context;
using LibraryInfraData.Context.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace LibraryInfraData.Repositories._Base
{
    public class RepositoryBase<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class
    {
        private readonly IDbContext _dbContext;
        private readonly IDbSet<TEntity> _dbSet;

        public RepositoryBase()
        {
            _dbContext = new ContextConnection();
            _dbSet = _dbContext.Set<TEntity>();
        }

        protected DbContext Context
        {
            get { return (DbContext)_dbContext; }
        }

        public void RefreshEntity(TEntity entity)
        {
            _dbContext.Entry(entity).Reload();
        }

        public ValidationResult Add(TEntity entity)
        {
            //entity.GetType().GetProperty("objID").SetValue(entity, Guid.NewGuid());
            _dbContext.Set<TEntity>().Add(entity);

            ValidationResult vr = _dbContext.SaveChanges();

            if (!vr.IsValid)
                _dbContext.Set<TEntity>().Remove(entity);

            return vr;
        }
        public TEntity Find(int Id)
        {
            return _dbContext.Set<TEntity>().Find(Id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        public ValidationResult Remove(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            return (_dbContext.SaveChanges());
        }

        public ValidationResult Update(TEntity entity)
        {
            _dbContext.Entry<TEntity>(entity).State = System.Data.Entity.EntityState.Modified;
            return (_dbContext.SaveChanges());
        }



        #region Dispose

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;

            if (Context == null) return;
            Context.Dispose();
        }

        #endregion
    }
}