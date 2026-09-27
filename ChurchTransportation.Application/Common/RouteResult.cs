using ChurchTransportation.Domain.ValueObjects;

namespace ChurchTransportation.Application.Common;

public sealed record RouteResult(
    string? Polyline,
    decimal? DistanceKm,
    int? DurationMinutes,
    IReadOnlyList<GeoCoordinate> Waypoints)
{
    public static RouteResult Empty { get; } = new(null, null, null, Array.Empty<GeoCoordinate>());
}
