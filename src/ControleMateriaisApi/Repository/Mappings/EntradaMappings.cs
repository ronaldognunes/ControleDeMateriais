using ControleMateriaisApi.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleMateriaisApi.Repository.Mappings
{
    public class EntradaMappings : IEntityTypeConfiguration<Entrada>
    {
        public void Configure(EntityTypeBuilder<Entrada> builder)
        {
            builder.ToTable("entradas");
            builder.HasKey(x => x.Id);
            /* 1 para muitos*/
            builder.HasOne(x => x.Polo)
                .WithMany(x => x.Entradas)
                .HasForeignKey(x => x.IdPolo);


        }
    }
}
