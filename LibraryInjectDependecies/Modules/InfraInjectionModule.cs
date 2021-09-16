using LibraryInfraData.Context.Common;
using LibraryInfraData.Context.Interfaces;
using Ninject.Modules;

namespace LibraryInjectDependecies.Modules
{
    public class InfraInjectionModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IDbContext)).To(typeof(BaseContext)); 
        }


    }
}
