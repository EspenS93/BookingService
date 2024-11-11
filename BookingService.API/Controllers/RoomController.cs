using BookingService.Core.Entities.Room;
using BookingService.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using System.Text.Json;

namespace BookingService.API.Controllers;

[ApiController]
[Route("[controller]")]
public class RoomController(ILogger<RoomController> logger, IRoomService roomService, IDistributedCache cache) : ControllerBase
{
    [HttpGet("{id:int}", Name = "GetRoom")]
    public async Task<RoomDetail?> GetRoom(int id, CancellationToken cancellationToken)
    {
        var cachedRoom = await cache.GetAsync($"room-{id}", cancellationToken);
        if(cachedRoom != null)
        {
            logger.LogInformation("Getting room from cache with id {id}", id);

            return JsonSerializer.Deserialize<RoomDetail>(Encoding.UTF8.GetString(cachedRoom));
        }

        logger.LogInformation("Getting room with id {id}", id);
        var room = await roomService.GetRoom(id, cancellationToken);
        await cache.SetAsync("forecast", Encoding.UTF8.GetBytes(JsonSerializer.Serialize(room)), new()
        {
            AbsoluteExpiration = DateTime.Now.AddSeconds(30)
        }, cancellationToken);

        return room;
    }

    [HttpGet(Name = "GetRooms")]
    public async Task<List<RoomDetail>> GetRooms(CancellationToken cancellationToken)
    {
        var cachedRooms = await cache.GetAsync("rooms", cancellationToken);

        if (cachedRooms != null)
        {
            logger.LogInformation("Getting all rooms from cache");

            return JsonSerializer.Deserialize<List<RoomDetail>>(Encoding.UTF8.GetString(cachedRooms)) ?? [];
        }

        logger.LogInformation("Getting all rooms");
        var rooms = await roomService.GetAllRooms(cancellationToken);
        await cache.SetAsync("rooms", Encoding.UTF8.GetBytes(JsonSerializer.Serialize(rooms)), new()
        {
            AbsoluteExpiration = DateTime.Now.AddSeconds(30)
        }, cancellationToken);

        return rooms;
    }

    [HttpPost(Name = "PostRoom")]
    public async Task<RoomDetail> PostRoom([FromBody]RoomDetail room, CancellationToken cancellationToken)
    {
        logger.LogInformation("Adding room with id {id}", room.Id);
        
        var newRoom = await roomService.AddRoom(room, cancellationToken);
        await cache.RemoveAsync("rooms", cancellationToken);
        return newRoom;
    }

    [HttpPut(Name = "UpdateRoom")]
    public async Task<RoomDetail> UpdateRoom(RoomDetail room, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating room with id {id}", room.Id);
        var newRoom = await roomService.UpdateRoom(room, cancellationToken);
        await cache.RemoveAsync("rooms", cancellationToken);
        await cache.RemoveAsync($"room-{room.Id}", cancellationToken);
        return newRoom;

    }

    [HttpDelete(Name = "DeleteRoom")]
    public async Task DeleteRoom(int id, CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting room with id {id}", id);
        await roomService.DeleteRoom(id, cancellationToken);
        await cache.RemoveAsync("rooms", cancellationToken);
        await cache.RemoveAsync($"room-{id}", cancellationToken);
    }
}
