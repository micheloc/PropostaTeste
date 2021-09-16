using FluentValidation.Results;
using LibraryAPP.Interfaces._Base;
using LibraryDomain._Base.Interfaces.Service;
using System;
using System.Collections.Generic;

namespace LibraryAPP._Base.AppService
{
    public class AppServices<TEntity> : IDisposable, IAppService<TEntity> where TEntity : class
    {
        private readonly IService<TEntity> _service;
        protected ValidationResult Result { get; set; }

        #region Ctor
        public AppServices(IService<TEntity> service)
        {
            this._service = service;
            this.Result = new ValidationResult();
        }
        #endregion

        #region CRUD
        public ValidationResult Add(TEntity entity)
        {
            Result = _service.Add(entity);
            return Result;
        }

        public ValidationResult Update(TEntity entity)
        {

            Result = _service.Update(entity);

            return Result;
        }

        public ValidationResult Remove(TEntity entity)
        {

            Result = _service.Remove(entity);
            return Result;
        }

        public TEntity Find(int Id)
        {
            return _service.Find(Id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _service.GetAll();
        }

        #endregion

        public void Dispose()
        {
            _service.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
