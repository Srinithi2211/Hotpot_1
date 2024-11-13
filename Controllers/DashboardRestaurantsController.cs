using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class DashboardRestaurantsController : ControllerBase
{
    private readonly IDashboardRestaurant _dashboardRestaurantService;

    public DashboardRestaurantsController(IDashboardRestaurant dashboardRestaurantService)
    {
        _dashboardRestaurantService = dashboardRestaurantService;
    }

    [HttpPost("AddMenuItem")]
    public async Task<IActionResult> AddMenuItem([FromBody] Menu menu)
    {
        var result = await _dashboardRestaurantService.AddMenuItem(menu);
        if (result) return Ok("Menu item added successfully.");
        return BadRequest("Failed to add menu item.");
    }

    [HttpPut("UpdateMenuItem")]
    public async Task<IActionResult> UpdateMenuItem([FromBody] Menu menu)
    {
        var result = await _dashboardRestaurantService.UpdateMenuItem(menu);
        if (result) return Ok("Menu item updated successfully.");
        return NotFound("Menu item not found.");
    }

    [HttpDelete("DeleteMenuItem/{itemId}")]
    public async Task<IActionResult> DeleteMenuItem(int itemId)
    {
        var result = await _dashboardRestaurantService.DeleteMenuItem(itemId);
        if (result) return Ok("Menu item deleted successfully.");
        return NotFound("Menu item not found.");
    }

    [HttpPut("MarkItemOutOfStock/{itemId}")]
    public async Task<IActionResult> MarkItemOutOfStock(int itemId)
    {
        var result = await _dashboardRestaurantService.MarkItemOutOfStock(itemId);
        if (result) return Ok("Menu item marked as out of stock.");
        return NotFound("Menu item not found.");
    }

    [HttpGet("GetMenuByCategory/{category}")]
    public async Task<IActionResult> GetMenuByCategory(string category)
    {
        var menuItems = await _dashboardRestaurantService.GetMenuByCategory(category);
        return Ok(menuItems);
    }

    [HttpGet("GetOrderStatuses")]
    public async Task<IActionResult> GetOrderStatuses()
    {
        var orderStatuses = await _dashboardRestaurantService.GetOrderStatuses();
        return Ok(orderStatuses);
    }

    [HttpGet("GetOrderHistory")]
    public async Task<IActionResult> GetOrderHistory()
    {
        var orderHistory = await _dashboardRestaurantService.GetOrderHistory();
        return Ok(orderHistory);
    }
}
