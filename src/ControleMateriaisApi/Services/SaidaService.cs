using AutoMapper;
using ControleMateriaisApi.Domain;
using ControleMateriaisApi.Dto;
using ControleMateriaisApi.Repository.Interfaces;
using ControleMateriaisApi.Services.Interfaces;

namespace ControleMateriaisApi.Services
{
    public class SaidaService : ISaidaService
    {
        private readonly ISaidaRepository _repository;
        private readonly IMapper _mapper;

        public SaidaService(ISaidaRepository repository,
                            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;   
        }
        public async Task<ResponseDto<SaidaDto>> AlterarSaidaAsync(int id, SaidaDto saida)
        {
            var response = new ResponseDto<SaidaDto>();
            var Existe = await _repository.RecuperarPorIdAsync(id);
            if (Existe is null)
            {
                response.MensagensDeErros.Add("Ordem de serviço não existe");
                response.Sucesso = false;
                return response;
            }
            var os = _mapper.Map<Saida>(saida);
            response.Sucesso = await _repository.AlterarAsync(os);
            return response;
        }

        public async Task<ResponseDto<SaidaDto>> CadastrarSaidalAsync(SaidaDto saida)
        {
            var response = new ResponseDto<SaidaDto>();
            var os = _mapper.Map<Saida>(saida);
            response.Sucesso = await _repository.CadastrarAsync(os);
            return response;
        }

        public async Task<ResponseDto<SaidaDto>> ConsultarSaidaPorIdAsync(int id)
        {
            var response = new ResponseDto<SaidaDto>();
            var Existe = await _repository.RecuperarPorIdAsync(id);
            if (Existe is null)
            {
                response.MensagensDeErros.Add("Ordem de serviço não existe");
                response.Sucesso = false;
                return response;
            }
            response.result = _mapper.Map<SaidaDto>(Existe);
            response.Sucesso = true;
            return response;
        }

        public async Task<ResponseDto<IList<SaidaDto>>> ConsultarSaidaPorNomesAsync(string nome)
        {
            //var response = new ResponseDto<SaidaDto>();
            //var Existe = await _repository.RecuperarPorIdAsync(id);
            //if (Existe is null)
            //{
            //    response.MensagensDeErros.Add("Ordem de serviço não existe");
            //    response.Sucesso = false;
            //    return response;
            //}
            //var os = _mapper.Map<Saida>(saida);
            //response.Sucesso = await _repository.AlterarAsync(os);
            return null;
        }

        public async Task<ResponseDto<SaidaDto>> DeletarSaidaAsync(int id)
        {
            var response = new ResponseDto<SaidaDto>();
            var Existe = await _repository.RecuperarPorIdAsync(id);
            if (Existe is null)
            {
                response.MensagensDeErros.Add("Ordem de serviço não existe");
                response.Sucesso = false;
                return response;
            }
            var os = _mapper.Map<Saida>(Existe);
            response.Sucesso = await _repository.DeletarAsync(os);
            return response;
        }

        public async Task<ResponseDto<IList<SaidaDto>>> ListarTodasSaidaAsync()
        {
            var response = new ResponseDto<IList<SaidaDto>>();
            var Existe = await _repository.RecuperarTodosAsync();
            if (!Existe.Any())
            {
                response.MensagensDeErros.Add("Ordens de serviços não existem");
                response.Sucesso = false;
                return response;
            }
            response.result = _mapper.Map<IList<SaidaDto>>(Existe);
            response.Sucesso = true;
            return response;
        }
    }
}
