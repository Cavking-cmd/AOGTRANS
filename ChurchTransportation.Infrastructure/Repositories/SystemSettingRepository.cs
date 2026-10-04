using ChurchTransportation.Application.Interfaces.Repositories;
using ChurchTransportation.Domain.Entities;
using ChurchTransportation.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ChurchTransportation.Infrastructure.Repositories;

public sealed class SystemSettingRepository : EfRepository<SystemSetting>, ISystemSettingRepository
{
    public SystemSettingRepository(ChurchTransportationDbContext context)
        : base(context)
    {
    }

    public Task<SystemSetting?> GetByKeyAsync(string key, CancellationToken cancellationToken = default)
    {
        return Query.FirstOrDefaultAsync(s => s.Key == key, cancellationToken);
    }

    public async Task<IReadOnlyList<SystemSetting>> GetByCategoryAsync(
        string category,
        CancellationToken cancellationToken = default)
    {
        return await Query
            .Where(s => s.Category == category)
            .OrderBy(s => s.Key)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<SystemSetting>> GetPublicSettingsAsync(
        CancellationToken cancellationToken = default)
    {
        return await Query
            .Where(s => s.IsPublic)
            .OrderBy(s => s.Key)
            .ToListAsync(cancellationToken);
    }
}