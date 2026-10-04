namespace ChurchTransportation.Domain.Entities;

public class AuditLog : BaseEntity
{
    public Guid? UserId { get; set; }

    public required string Action { get; set; }

    public required string EntityType { get; set; }

    public string? EntityId { get; set; }

    public string? Description { get; set; }

    public string? IpAddress { get; set; }

    public string? Metadata { get; set; }

    public User? User { get; set; }
}