using ControleMateriaisApi.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleMateriaisApi.Repository.Mappings
{
    public class MaterialMappings : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
            builder.ToTable("materiais");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.DataCadastro)
                .HasColumnName("data_cadastro");

            builder.Property(x => x.Id)
                .HasColumnName("id_material");

            builder.Property(x => x.UnidadeMedida)
                .HasColumnName("unidade_medida");

            builder.Property(x => x.Nome)
                .HasColumnName("nome");

            builder.HasIndex(x => x.UnidadeMedida);
            builder.HasIndex(x => x.Nome);

        }
    }
}
