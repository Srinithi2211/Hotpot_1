using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IOrder _orderService;

    public OrdersController(IOrder orderService)
    {
        _orderService = orderService;
    }

    // Endpoint to create a new order
    [HttpPost("create")]
    public async Task<IActionResult> CreateOrder([FromBody] Order order)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdOrder = await _orderService.CreateOrder(order);
        return CreatedAtAction(nameof(GetOrderById), new { orderId = createdOrder.OrderID }, createdOrder);
    }

    // Endpoint to get an order by ID
    [HttpGet("{orderId}")]
    public async Task<IActionResult> GetOrderById(int orderId)
    {
        var order = await _orderService.GetOrderById(orderId);
        if (order == null)
        {
            return NotFound("Order not found.");
        }
        return Ok(order);
    }

    // Endpoint to get all orders for a specific user by User ID
    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetOrdersByUserId(int userId)
    {
        var orders = await _orderService.GetOrdersByUserId(userId);
        return Ok(orders);
    }

    // Endpoint to update the status of an order by order ID
    [HttpPut("{orderId}/status")]
    public async Task<IActionResult> UpdateOrderStatus(int orderId, [FromBody] string status)
    {
        await _orderService.UpdateOrderStatus(orderId, status);
        return Ok("Order status updated successfully.");
    }

    // Endpoint to get all orders (for admin or tracking purposes)
    [HttpGet("all")]
    public async Task<IActionResult> GetAllOrders()
    {
        var orders = await _orderService.GetAllOrders();
        return Ok(orders);
    }
}
