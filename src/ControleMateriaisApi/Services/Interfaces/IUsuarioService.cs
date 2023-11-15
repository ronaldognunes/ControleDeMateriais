using ControleMateriaisApi.Dto;

namespace ControleMateriaisApi.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<ResponseDto<UsuarioDto>> ConsultarUsuariosPorIdAsync(int id);
        Task<ResponseDto<RetornoDadosLoginDto>> EfetuarLoginAsync(LoginDto usuario);
        Task<ResponseDto<UsuarioDto>> CadastrarUsuarioAsync(UsuarioCadastroDto usuario);
        Task<ResponseDto<UsuarioDto>> DeletarUsuarioAsync(int id);
        Task<ResponseDto<UsuarioDto>> AlterarUsuarioAsync(int id, AlteracaoUsuarioDto usuario);
        Task<ResponseDto<IList<UsuarioDto>>> ListarTodosUsuariosAsync(int qtdPorPag = 10, int pag = 1);
        Task<ResponseDto<IList<UsuarioDto>>> ListarTodosUsuariosAsync(string nome, int qtdPorPag = 10, int pag = 1);
        Task<ResponseDto<IList<UsuarioDto>>> ConsultarUsuariosPorNomesAsync(string nome);
        Task<ResponseDto<UsuarioDto>> GerarCodigoParaResetarSenhaAsync(string email);
        Task<ResponseDto<UsuarioDto>> ResetarSenhaAsync(ResetarSenhaDto dados);
    }
}
