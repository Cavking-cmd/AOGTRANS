namespace ChurchTransportation.Domain.Entities;

public class UserRole
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid RoleId { get; set; }

    public DateTime? AssignedAt { get; set; }

    public Guid? AssignedByUserId { get; set; }

    public User User { get; set; } = null!;

    public Role Role { get; set; } = null!;
}
