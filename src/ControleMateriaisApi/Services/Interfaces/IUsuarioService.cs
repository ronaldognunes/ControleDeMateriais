using ControleMateriaisApi.Dto;

namespace ControleMateriaisApi.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<ResponseDto<UsuarioDto>> ConsultarUsuariosPorIdAsync(int id);
        Task<ResponseDto<UsuarioDto>> EfetuarLoginAsync(UsuarioDto usuario);
        Task<ResponseDto<UsuarioDto>> CadastrarUsuarioAsync(UsuarioDto usuario);
        Task<ResponseDto<UsuarioDto>> DeletarUsuarioAsync(UsuarioDto usuario);
        Task<ResponseDto<UsuarioDto>> AlterarUsuarioAsync(int id,UsuarioDto usuario);
        Task<ResponseDto<IList<UsuarioDto>>> ListarTodosUsuariosAsync();
        Task<ResponseDto<IList<UsuarioDto>>> ConsultarUsuariosPorNomesAsync(string nome);
    }
}
