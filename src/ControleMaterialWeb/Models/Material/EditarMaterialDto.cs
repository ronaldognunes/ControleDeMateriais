namespace ControleMaterialWeb.Models.Material
{
    public class EditarMaterialDto
    {
        public int Codigo { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string UnidadeDeMedida { get; set; } = string.Empty;
        public DateTime DataCadastro { get; set; }
    }
}
