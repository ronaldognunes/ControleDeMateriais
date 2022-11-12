namespace ControleMateriaisApi.Domain
{
    //entidade
    public class Entity
    {
        public int? Id { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}
