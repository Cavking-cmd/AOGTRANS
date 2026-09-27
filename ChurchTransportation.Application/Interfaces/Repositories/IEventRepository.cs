using ChurchTransportation.Domain.Enums;
using ChurchTransportation.Domain.Entities;

namespace ChurchTransportation.Application.Interfaces.Repositories;

public interface IEventRepository : IRepository<Event>
{
    Task<Event?> GetByIdWithRideRequestsAsync(Guid id, CancellationToken cancellationToken = default);

    Task<Event?> GetByIdWithJourneysAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<Event>> GetByStatusAsync(EventStatus status, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<Event>> GetByDateRangeAsync(
        DateTime from,
        DateTime to,
        CancellationToken cancellationToken = default);
}
