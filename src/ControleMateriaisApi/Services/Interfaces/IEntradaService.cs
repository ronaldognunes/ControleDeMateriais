using ControleMateriaisApi.Dto;

namespace ControleMateriaisApi.Services.Interfaces
{
    public interface IEntradaService
    {
        Task<ResponseDto<EntradaDto>> ConsultarEntradaPorIdAsync(int id);
        Task<ResponseDto<EntradaDto>> CadastrarEntradaAsync(EntradaDto entrada);
        Task<ResponseDto<EntradaDto>> DeletarEntradaAsync(int id);
        Task<ResponseDto<EntradaDto>> AlterarEntradaAsync(int id, EntradaDto entrada);
        Task<ResponseDto<IList<EntradaDto>>> ListarTodasEntradasAsync();
        Task<ResponseDto<IList<EntradaDto>>> ConsultarEntradaPorNomesAsync(string nome);
    }
}
