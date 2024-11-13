using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class MenusController : ControllerBase
{
    private readonly IMenu _menuService;

    public MenusController(IMenu menuService)
    {
        _menuService = menuService;
    }

    // Endpoint to add a new menu item
    [HttpPost("add")]
    public async Task<IActionResult> AddItem([FromBody] Menu item)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var newItem = await _menuService.AddItem(item);
        return CreatedAtAction(nameof(GetAllItems), new { itemId = newItem.ItemID }, newItem);
    }

    // Endpoint to delete a menu item by ItemID
    [HttpDelete("{itemId}")]
    public async Task<IActionResult> DeleteItem(int itemId)
    {
        var deletedItem = await _menuService.DeleteItem(itemId);
        if (deletedItem == null)
        {
            return NotFound("Item not found.");
        }
        return Ok(deletedItem);
    }

    // Endpoint to get all menu items
    [HttpGet("all")]
    public async Task<IActionResult> GetAllItems()
    {
        var items = await _menuService.GetAllItems();
        return Ok(items);
    }

    // Endpoint to filter menu items by category and/or price
    [HttpGet("filter")]
    public async Task<IActionResult> FilterItems([FromQuery] string category, [FromQuery] decimal? price)
    {
        var filteredItems = await _menuService.FilterItems(category, price);
        return Ok(filteredItems);
    }
}
