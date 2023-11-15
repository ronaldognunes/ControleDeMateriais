using ControleMateriaisApi.Domain.Enum;

namespace ControleMateriaisApi.Dto
{
    public class AlteracaoOrdemServicoDto
    {
        public AlteracaoOrdemServicoDto()
        {
            ItensOrdemServico = new List<AlteracaoItemOrdemServicoDto>();
        }
        public int? Id { get; set; }
        public string? Logradouro { get; set; }
        public int? Numero { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Cep { get; set; }
        public string? Complemento { get; set; }
        public TipoOrdemServico TipoOrdemDeServico { get; set; }
        public int? IdPolo { get; set; }
        public int? IdUsuario { get; set; }
        public IList<AlteracaoItemOrdemServicoDto> ItensOrdemServico { get; set; }
        public IList<string> ValidaDados()
        {
            var mensagens = new List<string>();

            if (string.IsNullOrWhiteSpace(Logradouro))
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

            if (Id is null)
                mensagens.Add("Obrigatório informar Id.");

            foreach(var i in ItensOrdemServico)
            {
                var mensagensErrosItens = i.ValidarDados();
                mensagens.AddRange(mensagensErrosItens);
            }

            return mensagens;
        }
    }
}
