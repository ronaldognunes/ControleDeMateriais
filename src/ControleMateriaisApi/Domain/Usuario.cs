using ControleMateriaisApi.Domain.Enum;

namespace ControleMateriaisApi.Domain
{
    public class Usuario:Entity
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public TipoUsuario? Perfil { get; set; }
        public int? CodigoRecuperarSenha { get; set; }
    }
}
