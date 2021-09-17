using LibraryAPP.Interfaces._Base;
using LibraryDomain.Entities;
using System.Collections.Generic;

namespace LibraryAPP.Interfaces
{
    public interface IUsuarioAppService : IAppService<Usuario>
    {
        /// <summary>
        /// <para>Método utilizado para filtrar a lista de usuário</para>
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        IEnumerable<Usuario> GetListUser(string filter); 
    }
}
