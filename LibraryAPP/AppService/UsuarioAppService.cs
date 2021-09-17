using LibraryAPP._Base.AppService;
using LibraryAPP.Interfaces;
using LibraryDomain.Entities;
using LibraryDomain.Interfaces.Service;
using System.Collections.Generic;

namespace LibraryAPP.AppService
{
    public class UsuarioAppService : AppServices<Usuario>, IUsuarioAppService
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioAppService(IUsuarioService usuarioService)
            : base(usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public IEnumerable<Usuario> GetListUser(string filter)
        {
            return _usuarioService.GetListUser(filter); 
        }
    }
}
