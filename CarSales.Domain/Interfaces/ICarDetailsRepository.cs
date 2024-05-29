using CarSales.Domain.Models;

namespace CarSales.Domain.Interfaces
{
    public interface ICarDetailsRepository
    {
        Task<CarDetails?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        void Add(CarDetails carDetails);
    }
}
