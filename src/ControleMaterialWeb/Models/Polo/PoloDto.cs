namespace ControleMaterialWeb.Models.Polo
{
    public class PoloDto
    {
        public int Id { get; set; }
        public DateTime? DataCadastro { get; set; }
        public string? NomePolo { get; set; }
        public string? Logradouro { get; set; }
        public int? Numero { get; set; }
        public string? Cep { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Uf { get; set; }
    }
}
