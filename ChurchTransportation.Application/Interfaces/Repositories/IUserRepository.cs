using ChurchTransportation.Domain.Entities;

namespace ChurchTransportation.Application.Interfaces.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);

    Task<bool> EmailExistsAsync(string email, CancellationToken cancellationToken = default);

    Task<User?> GetByIdWithRolesAsync(Guid id, CancellationToken cancellationToken = default);

    Task<User?> GetByIdWithProfilesAsync(Guid id, CancellationToken cancellationToken = default);

    Task AddRoleAsync(UserRole userRole, CancellationToken cancellationToken = default);

    void RemoveRole(UserRole userRole);
}
