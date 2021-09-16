using LibraryDomain.Interfaces.Repository;
using LibraryDomain.Interfaces.Repository._Base;
using LibraryInfraData.Repositories;
using LibraryInfraData.Repositories._Base;
using Ninject.Modules;

namespace LibraryInjectDependecies.Modules
{
    public class RepositoryInjectionModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IRepository<>)).To(typeof(RepositoryBase<>));
            Bind(typeof(IUsuarioRepository)).To(typeof(UsuarioRepository));
            Bind(typeof(ISexoRepository)).To(typeof(SexoRepository)); 
        }

    }
}
