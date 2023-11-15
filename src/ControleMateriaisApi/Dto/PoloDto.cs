using ControleMateriaisApi.Domain;

namespace ControleMateriaisApi.Dto
{
    public class PoloDto
    {
        public int? Id { get; set; }
        public DateTime? DataCadastro { get; set; } 
        public string? NomePolo { get; set; }
        public string? Logradouro { get; set; }
        public int? Numero { get; set; }
        public string? Cep { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Uf { get; set; }

        public IList<string> Validar()
        {
            var retorno = new List<string>();
            if (Id == null)
                retorno.Add("ID do polo é obrigatório");

            if (string.IsNullOrWhiteSpace(NomePolo))
                retorno.Add("Nome do Polo é obrigatório");

            if (string.IsNullOrWhiteSpace(Logradouro))
                retorno.Add("Logradouro é obrigatório");

            if (Numero == null)
                retorno.Add("Número é obrigatório");

            if (string.IsNullOrWhiteSpace(Cep))
                retorno.Add("Cep é obrigatório");

            if (string.IsNullOrWhiteSpace(Bairro))
                retorno.Add("Bairro é obrigatório");

            if (string.IsNullOrWhiteSpace(Cidade))
                retorno.Add("Cidade é obrigatória");

            if (string.IsNullOrWhiteSpace(Uf))
                retorno.Add("Uf é obrigatório");

            return retorno;
        }
    }
}
