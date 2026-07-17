
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WarrantyManagement.Application.Interfaces;
using WarrantyManagement.Infrastructure.dataBase;
using WarrantyManagement.Infrastructure.Repository;


namespace WarrantyManagement.Infrastructure;


public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
       
         var connectionString =
         configuration.GetConnectionString("DefaultConnection")          
          ?? throw new InvalidOperationException(
                "Connection string 'DefaultConnection' was not found.");


        services.AddDbContext<AppDbContext>(option =>
        {
             option.UseSqlServer(connectionString);
        });
       services.AddScoped<ISaleRepository,SaleRepository>();
       services.AddScoped<IProductRepository,ProductRepository>();
       services.AddScoped<ICustomerRepository,CustomerRepository>();
       services.AddScoped<IWarrantyRepository,WarrantyRepository>();
       services.AddScoped<IWarrantyClaimRepository,WarrantyClaimRepository>();





        return services;
    }

}