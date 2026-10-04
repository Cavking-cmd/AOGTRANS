namespace ChurchTransportation.Domain.Entities;

public class LocationUpdate : BaseEntity
{
    public Guid JourneyId { get; set; }

    public decimal Latitude { get; set; }

    public decimal Longitude { get; set; }

    public decimal? AccuracyMeters { get; set; }

    public decimal? SpeedKph { get; set; }

    public decimal? HeadingDegrees { get; set; }

    public decimal? AltitudeMeters { get; set; }

    public DateTime Timestamp { get; set; }

    public required Journey Journey { get; set; }
}