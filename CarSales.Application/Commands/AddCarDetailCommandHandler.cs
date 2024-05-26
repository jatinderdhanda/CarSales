using CarSales.Domain.Interfaces;
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
                Name = command.CarName,
                Color = command.CarColor,
                Description = command.CarDescription,
                CompanyName = command.CarCompanyName,
                RegistrationNumber = command.CarRegistrationNumber,
            };

            await _carDetailsRepository.AddCarDetailsAsync(carDetails);
            return true;

        }
    }
}
