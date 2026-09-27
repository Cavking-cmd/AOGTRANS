namespace ChurchTransportation.Domain.ValueObjects;

public sealed record GeoCoordinate
{
    public decimal Latitude { get; init; }

    public decimal Longitude { get; init; }
}
