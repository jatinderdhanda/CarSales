using CarSales.Domain.Enum;

namespace CarSales.Domain.Models
{
    public sealed class CarDetails
    {
        public int Id { get; set; }
        public required string CarName { get; init; }
        public required string CarCompanyName { get; init; }
        public string? CarDescription { get; init; }
        public string? CarColor { get; init; }
        public string? CarManufactureYear { get; init; }
        public required string CarRegistrationNumber { get; init; }
        public Status Status { get; set; } = Status.Available;
        public FuelType FuelType { get; init; } = FuelType.Petrol;
    }
}
