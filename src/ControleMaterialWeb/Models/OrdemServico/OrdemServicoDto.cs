namespace ControleMaterialWeb.Models.OrdemServico
{
    public class OrdemServicoDto
    {
        public int? Id { get; set; }
        public DateTime? DataCadastro { get; set; }
        public string? Logradouro { get; set; }
        public int? Numero { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Cep { get; set; }
        public string? Complemento { get; set; }
        public TipoOrdemServico TipoOrdemDeServico { get; set; }
        public int? IdPolo { get; set; }
        public int? IdUsuario { get; set; }
    }
}
