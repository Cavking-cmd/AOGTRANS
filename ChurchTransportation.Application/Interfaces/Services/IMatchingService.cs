using ChurchTransportation.Domain.Enums;
using ChurchTransportation.Domain.ValueObjects;

namespace ChurchTransportation.Application.Interfaces.Services;

public interface IMatchingService
{
    Task<IReadOnlyList<MatchingCandidate>> FindCandidatesAsync(
        Guid eventId,
        RideDirection direction,
        CancellationToken cancellationToken = default);

    Task<MatchingCandidate?> SelectBestCandidateAsync(
        Guid rideRequestId,
        CancellationToken cancellationToken = default);
}

public sealed record MatchingCandidate(
    Guid JourneyId,
    Guid DriverProfileId,
    Guid VehicleId,
    decimal Score,
    int SeatsAvailable,
    decimal PickupDetourKm,
    int? PickupDetourMinutes,
    string? Reason);
