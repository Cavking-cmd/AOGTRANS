using ChurchTransportation.Application.Common;
using ChurchTransportation.Domain.Entities;

namespace ChurchTransportation.Application.Interfaces.Services;

public interface IUserService
{
    Task<OperationResult<User>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<OperationResult<User>> GetByEmailAsync(string email, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<User>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<OperationResult<User>> UpdateAsync(
        Guid id,
        string firstName,
        string lastName,
        string? phoneNumber,
        string? profileImageUrl,
        CancellationToken cancellationToken = default);

    Task<OperationResult> SetStatusAsync(
        Guid id,
        ChurchTransportation.Domain.Enums.UserStatus status,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<string>> GetRolesAsync(Guid userId, CancellationToken cancellationToken = default);

    Task<OperationResult> AddRoleAsync(Guid userId, Guid roleId, CancellationToken cancellationToken = default);

    Task<OperationResult> RemoveRoleAsync(Guid userId, Guid roleId, CancellationToken cancellationToken = default);
}
