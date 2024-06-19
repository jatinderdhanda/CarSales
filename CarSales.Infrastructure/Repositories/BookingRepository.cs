using CarSales.Application.Queries.Booking.GetBookingDetails;
using CarSales.Domain.Enum;
using CarSales.Domain.Interfaces;
using CarSales.Domain.Models;
using CarSales.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace CarSales.Infrastructure.Repositories;

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
        return await _dbContext.Bookings
        .AnyAsync(
            booking =>
                booking.CarId == carId &&
                ActiveBookingStatuses.Contains(booking.Status),
            cancellationToken);
    }

    public async Task<IEnumerable<BookingResponse>> GetAllBookingsForCarIdAsync(Guid carId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Bookings
            .Join(_dbContext.CarDetails,
                booking => booking.CarId,
                carDetail => carDetail.Id,
                (booking, carDetail) => new { Booking = booking, CarDetail = carDetail })
            .Where(bc => bc.Booking.CarId == carId)
            .Select(bc => new BookingResponse
            {
                CarId = bc.Booking.CarId,
                BookingId = bc.Booking.Id,
                CarName = bc.CarDetail.Name,
                CustomerId = bc.Booking.CustomerId,
                EmployeeId = bc.Booking.EmployeeId,
                CreatedOnUtc = bc.Booking.CreatedOnUtc,
                ModifiedOnUtc = bc.Booking.ModifiedOnUtc,
                ConfirmedOnUtc = bc.Booking.ConfirmedOnUtc,
                RejectedOnUtc = bc.Booking.RejectedOnUtc,
                CompletedOnUtc = bc.Booking.CompletedOnUtc,
                CancelledOnUtc = bc.Booking.CancelledOnUtc
            })
            .ToListAsync(cancellationToken);
    }
}
