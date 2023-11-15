using ControleMaterialWeb.Models;
using ControleMaterialWeb.Models.Material;

namespace ControleMaterialWeb.Services
{
    public interface IMaterialService
    {
        Task<ResponseDto<MaterialModel>> RecuperarMaterialAsync(int id);
        Task<ResponseDto<IList<MaterialModel>>> RecuperarTodosMateriaisAsync(string nome = "", int qtdPaginas = 10, int pagina = 1);
        Task<ResponseDto<MaterialModel>> ApagarMaterialAsync(int id);
        Task<ResponseDto<MaterialModel>> AlterarMaterialAsync(int id, MaterialModel material);
        Task<ResponseDto<MaterialModel>> InserirNovoMaterialAsync(CadastroMaterialDto material);

    }
}
