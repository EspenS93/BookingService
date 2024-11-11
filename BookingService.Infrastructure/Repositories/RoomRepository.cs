using BookingService.Core.Entities.Room;
using BookingService.Core.Interfaces;
using BookingService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BookingService.Infrastructure.Repositories
{
    public class RoomRepository(ILogger<RoomRepository> logger, BookingServiceDbContext ctx): IRoomRepository
    {
        public async Task<RoomDetail> AddRoom(RoomDetail room, CancellationToken cancellationToken)
        {
            ctx.RoomDetails.Add(room);
            await ctx.SaveChangesAsync(cancellationToken);
            return room;
        }

        public async Task<bool> DeleteRoom(int id, CancellationToken cancellationToken)
        {
            var deletedRows = await ctx.RoomDetails.Where(rd => rd.Id == id).ExecuteDeleteAsync(cancellationToken);
            logger.LogDebug("Deleted {deletedRows} rows from RoomDetails", deletedRows);

            return deletedRows > 0;
        }

        public async Task<RoomDetail?> GetRoom(int id, CancellationToken cancellationToken)
        {
            return await ctx.RoomDetails.FindAsync([id], cancellationToken);
        }

        public async Task<List<RoomDetail>> GetAllRooms(CancellationToken cancellationToken)
        {
            return await ctx.RoomDetails.ToListAsync(cancellationToken);
        }

        public async Task<RoomDetail> UpdateRoom(RoomDetail room, CancellationToken cancellationToken)
        {
            ctx.RoomDetails.Update(room);
            await ctx.SaveChangesAsync(cancellationToken);
            return room;
        }
    }
}