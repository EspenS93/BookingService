using BookingService.Core.Entities.Room;

namespace BookingService.Core.Interfaces
{
    public interface IRoomService
    {
        public Task<RoomDetail> AddRoom(RoomDetail room, CancellationToken cancellationToken);
        public Task<RoomDetail?> GetRoom(int id, CancellationToken cancellationToken);
        public Task<List<RoomDetail>> GetAllRooms(CancellationToken cancellationToken);
        public Task<RoomDetail> UpdateRoom(RoomDetail room, CancellationToken cancellationToken);
        public Task<bool> DeleteRoom(int id, CancellationToken cancellationToken);
    }
}
