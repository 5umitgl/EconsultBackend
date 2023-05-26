using System.Text.RegularExpressions;
using Econsult.Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Econsult.Infrastructure.Implementations;
using Microsoft.Extensions.Logging;

namespace EConsult.Infrastructure;

public static class DependencyInjection
{
    private static readonly Regex InterfacePattern = new Regex("I(?:.+)DataService", RegexOptions.Compiled);

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IAuthRepository, AuthRepository>();
        services.AddScoped<IDoctorRepository, DoctorRepository>();
        services.AddScoped<IPatientRepository, PatientRepository>();
        services.AddScoped<IAddressRepository, AddressRepository>();

/*
        (from c in typeof(Application.DependencyInjection).Assembly.GetTypes()
         where c.IsInterface && InterfacePattern.IsMatch(c.Name)
         from i in typeof(DependencyInjection).Assembly.GetTypes()
         where c.IsAssignableFrom(i)
         select new
         {
             Contract = c,
             Implementation = i
         }).ToList()
        .ForEach(x => services.AddScoped(x.Contract, x.Implementation));

       // services.AddSingleton<IDateTimeService, DateTimeService>();
        //services.AddScoped(typeof(ILoggerService<>), typeof(LoggerService<>));

       // services.AddScoped<IAuthRepository, AuthRepository>();
        //services.AddScoped<IDoctorRepository, DoctorRepository>();
        //services.AddScoped<IPatientRepository, PatientRepository>();
        //services.AddScoped<IAddressRepository, AddressRepository>();
*/
        return services;
    }
   /* public static void ConfigureServices(IServiceCollection services)
    {
        // Register services and dependencies here

        services.AddTransient<IAuthService, AuthService>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddSingleton<ILogger, Logger>();

        // Additional configuration and service registrations

        // Example of adding MVC services
        services.AddControllers();
    }
   */
}
