using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class DashboardUsersController : ControllerBase
{
    private readonly IDashboardUser _dashboardUserService;

    public DashboardUsersController(IDashboardUser dashboardUserService)
    {
        _dashboardUserService = dashboardUserService;
    }

    // Get user information
    [HttpGet("userinfo/{userId}")]
    public async Task<IActionResult> GetUserInfo(int userId)
    {
        var user = await _dashboardUserService.GetUserInfo(userId);
        if (user == null)
        {
            return NotFound("User not found");
        }
        return Ok(user);
    }

    // Update user address
    [HttpPut("update-address/{userId}")]
    public async Task<IActionResult> UpdateAddress(int userId, [FromBody] string newAddress)
    {
        var result = await _dashboardUserService.UpdateAddress(userId, newAddress);
        if (result)
        {
            return Ok("Address updated successfully");
        }
        return BadRequest("User not found or failed to update address");
    }

    // Get menu by category
    [HttpGet("menu-by-category/{category}")]
    public async Task<IActionResult> GetMenuByCategory(string category)
    {
        var menuItems = await _dashboardUserService.GetMenuByCategory(category);
        return Ok(menuItems);
    }

    // Search for menu items
    [HttpGet("search-menu/{searchTerm}")]
    public async Task<IActionResult> SearchMenuItems(string searchTerm)
    {
        var menuItems = await _dashboardUserService.SearchMenuItems(searchTerm);
        return Ok(menuItems);
    }

    // Validate contact number
    [HttpGet("validate-contact/{contactNumber}")]
    public IActionResult ValidateContactNumber(string contactNumber)
    {
        var isValid = _dashboardUserService.ValidateContactNumber(contactNumber);
        if (isValid)
        {
            return Ok("Contact number is valid");
        }
        return BadRequest("Invalid contact number");
    }

    // Validate email
    [HttpGet("validate-email/{email}")]
    public IActionResult ValidateEmail(string email)
    {
        var isValid = _dashboardUserService.ValidateEmail(email);
        if (isValid)
        {
            return Ok("Email is valid");
        }
        return BadRequest("Invalid email");
    }
}
