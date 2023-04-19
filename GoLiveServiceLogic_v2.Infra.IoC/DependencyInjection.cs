using GoLiveServiceLogic_v2.Domain;
using GoLiveServiceLogic_v2.Infra.Data.Context;
using GoLiveServiceLogic_v2.Application.Mapping;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using GoLiveServiceLogic_v2.Application.AppServices.Interfaces;
using GoLiveServiceLogic_v2.Infra.Data.Repositories;
using GoLiveServiceLogic_v2.Application.AppServices;

namespace GoLiveServiceLogic_v2.Infra.IoC
{
    public static class DependencyInjection
    {
        //Infra.IoC > Injetar as clases
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //local da string de conexão ao banco de dados
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            //O metodo AddAutoMapper exige a instalação no Nuget do pacote AutoMapper Dependency Injection
            services.AddAutoMapper(typeof(DomainToDtoMapping));
            services.AddScoped<IUsuarioService, UsuarioService>();
            return services;
        }
      
    }
}
