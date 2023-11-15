namespace ControleMateriaisApi.Dto
{
    public class ResetarSenhaDto
    {
        public int CodigoResetarSenha { get; set; }
        public string Email { get; set; } = string.Empty;
        public string SenhaNova { get; set; } = string.Empty;
        public string ConfirmacaoSenha { get; set; } = string.Empty;
    }
}
