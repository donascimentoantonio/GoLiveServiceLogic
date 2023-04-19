using GoLiveServiceLogic_v2.Infra.Data.Context;
using GoLiveServiceLogic_v2.Application.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GoLiveServiceLogic_v2.Application.AppServices.Interfaces;
using GoLiveServiceLogic_v2.Infra.Data.Repositories;
using GoLiveServiceLogic_v2.Application.AppServices;
using GoLiveServiceLogic_v2.Domain.Interfaces;
using GoLiveServiceLogic_v2.Domain.Interfaces.Base;
using GoLiveServiceLogic_v2.Infra.Data.Dapper;

namespace GoLiveServiceLogic_v2.Infra.IoC
{
    public static class DependencyInjection
    {
        //Infra.IoC > Injetar as clases
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //local da string de conexão ao banco de dados
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IDapperRepository, DapperRepository>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            //O metodo AddAutoMapper exige a instalação no Nuget do pacote AutoMapper Dependency Injection
            services.AddAutoMapper(typeof(DomainToDtoMapping));
            services.AddScoped<IUsuarioService, UsuarioService>();
            return services;
        }
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {

            //Todos os repositorios criados para as regras de negócio ficarão nesta classe
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            return services;
        }

    }
}
