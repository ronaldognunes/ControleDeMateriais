using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace ControleMaterialWeb.Services.Interfaces
{
    public class HttpServices : IHttpServices
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigation;
        public HttpServices(HttpClient httpClient,
                            NavigationManager navigation)
        {
            _httpClient = httpClient;
            _navigation = navigation;
        }

        public async Task<TSaida> HttpDeleteAsync<TSaida>(string rota) where TSaida : class
        {            
            var request = new HttpRequestMessage(HttpMethod.Delete, rota);
            using HttpResponseMessage response =  await _httpClient.SendAsync(request);
            ValidaToken(response);
            var retorno = await response.Content.ReadFromJsonAsync<TSaida>();
            return retorno;            
        }


        public async Task<TSaida> HttpGetAsync<TSaida>(string rota) where TSaida : class
        {
            var request = new HttpRequestMessage(HttpMethod.Get, rota);
            using HttpResponseMessage response = await _httpClient.SendAsync(request);
            ValidaToken(response);
            var retorno = await response.Content.ReadFromJsonAsync<TSaida>();
            return retorno;
        }


        public async Task<TSaida> HttpPostAsync<TEntrada, TSaida>(string rota, TEntrada model)
            where TEntrada : class
            where TSaida : class
        {
            var request = new HttpRequestMessage(HttpMethod.Post, rota);
            request.Content = new StringContent(JsonSerializer.Serialize<TEntrada>(model), Encoding.UTF8, "application/json");
            using HttpResponseMessage response = await _httpClient.SendAsync(request);
            ValidaToken(response);
            var retorno = await response.Content.ReadFromJsonAsync<TSaida>();
            return retorno;
        }

        public async Task<TSaida> HttpPutAsync<TEntrada, TSaida>(string rota, TEntrada model)
            where TEntrada : class
            where TSaida : class
        {
            var request = new HttpRequestMessage(HttpMethod.Put, rota);
            request.Content = new StringContent(JsonSerializer.Serialize<TEntrada>(model), Encoding.UTF8,"application/json");
            using HttpResponseMessage response = await _httpClient.SendAsync(request);
            ValidaToken(response);
            var retorno = await response.Content.ReadFromJsonAsync<TSaida>();
            return retorno;
        }

        private void ValidaToken(HttpResponseMessage response )
        {
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized || response.StatusCode == System.Net.HttpStatusCode.Forbidden)
            {
                _navigation.NavigateTo("/login");
                throw new Exception();
            }
        }
    }
}
