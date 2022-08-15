namespace ControleMateriaisApi.Domain
{
    public class SaidaMaterial:Entity
    {
        public int IdSaida { get; set; }
        public int IdMaterial { get; set; }
        public int Quantidade { get; set; }
        public Saida Saida { get; set; }
        public Material Material { get; set; }
    }
}
