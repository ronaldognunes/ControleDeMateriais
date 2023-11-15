using ControleMaterialWeb.Models;
using ControleMaterialWeb.Models.Material;
using ControleMaterialWeb.Services.Interfaces;

namespace ControleMaterialWeb.Services
{
    public class MaterialService : IMaterialService
    {
        
        private readonly IHttpServices _httpServices;
        private const string URI = "api/material/";

        public MaterialService(IHttpServices httpServices)
        {
            _httpServices = httpServices;
        }

        public async Task<ResponseDto<MaterialModel>> AlterarMaterialAsync(int id, MaterialModel material)
        {
            try 
            {
                return await _httpServices.HttpPutAsync<MaterialModel,ResponseDto<MaterialModel>>($"{URI}alterar-material/{id}", material);
            }
            catch (Exception ex)
            {
                return new ResponseDto<MaterialModel>() { Result = new MaterialModel(), MensagensDeErros = new List<string>() { ex.Message }, Sucesso=false };
            }
        }

        public async Task<ResponseDto<MaterialModel>> ApagarMaterialAsync(int id)
        {
            try 
            {
                return await _httpServices.HttpDeleteAsync<ResponseDto<MaterialModel>>($"{URI}excluir-material/{id}");                
            }
            catch(Exception ex)
            {
                return new ResponseDto<MaterialModel>() { Result = new MaterialModel() , MensagensDeErros= new List<string>() { ex.Message }, Sucesso = false };
            }
        }

        public async Task<ResponseDto<MaterialModel>> InserirNovoMaterialAsync(CadastroMaterialDto material)
        {
            try
            {
                return  await _httpServices.HttpPostAsync<CadastroMaterialDto, ResponseDto<MaterialModel>>($"{URI}cadastrar-material", material);                
            }
            catch (Exception ex)
            {
                return new ResponseDto<MaterialModel>() { Result = new MaterialModel(), MensagensDeErros = new List<string>() { ex.Message }, Sucesso = false };
            }

        }

        public async Task<ResponseDto<MaterialModel>> RecuperarMaterialAsync(int id)
        {
            try
            {
                return await _httpServices.HttpGetAsync<ResponseDto<MaterialModel>>($"{URI}consultar-material-por-id/{id}");                
            }
            catch (Exception ex)
            {
                return new ResponseDto<MaterialModel>() { Result = new MaterialModel() , MensagensDeErros = new List<string>() { ex.Message}, Sucesso = false };
            }
        }

        public async Task<ResponseDto<IList<MaterialModel>>> RecuperarTodosMateriaisAsync(string nome = "",int qtdPaginas = 10, int pagina = 1)
        {
            try
            {
                var response = new ResponseDto<IList<MaterialModel>>();
                if (string.IsNullOrWhiteSpace(nome))
                    response = await _httpServices.HttpGetAsync<ResponseDto<IList<MaterialModel>>>($"{URI}retornar-todos-materiais?qtdPorPagina={qtdPaginas}&pagina={pagina}");
                else
                    response = await _httpServices.HttpGetAsync<ResponseDto<IList<MaterialModel>>>($"{URI}retornar-todos-materiais?qtdPorPagina={qtdPaginas}&pagina={pagina}&nome={nome}");

                return response;
            }
            catch(Exception ex)
            {
                return new ResponseDto<IList<MaterialModel>>() { Result = new List<MaterialModel>(), MensagensDeErros = new List<string> { ex.Message}, Sucesso = false };
            }
        }        
    }
}

