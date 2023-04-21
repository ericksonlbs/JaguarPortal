using JaguarPortal.Core;
using JaguarPortal.Core.Interfaces;
using JaguarPortal.Infrastructure.Context;
using JaguarPortal.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JaguarPortal.Infrastructure.ServiceExtensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services, IConfiguration configuration)
        {

            #region DbContext
            services.AddScoped<JaguarDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion

            #region Repositories
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAnalysisRepository, AnalysisRepository>();
            services.AddScoped<ISpectrumRepository, SpectrumRepository>();
            #endregion


            return services;
        }
    }
}
