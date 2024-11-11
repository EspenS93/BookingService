using BookingService.Core.Entities.Reservation;

namespace BookingService.Core.Interfaces
{
    public interface IReservationService
    {
        public Task<ReservationDetail> AddReservation(ReservationDetail reservationDetails, CancellationToken cancellationToken);
        public Task<ReservationDetail?> GetReservationDetail(int id, CancellationToken cancellationToken);
        public Task<List<ReservationDetail>> GetAllReservationDetails(CancellationToken cancellationToken);
        public Task<ReservationDetail> UpdateReservation(ReservationDetail reservationDetails, CancellationToken cancellationToken);
        public Task<bool> DeleteReservation(int id, CancellationToken cancellationToken);
    }
}
