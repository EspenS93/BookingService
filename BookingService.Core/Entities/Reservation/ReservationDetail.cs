namespace BookingService.Core.Entities.Reservation;
using BookingService.Core.Entities.Room;
using System.ComponentModel.DataAnnotations;

public class ReservationDetail
{
    [Key]
    public required int ReservationId { get; set; }
    public required RoomDetail Room { get; set; }
    public DateOnly ArrivalDate { get; set; }
    public DateOnly DepartureDate { get; set; }
    public required string ReservationName { get; set; }
    public string Company { get; set; } = string.Empty;
    public int NumberOfGuests { get; set; }
    public double TotalCost { get; set; }
    public double TotalCostPaid { get; set; }
    public double TotalCostDue { get; set; }
}
