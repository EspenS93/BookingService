using System.ComponentModel.DataAnnotations;

namespace BookingService.Core.Entities.Room;

public class RoomDetail
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double BasePrice { get; set; }
    public bool IsAvailable { get; set; }
    public int Number { get; set; }
    public int Floor { get; set; }
    public int Beds { get; set; }
    public int MaxAdults { get; set; }
    public int? MaxChildren { get; set; }
    public int? MaxInfants { get; set; }
    public int MaxTotalOccupants { get; set; }
    public ICollection<RoomFacility> Facilities { get; set; } = [];
    public ICollection<RoomFeature> Features { get; set; } = [];
    public ICollection<Picture> Pictures { get; set; } = [];
}