using ConsulTech.Core.Services;
using ConsulTech.Core.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace ConsulTech.Core.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddTransient<IClientService, ClientService>();
        services.AddTransient<ICategorieService, CategorieService>();
        services.AddTransient<INiveauService, NiveauService>();
        services.AddTransient<IConsultantService, ConsultantService>();
        services.AddTransient<ICompetenceService, CompetenceService>();

        return services;
    }
}
