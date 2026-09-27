using ChurchTransportation.Domain.Entities;

namespace ChurchTransportation.Application.Interfaces.Repositories;

public interface IPassengerRepository : IRepository<PassengerProfile>
{
    Task<PassengerProfile?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);

    Task<PassengerProfile?> GetByIdWithRideRequestsAsync(Guid id, CancellationToken cancellationToken = default);
}
