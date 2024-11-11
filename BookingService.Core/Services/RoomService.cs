using BookingService.Core.Entities.Room;
using BookingService.Core.Interfaces;

namespace BookingService.Core.Services
{
    public class RoomService(IRoomRepository roomRepository) : IRoomService
    {
        public Task<RoomDetail> AddRoom(RoomDetail room, CancellationToken cancellationToken)
        {
            return roomRepository.AddRoom(room, cancellationToken);
        }

        public Task<RoomDetail?> GetRoom(int id, CancellationToken cancellationToken)
        {
            return roomRepository.GetRoom(id, cancellationToken);
        }

        public Task<List<RoomDetail>> GetAllRooms(CancellationToken cancellationToken)
        {
            var rooms = roomRepository.GetAllRooms(cancellationToken);

            return rooms;
        }

        public Task<RoomDetail> UpdateRoom(RoomDetail room, CancellationToken cancellationToken)
        {
            return roomRepository.UpdateRoom(room, cancellationToken);
        }

        public Task<bool> DeleteRoom(int id, CancellationToken cancellationToken)
        {
            return roomRepository.DeleteRoom(id, cancellationToken);
        }
    }
}
