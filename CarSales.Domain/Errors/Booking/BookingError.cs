using CarSales.Domain.Abstraction;

namespace CarSales.Domain.Errors.Booking
{
    public static class BookingError
    {
        public static readonly Error NotEligibleForBooking = new Error("Booking.Sold Out", "Booking can't be made for this car as it not available.");
    }
}
