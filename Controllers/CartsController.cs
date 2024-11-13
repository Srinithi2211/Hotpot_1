using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class CartsController : ControllerBase
{
    private readonly ICart _cartService;

    public CartsController(ICart cartService)
    {
        _cartService = cartService;
    }

    [HttpPost("add-to-cart")]
    public async Task<IActionResult> AddToCart([FromBody] AddToCartRequest request)
    {
        var cart = await _cartService.AddToCart(request.UserId, request.ItemId, request.Quantity);
        return Ok(cart);
    }

    [HttpPost("remove-from-cart")]
    public async Task<IActionResult> RemoveFromCart([FromBody] RemoveFromCartRequest request)
    {
        var cart = await _cartService.RemoveFromCart(request.UserId, request.ItemId);
        return Ok(cart);
    }

    [HttpGet("get-cart-items/{userId}")]
    public async Task<IActionResult> GetCartItems(int userId)
    {
        var items = await _cartService.GetCartItems(userId);
        return Ok(items);
    }

    [HttpGet("calculate-total/{userId}")]
    public async Task<IActionResult> CalculateTotal(int userId)
    {
        var totalCost = await _cartService.CalculateTotal(userId);
        return Ok(totalCost);
    }
}

public class AddToCartRequest
{
    public int UserId { get; set; }
    public int ItemId { get; set; }
    public int Quantity { get; set; }
}

public class RemoveFromCartRequest
{
    public int UserId { get; set; }
    public int ItemId { get; set; }
}
