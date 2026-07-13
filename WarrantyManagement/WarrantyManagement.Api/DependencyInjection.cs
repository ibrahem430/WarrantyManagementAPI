using WarrantyManagement.Application.Interfaces;
using WarrantyManagement.Application.Services;


namespace WarrantyManagement.Api;


public static class DependencyInjection
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        
        services.AddControllers();
        return services;
    }


}