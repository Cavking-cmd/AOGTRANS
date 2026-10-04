namespace ChurchTransportation.Domain.Entities;

public class SystemSetting : BaseEntity
{
    public required string Key { get; set; }

    public string? Value { get; set; }

    public string? ValueType { get; set; }

    public string? Category { get; set; }

    public string? Description { get; set; }

    public bool IsPublic { get; set; }
}