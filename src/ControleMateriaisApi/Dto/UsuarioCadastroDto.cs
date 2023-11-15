using ControleMateriaisApi.Domain.Enum;

namespace ControleMateriaisApi.Dto
{
    public class UsuarioCadastroDto
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? ConfirmacaoSenha { get; set; }
        public TipoUsuario? Perfil { get; set; }

        public bool VerificaSeSenhaSaoIguais()
        {
            return Senha == ConfirmacaoSenha;
        }


        private bool VerificaNomeEhVazio()
        {
            return string.IsNullOrWhiteSpace(Nome);
        }

        private bool VerificaEmailEhVazio()
        {
            return string.IsNullOrWhiteSpace(Email);
        }

        private bool VerificaSenhaEhVazio()
        {
            return string.IsNullOrWhiteSpace(Senha);
        }

        private bool VerificaConfirmacaoSenhaEhVazio()
        {
            return string.IsNullOrWhiteSpace(ConfirmacaoSenha);
        }

        public IList<string> ValidaCadastroUsuario()
        {
            var mensagensErros = new List<string>();
            if (VerificaEmailEhVazio())
                mensagensErros.Add("Necessário Informar o Email");

            if (VerificaSenhaEhVazio())
                mensagensErros.Add("Necessário Informar o Senha");

            if (VerificaConfirmacaoSenhaEhVazio())
                mensagensErros.Add("Necessário Informar o Confirmação de senha");

            if (VerificaNomeEhVazio())
                mensagensErros.Add("Necessário Informar o Nome");

            if (!VerificaSeSenhaSaoIguais())
                mensagensErros.Add("Senhas não são iguais");

            return mensagensErros;

        }
    }
}
