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
        private readonly IMapper _mapper;

        public MaterialService(IMaterialRepository materialRepository,
                               IMapper mapper )
        {
            _mapper = mapper;
            _materialRepository = materialRepository;   
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

        public async Task<ResponseDto<MaterialDto>> CadastrarMaterialAsync(MaterialDto material)
        {
            var response = new ResponseDto<MaterialDto>();
            if (string.IsNullOrWhiteSpace(material.Nome))
            {
                response.MensagensDeErros.Add("Nome do material não informado");
                response.Sucesso = false;
                return response;
            }
            var materialEntity = _mapper.Map<Material>(material);
            response.Sucesso= await _materialRepository.CadastrarAsync(materialEntity);
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
            if (materiais.Any())
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
            if(material is null)
            {
                response.MensagensDeErros.Add("Material não existe!");
                response.Sucesso = false;
                return response;
            }
            await _materialRepository.DeletarAsync(material);
            return response;
        }

        public async Task<ResponseDto<IList<MaterialDto>>> ListarTodosMateriaisAsync()
        {
            var response = new ResponseDto<IList<MaterialDto>>();
            var materiais = await _materialRepository.RecuperarTodosAsync();
            response.result = _mapper.Map<IList<MaterialDto>>(materiais);
            response.Sucesso = true;
            return response;
        }
    }
}
