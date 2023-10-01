using Application.IServices;
using Application.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace SenikWebApi;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddJWTConfiguration(this IServiceCollection services,
        string secretKey)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                                                    Encoding.UTF8.GetBytes(secretKey))
                    };
                });
        return services;
    }
    
    public static IServiceCollection AddSwaggerGenConfiguration(this IServiceCollection services)
    {
        services.AddSwaggerGen(opt =>
        {
            opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Senik Product Managment APIs", Version = "v1" });
            opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "bearer"
            });

            opt.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type=ReferenceType.SecurityScheme,
                        Id="Bearer"
                    }
                },
                new string[]{}
                }
            });
        });
        return services;
    }
    
    public static IServiceCollection AddServicesDIs(this IServiceCollection services)
    {
        services.AddScoped<IClaimService, ClaimService>();
        services.AddSingleton<IEmailService, EmailService>();
        return services;
    }
}
