using ControleMateriaisApi.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleMateriaisApi.Repository.Mappings
{
    public class EntradaMaterialMappings : IEntityTypeConfiguration<EntradaMaterial>
    {
        public void Configure(EntityTypeBuilder<EntradaMaterial> builder)
        {
            builder.ToTable("entradas_materiais");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Material)
                .WithMany()
                .HasForeignKey(x => x.IdMaterial);

            builder.HasOne(x => x.Entrada)
                .WithMany(x => x.Materiais)
                .HasForeignKey(x => x.IdEntrada);
            

        }
    }
}
