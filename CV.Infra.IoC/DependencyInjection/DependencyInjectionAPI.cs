using MediatR;
using CV.Application.Service;
using QuestPDF.Infrastructure;
using CV.Application.Interface;
using CV.Application.CQRS.Handlers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CV.Infra.IoC.DependencyInjection;

public static class DependencyInjectionAPI
{
    public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services, IConfiguration configuration)
    {
		try
		{
            services.AddMediatR(typeof(CreateCurriculumCommandHandler).Assembly);
            services.AddScoped<ICurriculumService, CurriculumService>();
            QuestPDF.Settings.License = LicenseType.Community;
            return services;
        }
		catch (Exception)
		{
			throw;
		}
    }
}
