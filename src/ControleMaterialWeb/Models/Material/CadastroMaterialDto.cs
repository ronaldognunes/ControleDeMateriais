using System.ComponentModel.DataAnnotations;

namespace ControleMaterialWeb.Models.Material
{
    public class CadastroMaterialDto
    {
        [Required(ErrorMessage = "Informe o nome do material")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Informe unidade de medida")]
        public string? UnidadeMedida { get; set; }
    }
}
