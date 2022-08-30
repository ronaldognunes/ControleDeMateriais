namespace ControleMateriaisApi.Dto
{
    public class EntradaMaterialDto
    {
        public int? Id { get; set; }
        public DateTime? DataCadastro { get; set; }
        public int? Quantidade { get; set; }
        public int? IdEntrada { get; set; }
        public int? IdMaterial { get; set; }


        public IList<string> ValidarCadastroMateriais()
        {
            var mensagens = new List<string>();
            if (Quantidade is null)
                mensagens.Add("Obrigatório informar quantidade.");

            if (IdEntrada is null)
                mensagens.Add("Obrigatório informar Id da Entrada.");

            if (IdMaterial is null)
                mensagens.Add("Obrigatório informar Id do Material.");

            return mensagens;
        }

        public IList<string> ValidarAlteracaoMateriais()
        {
            var mensagens = new List<string>();
            if (Id is null)
                mensagens.Add("Obrigatório informar Id Entrada ");

            mensagens.AddRange(ValidarCadastroMateriais());

            return mensagens;
        }


    }
}
