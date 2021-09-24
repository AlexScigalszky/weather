using Application.Interfaces;
using Application.Services;
using AutoMapper;
using Core.Configuration;
using Core.Interfaces;
using Core.Repositories.Base;
using Domain.Data;
using Domain.Repositories;
using Domain.Repositories.Implementation;
using Infrastructure.Data;
using Infrastructure.Logging;
using Infrastructure.Repository.Base;
using Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Config
{
    public static class DependencyContainer
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            // Add AutoMapper
            services.AddAutoMapper(typeof(Startup));


            // Add Core Layer
            services.Configure<Settings>(configuration);


            // Add Infrastructure Layer
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

            services.AddScoped<ExampleContext, AzureExampleContext>();
            // Add Repositories
            services.AddScoped<IWeatherRepository, WheatherRepository>();
            services.AddScoped<ICityRepository, CityRepository>();

            //Add Aplication Services
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IWeatherService, WeatherService>();
            services.AddScoped<IExternalWheatherService, ExternalWheatherService>();

        }
    }
}
