using ControleMateriaisApi.Dto;

namespace ControleMateriaisApi.Services.Interfaces
{
    public interface IMaterialService
    {

        Task<ResponseDto<MaterialDto>> ConsultarMaterialPorIdAsync(int id);        
        Task<ResponseDto<MaterialDto>> CadastrarMaterialAsync(CadastroMaterialDto material);
        Task<ResponseDto<MaterialDto>> DeletarMaterialAsync(int id);
        Task<ResponseDto<MaterialDto>> AlterarMaterialAsync(int id, MaterialDto material);
        Task<ResponseDto<IList<MaterialDto>>> ListarTodosMateriaisAsync(int qtdPorPag = 10,int pag = 1);
        Task<ResponseDto<IList<MaterialDto>>> ListarTodosMateriaisAsync(string nome , int qtdPorPag = 10,int pag = 1);
        Task<ResponseDto<IList<MaterialDto>>> ConsultarMaterialPorNomesAsync(string nome);
    }
}
