using CarSales.Domain.Abstraction;
using CarSales.Domain.Enum;

namespace CarSales.Domain.Models
{
    public sealed class CarDetails : Entity
    {
        public CarDetails(Guid id,
            string name,
            string companyName,
            string color,
            string manufacturerYear,
            string registrationNumber,
            CarStatus status,
            FuelType fuelType) :base(id) {
            Name = name;
            CompanyName = companyName;
            Color = color;
            ManufactureYear = manufacturerYear;
            RegistrationNumber = registrationNumber;
            Status = status;
            FuelType = fuelType;
        }

        public string Name { get; private set; }
        public string CompanyName { get; private set; }
        public string? Color { get; private set; }
        public string? ManufactureYear { get; private set; }
        public string RegistrationNumber { get; private set; }
        public CarStatus Status { get; private set; } = CarStatus.Available;
        public FuelType FuelType { get; private set; } = FuelType.Petrol;
    }
}
