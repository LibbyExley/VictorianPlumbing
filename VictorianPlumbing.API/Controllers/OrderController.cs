using Microsoft.AspNetCore.Mvc;
using VictorianPlumbing.Application.Orders;

namespace VictorianPlumbing.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly ILogger<OrderController> _logger;
    private readonly IOrderService _orderService;

    public OrderController(ILogger<OrderController> logger, IOrderService orderService)
    {
        _logger = logger;
        _orderService = orderService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomerOrder(NewOrderDTO customerOrder)
    {
        try
        {
            var order = await _orderService.CreateOrder(customerOrder);
            _logger.LogInformation($"Order {order.OrderId} created successfully");
            return Ok(order);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex.Message);
            return BadRequest("Request failed validation");
        }
    }
}
