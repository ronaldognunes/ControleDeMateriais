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
            builder.ToTable("polos");

            builder.Property(x => x.Id)
                .HasColumnName("id_polo");

            builder.Property(x => x.Bairro)
                .HasColumnName("bairro");

            builder.Property(x => x.Numero)
                .HasColumnName("numero");

            builder.Property(x => x.DataCadastro)
                .HasColumnName("data_cadastro");

            builder.Property(x => x.Cep)
                .HasColumnName("cep");

            builder.Property(x => x.Cidade)
                .HasColumnName("cidade");

            builder.Property(x => x.Logradouro)
                .HasColumnName("logradouro");

            builder.Property(x => x.NomePolo)
                .HasColumnName("nome_polo");

            builder.HasIndex(x => x.NomePolo);

        }
    }
}
