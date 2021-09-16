using LibraryDomain.Entities;
using LibraryInfraData.Context.Common;
using LibraryInfraData.Context.MapConfig;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryInfraData.Context
{
    public class ContextConnection : BaseContext
    {
        public ContextConnection()
            : base("ProjetoTeste")
        {
        }

        DbSet<Usuario> Usuario { get; set; }
        DbSet<Sexo> Sexo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new SexoConfig());
            modelBuilder.Configurations.Add(new UsuarioConfig());

            base.OnModelCreating(modelBuilder); 
        }

    }
}
