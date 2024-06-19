using CarSales.Application.Abstractions.Messaging;
using CarSales.Domain.Abstraction;
using CarSales.Domain.Interfaces;
using CarSales.Domain.Models;

namespace CarSales.Application.Queries.Booking.GetBookingDetails;
internal sealed class GetBookingDetailQueryHandler : IQueryHandler<GetBookingDetailQuery, IEnumerable<BookingResponse>>
{
    private readonly IBookingRepository _bookingRepository;
    public GetBookingDetailQueryHandler(IBookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }

    public async Task<Result<IEnumerable<BookingResponse>>> Handle(GetBookingDetailQuery request, CancellationToken cancellationToken)
    {
        var bookingDetail = await _bookingRepository.GetAllBookingsForCarIdAsync(request.CarId);
        return Result.Success(bookingDetail);
    }
}
