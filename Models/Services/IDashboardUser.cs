using System.Collections.Generic;
using System.Threading.Tasks;

public interface IDashboardUser
{
    Task<DashboardUser> GetUserInfo(int userId);
    Task<bool> UpdateAddress(int userId, string newAddress);
    Task<IEnumerable<Menu>> GetMenuByCategory(string category);
    Task<IEnumerable<Menu>> SearchMenuItems(string searchTerm);
    bool ValidateContactNumber(string contactNumber);
    bool ValidateEmail(string email);
}
