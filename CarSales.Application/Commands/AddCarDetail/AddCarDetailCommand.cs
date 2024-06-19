using CarSales.Domain.Abstraction;
using CarSales.Domain.Enum;
using MediatR;

namespace CarSales.Application.Commands.AddCarDetail;

public class AddCarDetailCommand : IRequest<Result<Guid>>
{
    public required string Name { get; init; }
    public required string CompanyName { get; init; }
    public required string Color { get; init; }
    public required string ManufactureYear { get; init; }
    public required string RegistrationNumber { get; init; }
    public FuelType FuelType { get; init; } = FuelType.Petrol;
}
