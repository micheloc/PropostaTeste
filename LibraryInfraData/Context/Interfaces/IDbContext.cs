using FluentValidation.Results;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace LibraryInfraData.Context.Interfaces
{
    public interface IDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        ValidationResult SaveChanges();
        void Dispose();
    }
}
