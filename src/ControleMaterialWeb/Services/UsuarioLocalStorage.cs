using ControleMaterialWeb.Models.Usuario;

using Blazored.LocalStorage;

namespace ControleMaterialWeb.Services
{
    public class UsuarioLocalStorage : IUsuarioLocalStorage
    {
        private readonly ILocalStorageService _localStorage;
        const string KEY = "DadosAutenticação";
        public UsuarioLocalStorage( ILocalStorageService localStorage ) 
        {
            _localStorage = localStorage;
        }
        public async Task<UsuarioDto> RecuperarDadosUsuario()
        {
            return await _localStorage.GetItemAsync<UsuarioDto>(KEY);
        }

        public async Task RemoverDados()
        {
            await _localStorage.RemoveItemAsync(KEY);
        }

        public async Task SalvarDadosUsuario(UsuarioDto usuario)
        {
            await _localStorage.SetItemAsync<UsuarioDto>(KEY, usuario);
        }
    }
}
