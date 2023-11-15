namespace ControleMaterialWeb.Models
{
    public class ResponseDto<T> where T : class
    {
        public List<string> MensagensDeErros { get; set; } = new List<string>();
        public bool Sucesso { get; set; }
        public T Result { get; set; }
        public int TotalDeRegistros { get; set; }
        public int TotalDePaginas { get; set; }
    }
}
