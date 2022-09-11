using ControleMateriaisApi.Dto;

namespace ControleMateriaisApi.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<ResponseDto<UsuarioDto>> ConsultarUsuariosPorIdAsync(int id);
        Task<ResponseDto<UsuarioDto>> EfetuarLoginAsync(LoginDto usuario);
        Task<ResponseDto<UsuarioDto>> CadastrarUsuarioAsync(UsuarioCadastroDto usuario);
        Task<ResponseDto<UsuarioDto>> DeletarUsuarioAsync(int id);
        Task<ResponseDto<UsuarioDto>> AlterarUsuarioAsync(int id,UsuarioDto usuario);
        Task<ResponseDto<IList<UsuarioDto>>> ListarTodosUsuariosAsync();
        Task<ResponseDto<IList<UsuarioDto>>> ConsultarUsuariosPorNomesAsync(string nome);
        Task<ResponseDto<UsuarioDto>> GerarCodigoParaResetarSenhaAsync(string email);
        Task<ResponseDto<UsuarioDto>> ResetarSenhaAsync(ResetarSenhaDto dados);
    }
}
