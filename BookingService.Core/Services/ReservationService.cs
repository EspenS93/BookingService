using BookingService.Core.Entities.Reservation;
using BookingService.Core.Interfaces;

namespace BookingService.Core.Services
{
    public class ReservationService(IReservationRepository reservationRepository): IReservationService
    {
        public async Task<ReservationDetail> AddReservation(ReservationDetail reservationDetails, CancellationToken cancellationToken)
        {
            return await reservationRepository.AddReservationDetails(reservationDetails, cancellationToken);
        }

        public async Task<ReservationDetail?> GetReservationDetail(int id, CancellationToken cancellationToken)
        {
            return await reservationRepository.GetReservationDetail(id, cancellationToken);
        }

        public async Task<List<ReservationDetail>> GetAllReservationDetails(CancellationToken cancellationToken)
        {
            return await reservationRepository.GetAllReservationDetails(cancellationToken);
        }

        public async Task<ReservationDetail> UpdateReservation(ReservationDetail reservationDetails, CancellationToken cancellationToken)
        {
            return await reservationRepository.UpdateReservationDetails(reservationDetails, cancellationToken);
        }

        public async Task<bool> DeleteReservation(int id, CancellationToken cancellationToken)
        {
            return await reservationRepository.DeleteReservation(id, cancellationToken);
        }
    }
}
