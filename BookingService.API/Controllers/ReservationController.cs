using BookingService.Core.Entities.Reservation;
using BookingService.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ReservationController(ILogger<ReservationController> logger, ReservationService reservationService) : ControllerBase
{
    [HttpGet("{id:int}", Name = "GetReservationDetail")]
    public async Task<ReservationDetail?> GetReservationDetail(int id, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting reservation details");
        return await reservationService.GetReservationDetail(id, cancellationToken);
    }

    [HttpGet(Name = "GetReservationDetails")]
    public async Task<List<ReservationDetail>> GetReservationDetails(CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all reservation details");
        return await reservationService.GetAllReservationDetails(cancellationToken);
    }

    [HttpPost(Name = "PostReservationDetails")]
    public async Task<ReservationDetail> PostReservationDetails(ReservationDetail reservationDetails, CancellationToken cancellationToken)
    {
        logger.LogInformation("Adding reservation details");
        return await reservationService.AddReservation(reservationDetails, cancellationToken);
    }
}
