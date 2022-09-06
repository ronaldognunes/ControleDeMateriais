using ControleMateriaisApi.Dto;

namespace ControleMateriaisApi.Services.Interfaces
{
    public interface IOrdemServicoService
    {
        Task<ResponseDto<OrdemServicoDto>> ConsultarOsPorIdAsync(int id);
        Task<ResponseDto<OrdemServicoDto>> CadastrarOsAsync(OrdemServicoDto entrada);
        Task<ResponseDto<OrdemServicoDto>> DeletarOsAsync(int id);
        Task<ResponseDto<OrdemServicoDto>> AlterarOsAsync(int id, OrdemServicoDto entrada);
        Task<ResponseDto<IList<OrdemServicoDto>>> ListarTodasOsAsync();
        Task<ResponseDto<IList<OrdemServicoDto>>> ConsultarOsPorNomesAsync(string nome);
    }
}
