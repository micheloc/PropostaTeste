using CommonServiceLocator.NinjectAdapter.Unofficial;
using LibraryInjectDependecies.Modules;
using Microsoft.Practices.ServiceLocation;
using Ninject;

namespace LibraryInjectDependecies
{
    public class IoC
    {
        public IKernel Kernel { get; private set; }

        public IoC()
        {
            Kernel = GetNinjectModules();
            ServiceLocator.SetLocatorProvider(() => new NinjectServiceLocator(Kernel));
        }

        public static StandardKernel GetNinjectModules()
        {
            return new StandardKernel(
                new ServiceInjectionModule(),
                new InfraInjectionModule(), 
                new RepositoryInjectionModule(), 
                new AppInjectionModule()
            );
        }
    }
}
