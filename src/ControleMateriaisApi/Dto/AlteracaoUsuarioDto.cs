using ControleMateriaisApi.Domain.Enum;

namespace ControleMateriaisApi.Dto
{
    public class AlteracaoUsuarioDto
    {
        public int? Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? ConfirmacaoSenha { get; set; }
        public TipoUsuario? Perfil { get; set; }
        public string? Token { get; set; }
        public DateTime? DataCadastro { get; set; }

        public bool VerificaSeSenhaSaoIguais()
        {
            return Senha == ConfirmacaoSenha;
        }

        public bool VerificaIdEhVazio()
        {
            return Id == null;
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



        public IList<string> ValidaLogin()
        {
            var mensagensErros = new List<string>();
            if (VerificaEmailEhVazio())
                mensagensErros.Add("Necessário Informar o Email");

            if (VerificaSenhaEhVazio())
                mensagensErros.Add("Necessário Informar o Senha");

            return mensagensErros;

        }

        public IList<string> ValidaDeletarUsuario()
        {
            var mensagensErros = new List<string>();
            if (VerificaIdEhVazio())
                mensagensErros.Add("Necessário Informar o Id");

            return mensagensErros;

        }

        public IList<string> ValidaAlterarUsuario()
        {
            var mensagensErros = new List<string>();
            if (VerificaIdEhVazio())
                mensagensErros.Add("Necessário Informar o ID");

            if (VerificaEmailEhVazio())
                mensagensErros.Add("Necessário Informar o Email");

            if (VerificaSenhaEhVazio())
                mensagensErros.Add("Necessário Informar o Senha");

            if (VerificaNomeEhVazio())
                mensagensErros.Add("Necessário Informar o Nome");

            return mensagensErros;

        }
    }
}
