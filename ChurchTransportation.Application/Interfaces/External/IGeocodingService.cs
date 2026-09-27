using ChurchTransportation.Application.Common;
using ChurchTransportation.Domain.ValueObjects;

namespace ChurchTransportation.Application.Interfaces.External;

public interface IGeocodingService
{
    Task<OperationResult<GeoCoordinate>> GeocodeAsync(
        string address,
        CancellationToken cancellationToken = default);

    Task<OperationResult<string>> ReverseGeocodeAsync(
        GeoCoordinate coordinate,
        CancellationToken cancellationToken = default);
}
