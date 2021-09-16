using LibraryDomain.Entities;
using LibraryDomain.Interfaces.Repository;
using LibraryDomain.Services._Base;

namespace LibraryDomain.Interfaces.Service
{
    public class UsuarioService : Service<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        public UsuarioService(IUsuarioRepository repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
}
