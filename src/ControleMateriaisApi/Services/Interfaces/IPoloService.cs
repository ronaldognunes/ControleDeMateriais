using ControleMateriaisApi.Dto;

namespace ControleMateriaisApi.Services.Interfaces
{
    public interface IPoloService
    {
        Task<ResponseDto<PoloDto>> ConsultarPoloPorIdAsync(int id);
        Task<ResponseDto<PoloDto>> CadastrarPololAsync(CadastroPoloDto polo);
        Task<ResponseDto<PoloDto>> DeletarPoloAsync(int id);
        Task<ResponseDto<PoloDto>> AlterarPoloAsync(int id, PoloDto polo);
        Task<ResponseDto<IList<PoloDto>>> ListarTodosPoloAsync(int qtdPorPag = 10, int pag = 1);
        Task<ResponseDto<IList<PoloDto>>> ListarTodosPoloAsync(string nome ,int qtdPorPag = 10, int pag = 1);
        Task<ResponseDto<IList<PoloDto>>> ConsultarPoloPorNomesAsync(string nome);
    }
}
