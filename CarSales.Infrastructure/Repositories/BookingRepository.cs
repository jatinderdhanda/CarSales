using CarSales.Domain.Enum;
using CarSales.Domain.Interfaces;
using CarSales.Domain.Models;
using CarSales.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace CarSales.Infrastructure.Repositories
{
    internal sealed class BookingRepository : GenericRepository<Booking>, IBookingRepository
    {
        public BookingRepository(CarSalesDbContext dbContext) : base(dbContext)
        {
        }

        private static readonly BookingStatus[] ActiveBookingStatuses =
        {
            BookingStatus.Reserved,
            BookingStatus.Confirmed,
            BookingStatus.Completed
        };

        public async Task<bool> IsOverlappingAsync(Guid carId, DateRange duration, CancellationToken cancellationToken = default)
        {
            return await _dbContext
            .Set<Booking>()
            .AnyAsync(
                booking =>
                    booking.CarId == carId &&
                    booking.Duration.Start <= duration.End &&
                    booking.Duration.End >= duration.Start &&
                    ActiveBookingStatuses.Contains(booking.BookingStatus),
                cancellationToken);
        }
    }
}
