using System.IdentityModel.Tokens.Jwt;
using System.Text;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using WarrantyManagement.Api.Exceptions;
using WarrantyManagement.Application.Interfaces;
using WarrantyManagement.Application.Services;


namespace WarrantyManagement.Api;


public static class DependencyInjection
{
    public static IServiceCollection AddApi(this IServiceCollection services,IConfiguration configuration)
    {
        
        services.AddControllers();
        services.AddProblemDetails();
        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddFluentValidationAutoValidation();

        services.AddAuthentication(option =>
        {
            
            option.DefaultAuthenticateScheme=JwtBearerDefaults.AuthenticationScheme;
            option.DefaultChallengeScheme=JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(option =>
        {
             var JWTSitting=configuration.GetSection("jwtInformation");
             var issuer=JWTSitting["Issuer"]??
                throw new InvalidOperationException("Invalid Issuer");
             var audience=JWTSitting["Audience"]??
                throw new InvalidOperationException("Invalid Audience");

            var Key=Encoding.UTF8.GetBytes(JWTSitting["Key"] ?? throw new InvalidOperationException("Invalid Audience"));
            option.TokenValidationParameters = new()
            {

               
                ValidateIssuer=true,
                ValidateAudience=true,
                ValidateIssuerSigningKey=true,
                ValidateLifetime=true,
                ValidIssuer=issuer,
                ValidAudience=issuer,
                IssuerSigningKey= new SymmetricSecurityKey(Key)

            };
        }
        );
        return services;
    }


}