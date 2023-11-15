using System.ComponentModel.DataAnnotations;

namespace ControleMaterialWeb.Models.Usuario
{
    public class CadastroUsuarioDto
    {
        [Required(ErrorMessage = "Nome é Obrigatório")]        
        public string? Nome { get; set; }
        [Required(ErrorMessage = "Email é Obrigatório")]
        [EmailAddress(ErrorMessage = "Email não é valido")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Senha é obrigatória")]
        public string? Senha { get; set; }
        [Required(ErrorMessage = "Confirmar senha")]
        public string? ConfirmacaoSenha { get; set; }
        public TipoUsuario? Perfil { get; set; }
    }
}
