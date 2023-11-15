using ControleMaterialWeb.Models;
using ControleMaterialWeb.Models.Polo;
using ControleMaterialWeb.Services.Interfaces;
using System.Net.Http.Json;

namespace ControleMaterialWeb.Services
{
    public class PoloService : IPoloService
    {        
        private readonly IHttpServices _httpServices;
        private const string URI = "api/polo/";

        public PoloService(IHttpServices httpServices)
        {
            _httpServices = httpServices;
        }

        public async Task<ResponseDto<PoloDto>> AlterarPoloAsync(int id, PoloDto Polo)
        {
            try
            {
                return  await _httpServices.HttpPutAsync<PoloDto,ResponseDto<PoloDto>>($"{URI}alterar-polo/{id}", Polo);                
            }
            catch (Exception ex)
            {
                return new ResponseDto<PoloDto>() { Result = new PoloDto(),MensagensDeErros = new List<string>() { ex.Message}, Sucesso = false };
            }
        }

        public async Task<ResponseDto<PoloDto>> ApagarPoloAsync(int id)
        {
            try
            {
                return  await _httpServices.HttpDeleteAsync<ResponseDto<PoloDto>>($"{URI}excluir-polo/{id}");                
            }
            catch (Exception ex)
            {
                return new ResponseDto<PoloDto>() { Result = new PoloDto(), MensagensDeErros = new List<string>() { ex.Message }, Sucesso = false };
            }
        }

        public async Task<ResponseDto<PoloDto>> InserirNovoPoloAsync(CadastroPoloDto Polo)
        {
            try
            {
                return await _httpServices.HttpPostAsync<CadastroPoloDto,ResponseDto<PoloDto>>($"{URI}cadastrar-polo", Polo);
                
            }
            catch (Exception ex)
            {
                return new ResponseDto<PoloDto>() { Result = new PoloDto(), MensagensDeErros = new List<string>() { ex.Message }, Sucesso = false };
            }
        }

        public async Task<ResponseDto<PoloDto>> RecuperarPoloAsync(int id)
        {
            try
            {
                return await _httpServices.HttpGetAsync<ResponseDto<PoloDto>>($"{URI}consultar-polo-por-id/{id}");
            }
            catch (Exception ex)
            {
                return new ResponseDto<PoloDto>() { Result = new PoloDto(), MensagensDeErros = new List<string>() { ex.Message }, Sucesso = false };
            }
        }

        public async Task<ResponseDto<IList<PoloDto>>> RecuperarTodosMateriaisAsync(string nome = "", int qtdPorPaginas = 10, int pagina = 1)
        {
            try
            {
                var response = new ResponseDto<IList<PoloDto>>();
                if(string.IsNullOrWhiteSpace(nome))
                    response = await _httpServices.HttpGetAsync<ResponseDto<IList<PoloDto>>>($"{URI}retornar-todas-polos?qtdPorPagina={qtdPorPaginas}& pagina={pagina}");
                else
                    response = await _httpServices.HttpGetAsync<ResponseDto<IList<PoloDto>>>($"{URI}retornar-todas-polos?qtdPorPagina={qtdPorPaginas}& pagina={pagina}&nome={nome}");

                if (response != null && response.Sucesso)
                    return response;

                return response;
            }
            catch (Exception ex)
            {
                return new ResponseDto<IList<PoloDto>>() { Result = new List<PoloDto>(), MensagensDeErros = new List<string>() { ex.Message }, Sucesso = false };
            }
        }
    }
}
