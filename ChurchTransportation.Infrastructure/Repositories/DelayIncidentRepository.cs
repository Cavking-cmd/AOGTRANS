using ChurchTransportation.Application.Interfaces.Repositories;
using ChurchTransportation.Domain.Entities;
using ChurchTransportation.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ChurchTransportation.Infrastructure.Repositories;

public sealed class DelayIncidentRepository : EfRepository<DelayIncident>, IDelayIncidentRepository
{
    public DelayIncidentRepository(ChurchTransportationDbContext context)
        : base(context)
    {
    }

    public async Task<IReadOnlyList<DelayIncident>> GetByJourneyIdAsync(
        Guid journeyId,
        CancellationToken cancellationToken = default)
    {
        return await Query
            .Include(d => d.JourneyStop)
            .Where(d => d.JourneyId == journeyId)
            .OrderByDescending(d => d.StartTime)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<DelayIncident>> GetByJourneyStopIdAsync(
        Guid journeyStopId,
        CancellationToken cancellationToken = default)
    {
        return await Query
            .Where(d => d.JourneyStopId == journeyStopId)
            .OrderByDescending(d => d.StartTime)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<DelayIncident>> GetUnresolvedByJourneyIdAsync(
        Guid journeyId,
        CancellationToken cancellationToken = default)
    {
        return await Query
            .Where(d => d.JourneyId == journeyId && !d.IsResolved)
            .OrderByDescending(d => d.StartTime)
            .ToListAsync(cancellationToken);
    }
}