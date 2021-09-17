using LibraryDomain.Entities;
using LibraryDomain.Interfaces.Repository;
using LibraryDomain.Services._Base;
using System.Collections.Generic;

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

        public IEnumerable<Usuario> GetListUser(string filter)
        {
            return _repository.GetListUser(filter); 
        }
    }
}
