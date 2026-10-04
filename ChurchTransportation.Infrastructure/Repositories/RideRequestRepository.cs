using ChurchTransportation.Application.Interfaces.Repositories;
using ChurchTransportation.Domain.Entities;
using ChurchTransportation.Domain.Enums;
using ChurchTransportation.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ChurchTransportation.Infrastructure.Repositories;

public sealed class RideRequestRepository : EfRepository<RideRequest>, IRideRequestRepository
{
    public RideRequestRepository(ChurchTransportationDbContext context)
        : base(context)
    {
    }

    public Task<RideRequest?> GetByIdWithAssignmentAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return Query
            .Include(r => r.RideAssignment)
            .Include(r => r.PassengerProfile)
            .Include(r => r.Event)
            .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
    }

    public Task<RideRequest?> GetByIdWithJourneyStopsAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return Query
            .Include(r => r.JourneyStops)
            .Include(r => r.PassengerProfile)
            .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<RideRequest>> GetByEventIdAsync(
        Guid eventId,
        RideDirection direction,
        CancellationToken cancellationToken = default)
    {
        return await Query
            .Include(r => r.PassengerProfile)
            .Where(r => r.EventId == eventId && r.Direction == direction)
            .OrderBy(r => r.RequestedAt)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<RideRequest>> GetByPassengerProfileIdAsync(
        Guid passengerProfileId,
        CancellationToken cancellationToken = default)
    {
        return await Query
            .Include(r => r.Event)
            .Include(r => r.RideAssignment)
            .Where(r => r.PassengerProfileId == passengerProfileId)
            .OrderByDescending(r => r.RequestedAt)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<RideRequest>> GetByStatusForEventAsync(
        Guid eventId,
        RideRequestStatus status,
        CancellationToken cancellationToken = default)
    {
        return await Query
            .Include(r => r.PassengerProfile)
            .Where(r => r.EventId == eventId && r.Status == status)
            .OrderBy(r => r.RequestedAt)
            .ToListAsync(cancellationToken);
    }
}