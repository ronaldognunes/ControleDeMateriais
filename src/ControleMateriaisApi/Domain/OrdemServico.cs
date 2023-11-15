using ControleMateriaisApi.Domain.Enum;

namespace ControleMateriaisApi.Domain
{
    public class OrdemServico:Entity
    {
        public OrdemServico()
        {
            ItensOrdemServico = new List<ItemOrdemServico>();
        }
        public string? Logradouro { get; set; }
        public int Numero { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Cep { get; set; }
        public string? Complemento { get; set; }
        public List<ItemOrdemServico> ItensOrdemServico { get; set; }
        public int IdPolo { get; set; }
        public TipoOrdemServico TipoOrdemDeServico { get; set; }
        public int? IdUsuario { get; set; }
        public Usuario? Usuario { get; set; }
        public Polo? Polo { get; set; }
    }
}
