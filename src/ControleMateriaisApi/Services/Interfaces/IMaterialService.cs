using ControleMateriaisApi.Dto;

namespace ControleMateriaisApi.Services.Interfaces
{
    public interface IMaterialService
    {

        Task<ResponseDto<MaterialDto>> ConsultarMaterialPorIdAsync(int id);        
        Task<ResponseDto<MaterialDto>> CadastrarMaterialAsync(MaterialDto material);
        Task<ResponseDto<MaterialDto>> DeletarMaterialAsync(int id);
        Task<ResponseDto<MaterialDto>> AlterarMaterialAsync(int id, MaterialDto material);
        Task<ResponseDto<IList<MaterialDto>>> ListarTodosMateriaisAsync();
        Task<ResponseDto<IList<MaterialDto>>> ConsultarMaterialPorNomesAsync(string nome);
    }
}
