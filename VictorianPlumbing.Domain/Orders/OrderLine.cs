using VictorianPlumbing.Domain.Products;

namespace VictorianPlumbing.Domain.Orders;

public class OrderLine
{
    public OrderLine(Guid id, int quantity)
    {
        Id = id;
        Quantity = quantity;
    }

    public Guid Id { get; init; }
    public Product Product { get; private set; }
    public int Quantity {  get; private set; }
    public decimal LineTotal => Product.Price * Quantity;

    public Order Order { get; private set; }

    public void AddProductToLine(Product product)
    {
        Product = product;
    }
}
