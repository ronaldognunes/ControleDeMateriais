using ControleMateriaisApi.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleMateriaisApi.Repository.Mappings
{
    public class OrdemServicoMappings : IEntityTypeConfiguration<OrdemServico>
    {
        public void Configure(EntityTypeBuilder<OrdemServico> builder)
        {
            builder.ToTable("ordens_servico");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Bairro)
                .HasColumnName("bairro");

            builder.Property(x => x.Numero)
                .HasColumnName("numero");

            builder.Property(x => x.TipoOrdemDeServico)
                .HasColumnName("tipo_ordem_servico");

            builder.Property(x => x.DataCadastro)
                .HasColumnName("data_cadastro");

            builder.Property(x => x.Cep)
                .HasColumnName("cep");

            builder.Property(x => x.Cidade)
                .HasColumnName("cidade");

            builder.Property(x => x.Complemento)
                .HasColumnName("complemento");

            builder.Property(x => x.IdPolo)
                .HasColumnName("id_polo");

            builder.Property(x => x.Id)
                .HasColumnName("id_ordem_servico");

            builder.Property(x => x.Id)
                .HasColumnName("id_os");

            /* 1 para muitos polos*/
            builder.HasOne(x => x.Polo)
                .WithMany(x => x.OrdensDeServicos)
                .HasForeignKey(x => x.IdPolo);

            /* 1 para muitos usuários*/
            builder.HasOne(x => x.Usuario)
                .WithMany()
                .HasForeignKey(x => x.IdUsuario);


        }
    }
}
