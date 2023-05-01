using VictorianPlumbing.Domain.Orders;

namespace VictorianPlumbing.Domain.Products;

public class Product
{
    public Product(Guid productId, string name, decimal price)
    {
        ProductId = productId;
        Name = name;
        Price = price;
    }

    public Guid ProductId { get; init; }
    public string Name { get; private set; }
    public decimal Price { get; set; }
    public ICollection<OrderLine> OrderLines { get; set; }
}
