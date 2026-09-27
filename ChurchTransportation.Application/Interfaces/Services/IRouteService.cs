using ChurchTransportation.Application.Common;
using ChurchTransportation.Domain.ValueObjects;

namespace ChurchTransportation.Application.Interfaces.Services;

public interface IRouteService
{
    Task<OperationResult<RouteResult>> CalculateAsync(
        GeoCoordinate origin,
        GeoCoordinate destination,
        CancellationToken cancellationToken = default);

    Task<OperationResult<RouteResult>> CalculateWithStopsAsync(
        GeoCoordinate origin,
        GeoCoordinate destination,
        IReadOnlyList<GeoCoordinate> stops,
        CancellationToken cancellationToken = default);

    Task<OperationResult<decimal>> GetDistanceAsync(
        GeoCoordinate origin,
        GeoCoordinate destination,
        CancellationToken cancellationToken = default);

    Task<OperationResult<int>> GetEstimatedTravelMinutesAsync(
        GeoCoordinate origin,
        GeoCoordinate destination,
        CancellationToken cancellationToken = default);
}
