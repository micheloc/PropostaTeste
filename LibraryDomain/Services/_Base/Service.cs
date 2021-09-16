using FluentValidation.Results;
using LibraryDomain._Base.Interfaces.Service;
using LibraryDomain.Interfaces;
using LibraryDomain.Interfaces.Repository._Base;
using LibraryDomain.Interfaces.Service;
using System;
using System.Collections.Generic;

namespace LibraryDomain.Services._Base
{
    public class Service<TEntity> : IService<TEntity>
         where TEntity : class
    {
        #region Propriedades

        private readonly IRepository<TEntity> _repository;

        protected IRepository<TEntity> Repository
        {
            get { return _repository; }
        }

        #endregion

        #region Ctor

        public Service(
            IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Crud
        public virtual TEntity Find(int Id)
        {
            return _repository.Find(Id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual ValidationResult Add(TEntity entity)
        {

            var selfValidationEntity = entity as ISelfValidation;

            if (selfValidationEntity != null && !selfValidationEntity.IsValid)
                return selfValidationEntity.ValidationResult;

            return _repository.Add(entity);
        }

        public virtual ValidationResult Update(TEntity entity)
        {
            var selfValidationEntity = entity as ISelfValidation;
            if (selfValidationEntity != null && !selfValidationEntity.IsValid)
                return selfValidationEntity.ValidationResult;

            return _repository.Update(entity);
        }

        public virtual ValidationResult Remove(TEntity entity)
        {
            ValidationResult validationResult = new ValidationResult();
            try
            {
                ValidationResult command = _repository.Remove(entity);
                if (!command.IsValid)
                {
                    foreach (var error in command.Errors)
                    {
                        validationResult.Errors.Add(error);
                    }
                }
            }
            catch (Exception ex)
            {
                validationResult.Errors.Add(new ValidationFailure("ERRO", ex.Message));
            }

            return validationResult;
        }

        #endregion

        public virtual void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
