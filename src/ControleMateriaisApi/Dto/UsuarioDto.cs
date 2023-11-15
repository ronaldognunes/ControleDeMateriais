using ControleMateriaisApi.Domain.Enum;

namespace ControleMateriaisApi.Dto
{
    public class UsuarioDto
    {
        public int? Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }        
        public TipoUsuario? Perfil { get; set; }        
        public DateTime? DataCadastro { get; set; }

    }
}
