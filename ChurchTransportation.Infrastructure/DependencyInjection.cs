using ChurchTransportation.Application.Interfaces.Repositories;
using ChurchTransportation.Infrastructure.Persistence;
using ChurchTransportation.Infrastructure.Repositories;
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

        services.AddScoped<IUnitOfWork, EfUnitOfWork>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IDriverRepository, DriverRepository>();
        services.AddScoped<IPassengerRepository, PassengerRepository>();
        services.AddScoped<IEventRepository, EventRepository>();
        services.AddScoped<IVehicleRepository, VehicleRepository>();
        services.AddScoped<IDriverVehicleRepository, DriverVehicleRepository>();
        services.AddScoped<IRideRequestRepository, RideRequestRepository>();
        services.AddScoped<IRideAssignmentRepository, RideAssignmentRepository>();
        services.AddScoped<IJourneyRepository, JourneyRepository>();
        services.AddScoped<IJourneyStopRepository, JourneyStopRepository>();
        services.AddScoped<ILocationUpdateRepository, LocationUpdateRepository>();
        services.AddScoped<IDelayIncidentRepository, DelayIncidentRepository>();
        services.AddScoped<INotificationRepository, NotificationRepository>();
        services.AddScoped<IChatRepository, ChatRepository>();
        services.AddScoped<IChatParticipantRepository, ChatParticipantRepository>();
        services.AddScoped<IChatMessageRepository, ChatMessageRepository>();
        services.AddScoped<ISystemSettingRepository, SystemSettingRepository>();
        services.AddScoped<IAuditLogRepository, AuditLogRepository>();

        return services;
    }
}