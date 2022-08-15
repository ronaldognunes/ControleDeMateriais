using ControleMateriaisApi.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleMateriaisApi.Repository.Mappings
{
    public class SaidaMaterialMappings : IEntityTypeConfiguration<SaidaMaterial>
    {
        public void Configure(EntityTypeBuilder<SaidaMaterial> builder)
        {
            builder.ToTable("saidas_materiais");
            builder.HasOne(x => x.Material)
                .WithMany()
                .HasForeignKey(x => x.IdMaterial);

            builder.HasOne(x => x.Saida)
                .WithMany(x => x.Materiais)
                .HasForeignKey(x => x.IdSaida);
        }
    }
}
