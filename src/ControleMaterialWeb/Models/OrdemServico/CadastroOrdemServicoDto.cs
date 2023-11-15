using System.ComponentModel.DataAnnotations;

namespace ControleMaterialWeb.Models.OrdemServico
{
    public class CadastroOrdemServicoDto
    {
        public CadastroOrdemServicoDto()
        {
            Itens = new List<ItemOrdenServicoDto>();
        }
        [Required(ErrorMessage = "informe o logradouro")]
        [MaxLength(100)]
        public string? Logradouro { get; set; }
        [Required(ErrorMessage = "informe o Número")]
        public int? Numero { get; set; }

        [Required(ErrorMessage = "informe o bairro")]
        [MaxLength(50)]
        public string? Bairro { get; set; }

        [Required(ErrorMessage = "informe a cidade")]
        [MaxLength(50)]
        public string? Cidade { get; set; }

        [Required(ErrorMessage = "informe o cep")]
        [MaxLength(12)]
        public string? Cep { get; set; }
        public string? Complemento { get; set; }

        [Required(ErrorMessage = "informe o tipo de ordem de serviço")]     
        public TipoOrdemServico TipoOrdemDeServico { get; set; }

        [Required(ErrorMessage = "informe o polo de origem")]        
        public int? IdPolo { get; set; }
        public int? IdUsuario { get; set; }
        public IList<ItemOrdenServicoDto> Itens { get; set; }
    }
}
