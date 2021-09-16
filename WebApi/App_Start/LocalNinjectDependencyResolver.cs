using Ninject;
using Ninject.Web.WebApi;
using System.Web.Http.Dependencies;

namespace WebApi.App_Start
{
    public class LocalNinjectDependencyResolver : LocalNinjectDependencyScope, IDependencyResolver, System.Web.Mvc.IDependencyResolver
    {
        private readonly IKernel kernel;

        public LocalNinjectDependencyResolver(IKernel kernel)
            : base(kernel)
        {
            this.kernel = kernel;
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectDependencyScope(this.kernel.BeginBlock());
        }
    }
}