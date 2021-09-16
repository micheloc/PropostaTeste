using LibraryDomain._Base.Interfaces.Service;
using LibraryDomain.Interfaces.Service;
using LibraryDomain.Services._Base;
using Ninject.Modules;

namespace LibraryInjectDependecies.Modules
{
    public class ServiceInjectionModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IService<>)).To(typeof(Service<>));
            Bind(typeof(IUsuarioService)).To(typeof(UsuarioService));
            Bind(typeof(ISexoService)).To(typeof(SexoService)); 
        }
    }
}
