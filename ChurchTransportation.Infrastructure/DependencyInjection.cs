using ChurchTransportation.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChurchTransportation.Infrastructure;

public static class DependencyInjection
{
    public const string DefaultConnectionName = "DefaultConnection";

    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(DefaultConnectionName);

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException(
                $"Connection string '{DefaultConnectionName}' was not found. " +
                "Set ConnectionStrings:DefaultConnection in appsettings.json.");
        }

        services.AddDbContext<ChurchTransportationDbContext>(options =>
            options.UseSqlServer(connectionString));

        return services;
    }
}
