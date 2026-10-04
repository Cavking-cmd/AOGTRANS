using ChurchTransportation.Application.Interfaces.Repositories;
using ChurchTransportation.Domain.Entities;
using ChurchTransportation.Domain.Enums;
using ChurchTransportation.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ChurchTransportation.Infrastructure.Repositories;

public sealed class DriverRepository : EfRepository<DriverProfile>, IDriverRepository
{
    public DriverRepository(ChurchTransportationDbContext context)
        : base(context)
    {
    }

    public Task<DriverProfile?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return Query
            .Include(d => d.User)
            .FirstOrDefaultAsync(d => d.UserId == userId, cancellationToken);
    }

    public async Task<IReadOnlyList<DriverProfile>> GetByStatusAsync(
        DriverStatus status,
        CancellationToken cancellationToken = default)
    {
        return await Query
            .Include(d => d.User)
            .Where(d => d.Status == status)
            .OrderBy(d => d.User!.LastName)
            .ThenBy(d => d.User!.FirstName)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<DriverProfile>> GetAvailableForEventAsync(
        Guid eventId,
        RideDirection direction,
        CancellationToken cancellationToken = default)
    {
        return await Query
            .Include(d => d.User)
            .Include(d => d.DriverVehicles)
                .ThenInclude(dv => dv.Vehicle)
            .Where(d => d.Status == DriverStatus.Available || d.Status == DriverStatus.Assigned)
            .Where(d => d.DriverVehicles.Any(dv => dv.AssignedTo == null))
            .Where(d => !d.Journeys.Any(j =>
                j.EventId == eventId &&
                j.Direction == direction &&
                (j.Status == JourneyStatus.Dispatching || j.Status == JourneyStatus.InProgress)))
            .OrderBy(d => d.User!.LastName)
            .ToListAsync(cancellationToken);
    }

    public Task<DriverProfile?> GetByIdWithVehiclesAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return Query
            .Include(d => d.User)
            .Include(d => d.DriverVehicles)
                .ThenInclude(dv => dv.Vehicle)
            .FirstOrDefaultAsync(d => d.Id == id, cancellationToken);
    }

    public Task<DriverProfile?> GetByIdWithJourneysAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return Query
            .Include(d => d.User)
            .Include(d => d.Journeys)
                .ThenInclude(j => j.Event)
            .FirstOrDefaultAsync(d => d.Id == id, cancellationToken);
    }
}