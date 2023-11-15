namespace ControleMaterialWeb.Models.Usuario
{
    public class ResetarSenhaDto
    {
        public int CodigoResetarSenha { get; set; }
        public string? Email { get; set; }
        public string? SenhaNova { get; set; }
        public string? ConfirmacaoSenha { get; set; }
    }
}
