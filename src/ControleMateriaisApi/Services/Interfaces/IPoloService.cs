using ControleMateriaisApi.Dto;

namespace ControleMateriaisApi.Services.Interfaces
{
    public interface IPoloService
    {
        Task<ResponseDto<PoloDto>> ConsultarPoloPorIdAsync(int id);
        Task<ResponseDto<PoloDto>> CadastrarPololAsync(CadastroPoloDto polo);
        Task<ResponseDto<PoloDto>> DeletarPoloAsync(int id);
        Task<ResponseDto<PoloDto>> AlterarPoloAsync(int id, PoloDto polo);
        Task<ResponseDto<IList<PoloDto>>> ListarTodosPoloAsync();
        Task<ResponseDto<IList<PoloDto>>> ConsultarPoloPorNomesAsync(string nome);
    }
}
