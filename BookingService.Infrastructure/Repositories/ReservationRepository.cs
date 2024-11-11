using BookingService.Core.Entities.Reservation;
using BookingService.Core.Interfaces;
using BookingService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Infrastructure.Repositories
{
    public class ReservationRepository(BookingServiceDbContext ctx) : IReservationRepository
    {
        public async Task<ReservationDetail> AddReservationDetails(ReservationDetail reservationDetails, CancellationToken cancellationToken)
        {
            ctx.ReservationDetails.Add(reservationDetails);
            await ctx.SaveChangesAsync(cancellationToken);
            return reservationDetails;
        }

        public async Task<bool> DeleteReservation(int id, CancellationToken cancellationToken)
        {
            return await ctx.ReservationDetails.Where(rd => rd.ReservationId == id).ExecuteDeleteAsync(cancellationToken) == 1;
        }

        public async Task<ReservationDetail?> GetReservationDetail(int id, CancellationToken cancellationToken)
        {
            return await ctx.ReservationDetails.Where(rd => rd.ReservationId == id).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<List<ReservationDetail>> GetAllReservationDetails(CancellationToken cancellationToken)
        {
            return await ctx.ReservationDetails.ToListAsync(cancellationToken);
        }

        public async Task<ReservationDetail> UpdateReservationDetails(ReservationDetail reservationDetails, CancellationToken cancellationToken)
        {
            ctx.ReservationDetails.Update(reservationDetails);
            await ctx.SaveChangesAsync(cancellationToken);
            return reservationDetails;
        }
    }
}