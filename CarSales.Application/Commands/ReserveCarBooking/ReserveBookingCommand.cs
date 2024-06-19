using CarSales.Application.Abstractions.Messaging;

namespace CarSales.Application.Commands.ReserveCarBooking;

public record ReserveBookingCommand(Guid CarId,
    Guid EmployeeId,
    Guid CustomerId,
    DateOnly StartDate,
    DateOnly EndDate) : ICommand<Guid>;
