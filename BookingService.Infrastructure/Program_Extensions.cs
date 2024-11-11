using BookingService.Core.Interfaces;
using BookingService.Infrastructure.Data;
using BookingService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BookingService.Infrastructure
{
    public static class Program_Extensions
    {
        public static IHostApplicationBuilder? AddBookingService(this IHostApplicationBuilder? builder)
        {
            builder?.AddNpgsqlDbContext<BookingServiceDbContext>("BookingServicePostgres", configureDbContextOptions:
                opts => opts.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
            builder?.Services.AddScoped<IRoomRepository, RoomRepository>();
            builder?.Services.AddScoped<IReservationRepository, ReservationRepository>();
            return builder;
        }
    }
}
