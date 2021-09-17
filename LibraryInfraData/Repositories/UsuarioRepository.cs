using LibraryDomain.Entities;
using LibraryDomain.Interfaces.Repository;
using LibraryInfraData.Repositories._Base;
using System.Collections.Generic;
using System.Text;

namespace LibraryInfraData.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public IEnumerable<Usuario> GetListUser(string filter)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine("SELECT * FROM Usuario WHERE Nome LIKE'%" + filter + "%'");
            return Context.Database.SqlQuery<Usuario>(query.ToString());
        }
    }
}
