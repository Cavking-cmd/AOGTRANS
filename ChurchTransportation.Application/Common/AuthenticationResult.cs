using ChurchTransportation.Domain.Entities;

namespace ChurchTransportation.Application.Common;

public sealed record AuthenticationResult(
    string AccessToken,
    DateTime ExpiresAt,
    Guid UserId,
    string Email,
    IReadOnlyList<string> Roles)
{
    public User? User { get; init; }
}
