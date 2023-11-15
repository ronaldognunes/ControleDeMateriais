using ControleMateriaisApi.Domain.Enum;

namespace ControleMateriaisApi.Dto
{
    public class RetornoOrdemServicoDto
    {
        public RetornoOrdemServicoDto()
        {
            ItensOrdemServico = new List<ItemOrdemServicoDto>();
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
        public IList<ItemOrdemServicoDto> ItensOrdemServico { get; set; }
    }
}
