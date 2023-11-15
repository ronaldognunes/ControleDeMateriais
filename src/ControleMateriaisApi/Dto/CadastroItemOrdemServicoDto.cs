namespace ControleMateriaisApi.Dto
{
    public class CadastroItemOrdemServicoDto
    {
        public int? Quantidade { get; set; }
        public int? IdMaterial { get; set; }
        public int? IdOs { get; set; }


        public IList<string> ValidarCadastroMateriais()
        {
            var mensagens = new List<string>();
            if (Quantidade is null)
                mensagens.Add("Obrigatório informar quantidade.");

            if (IdMaterial is null)
                mensagens.Add("Obrigatório informar Id do Material.");

            return mensagens;
        }
    }
}
