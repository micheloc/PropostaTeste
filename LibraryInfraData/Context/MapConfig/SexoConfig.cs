using LibraryDomain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace LibraryInfraData.Context.MapConfig
{
    public class SexoConfig : EntityTypeConfiguration<Sexo>
    {
        public SexoConfig()
        {
            HasKey(o => o.SexoId); 

            Property(o => o.Descricao)
                .IsRequired()
                .HasMaxLength(15)
                .HasColumnType("varchar"); 
        }
    }
}
