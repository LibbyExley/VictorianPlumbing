namespace VictorianPlumbing.Application.Orders;

public record CreatedOrderDTO(Guid OrderId);
public record NewOrderDTO(CustomerDTO Customer, IEnumerable<OrderItemDto> OrderItems);
public class OrderItemDto
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}

public record CustomerDTO(string CustomerName, string EmailAddress);

public interface IOrderService
{
    Task<CreatedOrderDTO> CreateOrder(NewOrderDTO order);
}
