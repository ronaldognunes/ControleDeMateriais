namespace ControleMateriaisApi.Domain
{
    public class RelatorioOs
    {
        public int? IdOs { get; set; }
        public string? DataCadastro { get; set; }
        public int? IdMaterial { get; set; }
        public string? NomeMaterial { get; set; }
        public int? Quantidade { get; set; }
        public string? UnidadeMedida { get; set; }
        public string? TipoOrdemServico { get; set; }
    }
}
