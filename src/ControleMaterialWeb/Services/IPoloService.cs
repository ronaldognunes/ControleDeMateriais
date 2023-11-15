using ControleMaterialWeb.Models;
using ControleMaterialWeb.Models.Polo;

namespace ControleMaterialWeb.Services
{
    public interface IPoloService
    {
        Task<ResponseDto<PoloDto>> RecuperarPoloAsync(int id);
        Task<ResponseDto<IList<PoloDto>>> RecuperarTodosMateriaisAsync(string nome = "", int qtdPorPaginas = 10, int pagina = 1);
        Task<ResponseDto<PoloDto>> ApagarPoloAsync(int id);
        Task<ResponseDto<PoloDto>> AlterarPoloAsync(int id, PoloDto Polo);
        Task<ResponseDto<PoloDto>> InserirNovoPoloAsync(CadastroPoloDto Polo);

    }
}
