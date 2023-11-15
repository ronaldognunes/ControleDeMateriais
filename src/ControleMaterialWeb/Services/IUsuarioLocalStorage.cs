using ControleMaterialWeb.Models.Usuario;

namespace ControleMaterialWeb.Services
{
    public interface IUsuarioLocalStorage
    {
        Task<UsuarioDto> RecuperarDadosUsuario();
        Task SalvarDadosUsuario(UsuarioDto usuario);
        Task RemoverDados();
    }
}
