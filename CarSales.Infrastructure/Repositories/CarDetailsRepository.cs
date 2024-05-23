using CarSales.Domain.Models;
using CarSales.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarSales.Infrastructure.Repositories
{
    public class CarDetailsRepository: ICarDetailsRepository
    {
        private readonly CarSalesDbContext _dbContext;
        public CarDetailsRepository(CarSalesDbContext dbContext) {
        _dbContext = dbContext;
        }

        public async Task<CarDetails?> GetAllCarDetailsAsync()
        {
            return await _dbContext.CarDetails.FirstOrDefaultAsync(x => x.CarName != string.Empty);
        }

        public async Task AddCarDetailsAsync(CarDetails carDetails) { 
             _dbContext.CarDetails.Add(carDetails); 
            await _dbContext.SaveChangesAsync();    
        }
    }

}
