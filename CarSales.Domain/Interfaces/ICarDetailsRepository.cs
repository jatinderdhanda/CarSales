using CarSales.Domain.Models;

namespace CarSales.Domain.Interfaces
{
    public interface ICarDetailsRepository
    {
        Task<CarDetails?> GetCarDetailsByIdAsync(Guid id);
        Task AddCarDetailsAsync(CarDetails carDetails);
    }
}
