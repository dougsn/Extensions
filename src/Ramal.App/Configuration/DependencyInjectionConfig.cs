using Ramal.Business.Interfaces;
using Ramal.Data;
using Ramal.Data.Repository;

namespace Ramal.App.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            services.AddScoped<ISetorRepository, SetorRepository>();

            return services;
        }
    }
}
