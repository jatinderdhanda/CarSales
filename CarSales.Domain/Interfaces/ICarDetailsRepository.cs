using CarSales.Domain.Models;

namespace CarSales.Domain.Interfaces
{
    public interface ICarDetailsRepository
    {
        Task<CarDetail?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        void Add(CarDetail carDetails);
    }
}
