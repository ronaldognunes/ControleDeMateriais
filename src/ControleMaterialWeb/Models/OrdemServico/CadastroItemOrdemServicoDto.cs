using System.ComponentModel.DataAnnotations;

namespace ControleMaterialWeb.Models.OrdemServico
{
    public class CadastroItemOrdemServicoDto
    {
        [Required(ErrorMessage = "Quantidade Obrigatória")]
        [MaxLength(7)]
        public int Quantidade { get; set; }
        [Required(ErrorMessage = "Código do material Obrigatório")]
        public int IdMaterial { get; set; }
        public int IdOs { get; set; }
        public string Descricao { get; set; }

    }
}
