using ControleMaterialWeb.Services;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;

namespace ControleMaterialWeb.Autenticacao
{
    public class TokenAutehtication : AuthenticationStateProvider
    {
        private readonly HttpClient http;
        private readonly IUsuarioLocalStorage usuarioLocalStorage;
        public TokenAutehtication(HttpClient http,
            IUsuarioLocalStorage usuarioLocalStorage)
        {
            this.http = http;
            this.usuarioLocalStorage = usuarioLocalStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var usuario = await usuarioLocalStorage.RecuperarDadosUsuario();
            if (usuario != null)
            {
                if (!string.IsNullOrWhiteSpace(usuario?.Token))
                    return await RetornarAutenticacao(usuario.Token);
            }            

            return NotAuthenticate(); 
        }
        // metodo retonar não autenticado
        private AuthenticationState NotAuthenticate()
        {
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }


        // retornar autenticação
        private Task<AuthenticationState> RetornarAutenticacao(string token)
        {
            //adicionar token nos headers das requisições
            http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);

            var claims = new List<Claim>();
            var payload = token.Split(".")[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            keyValuePairs.TryGetValue(ClaimTypes.Role, out object roles);

            if (roles != null)
            {
                if (roles.ToString().Trim().StartsWith("["))
                {
                    var parsedRoles = JsonSerializer.Deserialize<string[]>(roles.ToString());
                    foreach (var parsed in parsedRoles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, parsed));
                    }
                }
                else
                {
                    claims.Add(new Claim(ClaimTypes.Role, roles.ToString()));
                }
                keyValuePairs.Remove(ClaimTypes.Role);
            }

            claims.AddRange(keyValuePairs.Select(k => new Claim(k.Key, k.Value.ToString())));

            return Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"))));

        }

        private byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }

        public async Task Login()
        {
            var auth = await GetAuthenticationStateAsync();
            NotifyAuthenticationStateChanged(Task.FromResult(auth));
        }

        public async Task Logout()
        {
            await usuarioLocalStorage.RemoverDados();
            http.DefaultRequestHeaders.Authorization = null;
            NotifyAuthenticationStateChanged(Task.FromResult(NotAuthenticate()));
        }


    }
}
