using CarSales.Domain.Abstraction;
using CarSales.Domain.Enum;
using CarSales.Domain.Shared;

namespace CarSales.Domain.Models
{
    public class Booking : Entity
    {
        public Booking(Guid id,
            Guid employeeId,
            Guid customerId,
            Guid carId,
            DateRange duration,
            BookingStatus status,
            DateTime createdOnUtc
            ) : base(id)
        {
            EmployeeId = employeeId;
            CustomerId = customerId;
            CarId = carId;
            Duration = duration;
            BookingStatus = status;
            CreatedOnUtc = createdOnUtc;
        }

        public BookingStatus BookingStatus { get; private set; }
        public DateRange Duration { get; private set; }
        public Guid CarId { get; private set; }
        public Guid CustomerId { get; private set; }
        public Guid EmployeeId { get; private set; }

        public DateTime CreatedOnUtc { get; private set; }

        public DateTime? ConfirmedOnUtc { get; private set; }

        public DateTime? RejectedOnUtc { get; private set; }

        public DateTime? CompletedOnUtc { get; private set; }

        public DateTime? CancelledOnUtc { get; private set; }
    }

}