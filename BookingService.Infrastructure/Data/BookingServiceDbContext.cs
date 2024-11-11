using BookingService.Core.Entities.Reservation;
using BookingService.Core.Entities.Room;
using BookingService.Core.Entities.Translation;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Infrastructure.Data
{
    public class BookingServiceDbContext(DbContextOptions<BookingServiceDbContext> options) : DbContext(options)
    {
        public DbSet<RoomDetail> RoomDetails { get; set; }
        public DbSet<ReservationDetail> ReservationDetails { get; set; }
        public DbSet<Translation> Translations { get; set; }

        // Add other DbSet properties for your entities

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Translation>()
            .HasKey(t => new { t.ResourceKey, t.Culture });
        }
    }
}
