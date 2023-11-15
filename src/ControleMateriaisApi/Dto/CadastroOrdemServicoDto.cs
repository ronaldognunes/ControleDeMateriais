using ControleMateriaisApi.Domain;
using ControleMateriaisApi.Domain.Enum;
using System.Runtime.ConstrainedExecution;

namespace ControleMateriaisApi.Dto
{
    public class CadastroOrdemServicoDto
    {
        public CadastroOrdemServicoDto()
        {
            Itens = new List<CadastroItemOrdemServicoDto>();
        }
        public string? Logradouro { get; set; }
        public int? Numero { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Cep { get; set; }
        public string? Complemento { get; set; }
        public TipoOrdemServico TipoOrdemDeServico { get; set; }
        public int? IdPolo { get; set; }
        public int? IdUsuario { get; set; }
        public IList<CadastroItemOrdemServicoDto> Itens { get; set; }
        public IList<string> ValidaCadastro()
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

            return mensagens;
        }        
    }
}
