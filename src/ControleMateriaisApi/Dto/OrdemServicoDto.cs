using ControleMateriaisApi.Domain.Enum;

namespace ControleMateriaisApi.Dto
{
    public class OrdemServicoDto
    {
        public OrdemServicoDto()
        {
            ItensOrdemDeServico = new List<ItemOrdemServicoDto>();
        }
        public int? Id { get; set; }
        public DateTime? DataCadastro { get; set; } 
        public string? Logradouro { get; set; }
        public int? Numero { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Cep { get; set; }
        public string? Complemento { get; set; }
        public List<ItemOrdemServicoDto> ItensOrdemDeServico { get; set; }
        public TipoOrdemServico TipoOrdemDeServico { get; set; }
        public int? IdPolo { get; set; }
        public int? IdUsuario { get; set; }

        public IList<string> ValidaCadastro()
        {
            var mensagens = new List<string>();

            if (string.IsNullOrWhiteSpace(Logradouro))
                mensagens.Add("Obrigatório informar logradouro.");

            if (Numero is null)
                mensagens.Add("Obrigatório informar Número do endereço.");

            if (string.IsNullOrWhiteSpace(Bairro))
                mensagens.Add("Obrigatório informar Bairro.");

            if (string.IsNullOrWhiteSpace(Cidade))
                mensagens.Add("Obrigatório informar Cidade.");

            if (string.IsNullOrWhiteSpace(Cep))
                mensagens.Add("Obrigatório informar Cep.");

            if (IdPolo is null)
                mensagens.Add("Obrigatório informar Id do Polo.");

            mensagens.AddRange(validaMateriais());

            return mensagens;
        }

        public IList<string> ValidaAlteracao()
        {
            var mensagens = new List<string>();

            if (Id is null)
                mensagens.Add("Obrigatório informar Id.");

            mensagens.AddRange(ValidaCadastro());
            mensagens.AddRange(validaMateriais("A"));

            return mensagens;
        }

        public IList<string> validaMateriais(string operacao = "I")
        {
            var mensagens = new List<string>();
            var temMateriais = !ItensOrdemDeServico.Any();
            if (temMateriais)
            {
                if (operacao == "I")
                { 
                    foreach(var material in ItensOrdemDeServico)                    
                        mensagens.AddRange(material.ValidarCadastroMateriais());                    
                }
                else
                {
                    foreach (var material in ItensOrdemDeServico)
                        mensagens.AddRange(material.ValidarAlteracaoMateriais());
                }
            }

            return mensagens;
        }
    }
}
