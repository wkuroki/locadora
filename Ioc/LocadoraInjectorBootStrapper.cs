using Microsoft.Extensions.DependencyInjection;
using Locadora.Entities;
using Locadora.Infra.Data.Repository;
using Locadora.Service.Services;
using Locadora.Infra.Data.Context;

namespace Locadora.IoC
{
    public class LocadoraInjectorBootStrapper 
    {
        public static void RegisterServices(IServiceCollection services)
        {

            // Context
            services.AddScoped<LocadoraContext>();

            // Repository
            services.AddScoped<BaseRepository<Filme>>();
            services.AddScoped<BaseRepository<Locacao>>();
            services.AddScoped<BaseRepository<Cliente>>();

            // Services - API (Interno)
            services.AddScoped<FilmeService>();
            services.AddScoped<Locacaoervice>();
            services.AddScoped<ClienteService>();
        }
    }
}
