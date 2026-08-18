using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using AdsSqlApi.Infrastructure.Persistence;
using AdsSqlApi.Application.Abstractions.Services;
using AdsSqlApi.Application.Abstractions.Persistence;
using AdsSqlApi.Infrastructure.Persistence.Repositories;
using AdsSqlApi.Infrastructure.Services;
using MediatR;
using System.Reflection;

namespace AdsSqlApi.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("SqlDatabase")));

        // Register repositories, services
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IWellService, WellService>();
        services.AddScoped<IPadsService, PadsService>();

        // Register MediatR handlers by scanning assemblies
        var assemblies = new[]
        {
            Assembly.GetExecutingAssembly(), // Infrastructure handlers
            Assembly.GetAssembly(typeof(AdsSqlApi.Application.Features.Wells.Commands.CreateWellCommand))!, // Application requests
        };
        services.AddMediatR(assemblies);

        return services;
    }
}
