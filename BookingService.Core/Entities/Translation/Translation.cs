using System.ComponentModel.DataAnnotations;

namespace BookingService.Core.Entities.Translation
{
    public class Translation
    {
        [Required]
        [MaxLength(100)]
        public required string ResourceKey { get; set; }

        [Required]
        [MaxLength(10)]
        public required string Culture { get; set; }

        [Required]
        [MaxLength(500)]
        public required string TranslatedValue { get; set; }
    }
}
