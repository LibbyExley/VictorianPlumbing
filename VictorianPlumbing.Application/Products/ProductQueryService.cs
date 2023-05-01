using VictorianPlumbing.Domain.Products;

namespace VictorianPlumbing.Application.Products;

public class ProductQueryService : IProductQueryService
{
    private readonly IProductRepository _productRepository;

    public ProductQueryService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<bool> CheckProductsExist(IEnumerable<Guid> productIds)
    {
        var products = await _productRepository.GetProductsById(productIds);
        return !products
            .Select(p => p.ProductId)
            .Except(productIds)
            .Any();
    }

    public Task<IEnumerable<Product>> GetProductsById(IEnumerable<Guid> productIds)
    {
        return _productRepository.GetProductsById(productIds);
    }
}
