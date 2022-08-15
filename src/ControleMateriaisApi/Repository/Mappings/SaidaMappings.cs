using ControleMateriaisApi.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleMateriaisApi.Repository.Mappings
{
    public class SaidaMappings : IEntityTypeConfiguration<Saida>
    {
        public void Configure(EntityTypeBuilder<Saida> builder)
        {
            builder.ToTable("saidas");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Polo)
                .WithMany(x=>x.Saidas)
                .HasForeignKey(x=>x.IdPolo);
        }
    }
}
