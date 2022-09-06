using ControleMateriaisApi.Domain;

namespace ControleMateriaisApi.Dto
{
    public class PoloDto:Entity
    {
        public string? NomePolo { get; set; }
        public string? Logradouro { get; set; }
        public int? Numero { get; set; }
        public string? Cep { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Uf { get; set; }
    }
}
