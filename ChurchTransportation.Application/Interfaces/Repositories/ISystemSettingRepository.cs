using ChurchTransportation.Domain.Entities;

namespace ChurchTransportation.Application.Interfaces.Repositories;

public interface ISystemSettingRepository : IRepository<SystemSetting>
{
    Task<SystemSetting?> GetByKeyAsync(string key, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<SystemSetting>> GetByCategoryAsync(string category, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<SystemSetting>> GetPublicSettingsAsync(CancellationToken cancellationToken = default);
}
