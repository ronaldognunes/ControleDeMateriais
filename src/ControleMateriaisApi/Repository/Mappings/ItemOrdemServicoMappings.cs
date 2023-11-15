using ControleMateriaisApi.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleMateriaisApi.Repository.Mappings
{
    public class ItemOrdemServicoMappings : IEntityTypeConfiguration<ItemOrdemServico>
    {
        public void Configure(EntityTypeBuilder<ItemOrdemServico> builder)
        {
            builder.ToTable("item_ordem_servico");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id_item_ordem_servico");

            builder.Property(x => x.IdMaterial)
                .HasColumnName("id_material");

            builder.Property(x => x.DataCadastro)
                .HasColumnName("data_cadastro");

            builder.Property(x => x.IdOs)
                .HasColumnName("id_ordem_servico");

            builder.Property(x =>x.Quantidade)
                .HasColumnName("quantidade");

            builder.HasIndex(x => x.IdMaterial);
            builder.HasIndex(x => x.IdOs);

            builder.HasOne(x => x.Material)
                .WithMany()
                .HasForeignKey(x => x.IdMaterial);

            builder.HasOne(x => x.OrdemServico)
                .WithMany(x => x.ItensOrdemServico)
                .HasForeignKey(x => x.IdOs);
            

        }
    }
}
