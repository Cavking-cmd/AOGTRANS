using ChurchTransportation.Application.Interfaces.Repositories;
using ChurchTransportation.Domain.Entities;
using ChurchTransportation.Domain.Enums;
using ChurchTransportation.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ChurchTransportation.Infrastructure.Repositories;

public sealed class EventRepository : EfRepository<Event>, IEventRepository
{
    public EventRepository(ChurchTransportationDbContext context)
        : base(context)
    {
    }

    public Task<Event?> GetByIdWithRideRequestsAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return Query
            .Include(e => e.RideRequests)
                .ThenInclude(r => r.PassengerProfile)
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    public Task<Event?> GetByIdWithJourneysAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return Query
            .Include(e => e.Journeys)
                .ThenInclude(j => j.DriverProfile)
            .Include(e => e.Journeys)
                .ThenInclude(j => j.Vehicle)
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<Event>> GetByStatusAsync(
        EventStatus status,
        CancellationToken cancellationToken = default)
    {
        return await Query
            .Where(e => e.Status == status)
            .OrderBy(e => e.StartTime)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Event>> GetByDateRangeAsync(
        DateTime from,
        DateTime to,
        CancellationToken cancellationToken = default)
    {
        return await Query
            .Where(e => e.StartTime >= from && e.StartTime <= to)
            .OrderBy(e => e.StartTime)
            .ToListAsync(cancellationToken);
    }
}