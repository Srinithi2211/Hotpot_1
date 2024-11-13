using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class OrderImpl : IOrder
{
    private readonly ApplicationDbContext _context;

    public OrderImpl(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Order> CreateOrder(Order order)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
        return order;
    }

    public async Task<Order> GetOrderById(int orderId)
    {
        return await _context.Orders.FindAsync(orderId);
    }

    public async Task<List<Order>> GetOrdersByUserId(int userId)
    {
        return await _context.Orders
            .Where(o => o.UserID == userId)
            .ToListAsync();
    }

    public async Task UpdateOrderStatus(int orderId, string status)
    {
        var order = await _context.Orders.FindAsync(orderId);
        if (order != null)
        {
            order.Status = status;
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<Order>> GetAllOrders()
    {
        return await _context.Orders.ToListAsync();
    }
}
