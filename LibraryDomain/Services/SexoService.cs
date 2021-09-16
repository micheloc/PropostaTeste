using LibraryDomain.Entities;
using LibraryDomain.Interfaces.Repository;
using LibraryDomain.Services._Base;

namespace LibraryDomain.Interfaces.Service
{
    public class SexoService : Service<Sexo>, ISexoService
    {
        private readonly ISexoRepository _repository;
        public SexoService(ISexoRepository repository)
           : base(repository)
        {
            _repository = repository;
        }


    }
}
