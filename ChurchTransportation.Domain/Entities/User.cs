using ChurchTransportation.Domain.Enums;

namespace ChurchTransportation.Domain.Entities;

public class User
{
    public Guid Id { get; set; }

    public string Email { get; set; } = string.Empty;

    public string? PasswordHash { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string? PhoneNumber { get; set; }

    public string? ProfileImageUrl { get; set; }

    public UserStatus Status { get; set; } = UserStatus.PendingActivation;

    public bool IsEmailVerified { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? LastLoginAt { get; set; }

    public DriverProfile? DriverProfile { get; set; }

    public PassengerProfile? PassengerProfile { get; set; }

    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

    public ICollection<ChatParticipant> ChatParticipants { get; set; } = new List<ChatParticipant>();

    public ICollection<ChatMessage> SentMessages { get; set; } = new List<ChatMessage>();

    public ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();
}
