using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Application.Interfaces;
using Application.Services;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Services;
using Infra.Data.Repositories;
using AutoMapper;

namespace Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {

            MapperConfiguration configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainToViewModelMappingProfile());
                cfg.AddProfile(new ViewModelToDomainMappingProfile());
            });

            services.AddSingleton(typeof(IMapper), configuration.CreateMapper());

            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            services.AddScoped<IClientesAppService, ClientesAppService>();
            services.AddScoped<IClientesService, ClientesService>();
            services.AddScoped<IClientesRepository, ClientesRepository>();


        }
    }
}
