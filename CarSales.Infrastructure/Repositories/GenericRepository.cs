using CarSales.Domain.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace CarSales.Infrastructure.Repositories;

public abstract class GenericRepository<T> where T : Entity
{
    protected readonly CarSalesDbContext _dbContext;
    protected GenericRepository(CarSalesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<T?> GetByIdAsync(
    Guid id,
    CancellationToken cancellationToken = default)
    {
        return await _dbContext
            .Set<T>()
            .FirstOrDefaultAsync(user => user.Id == id, cancellationToken);
    }

    public void Add(T entity)
    {
        _dbContext.Add(entity);
    }
}
