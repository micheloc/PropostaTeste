using LibraryAPP._Base.AppService;
using LibraryAPP.AppService;
using LibraryAPP.Interfaces;
using LibraryAPP.Interfaces._Base;
using Ninject.Modules;

namespace LibraryInjectDependecies.Modules
{
    public class AppInjectionModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IAppService<>)).To(typeof(AppServices<>)); 
            Bind(typeof(IUsuarioAppService)).To(typeof(UsuarioAppService));
            Bind(typeof(ISexoAppService)).To(typeof(SexoAppService));
        }
    }
}
