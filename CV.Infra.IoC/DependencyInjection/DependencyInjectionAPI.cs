using CV.Application.Service;
using CV.Application.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CV.Infra.IoC.DependencyInjection
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICurriculumService, CurriculumService>();
            return services;
        }
    }
}
