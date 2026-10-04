namespace ChurchTransportation.Domain.Entities;

public class UserRole : BaseEntity
{
    public Guid UserId { get; set; }

    public Guid RoleId { get; set; }

    public DateTime? AssignedAt { get; set; }

    public Guid? AssignedByUserId { get; set; }

    public required User User { get; set; }

    public required Role Role { get; set; }
}