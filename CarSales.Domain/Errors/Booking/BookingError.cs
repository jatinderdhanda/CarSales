using CarSales.Domain.Abstraction;

namespace CarSales.Domain.Errors.Booking
{
    public static class BookingError
    {
        public static readonly Error NotEligibleForBooking = new(
            "Booking.Sold Out",
            "Booking can't be made for this car as it not available.");

        public static Error Overlap = new(
        "Booking.Overlap",
        "The current booking is overlapping with an existing one");
    }
}
