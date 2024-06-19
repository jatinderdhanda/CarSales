using System.ComponentModel.DataAnnotations;
using CarSales.Domain.Abstraction;
using CarSales.Domain.Enum;
using CarSales.Domain.Shared;

namespace CarSales.Domain.Models;

public sealed class Booking : Entity
{
    public Booking(Guid id,
        Guid employeeId,
        Guid customerId,
        Guid carId,
        DateRange duration,
        BookingStatus status,
        DateTime createdOnUtc,
        DateTime modifiedOnUtc
        ) : base(id)
    {
        EmployeeId = employeeId;
        CustomerId = customerId;
        CarId = carId;
        Duration = duration;
        Status = status;
        CreatedOnUtc = createdOnUtc;
        ModifiedOnUtc = modifiedOnUtc;
    }
    private Booking()
    {

    }

    public BookingStatus Status { get; private set; }
    public DateRange Duration { get; private set; }
    public Guid CarId { get; private set; }
    public Guid CustomerId { get; private set; }
    public Guid EmployeeId { get; private set; }

    public DateTime CreatedOnUtc { get; private set; }

    [ConcurrencyCheck]
    public DateTime ModifiedOnUtc { get; private set; }

    public DateTime? ConfirmedOnUtc { get; private set; }

    public DateTime? RejectedOnUtc { get; private set; }

    public DateTime? CompletedOnUtc { get; private set; }

    public DateTime? CancelledOnUtc { get; private set; }

    public static Booking Reserve(
        Guid carId,
        Guid employeeId,
        Guid customerId,
        DateRange duration,
        DateTime utcNow)
    {
        var booking = new Booking(
            Guid.NewGuid(),
            employeeId,
            customerId,
            carId,
            duration,
            BookingStatus.Reserved,
            utcNow,
            utcNow);

        return booking;
    }
}
