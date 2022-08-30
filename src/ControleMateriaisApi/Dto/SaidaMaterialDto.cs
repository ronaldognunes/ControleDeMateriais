namespace ControleMateriaisApi.Dto
{
    public class SaidaMaterialDto
    {
        public int? Id { get; set; }
        public DateTime? DataCadastro { get; set; }
        public int? IdSaida { get; set; }
        public int? IdMaterial { get; set; }
        public int? Quantidade { get; set; }

        public IList<string> ValidarCadastroMateriais()
        {
            var mensagens = new List<string>();
            if (Quantidade is null)
                mensagens.Add("Obrigatório informar quantidade.");

            if (IdSaida is null)
                mensagens.Add("Obrigatório informar Id da Saída.");

            if (IdMaterial is null)
                mensagens.Add("Obrigatório informar Id do Material.");

            return mensagens;
        }

        public IList<string> ValidarAlteracaoMateriais()
        {
            var mensagens = new List<string>();
            if (Id is null)
                mensagens.Add("Obrigatório informar Id Saída.");

            mensagens.AddRange(ValidarCadastroMateriais());

            return mensagens;
        }


    }
}
