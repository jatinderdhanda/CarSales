using CarSales.Domain.Models;

namespace CarSales.Infrastructure.Repositories.Interfaces
{
    public interface ICarDetailsRepository
    {
        Task<CarDetails?> GetAllCarDetailsAsync();
        Task AddCarDetailsAsync(CarDetails carDetails);
    }
}
