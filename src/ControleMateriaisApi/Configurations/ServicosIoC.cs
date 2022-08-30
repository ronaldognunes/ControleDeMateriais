using ControleMateriaisApi.Repository;
using ControleMateriaisApi.Repository.Interfaces;
using ControleMateriaisApi.Services;
using ControleMateriaisApi.Services.Interfaces;

namespace ControleMateriaisApi.Configurations
{
    public static class ServicosIoC
    {
        public static IServiceCollection AddServicosIoC(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IMaterialRepository, MaterialRepository>();
            services.AddScoped<ISaidaRepository, SaidaRepository>();
            services.AddScoped<IEntradaRepository, EntradaRepository>();
            services.AddScoped<IEntradaMaterialRepository, EntradaMaterialRepository>();
            services.AddScoped<ISaidaMaterialRepository, SaidaMaterialRepository>();
            services.AddScoped<IPoloRepository, PoloRepository>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IMaterialService, MaterialService>();
            services.AddScoped<IPoloService, PoloService>();
            services.AddScoped<IEntradaService, EntradaService>();
            services.AddScoped<ISaidaService, SaidaService>();
            return services;
        }
    }
}
