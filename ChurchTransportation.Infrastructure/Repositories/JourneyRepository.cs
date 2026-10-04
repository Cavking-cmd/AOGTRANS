using ChurchTransportation.Application.Interfaces.Repositories;
using ChurchTransportation.Domain.Entities;
using ChurchTransportation.Domain.Enums;
using ChurchTransportation.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ChurchTransportation.Infrastructure.Repositories;

public sealed class JourneyRepository : EfRepository<Journey>, IJourneyRepository
{
    public JourneyRepository(ChurchTransportationDbContext context)
        : base(context)
    {
    }

    public Task<Journey?> GetByIdWithStopsAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return Query
            .Include(j => j.JourneyStops.OrderBy(s => s.SequenceNumber))
            .Include(j => j.DriverProfile)
                .ThenInclude(d => d.User)
            .Include(j => j.Vehicle)
            .FirstOrDefaultAsync(j => j.Id == id, cancellationToken);
    }

    public Task<Journey?> GetByIdWithAssignmentsAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return Query
            .Include(j => j.RideAssignments)
                .ThenInclude(a => a.RideRequest)
            .Include(j => j.Event)
            .FirstOrDefaultAsync(j => j.Id == id, cancellationToken);
    }

    public Task<Journey?> GetByReferenceCodeAsync(
        string referenceCode,
        CancellationToken cancellationToken = default)
    {
        return Query.FirstOrDefaultAsync(j => j.ReferenceCode == referenceCode, cancellationToken);
    }

    public async Task<IReadOnlyList<Journey>> GetByDriverProfileIdAsync(
        Guid driverProfileId,
        CancellationToken cancellationToken = default)
    {
        return await Query
            .Include(j => j.Event)
            .Include(j => j.Vehicle)
            .Where(j => j.DriverProfileId == driverProfileId)
            .OrderByDescending(j => j.PlannedStartTime)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Journey>> GetByEventIdAsync(
        Guid eventId,
        RideDirection direction,
        CancellationToken cancellationToken = default)
    {
        return await Query
            .Include(j => j.DriverProfile)
            .Include(j => j.Vehicle)
            .Where(j => j.EventId == eventId && j.Direction == direction)
            .OrderBy(j => j.PlannedStartTime)
            .ThenBy(j => j.ReferenceCode)
            .ToListAsync(cancellationToken);
    }

    public Task<Journey?> GetActiveByDriverProfileIdAsync(
        Guid driverProfileId,
        CancellationToken cancellationToken = default)
    {
        return Query
            .Include(j => j.JourneyStops.OrderBy(s => s.SequenceNumber))
            .Include(j => j.Event)
            .FirstOrDefaultAsync(j =>
                j.DriverProfileId == driverProfileId &&
                (j.Status == JourneyStatus.Dispatching || j.Status == JourneyStatus.InProgress),
                cancellationToken);
    }
}