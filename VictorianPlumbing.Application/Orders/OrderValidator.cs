using FluentValidation;
using VictorianPlumbing.Application.Products;

namespace VictorianPlumbing.Application.Orders;

public class OrderValidator : AbstractValidator<NewOrderDTO>
{
    private readonly IProductQueryService _productQueryService;

    public OrderValidator(IProductQueryService productQueryService)
    {
        _productQueryService = productQueryService;

        RuleFor(order => order.Customer.CustomerName).NotEmpty();
        RuleFor(order => order.Customer.EmailAddress).EmailAddress();
        RuleFor(x => x.OrderItems).NotEmpty().MustAsync((i, cancellationToken) => ProductsExist(i));
        RuleForEach(x => x.OrderItems).Must(orderItem => orderItem.Quantity > 0);
    }

    private async Task<bool> ProductsExist(IEnumerable<OrderItemDto> items)
    {
        var productIds = items.Select(item => item.ProductId);
        return await _productQueryService.CheckProductsExist(productIds);
    }
}
