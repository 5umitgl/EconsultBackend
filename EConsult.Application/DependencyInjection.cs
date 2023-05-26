using System.Reflection;
using Econsult.Infrastructure.Implementations;
using Econsult.Infrastructure.Interfaces;
using EConsult.Application.Interfaces;
using EConsult.Application.Services;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EConsult.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient(typeof(IRequestValidator<>), typeof(RequestValidator<>));

        var thisAssembly = Assembly.GetExecutingAssembly();
        services.AddAutoMapper(thisAssembly);
        services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssembly(thisAssembly));
        services.AddMediatR(thisAssembly);

       /* services.AddScoped<IAuthService,AuthService>();
        services.AddScoped<IDoctorService, DoctorService>();
        services.AddScoped<IPatientService, PatientService>();
        services.AddScoped<IAddressService, AddressService>();
       */
        return services;
    }
    public static void ConfigureServices(IServiceCollection services)
    {
        // Register services and dependencies here

        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IDoctorService, DoctorService>();
        services.AddScoped<IPatientService, PatientService>();
        services.AddScoped<IAddressService, AddressService>();

        // Additional configuration and service registrations

        // Example of adding MVC services
        services.AddControllers();
    }

}
