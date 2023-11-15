using AutoMapper;
using ControleMateriaisApi.Domain;
using ControleMateriaisApi.Dto;
using ControleMateriaisApi.Repository.Interfaces;
using ControleMateriaisApi.Services.Interfaces;

namespace ControleMateriaisApi.Services
{
    public class MaterialService:IMaterialService
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IOrdemServicoRepository _ordemServicoRepository;

        private readonly IMapper _mapper;

        public MaterialService(IMaterialRepository materialRepository,
                               IMapper mapper,
                               IOrdemServicoRepository ordemServicoRepository)
        {
            _mapper = mapper;
            _materialRepository = materialRepository;
            _ordemServicoRepository = ordemServicoRepository;
        }

        public async Task<ResponseDto<MaterialDto>> AlterarMaterialAsync(int id, MaterialDto material)
        {
            var response = new ResponseDto<MaterialDto>();
            if (string.IsNullOrWhiteSpace(material.Nome))
            {
                response.MensagensDeErros.Add("Nome do material não informado");
                response.Sucesso = false;
                return response;
            }
            var ExisteMaterial = await _materialRepository.RecuperarPorIdAsync(id);

            if(ExisteMaterial is null)
            {
                response.MensagensDeErros.Add("material não existe.");
                response.Sucesso = false;
                return response;
            }
            var materialEntity = _mapper.Map<Material>(material);

            response.Sucesso = await _materialRepository.AlterarAsync(materialEntity);
            return response;

        }

        public async Task<ResponseDto<MaterialDto>> CadastrarMaterialAsync(CadastroMaterialDto material)
        {
            var response = new ResponseDto<MaterialDto>();
            if (string.IsNullOrWhiteSpace(material.Nome))
            {
                response.MensagensDeErros.Add("Nome do material não informado");
                response.Sucesso = false;
                return response;
            }
            
            var materialEntity = _mapper.Map<Material>(material);
            var MaterialJaExiste = await _materialRepository.RecuperarDadosPorFiltroAsync(m => m.Nome.ToLower() == material.Nome.ToLower());
            if(MaterialJaExiste is null)
            {
                response.Sucesso = await _materialRepository.CadastrarAsync(materialEntity);
                return response;
            }

            response.Sucesso = false;
            response.MensagensDeErros.Add("Já existe material cadastrado com esse nome");
            return response;
            
        }

        public async Task<ResponseDto<MaterialDto>> ConsultarMaterialPorIdAsync(int id)
        {
            var response = new ResponseDto<MaterialDto>();
            var material = await _materialRepository.RecuperarPorIdAsync(id);
            if (material is null)
            {
                response.MensagensDeErros.Add("Material não existe!");
                response.Sucesso = false;
                return response;
            }
            response.result = _mapper.Map<MaterialDto>(material);
            response.Sucesso = true;
            return response;

        }

        public async Task<ResponseDto<IList<MaterialDto>>> ConsultarMaterialPorNomesAsync(string nome)
        {
            var response = new ResponseDto<IList<MaterialDto>>();
            var materiais = await _materialRepository.RecuperarMaterialPorNomeAsync(nome);
            if (!materiais.Any())
            {
                response.MensagensDeErros.Add("Material não existe");
                response.Sucesso = false;
                return response;
            }            
            response.result = _mapper.Map<IList<MaterialDto>>(materiais);
            response.Sucesso = true;
            return response;
        }

        public async Task<ResponseDto<MaterialDto>> DeletarMaterialAsync(int id)
        {
            var response = new ResponseDto<MaterialDto>();
            var material = await _materialRepository.RecuperarPorIdAsync(id);            
            if (material is null)
            {
                response.MensagensDeErros.Add("Material não existe!");
                response.Sucesso = false;
                return response;
            }
            var existeOsParaOMaterial = await _ordemServicoRepository.VerificaMaterialAlgumaOs(id);
            if(existeOsParaOMaterial)
            {
                response.MensagensDeErros.Add("Material não pode ser excluido, pois já pertence a uma Ordem de Serviço");
                response.Sucesso = false;
                return response;
            }

            response.Sucesso = await _materialRepository.DeletarAsync(material);
            return response;
        }

        public async Task<ResponseDto<IList<MaterialDto>>> ListarTodosMateriaisAsync(int qtdPorPag=10, int pag = 1 )
        {
            var response = new ResponseDto<IList<MaterialDto>>();
            var dados = await _materialRepository.ConsultaPaginadaAsync(null, qtdPorPag, pag);
            if (dados.items.Any())
            {
                response.result = _mapper.Map<IList<MaterialDto>>(dados.items);
                response.TotalDeRegistros = dados.registros;
                response.TotalDePaginas = Convert.ToInt32(dados.total);
                response.Sucesso = true;
                return response;
            }
            response.Sucesso = false;
            response.MensagensDeErros.Add("Nenhum material encontrado.");
            return response;
        }

        public async Task<ResponseDto<IList<MaterialDto>>> ListarTodosMateriaisAsync(string nome,int qtdPorPag=10, int pag = 1 )
        {
            var response = new ResponseDto<IList<MaterialDto>>();
            var dados = await _materialRepository.ConsultaPaginadaAsync(p => p.Nome.ToLower().Contains(nome.ToLower()), qtdPorPag, pag);
            if (dados.items.Any())
            {
                response.result = _mapper.Map<IList<MaterialDto>>(dados.items);
                response.TotalDeRegistros = dados.registros;
                response.TotalDePaginas = Convert.ToInt32(dados.total);
                response.Sucesso = true;
                return response;
            }
            response.Sucesso = false;
            response.MensagensDeErros.Add("Nenhum material encontrado.");
            return response;
        }
    }
}
