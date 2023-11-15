namespace ControleMateriaisApi.Dto
{
    public class AlteracaoItemOrdemServicoDto
    {
        public int? Id { get;set; }        
        public int? Quantidade { get; set; }
        public int? IdMaterial { get; set; }
        public int? IdOs { get; set; }


        public IList<string> ValidarDados()
        {
            var mensagens = new List<string>();
            if (Quantidade is null)
                mensagens.Add("Obrigatório informar quantidade.");

            if (IdMaterial is null)
                mensagens.Add("Obrigatório informar Id do Material.");

            if (Id is null)
                mensagens.Add("Obrigatório informar Id.");

            if (IdOs is null)
                mensagens.Add("Obrigatório informar Id da OS.");

            return mensagens;
        }
    }
}

