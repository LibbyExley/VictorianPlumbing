using VictorianPlumbing.Domain.Products;

namespace VictorianPlumbing.Application.Products;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProductsById(IEnumerable<Guid> productIds);
}
