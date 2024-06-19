using CarSales.Application.Abstractions.Clock;
using CarSales.Application.Abstractions.Messaging;
using CarSales.Application.Exceptions;
using CarSales.Domain.Abstraction;
using CarSales.Domain.Errors.Booking;
using CarSales.Domain.Interfaces;
using CarSales.Domain.Models;
using CarSales.Domain.Shared;
namespace CarSales.Application.Commands.ReserveCarBooking
{
    internal sealed class ReserveBookingCommandHandler : ICommandHandler<ReserveBookingCommand, Guid>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IUnitOfWork _unitOfWork;

        public ReserveBookingCommandHandler(IBookingRepository bookingRepository,
            IUnitOfWork unitOfWork,
            IDateTimeProvider dateTimeProvider)
        {
            _bookingRepository = bookingRepository;
            _unitOfWork = unitOfWork;
            _dateTimeProvider = dateTimeProvider;
        }
        public async Task<Result<Guid>> Handle(ReserveBookingCommand command, CancellationToken cancellationToken)
        {
            var duration = DateRange.Create(command.StartDate, command.EndDate);
            if (await _bookingRepository.IsOverlappingAsync(command.CarId, duration, cancellationToken))
            {
                return Result.Failure<Guid>(BookingError.Overlap);
            }

            try
            {
                var booking = Booking.Reserve(
                    command.CarId,
                    command.EmployeeId,
                    command.CustomerId,
                    duration,
                    _dateTimeProvider.UtcNow);

                _bookingRepository.Add(booking);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return booking.Id;
            }
            catch (ConcurrencyException)
            {
                return Result.Failure<Guid>(BookingError.Overlap);
            }
            catch (Exception ex)
            {
                return Result.Failure<Guid>(BookingError.Overlap);
            }
        }
    }
}
