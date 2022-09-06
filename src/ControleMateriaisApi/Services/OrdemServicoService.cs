using AutoMapper;
using ControleMateriaisApi.Domain;
using ControleMateriaisApi.Dto;
using ControleMateriaisApi.Repository.Interfaces;
using ControleMateriaisApi.Services.Interfaces;

namespace ControleMateriaisApi.Services
{
    public class OrdemServicoService : IOrdemServicoService
    {
        private readonly IOrdemServicoRepository _repository;
        private readonly IMapper _mapper;
        public OrdemServicoService(IOrdemServicoRepository repository,
                              IMapper mapper  )
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ResponseDto<OrdemServicoDto>> AlterarOsAsync(int id, OrdemServicoDto entrada)
        {
            var response = new ResponseDto<OrdemServicoDto>();
            var Existe = await _repository.RecuperarPorIdAsync(id);
            if (Existe is null)
            {
                response.MensagensDeErros.Add("Ordem de serviço não existe");
                response.Sucesso = false;
                return response;
            }
            var mensagensErros = entrada.ValidaAlteracao();
            if (mensagensErros.Any())
            {
                response.MensagensDeErros.AddRange(mensagensErros);
                response.Sucesso = false;
                return response;
            }

            var os = _mapper.Map<OrdemServico>(entrada);
            response.Sucesso = await _repository.AlterarAsync(os);
            return response;
        }

        public async Task<ResponseDto<OrdemServicoDto>> CadastrarOsAsync(OrdemServicoDto entrada)
        {
            var response = new ResponseDto<OrdemServicoDto>();
            var mensagensErros = entrada.ValidaCadastro();
            if (mensagensErros.Any())
            {
                response.MensagensDeErros.AddRange(mensagensErros);
                response.Sucesso = false;
                return response;
            }
            var os = _mapper.Map<OrdemServico>(entrada);
            response.Sucesso = await _repository.CadastrarAsync(os);
            return response;
        }

        public async Task<ResponseDto<OrdemServicoDto>> ConsultarOsPorIdAsync(int id)
        {
            var response = new ResponseDto<OrdemServicoDto>();
            var Existe = await _repository.RecuperarPorIdAsync(id);
            if (Existe is null)
            {
                response.MensagensDeErros.Add("Ordem de serviço não existe");
                response.Sucesso = false;
                return response;
            }
            response.result = _mapper.Map<OrdemServicoDto>(Existe);
            response.Sucesso = true;
            return response;
        }

        public async Task<ResponseDto<IList<OrdemServicoDto>>> ConsultarOsPorNomesAsync(string nome)
        {
            //var response = new ResponseDto<EntradaDto>();
            //var Existe = await _repository.RecuperarPorIdAsync(id);
            //if (Existe is null)
            //{
            //    response.MensagensDeErros.Add("Ordem de serviço não existe");
            //    response.Sucesso = false;
            //    return response;
            //}
            //var os = _mapper.Map<Entrada>(entrada);
            //response.Sucesso = await _repository.AlterarAsync(os);
            return null;
        }

        public async Task<ResponseDto<OrdemServicoDto>> DeletarOsAsync(int id)
        {
            var response = new ResponseDto<OrdemServicoDto>();
            var Existe = await _repository.RecuperarPorIdAsync(id);
            if (Existe is null)
            {
                response.MensagensDeErros.Add("Ordem de serviço não existe");
                response.Sucesso = false;
                return response;
            }
            var os = _mapper.Map<OrdemServico>(Existe);
            response.Sucesso = await _repository.DeletarAsync(os);
            return response;
        }

        public async Task<ResponseDto<IList<OrdemServicoDto>>> ListarTodasOsAsync()
        {
            var response = new ResponseDto<IList<OrdemServicoDto>>();
            var Existe = await _repository.RecuperarTodosAsync();
            if (!Existe.Any())
            {
                response.MensagensDeErros.Add("Ordem de serviço não existe");
                response.Sucesso = false;
                return response;
            }
            response.result = _mapper.Map<IList<OrdemServicoDto>>(Existe);
            response.Sucesso = true;
            return response;
        }
    }
}
