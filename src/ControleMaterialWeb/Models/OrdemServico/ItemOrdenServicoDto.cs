using System.ComponentModel.DataAnnotations;

namespace ControleMaterialWeb.Models.OrdemServico
{
    public class ItemOrdenServicoDto
    {
        public int Quantidade { get; set; }
        public int IdMaterial { get; set; }
        public int IdOs { get; set; }
    }
}
