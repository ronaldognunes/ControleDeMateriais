using AutoMapper;
using ControleMateriaisApi.Domain;
using ControleMateriaisApi.Dto;
using ControleMateriaisApi.Repository.Interfaces;
using ControleMateriaisApi.Services.Interfaces;

namespace ControleMateriaisApi.Services
{
    public class PoloService : IPoloService
    {
        private readonly IPoloRepository _repository;
        private readonly IMapper _mapper;

        public PoloService(IPoloRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<PoloDto>> AlterarPoloAsync(int id, PoloDto polo)
        {
            var response = new ResponseDto<PoloDto>();
            var Existe = await _repository.RecuperarPorIdAsync(id);
            if (Existe is null)
            {
                response.MensagensDeErros.Add("Polo não existe");
                response.Sucesso = false;
                return response;
            }
            var poloEntity = _mapper.Map<Polo>(polo);
            response.Sucesso = await _repository.AlterarAsync(poloEntity);
            return response;
        }

        public async Task<ResponseDto<PoloDto>> CadastrarPololAsync(PoloDto polo)
        {
            var response = new ResponseDto<PoloDto>();
            var poloEntity = _mapper.Map<Polo>(polo);
            response.Sucesso = await _repository.CadastrarAsync(poloEntity);
            return response;
        }

        public async Task<ResponseDto<PoloDto>> ConsultarPoloPorIdAsync(int id)
        {
            var response = new ResponseDto<PoloDto>();
            var Existe = await _repository.RecuperarPorIdAsync(id);
            if (Existe is null)
            {
                response.MensagensDeErros.Add("Polo não existe");
                response.Sucesso = false;
                return response;
            }
            response.result = _mapper.Map<PoloDto>(Existe);
            response.Sucesso = true;
            return response;
        }

        public async Task<ResponseDto<IList<PoloDto>>> ConsultarPoloPorNomesAsync(string nome)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto<PoloDto>> DeletarPoloAsync(int id)
        {
            var response = new ResponseDto<PoloDto>();
            var Existe = await _repository.RecuperarPorIdAsync(id);
            if (Existe is null)
            {
                response.MensagensDeErros.Add("Polo não existe");
                response.Sucesso = false;
                return response;
            }
            var poloEntity = _mapper.Map<Polo>(Existe);
            response.Sucesso = await _repository.DeletarAsync(poloEntity);
            return response;
        }

        public async Task<ResponseDto<IList<PoloDto>>> ListarTodosPoloAsync()
        {
            var response = new ResponseDto<IList<PoloDto>>();
            var Existe = await _repository.RecuperarTodosAsync();
            if (!Existe.Any())
            {
                response.MensagensDeErros.Add("Polos não existem");
                response.Sucesso = false;
                return response;
            }
            response.result = _mapper.Map<IList<PoloDto>>(Existe);
            response.Sucesso = true;
            return response;
        }
    }
}
