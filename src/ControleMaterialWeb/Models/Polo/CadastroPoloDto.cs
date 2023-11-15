using System.ComponentModel.DataAnnotations;

namespace ControleMaterialWeb.Models.Polo
{
    public class CadastroPoloDto
    {
        [Required(ErrorMessage ="Obrigatório informar o nome do Polo")]
        [MaxLength(50, ErrorMessage = "Maximo de caracter excedido")]
        public string? NomePolo { get; set; }

        [MaxLength(50, ErrorMessage = "Maximo de caracter excedido")]
        [Required(ErrorMessage = "Obrigatório informar o logradouro")]
        public string? Logradouro { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o número")]        
        public int Numero { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o cep")]
        [MaxLength(50, ErrorMessage = "Maximo de caracter excedido")]
        public string? Cep { get; set; }
        [Required(ErrorMessage = "Obrigatório informar o bairro")]
        [MaxLength(50, ErrorMessage = "Maximo de caracter excedido")]
        public string? Bairro { get; set; }
        [Required(ErrorMessage = "Obrigatório informar o cidade")]
        [MaxLength(50, ErrorMessage = "Maximo de caracter excedido")]
        public string? Cidade { get; set; }
        
        [Required(ErrorMessage = "Obrigatório informar o UF")]
        [MaxLength(2,ErrorMessage ="Maximo de caracter excedido")]
        public string? Uf { get; set; }
    }
}
