using ChurchTransportation.Application.Common;
using ChurchTransportation.Domain.Entities;
using ChurchTransportation.Domain.Enums;

namespace ChurchTransportation.Application.Interfaces.Services;

public interface IVehicleService
{
    Task<OperationResult<Vehicle>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<Vehicle>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<IReadOnlyList<Vehicle>> GetByStatusAsync(VehicleStatus status, CancellationToken cancellationToken = default);

    Task<OperationResult<Vehicle>> CreateAsync(
        string registrationNumber,
        string? plateNumber,
        string? make,
        string? model,
        int? year,
        int capacity,
        CancellationToken cancellationToken = default);

    Task<OperationResult> UpdateAsync(
        Guid id,
        string registrationNumber,
        string? plateNumber,
        string? make,
        string? model,
        int? year,
        int capacity,
        CancellationToken cancellationToken = default);

    Task<OperationResult> SetStatusAsync(
        Guid id,
        VehicleStatus status,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<DriverProfile>> GetAssignedDriversAsync(
        Guid vehicleId,
        CancellationToken cancellationToken = default);
}
