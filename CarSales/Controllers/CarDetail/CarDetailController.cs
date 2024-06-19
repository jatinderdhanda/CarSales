using CarSales.Application.Commands.AddCarDetail;
using CarSales.Application.Commands.ReserveCarBooking;
using CarSales.Application.Queries.Booking.GetBookingDetails;
using CarSales.Domain.Enum;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarSales.Web.Controllers.CarDetail;

[ApiController]
[Route("[controller]")]
public class CarDetailController : ControllerBase
{
    private readonly ISender _sender;
    public CarDetailController(ISender sender)
    {
        _sender = sender;
    }
    [HttpPost("add")]
    public async Task<IActionResult> AdddNewCar([FromBody] AddCarDetailRequest request, CancellationToken cancellationToken)
    {
        var command = new AddCarDetailCommand {
            Name = request.Name,
            Color = request.Color,
            CompanyName = request.CompanyName,
            ManufactureYear = request.ManufactureYear,
            RegistrationNumber = request.RegistrationNumber,
            FuelType = ConvertToFuelType(request.FuelType)
        };

        var result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return CreatedAtAction(nameof(AdddNewCar), new { id = result.Value }, result.Value);
    }
    
    private FuelType ConvertToFuelType(string fuelTypeStr)
    {
        if (Enum.TryParse<FuelType>(fuelTypeStr, true, out var fuelType))
        {
            return fuelType;
        }
        else
        {
            throw new ArgumentException($"Invalid fuel type: {fuelTypeStr}");
            // Or handle the error in a way appropriate for your application
        }
    }
}
