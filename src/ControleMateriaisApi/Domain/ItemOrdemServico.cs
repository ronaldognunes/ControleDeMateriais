namespace ControleMateriaisApi.Domain
{
    public class ItemOrdemServico:Entity
    {        
        public int Quantidade { get; set; }
        public int? IdOs { get; set; }
        public int? IdMaterial { get; set; }
        public Material? Material { get; set; }
        public OrdemServico? OrdemServico { get; set; }
    }
}
