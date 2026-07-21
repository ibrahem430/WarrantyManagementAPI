using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using WarrantyManagement.Application.Services;
using WarrantyManagement.Application.Validators.Customers;
using WarrantyManagement.Application.Validators.Login;
using WarrantyManagement.Application.Validators.Products;
using WarrantyManagement.Application.Validators.Register;
using WarrantyManagement.Application.Validators.Sales;
using WarrantyManagement.Application.Validators.Warranties;
using WarrantyManagement.Application.Validators.WarrantyClaims;

namespace WarrantyManagement.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ProductService>();
        services.AddScoped<CustomerService>();
        services.AddScoped<SaleService>();
        services.AddScoped<WarrantyService>();
        services.AddScoped<WarrantyClaimService>();
        services.AddScoped<LoginService>();
        services.AddScoped<RegisterService>();
         services.AddScoped<RefreshTokenService>();
         services.AddScoped<LogoutService>();


       services.AddValidatorsFromAssemblyContaining<CreateProductRequestValidator>();
       services.AddValidatorsFromAssemblyContaining<UpdateProductRequestValidator>();
       services.AddValidatorsFromAssemblyContaining<CreateCustomerRequestValidator>();
       services.AddValidatorsFromAssemblyContaining<UpdateCustomerRequestValidator>();
       services.AddValidatorsFromAssemblyContaining<CreateSaleRequestValidator>();
       services.AddValidatorsFromAssemblyContaining<CreateWarrantyRequestValidator>();
       services.AddValidatorsFromAssemblyContaining<UpdateWarrantyClaimRequestValidator>();
       services.AddValidatorsFromAssemblyContaining<CreateWarrantyClaimRequestValidator>();
       services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
       services.AddValidatorsFromAssemblyContaining<RefreshTokenRequestValidator>();
       services.AddValidatorsFromAssemblyContaining<RegisterRequestValidator>();




        return services;
    }
}