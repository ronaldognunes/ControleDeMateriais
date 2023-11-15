namespace ControleMateriaisApi.Dto
{
    public class ResponseDto<T> where T : class
    {
        public List<string> MensagensDeErros { get; } = new List<string>();
        public bool Sucesso{ get; set; }
        public T? result { get; set; }
        public int? TotalDeRegistros { get; set; }
        public int? TotalDePaginas { get; set; }


    }
}
