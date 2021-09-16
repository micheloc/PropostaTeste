using LibraryAPP._Base.AppService;
using LibraryAPP.Interfaces;
using LibraryDomain.Entities;
using LibraryDomain.Interfaces.Service;

namespace LibraryAPP.AppService
{
    public class SexoAppService : AppServices<Sexo>, ISexoAppService
    {
        private readonly ISexoService _sexoService;

        public SexoAppService(ISexoService sexoServices)
            : base(sexoServices)
        {
            _sexoService = sexoServices;
        }
    }
}
