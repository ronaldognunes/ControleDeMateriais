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
        private readonly IOrdemServicoRepository _ordemServicoRepository;

        public PoloService(IPoloRepository repository, IMapper mapper, IOrdemServicoRepository ordemServicoRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _ordemServicoRepository = ordemServicoRepository;
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

        public async Task<ResponseDto<PoloDto>> CadastrarPololAsync(CadastroPoloDto polo)
        {
            var response = new ResponseDto<PoloDto>();
            var mensagensErros = polo.Validar();
            if (mensagensErros.Any())
            {
                response.MensagensDeErros.AddRange(mensagensErros);
                response.Sucesso = false;
                return response;
            }

            var poloEntity = _mapper.Map<Polo>(polo);
            var poloJaExiste = await _repository.RecuperarDadosPorFiltroAsync(p => p.NomePolo.ToLower() == poloEntity.NomePolo);

            if(poloJaExiste is null)
            {
                response.Sucesso = await _repository.CadastrarAsync(poloEntity);
                return response;
            }

            response.Sucesso = false;
            response.MensagensDeErros.Add("Nome do Polo já existe");
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

            var existePoloCadastradoEmUmaOs = await _ordemServicoRepository.VerificaPoloAlgumaOs(id);
            if (existePoloCadastradoEmUmaOs)
            {
                response.MensagensDeErros.Add("Polo não pode ser excluido, pois está cadastrado em uma ordem de serviço.");
                response.Sucesso = false;
                return response;
            }

            var poloEntity = _mapper.Map<Polo>(Existe);
            response.Sucesso = await _repository.DeletarAsync(poloEntity);
            return response;
        }

        public async Task<ResponseDto<IList<PoloDto>>> ListarTodosPoloAsync(int qtdPorPag = 10, int pag = 1)
        {
            var response = new ResponseDto<IList<PoloDto>>();
            var dados = await _repository.ConsultaPaginadaAsync(null,qtdPorPag,pag);
            if (dados.items.Any())
            {
                response.result = _mapper.Map<IList<PoloDto>>(dados.items);
                response.Sucesso = true;
                response.TotalDePaginas = Convert.ToInt32(dados.total);
                response.TotalDeRegistros = dados.registros;
                return response;               
            }

            response.MensagensDeErros.Add("Polos não existem");
            response.Sucesso = false;
            return response;

        }

        public async Task<ResponseDto<IList<PoloDto>>> ListarTodosPoloAsync(string nome , int qtdPorPag = 10, int pag = 1)
        {
            var response = new ResponseDto<IList<PoloDto>>();
            var dados = await _repository.ConsultaPaginadaAsync( p => p.NomePolo.ToLower().Contains(nome.ToLower()),qtdPorPag,pag);
            if (dados.items.Any())
            {
                response.result = _mapper.Map<IList<PoloDto>>(dados.items);
                response.Sucesso = true;
                response.TotalDePaginas = Convert.ToInt32(dados.total);
                response.TotalDeRegistros = dados.registros;
                return response;               
            }

            response.MensagensDeErros.Add("Polos não existem");
            response.Sucesso = false;
            return response;
        }
    }
}
