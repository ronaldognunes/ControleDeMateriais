namespace ControleMateriaisApi.Domain
{
    public class Entrada:Entity
    {
        public Entrada()
        {
            Materiais = new List<EntradaMaterial>();
        }
        public string? Logradouro { get; set; }
        public int Numero { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Cep { get; set; }
        public string? Complemento { get; set; }
        public List<EntradaMaterial> Materiais { get; set; }
        public int IdPolo { get; set; }
        public Polo? Polo { get; set; }
    }
}
