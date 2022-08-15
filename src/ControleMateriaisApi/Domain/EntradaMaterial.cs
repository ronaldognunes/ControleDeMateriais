namespace ControleMateriaisApi.Domain
{
    public class EntradaMaterial:Entity
    {        
        public int Quantidade { get; set; }
        public int IdEntrada { get; set; }
        public int IdMaterial { get; set; }
        public Material? Material { get; set; }
        public Entrada? Entrada { get; set; }

    }
}
