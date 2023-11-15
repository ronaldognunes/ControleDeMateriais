namespace ControleMaterialWeb.Services.Interfaces
{
    public interface IHttpServices
    {        
        Task<TSaida> HttpGetAsync<TSaida>(string rota) where TSaida : class;        
        Task<TSaida> HttpPostAsync<TEntrada, TSaida>(string rota, TEntrada model) where TEntrada : class where TSaida : class;
        Task<TSaida> HttpPutAsync<TEntrada, TSaida>(string rota, TEntrada model) where TEntrada : class where TSaida : class;
        Task<TSaida> HttpDeleteAsync<TSaida>(string rota) where TSaida : class;
    }
}
