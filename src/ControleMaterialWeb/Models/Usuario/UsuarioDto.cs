using System.ComponentModel.DataAnnotations;

namespace ControleMaterialWeb.Models.Usuario
{
    public class UsuarioDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Nome { get; set; }
        [Required]
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public TipoUsuario? Perfil { get; set; }
        public string? Token { get; set; }
        public DateTime? DataCadastro { get; set; }
    }
}
