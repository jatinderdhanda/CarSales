using CarSales.Application.Abstractions.Messaging;
using CarSales.Domain.Models;

namespace CarSales.Application.Queries.Booking.GetBookingDetails;
public sealed record GetBookingDetailQuery(Guid CarId) : IQuery<IEnumerable<BookingResponse>>;
