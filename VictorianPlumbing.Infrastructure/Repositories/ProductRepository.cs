using Microsoft.EntityFrameworkCore;
using VictorianPlumbing.Application.Products;
using VictorianPlumbing.Domain.Products;
using VictorianPlumbing.Infrastructure.Context;

namespace VictorianPlumbing.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ProductRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Product>> GetProductsById(IEnumerable<Guid> productIds)
    {
        return await _dbContext.Products
            .Where(p => productIds.Contains(p.ProductId))
            .ToListAsync();
    }
}
