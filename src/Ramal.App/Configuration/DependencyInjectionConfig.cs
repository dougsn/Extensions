using Ramal.Business.Interfaces;
using Ramal.Business.Services;
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
            services.AddScoped<IEmailRepository, EmailRepository>();
            services.AddScoped<IComputadorRepository, ComputadorRepository>();
            services.AddScoped<IImpressoraRepository, ImpressoraRepository>();

            services.AddScoped<IFuncionarioService, FuncionarioService>();
            services.AddScoped<ISetorService, SetorService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IComputadorService, ComputadorService>();
            services.AddScoped<IImpressoraService, ImpressoraService>();

            return services;
        }
    }
}
