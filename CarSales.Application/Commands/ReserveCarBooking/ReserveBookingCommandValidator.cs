using FluentValidation;

namespace CarSales.Application.Commands.ReserveCarBooking;
public class ReserveBookingCommandValidator : AbstractValidator<ReserveBookingCommand>
{
    public ReserveBookingCommandValidator()
    {
        RuleFor(c => c.CarId).NotEmpty();

        RuleFor(c => c.EmployeeId).NotEmpty();

        RuleFor(c => c.CustomerId).NotEmpty();

        RuleFor(c => c.StartDate).LessThan(c => c.EndDate);
    }
}
