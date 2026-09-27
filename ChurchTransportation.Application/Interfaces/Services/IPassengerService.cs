using ChurchTransportation.Application.Common;
using ChurchTransportation.Domain.Entities;

namespace ChurchTransportation.Application.Interfaces.Services;

public interface IPassengerService
{
    Task<OperationResult<PassengerProfile>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<OperationResult<PassengerProfile>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<PassengerProfile>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<OperationResult<PassengerProfile>> CreateAsync(
        Guid userId,
        string? phoneNumber,
        string? emergencyContactName,
        string? emergencyContactPhone,
        CancellationToken cancellationToken = default);

    Task<OperationResult> UpdateAsync(
        Guid id,
        string? phoneNumber,
        string? emergencyContactName,
        string? emergencyContactPhone,
        string? defaultPickupAddress,
        decimal? defaultPickupLatitude,
        decimal? defaultPickupLongitude,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<RideRequest>> GetRideRequestsAsync(
        Guid passengerId,
        CancellationToken cancellationToken = default);
}
