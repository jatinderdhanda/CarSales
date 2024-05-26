using CarSales.Domain.Interfaces;
using CarSales.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CarSales.Infrastructure.Repositories
{
    public class CarDetailsRepository: ICarDetailsRepository
    {
        private readonly CarSalesDbContext _dbContext;
        public CarDetailsRepository(CarSalesDbContext dbContext) {
        _dbContext = dbContext;
        }

        public async Task<CarDetails?> GetCarDetailsByIdAsync(Guid id)
        {
            return await _dbContext.CarDetails.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddCarDetailsAsync(CarDetails carDetails) { 
             _dbContext.CarDetails.Add(carDetails); 
            await _dbContext.SaveChangesAsync();    
        }
    }

}
