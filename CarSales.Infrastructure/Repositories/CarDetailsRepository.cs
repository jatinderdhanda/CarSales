using CarSales.Domain.Interfaces;
using CarSales.Domain.Models;

namespace CarSales.Infrastructure.Repositories
{
    public class CarDetailsRepository: GenericRepository<CarDetail>, ICarDetailsRepository
    {
        public CarDetailsRepository(CarSalesDbContext dbContext)
       : base(dbContext)
        {
        }
    }

}
