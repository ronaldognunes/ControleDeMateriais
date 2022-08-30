namespace ControleMateriaisApi.Dto
{
    public class SaidaDto
    {
        public SaidaDto()
        {
            Materiais = new List<SaidaMaterialDto>();
        }
        public int? Id { get; set; }
        public DateTime? DataCadastro { get; set; }
        public string? Logradouro { get; set; }
        public int? Numero { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Cep { get; set; }
        public string? Complemento { get; set; }
        public List<SaidaMaterialDto> Materiais { get; set; }
        public int? IdPolo { get; set; }

        public IList<string> ValidaCadastro()
        {
            var mensagens = new List<string>();

            if(string.IsNullOrWhiteSpace(Logradouro))
                mensagens.Add("Obrigatório informar logradouro.");

            if (Numero is null)
                mensagens.Add("Obrigatório informar Número do endereço.");

            if (string.IsNullOrWhiteSpace(Bairro))
                mensagens.Add("Obrigatório informar Bairro.");

            if (string.IsNullOrWhiteSpace(Cidade))
                mensagens.Add("Obrigatório informar Cidade.");

            if (string.IsNullOrWhiteSpace(Cep))
                mensagens.Add("Obrigatório informar Cep.");

            if (IdPolo is null)
                mensagens.Add("Obrigatório informar Id do Polo.");

            return mensagens;
        }

        public IList<string> ValidaAlteracao()
        {
            var mensagens = new List<string>();

            if (Id is null)
                mensagens.Add("Obrigatório informar Id.");

            mensagens.AddRange(ValidaCadastro());

            return mensagens;
        }
    }
}
