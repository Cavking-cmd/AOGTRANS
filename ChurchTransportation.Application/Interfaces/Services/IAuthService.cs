using ChurchTransportation.Application.Common;
using ChurchTransportation.Domain.Entities;

namespace ChurchTransportation.Application.Interfaces.Services;

public interface IAuthService
{
    Task<OperationResult<AuthenticationResult>> RegisterPassengerAsync(
        string email,
        string password,
        string firstName,
        string lastName,
        string? phoneNumber,
        CancellationToken cancellationToken = default);

    Task<OperationResult<AuthenticationResult>> LoginAsync(
        string email,
        string password,
        CancellationToken cancellationToken = default);

    Task<OperationResult<AuthenticationResult>> RefreshTokenAsync(
        string accessToken,
        CancellationToken cancellationToken = default);

    Task<OperationResult> LogoutAsync(string accessToken, CancellationToken cancellationToken = default);

    Task<OperationResult> ChangePasswordAsync(
        Guid userId,
        string currentPassword,
        string newPassword,
        CancellationToken cancellationToken = default);

    Task<OperationResult> ResetPasswordAsync(
        string email,
        CancellationToken cancellationToken = default);
}
