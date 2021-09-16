using LibraryDomain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace LibraryInfraData.Context.MapConfig
{
    public class UsuarioConfig : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfig()
        {
            HasKey(o => o.UsuarioId); 
           
            Property(o => o.Nome)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnType("varchar");

            Property(o => o.DataNascimento)
                .IsRequired()
                .HasColumnType("DateTime");

            Property(o => o.Email)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar");

            Property(o => o.Senha)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnType("Varchar");

            Property(o => o.Ativo)
                .IsRequired()
                .HasColumnName("bit");

            HasRequired(o => o.Sexo)
            .WithMany(o => o.Usuario)
            .HasForeignKey(o => o.SexoId);

        }
    }
}
