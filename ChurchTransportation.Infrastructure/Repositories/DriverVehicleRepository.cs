using ChurchTransportation.Application.Interfaces.Repositories;
using ChurchTransportation.Domain.Entities;
using ChurchTransportation.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ChurchTransportation.Infrastructure.Repositories;

public sealed class DriverVehicleRepository : EfRepository<DriverVehicle>, IDriverVehicleRepository
{
    public DriverVehicleRepository(ChurchTransportationDbContext context)
        : base(context)
    {
    }

    public async Task<IReadOnlyList<DriverVehicle>> GetByDriverProfileIdAsync(
        Guid driverProfileId,
        CancellationToken cancellationToken = default)
    {
        return await Query
            .Include(dv => dv.Vehicle)
            .Where(dv => dv.DriverProfileId == driverProfileId)
            .OrderByDescending(dv => dv.IsPrimary)
            .ThenByDescending(dv => dv.AssignedFrom)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<DriverVehicle>> GetByVehicleIdAsync(
        Guid vehicleId,
        CancellationToken cancellationToken = default)
    {
        return await Query
            .Include(dv => dv.DriverProfile)
                .ThenInclude(d => d.User)
            .Where(dv => dv.VehicleId == vehicleId)
            .OrderByDescending(dv => dv.AssignedFrom)
            .ToListAsync(cancellationToken);
    }

    public Task<DriverVehicle?> GetCurrentByDriverProfileIdAsync(
        Guid driverProfileId,
        CancellationToken cancellationToken = default)
    {
        return Query
            .Include(dv => dv.Vehicle)
            .Where(dv => dv.DriverProfileId == driverProfileId && dv.AssignedTo == null)
            .OrderByDescending(dv => dv.IsPrimary)
            .ThenByDescending(dv => dv.AssignedFrom)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public Task<DriverVehicle?> GetCurrentByVehicleIdAsync(
        Guid vehicleId,
        CancellationToken cancellationToken = default)
    {
        return Query
            .Include(dv => dv.DriverProfile)
                .ThenInclude(d => d.User)
            .Where(dv => dv.VehicleId == vehicleId && dv.AssignedTo == null)
            .OrderByDescending(dv => dv.AssignedFrom)
            .FirstOrDefaultAsync(cancellationToken);
    }
}