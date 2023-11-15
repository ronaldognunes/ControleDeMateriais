using ControleMaterialWeb.Models.OrdemServico;

namespace ControleMaterialWeb.Models.NovaPasta
{
    public class RelatorioDto
    {
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public TipoOrdemServico TipoOrdem { get; set; }
    }
}
