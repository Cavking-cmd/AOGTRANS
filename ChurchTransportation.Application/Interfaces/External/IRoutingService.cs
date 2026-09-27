using ChurchTransportation.Application.Common;
using ChurchTransportation.Domain.ValueObjects;

namespace ChurchTransportation.Application.Interfaces.External;

public interface IRoutingService
{
    Task<OperationResult<RouteResult>> GetRouteAsync(
        GeoCoordinate origin,
        GeoCoordinate destination,
        CancellationToken cancellationToken = default);

    Task<OperationResult<RouteResult>> GetRouteWithStopsAsync(
        GeoCoordinate origin,
        GeoCoordinate destination,
        IReadOnlyList<GeoCoordinate> stops,
        CancellationToken cancellationToken = default);
}
