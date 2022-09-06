namespace ControleMateriaisApi.Domain
{
    public class Polo:Entity
    {
        public Polo()
        {
            OrdensDeServicos = new List<OrdemServico>();
        }
        public string? NomePolo { get; set; }
        public string? Logradouro { get; set; }
        public int Numero { get; set; }
        public string? Cep { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Uf { get; set; }
        public List<OrdemServico> OrdensDeServicos { get; set; }
    }
}
