using CarSales.Domain.Enum;
using MediatR;

namespace CarSales.Application.Commands
{
    public class AddCarDetailCommand: IRequest<bool>
    {
        public required string CarName { get; init; }
        public required string CarCompanyName { get; init; }
        public string? CarDescription { get; init; }
        public string? CarColor { get; init; }
        public string? CarManufactureYear { get; init; }
        public required string CarRegistrationNumber { get; init; }
        public FuelType FuelType { get; init; } = FuelType.Petrol;
    }
}
