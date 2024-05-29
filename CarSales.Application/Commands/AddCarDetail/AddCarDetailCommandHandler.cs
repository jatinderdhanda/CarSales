using CarSales.Domain.Abstraction;
using CarSales.Domain.Enum;
using CarSales.Domain.Interfaces;
using CarSales.Domain.Models;
using MediatR;

namespace CarSales.Application.Commands.AddCarDetail
{
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
            var carDetails = CarDetails.CreateCarDetail(Guid.NewGuid(),
            command.CarName,
            command.CarCompanyName,
            command.CarColor,
            command.CarManufactureYear,
            command.CarRegistrationNumber,
            CarStatus.Available,
            command.FuelType);

            _carDetailsRepository.Add(carDetails);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return carDetails.Id;

        }
    }
}
