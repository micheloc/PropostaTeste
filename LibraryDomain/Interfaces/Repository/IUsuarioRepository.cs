using LibraryDomain.Entities;
using LibraryDomain.Interfaces.Repository._Base;
using System.Collections.Generic;

namespace LibraryDomain.Interfaces.Repository
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        /// <summary>
        /// <para>Método utilizado para filtrar a lista de usuário</para>
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        IEnumerable<Usuario> GetListUser(string filter);
    }
}
