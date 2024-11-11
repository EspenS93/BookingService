using BookingService.Core.Entities.Reservation;

namespace BookingService.Core.Interfaces
{
    public interface IReservationRepository
    {
        public Task<ReservationDetail> AddReservationDetails(ReservationDetail reservationDetails, CancellationToken cancellationToken);
        public Task<bool> DeleteReservation(int id, CancellationToken cancellationToken);
        public Task<ReservationDetail?> GetReservationDetail(int id, CancellationToken cancellationToken);
        public Task<List<ReservationDetail>> GetAllReservationDetails(CancellationToken cancellationToken);
        public Task<ReservationDetail> UpdateReservationDetails(ReservationDetail reservationDetails, CancellationToken cancellationToken);
    }
}