using CarSales.Application.Commands.ReserveCarBooking;
using CarSales.Application.Queries.Booking.GetBookingDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarSales.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class BookingController : ControllerBase
{
    private readonly ISender _sender;
    public BookingController(ISender sender)
    {
        _sender = sender;
    }
    [HttpPost("reserve")]
    public async Task<IActionResult> ReserveBooking([FromBody] ReserveBookingRequest request, CancellationToken cancellationToken)
    {
        var command = new ReserveBookingCommand(
            request.CarId,
            request.EmployeeId,
            request.CustomerId,
            request.StartDate,
            request.EndDate);

        var result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return CreatedAtAction(nameof(ReserveBooking), new { id = result.Value }, result.Value);
    }

    [HttpGet("getBookingsForCar/{carId}")]
    public async Task<IActionResult> GetBooking(Guid carId, CancellationToken cancellationToken)
    {
        var query = new GetBookingDetailQuery(carId);

        var result = await _sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }
}
