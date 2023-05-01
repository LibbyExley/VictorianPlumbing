using VictorianPlumbing.Domain.Products;

namespace VictorianPlumbing.Application.Products;

public interface IProductQueryService
{
    Task<bool> CheckProductsExist(IEnumerable<Guid> productIds);
    Task<IEnumerable<Product>> GetProductsById(IEnumerable<Guid> productId);
}
