namespace ControleMateriaisApi.Dto
{
    public class CadastroItemOrdemServicoDto
    {
        public int? Quantidade { get; set; }
        public int? IdEntrada { get; set; }
        public int? IdMaterial { get; set; }
        public int? IdOs { get; set; }


        public IList<string> ValidarCadastroMateriais()
        {
            var mensagens = new List<string>();
            if (Quantidade is null)
                mensagens.Add("Obrigatório informar quantidade.");

            if (IdEntrada is null)
                mensagens.Add("Obrigatório informar Id da Entrada.");

            if (IdMaterial is null)
                mensagens.Add("Obrigatório informar Id do Material.");

            if (IdOs is null)
                mensagens.Add("Obrigatório informar Id da OS.");

            return mensagens;
        }
    }
}
