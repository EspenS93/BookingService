namespace BookingService.Core.Entities.Room;

public class RoomFacility
{
    public int ID { get; set; }
    public required string Name { get; set; }
    public int Amount { get; set; }
}