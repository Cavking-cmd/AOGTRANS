using ChurchTransportation.Application.Interfaces.Repositories;
using ChurchTransportation.Domain.Entities;
using ChurchTransportation.Domain.Enums;
using ChurchTransportation.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ChurchTransportation.Infrastructure.Repositories;

public sealed class VehicleRepository : EfRepository<Vehicle>, IVehicleRepository
{
    public VehicleRepository(ChurchTransportationDbContext context)
        : base(context)
    {
    }

    public Task<Vehicle?> GetByRegistrationNumberAsync(
        string registrationNumber,
        CancellationToken cancellationToken = default)
    {
        return Query.FirstOrDefaultAsync(v => v.RegistrationNumber == registrationNumber, cancellationToken);
    }

    public async Task<IReadOnlyList<Vehicle>> GetByStatusAsync(
        VehicleStatus status,
        CancellationToken cancellationToken = default)
    {
        return await Query
            .Where(v => v.Status == status)
            .OrderBy(v => v.RegistrationNumber)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Vehicle>> GetAvailableForEventAsync(
        Guid eventId,
        RideDirection direction,
        int requiredCapacity,
        CancellationToken cancellationToken = default)
    {
        return await Query
            .Where(v => v.Status == VehicleStatus.Available && v.Capacity >= requiredCapacity)
            .Where(v => !v.Journeys.Any(j =>
                j.EventId == eventId &&
                j.Direction == direction &&
                (j.Status == JourneyStatus.Dispatching || j.Status == JourneyStatus.InProgress)))
            .OrderByDescending(v => v.Capacity)
            .ThenBy(v => v.RegistrationNumber)
            .ToListAsync(cancellationToken);
    }

    public Task<Vehicle?> GetByIdWithDriverVehiclesAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return Query
            .Include(v => v.DriverVehicles)
                .ThenInclude(dv => dv.DriverProfile)
                    .ThenInclude(d => d.User)
            .FirstOrDefaultAsync(v => v.Id == id, cancellationToken);
    }
}