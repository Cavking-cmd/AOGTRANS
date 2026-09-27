using ChurchTransportation.Domain.Entities;

namespace ChurchTransportation.Application.Interfaces.Repositories;

public interface IDelayIncidentRepository : IRepository<DelayIncident>
{
    Task<IReadOnlyList<DelayIncident>> GetByJourneyIdAsync(
        Guid journeyId,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<DelayIncident>> GetByJourneyStopIdAsync(
        Guid journeyStopId,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<DelayIncident>> GetUnresolvedByJourneyIdAsync(
        Guid journeyId,
        CancellationToken cancellationToken = default);
}
