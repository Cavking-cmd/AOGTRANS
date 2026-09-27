namespace ChurchTransportation.Domain.Enums;

public enum RideRequestStatus
{
    Pending = 1,
    Assigned = 2,
    Confirmed = 3,
    PickedUp = 4,
    DroppedOff = 5,
    Completed = 6,
    Cancelled = 7,
    NoShow = 8
}
