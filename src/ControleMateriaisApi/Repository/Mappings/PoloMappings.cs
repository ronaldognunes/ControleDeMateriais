using ControleMateriaisApi.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleMateriaisApi.Repository.Mappings
{
    public class PoloMappings : IEntityTypeConfiguration<Polo>
    {
        public void Configure(EntityTypeBuilder<Polo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("polo");
        }
    }
}
