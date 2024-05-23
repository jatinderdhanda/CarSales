using CarSales.Domain.Models;
using CarSales.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace CarSales.Application.Commands
{
    public class AddCarDetailCommandHandler: IRequestHandler<AddCarDetailCommand, bool>
    {
        private readonly ICarDetailsRepository _carDetailsRepository;

        public AddCarDetailCommandHandler(ICarDetailsRepository carDetailsRepository)
        {
            _carDetailsRepository = carDetailsRepository;
        }

        public async Task<bool> Handle(AddCarDetailCommand command, CancellationToken cancellationToken) {

            if (command == null)
            return false;

            var carDetails = new CarDetails
            {
                CarName = command.CarName,
                CarColor = command.CarColor,
                CarDescription = command.CarDescription,
                CarCompanyName = command.CarCompanyName,
                CarRegistrationNumber = command.CarRegistrationNumber,
            };

            await _carDetailsRepository.AddCarDetailsAsync(carDetails);
            return true;

        }
    }
}
