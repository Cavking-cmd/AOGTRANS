using ChurchTransportation.Application.Common;
using ChurchTransportation.Domain.Entities;
using ChurchTransportation.Domain.Enums;

namespace ChurchTransportation.Application.Interfaces.Services;

public interface IDriverService
{
    Task<OperationResult<DriverProfile>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<OperationResult<DriverProfile>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<DriverProfile>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<IReadOnlyList<DriverProfile>> GetByStatusAsync(DriverStatus status, CancellationToken cancellationToken = default);

    Task<OperationResult<DriverProfile>> CreateAsync(
        Guid userId,
        string? licenseNumber,
        DateTime? licenseExpiryDate,
        string? notes,
        CancellationToken cancellationToken = default);

    Task<OperationResult> UpdateAsync(
        Guid id,
        string? licenseNumber,
        DateTime? licenseExpiryDate,
        string? notes,
        CancellationToken cancellationToken = default);

    Task<OperationResult> SetStatusAsync(
        Guid id,
        DriverStatus status,
        CancellationToken cancellationToken = default);

    Task<OperationResult> AssignVehicleAsync(
        Guid driverId,
        Guid vehicleId,
        bool isPrimary,
        CancellationToken cancellationToken = default);

    Task<OperationResult> UnassignVehicleAsync(
        Guid driverId,
        Guid vehicleId,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<Vehicle>> GetVehiclesAsync(Guid driverId, CancellationToken cancellationToken = default);
}
