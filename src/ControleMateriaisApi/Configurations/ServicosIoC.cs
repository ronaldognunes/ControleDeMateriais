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
            services.AddScoped<IOrdemServicoRepository, OrdemServicoRepository>();
            services.AddScoped<IItemOrdemServicoRepository, ItemOrdemServicoRepository>();
            services.AddScoped<IPoloRepository, PoloRepository>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IMaterialService, MaterialService>();
            services.AddScoped<IPoloService, PoloService>();
            services.AddScoped<IOrdemServicoService, OrdemServicoService>();
            services.AddScoped<IEnvioDeEmailService, EnvioDeEmailService>();
            return services;
        }
    }
}
