namespace ChurchTransportation.Domain.Entities;

public class SystemSetting
{
    public Guid Id { get; set; }

    public string Key { get; set; } = string.Empty;

    public string? Value { get; set; }

    public string? ValueType { get; set; }

    public string? Category { get; set; }

    public string? Description { get; set; }

    public bool IsPublic { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
