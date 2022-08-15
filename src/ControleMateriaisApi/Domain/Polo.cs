namespace ControleMateriaisApi.Domain
{
    public class Polo:Entity
    {
        public Polo()
        {
            Entradas = new List<Entrada>();
            Saidas = new List<Saida>();
        }
        public string? NomePolo { get; set; }
        public string? Logradouro { get; set; }
        public int Numero { get; set; }
        public string? Cep { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Uf { get; set; }
        public List<Entrada> Entradas { get; set; }
        public List<Saida> Saidas { get; set; }
    }
}
