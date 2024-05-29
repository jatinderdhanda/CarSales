using CarSales.Domain.Models;
using CarSales.Domain.Shared;

namespace CarSales.Domain.Interfaces
{
    public interface IBookingRepository
    {
        Task<Booking?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<bool> IsOverlappingAsync(
        Guid carId,
        DateRange duration,
        CancellationToken cancellationToken = default);

        void Add(Booking booking);
    }
}
