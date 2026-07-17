using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using WarrantyManagement.Application.Services;
using WarrantyManagement.Application.Validators.Customers;
using WarrantyManagement.Application.Validators.Products;

namespace WarrantyManagement.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ProductService>();

       services.AddValidatorsFromAssemblyContaining<CreateProductRequestValidator>();
       services.AddValidatorsFromAssemblyContaining<UpdateProductRequestValidator>();
       services.AddValidatorsFromAssemblyContaining<CreateCustomerRequestValidator>();
       services.AddValidatorsFromAssemblyContaining<UpdateCustomerRequestValidator>();



        return services;
    }
}