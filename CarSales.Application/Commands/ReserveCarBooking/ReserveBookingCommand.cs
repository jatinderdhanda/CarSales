using CarSales.Application.Abstractions.Messaging;
using CarSales.Domain.Abstraction;
using MediatR;

namespace CarSales.Application.Commands.ReserveCarBooking
{
    public record ReserveBookingCommand(Guid CarId,
        Guid EmployeeId,
        Guid CustomerId,
        DateOnly StartDate,
        DateOnly EndDate) : ICommand<Guid>;
}
