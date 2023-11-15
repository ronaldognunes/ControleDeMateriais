using System.ComponentModel.DataAnnotations;


namespace ControleMaterialWeb.Models.Material
{
    public class MaterialModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome do material")]
        public string? Nome { get; set; }

        public DateTime? DataCadastro { get; set; }
        [Required(ErrorMessage = "Informe unidade de medida")]
        public string? UnidadeMedida { get; set; }
    }
}