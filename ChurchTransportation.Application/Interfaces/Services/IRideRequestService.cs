using ChurchTransportation.Application.Common;
using ChurchTransportation.Domain.Entities;
using ChurchTransportation.Domain.Enums;

namespace ChurchTransportation.Application.Interfaces.Services;

public interface IRideRequestService
{
    Task<OperationResult<RideRequest>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<RideRequest>> GetByPassengerAsync(
        Guid passengerProfileId,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<RideRequest>> GetByEventAsync(
        Guid eventId,
        RideDirection direction,
        CancellationToken cancellationToken = default);

    Task<OperationResult<RideRequest>> CreateAsync(
        Guid passengerProfileId,
        Guid eventId,
        RideDirection direction,
        string pickupAddress,
        decimal pickupLatitude,
        decimal pickupLongitude,
        int passengerCount,
        string? notes,
        CancellationToken cancellationToken = default);

    Task<OperationResult> CancelAsync(
        Guid id,
        string? reason,
        CancellationToken cancellationToken = default);

    Task<OperationResult> UpdatePickupAsync(
        Guid id,
        string pickupAddress,
        decimal pickupLatitude,
        decimal pickupLongitude,
        string? notes,
        CancellationToken cancellationToken = default);

    Task<OperationResult> SetStatusAsync(
        Guid id,
        RideRequestStatus status,
        CancellationToken cancellationToken = default);
}
