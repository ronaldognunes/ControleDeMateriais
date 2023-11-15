namespace ControleMateriaisApi.Dto
{
    public class ItemOrdemServicoDto
    {
        public int Id { get; set; }
        public DateTime? DataCadastro { get; set; }
        public int? Quantidade { get; set; }
        public int? IdMaterial { get; set; }
        public int? IdOs { get; set; }
        public MaterialDto? Material { get; set; }


        public IList<string> ValidarCadastroMateriais()
        {
            var mensagens = new List<string>();
            if (Quantidade is null)
                mensagens.Add("Obrigatório informar quantidade.");

            if (IdMaterial is null)
                mensagens.Add("Obrigatório informar Id do Material.");

            if (IdOs is null)
                mensagens.Add("Obrigatório informar Id da OS.");

            return mensagens;
        }

        public IList<string> ValidarAlteracaoMateriais()
        {
            var mensagens = new List<string>();            
            mensagens.AddRange(ValidarCadastroMateriais());

            return mensagens;
        }


    }
}
