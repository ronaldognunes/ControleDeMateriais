using AutoMapper;
using ControleMateriaisApi.Domain;
using ControleMateriaisApi.Dto;
using ControleMateriaisApi.Repository.Interfaces;
using ControleMateriaisApi.Services.Interfaces;

namespace ControleMateriaisApi.Services
{
    public class EntradaService : IEntradaService
    {
        private readonly IEntradaRepository _repository;
        private readonly IMapper _mapper;
        public EntradaService(IEntradaRepository repository,
                              IMapper mapper  )
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ResponseDto<EntradaDto>> AlterarEntradaAsync(int id, EntradaDto entrada)
        {
            var response = new ResponseDto<EntradaDto>();
            var Existe = await _repository.RecuperarPorIdAsync(id);
            if (Existe is null)
            {
                response.MensagensDeErros.Add("Ordem de serviço não existe");
                response.Sucesso = false;
                return response;
            }
            var os = _mapper.Map<Entrada>(entrada);
            response.Sucesso = await _repository.AlterarAsync(os);
            return response;
        }

        public async Task<ResponseDto<EntradaDto>> CadastrarEntradaAsync(EntradaDto entrada)
        {
            var response = new ResponseDto<EntradaDto>();
            var os = _mapper.Map<Entrada>(entrada);
            response.Sucesso = await _repository.CadastrarAsync(os);
            return response;
        }

        public async Task<ResponseDto<EntradaDto>> ConsultarEntradaPorIdAsync(int id)
        {
            var response = new ResponseDto<EntradaDto>();
            var Existe = await _repository.RecuperarPorIdAsync(id);
            if (Existe is null)
            {
                response.MensagensDeErros.Add("Ordem de serviço não existe");
                response.Sucesso = false;
                return response;
            }
            response.result = _mapper.Map<EntradaDto>(Existe);
            response.Sucesso = true;
            return response;
        }

        public async Task<ResponseDto<IList<EntradaDto>>> ConsultarEntradaPorNomesAsync(string nome)
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

        public async Task<ResponseDto<EntradaDto>> DeletarEntradaAsync(int id)
        {
            var response = new ResponseDto<EntradaDto>();
            var Existe = await _repository.RecuperarPorIdAsync(id);
            if (Existe is null)
            {
                response.MensagensDeErros.Add("Ordem de serviço não existe");
                response.Sucesso = false;
                return response;
            }
            var os = _mapper.Map<Entrada>(Existe);
            response.Sucesso = await _repository.DeletarAsync(os);
            return response;
        }

        public async Task<ResponseDto<IList<EntradaDto>>> ListarTodasEntradasAsync()
        {
            var response = new ResponseDto<IList<EntradaDto>>();
            var Existe = await _repository.RecuperarTodosAsync();
            if (!Existe.Any())
            {
                response.MensagensDeErros.Add("Ordem de serviço não existe");
                response.Sucesso = false;
                return response;
            }
            response.result = _mapper.Map<IList<EntradaDto>>(Existe);
            response.Sucesso = true;
            return response;
        }
    }
}
