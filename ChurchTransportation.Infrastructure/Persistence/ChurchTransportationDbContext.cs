using ChurchTransportation.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChurchTransportation.Infrastructure.Persistence;

public class ChurchTransportationDbContext : DbContext
{
    public ChurchTransportationDbContext(DbContextOptions<ChurchTransportationDbContext> options)
        : base(options)
    {
    }

    // Identity
    public DbSet<User> Users => Set<User>();

    public DbSet<Role> Roles => Set<Role>();

    public DbSet<UserRole> UserRoles => Set<UserRole>();

    public DbSet<DriverProfile> DriverProfiles => Set<DriverProfile>();

    public DbSet<PassengerProfile> PassengerProfiles => Set<PassengerProfile>();

    // Transportation
    public DbSet<Event> Events => Set<Event>();

    public DbSet<Vehicle> Vehicles => Set<Vehicle>();

    public DbSet<DriverVehicle> DriverVehicles => Set<DriverVehicle>();

    public DbSet<RideRequest> RideRequests => Set<RideRequest>();

    public DbSet<RideAssignment> RideAssignments => Set<RideAssignment>();

    public DbSet<Journey> Journeys => Set<Journey>();

    public DbSet<JourneyStop> JourneyStops => Set<JourneyStop>();

    // Operations
    public DbSet<LocationUpdate> LocationUpdates => Set<LocationUpdate>();

    public DbSet<DelayIncident> DelayIncidents => Set<DelayIncident>();

    public DbSet<Notification> Notifications => Set<Notification>();

    // Communication
    public DbSet<ChatRoom> ChatRooms => Set<ChatRoom>();

    public DbSet<ChatParticipant> ChatParticipants => Set<ChatParticipant>();

    public DbSet<ChatMessage> ChatMessages => Set<ChatMessage>();

    // Administration
    public DbSet<SystemSetting> SystemSettings => Set<SystemSetting>();

    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ChurchTransportationDbContext).Assembly);
    }
}
