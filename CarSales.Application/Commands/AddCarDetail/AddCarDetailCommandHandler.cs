using CarSales.Domain.Abstraction;
using CarSales.Domain.Enum;
using CarSales.Domain.Errors.Booking;
using CarSales.Domain.Errors.Car;
using CarSales.Domain.Interfaces;
using CarSales.Domain.Models;
using MediatR;

namespace CarSales.Application.Commands.AddCarDetail;

public class AddCarDetailCommandHandler : IRequestHandler<AddCarDetailCommand, Result<Guid>>
{
    private readonly ICarDetailsRepository _carDetailsRepository;
    private readonly IUnitOfWork _unitOfWork;
    public AddCarDetailCommandHandler(ICarDetailsRepository carDetailsRepository, IUnitOfWork unitOfWork)
    {
        _carDetailsRepository = carDetailsRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(AddCarDetailCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var carDetails = CarDetail.CreateCarDetail(Guid.NewGuid(),
            command.Name,
            command.CompanyName,
            command.Color,
            command.ManufactureYear,
            command.RegistrationNumber,
            CarStatus.Available,
            command.FuelType);

            _carDetailsRepository.Add(carDetails);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return carDetails.Id;
        }
        catch(Exception ex)
        {
            return Result.Failure<Guid>(CarDetailError.NotAbleToAdd);
        }
    }
}
