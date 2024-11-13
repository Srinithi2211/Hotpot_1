using System.Collections.Generic;
using System.Threading.Tasks;

public interface IOrder
{
    Task<Order> CreateOrder(Order order);
    Task<Order> GetOrderById(int orderId);
    Task<List<Order>> GetOrdersByUserId(int userId);
    Task UpdateOrderStatus(int orderId, string status);
    Task<List<Order>> GetAllOrders();
}
