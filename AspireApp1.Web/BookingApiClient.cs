
using BookingService.Core.Entities.Room;

namespace AspireApp1.Web;

public class BookingApiClient(HttpClient httpClient)
{
    public async Task<RoomDetail[]> GetRoomsAsync(int maxItems = 10, CancellationToken cancellationToken = default)
    {
        List<RoomDetail>? rooms = null;

        await foreach (var room in httpClient.GetFromJsonAsAsyncEnumerable<RoomDetail>("/room", cancellationToken))
        {
            if (rooms?.Count >= maxItems)
            {
                break;
            }
            if (room is not null)
            {
                rooms ??= [];
                rooms.Add(room);
            }
        }

        return rooms?.ToArray() ?? [];
    }

    public async Task<RoomDetail> GetRoomAsync(int id, CancellationToken cancellationToken = default)
    {
        var room = await httpClient.GetFromJsonAsync<RoomDetail>($"/room/{id}", cancellationToken) ?? throw new InvalidOperationException("Room not found");
        return room;
    }

    public async Task<RoomDetail> AddRoomAsync(RoomDetail room, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PostAsJsonAsync("/room", room, cancellationToken);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<RoomDetail>(cancellationToken: cancellationToken) ?? throw new InvalidOperationException("Failed to add room");
        }

        throw new InvalidOperationException("Failed to add room");
    }

    public async Task<RoomDetail> UpdateRoomAsync(RoomDetail room, CancellationToken cancellationToken = default)
    {

        var response = await httpClient.PutAsJsonAsync("/room", room, cancellationToken);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<RoomDetail>(cancellationToken: cancellationToken) ?? throw new InvalidOperationException("Failed to update room");
        }

        throw new InvalidOperationException("Failed to update room");
    }

    public async Task<bool> DeleteRoomAsync(int id, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.DeleteAsync($"/room/{id}", cancellationToken);

        if (response.IsSuccessStatusCode)
        {
            return true;
        }

        throw new InvalidOperationException("Failed to delete room");
    }
}