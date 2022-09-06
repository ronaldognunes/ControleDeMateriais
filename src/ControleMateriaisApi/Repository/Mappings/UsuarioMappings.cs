using ControleMateriaisApi.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleMateriaisApi.Repository.Mappings
{
    public class UsuarioMappings : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuarios");
            builder.HasKey( x => x.Id);

            builder.Property(x => x.DataCadastro)
                .HasColumnName("data_cadastro");

            builder.Property(x => x.Perfil)
                .HasColumnName("perfil");

            builder.Property(x => x.Senha)
                .HasColumnName("senha");

            builder.Property(x => x.Email)
                .HasColumnName("email");

            builder.Property(x => x.Nome)
                .HasColumnName("nome");

            builder.Property(x => x.Id)
                .HasColumnName("id_usuario");

            builder.Property(x => x.CodigoRecuperarSenha)
                .HasColumnName("codigo_senha");

            builder.HasIndex(x => x.Nome);
            builder.HasIndex(x => x.Email);
            builder.HasIndex(x => x.Senha);
            builder.HasIndex(x => x.CodigoRecuperarSenha);
            builder.HasIndex(x => new { x.Senha,x.Email});

        }
    }
}
