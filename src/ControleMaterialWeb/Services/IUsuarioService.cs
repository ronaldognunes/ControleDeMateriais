using ControleMaterialWeb.Models;
using ControleMaterialWeb.Models.Material;
using ControleMaterialWeb.Models.Usuario;

namespace ControleMaterialWeb.Services
{
    public interface IUsuarioService
    {
        Task<ResponseDto<UsuarioDto>> RecuperarUsuarioAsync(int id);
        Task<ResponseDto<IList<UsuarioDto>>> RecuperarTodosUsuariosAsync(string nome = "", int qtdPorPaginas = 10, int pagina = 1);
        Task<ResponseDto<UsuarioDto>> ApagarUsuarioAsync(int id);
        Task<ResponseDto<UsuarioDto>> AlterarUsuarioAsync(int id, UsuarioDto usuario);
        Task<ResponseDto<UsuarioDto>> InserirNovoUsuarioAsync(CadastroUsuarioDto usuario);
        Task<ResponseDto<UsuarioDto>> EfetuarLoginAsync(UsuarioLogin usuario);
        Task<ResponseDto<UsuarioDto>> ResetarSenhaAsync(ResetarSenhaDto usuario);
        Task<ResponseDto<UsuarioDto>> LembrarSenha(string email);
    }
}
