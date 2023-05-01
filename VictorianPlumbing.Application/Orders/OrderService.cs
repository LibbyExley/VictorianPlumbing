using FluentValidation;
using VictorianPlumbing.Application.Customers;
using VictorianPlumbing.Application.Products;
using VictorianPlumbing.Domain.Orders;
using VictorianPlumbing.Domain.Products;

namespace VictorianPlumbing.Application.Orders;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly ICustomerQueryService _customerQueryService;
    private readonly IProductQueryService _productQueryService;
    private readonly IValidator<NewOrderDTO> _orderValidator;

    public OrderService(IOrderRepository orderRepository,
        ICustomerQueryService customerQueryService,
        IProductQueryService productQueryService,
        IValidator<NewOrderDTO> orderValidator)
    {
        _orderRepository = orderRepository;
        _customerQueryService = customerQueryService;
        _productQueryService = productQueryService;
        _orderValidator = orderValidator;
    }

    public async Task<CreatedOrderDTO> CreateOrder(NewOrderDTO orderDto)
    {
        var validationResult = await _orderValidator.ValidateAsync(orderDto);
        if (!validationResult.IsValid)
        {
            throw new ArgumentException(nameof(orderDto));
        }

        var customer = await _customerQueryService.FindCustomerFromDTO(orderDto.Customer);
        var lines = await CreateOrderLines(orderDto.OrderItems);

        var order = new OrderBuilder(Guid.NewGuid(), DateTime.Now)
            .WithCustomer(customer)
            .WithLines(lines)
            .Build();

        var createdOrder = await _orderRepository.CreateCustomerOrder(order);
        return new CreatedOrderDTO(createdOrder.Id);
    }

    private async Task<IEnumerable<OrderLine>> CreateOrderLines(IEnumerable<OrderItemDto> orderItems)
    {
        var productIds = orderItems.Select(x => x.ProductId);
        var products = await _productQueryService.GetProductsById(productIds);

        return orderItems.Select(orderItem =>
        {
            var product = products.Single(product => product.ProductId == orderItem.ProductId);
            return CreateOrderLine(orderItem, product);
        });
    }

    private static OrderLine CreateOrderLine(OrderItemDto dto, Product product)
    {
        var line = new OrderLine(Guid.NewGuid(), dto.Quantity);
        line.AddProductToLine(product);
        return line;
    }
}
