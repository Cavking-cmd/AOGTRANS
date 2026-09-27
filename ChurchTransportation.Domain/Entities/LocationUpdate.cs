namespace ChurchTransportation.Domain.Entities;

public class LocationUpdate
{
    public Guid Id { get; set; }

    public Guid JourneyId { get; set; }

    public decimal Latitude { get; set; }

    public decimal Longitude { get; set; }

    public decimal? AccuracyMeters { get; set; }

    public decimal? SpeedKph { get; set; }

    public decimal? HeadingDegrees { get; set; }

    public decimal? AltitudeMeters { get; set; }

    public DateTime Timestamp { get; set; }

    public DateTime CreatedAt { get; set; }

    public Journey Journey { get; set; } = null!;
}
