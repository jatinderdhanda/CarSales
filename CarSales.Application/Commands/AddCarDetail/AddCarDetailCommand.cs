using CarSales.Domain.Abstraction;
using CarSales.Domain.Enum;
using MediatR;

namespace CarSales.Application.Commands.AddCarDetail
{
    public class AddCarDetailCommand : IRequest<Result<Guid>>
    {
        public required string CarName { get; init; }
        public required string CarCompanyName { get; init; }
        public string? CarDescription { get; init; }
        public required string CarColor { get; init; }
        public required string CarManufactureYear { get; init; }
        public required string CarRegistrationNumber { get; init; }
        public FuelType FuelType { get; init; } = FuelType.Petrol;
    }
}
