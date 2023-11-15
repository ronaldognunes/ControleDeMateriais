using ControleMaterialWeb.Autenticacao;
using ControleMaterialWeb.Services;
using ControleMaterialWeb.Services.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;

namespace ControleMaterialWeb.Configurations
{
    public static class AdicionarServicos
    {
        public static IServiceCollection AddServicos(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IMaterialService, MaterialService>();
            services.AddScoped<IOrdemServicoService, OrdemServicoService>();
            services.AddScoped<IPoloService, PoloService>();
            services.AddScoped<IUsuarioLocalStorage, UsuarioLocalStorage>();
            services.AddScoped<IHttpServices, HttpServices>();            
            services.AddScoped<IRecursos, Recursos>();            
            return services;
        }
    }
}
