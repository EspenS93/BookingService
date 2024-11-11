using System.ComponentModel.DataAnnotations;

namespace AspireApp1.Web.Components.Pages.Rooms
{
    public class RoomDetailForm
    {
        [LocalizedDisplayName("RoomDetailForm.Name")]
        [Required(ErrorMessage = "The name is required.")]
        public required string Name { get; set; }

        [LocalizedDisplayName("RoomDetailForm.Price")]
        [DataType(DataType.Currency)]
        public double Price { get; set; }

        [LocalizedDisplayName("RoomDetailForm.Description")]
        public string Description { get; set; } = string.Empty;

        [LocalizedDisplayName("RoomDetailForm.IsAvailable")]
        public bool IsAvailable { get; set; }

        [LocalizedDisplayName("RoomDetailForm.Number")]
        public int Number { get; set; }

        [LocalizedDisplayName("RoomDetailForm.Floor")]
        public int Floor { get; set; }

        [LocalizedDisplayName("RoomDetailForm.Beds")]
        public int Beds { get; set; }

        [LocalizedDisplayName("RoomDetailForm.MaxAdults")]
        public int MaxAdults { get; set; }

        [LocalizedDisplayName("RoomDetailForm.MaxChildren")]
        public int? MaxChildren { get; set; }

        [LocalizedDisplayName("RoomDetailForm.MaxInfants")]
        public int? MaxInfants { get; set; }

        [LocalizedDisplayName("RoomDetailForm.MaxTotalOccupants")]
        public int MaxTotalOccupants { get; set; }
    }
}
