using ControleMaterialWeb.Models;

namespace ControleMateriaisApi.Dto
{
    public class AlteracaoItemOrdemServicoDto
    {
        public int? Id { get;set; }        
        public int? Quantidade { get; set; }
        public int? IdMaterial { get; set; }
        public int? IdOs { get; set; }
        public MaterialDto Material { get; set; }      

    }
}

