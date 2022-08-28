using ControleMateriaisApi.Dto;

namespace ControleMateriaisApi.Services.Interfaces
{
    public interface ISaidaService
    {
        Task<ResponseDto<SaidaDto>> ConsultarSaidaPorIdAsync(int id);
        Task<ResponseDto<SaidaDto>> CadastrarSaidalAsync(SaidaDto saida);
        Task<ResponseDto<SaidaDto>> DeletarSaidaAsync(int id);
        Task<ResponseDto<SaidaDto>> AlterarSaidaAsync(int id, SaidaDto saida);
        Task<ResponseDto<IList<SaidaDto>>> ListarTodasSaidaAsync();
        Task<ResponseDto<IList<SaidaDto>>> ConsultarSaidaPorNomesAsync(string nome);
    }
}
