using Microsoft.Extensions.DependencyInjection;
using WarrantyManagement.Application.Services;

namespace WarrantyManagement.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ProductService>();

        return services;
    }
}