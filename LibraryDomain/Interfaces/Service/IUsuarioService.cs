using LibraryDomain._Base.Interfaces.Service;
using LibraryDomain.Entities;
using System.Collections.Generic;

namespace LibraryDomain.Interfaces.Service
{
    public interface IUsuarioService : IService<Usuario>
    {
        IEnumerable<Usuario> GetListUser(string filter);
    }
}
