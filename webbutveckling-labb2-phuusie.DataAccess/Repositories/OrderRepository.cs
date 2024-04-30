using Microsoft.EntityFrameworkCore;
using webbutveckling_labb2_phuusie.DataAccess.Interface;
using webbutveckling_labb2_phuusie.Shared.Entities;

namespace webbutveckling_labb2_phuusie.DataAccess.Repositories;

public class OrderRepository(StoreDbContext context) : IRepository<Order>
{
    public async Task<IEnumerable<Order>> GetAll()
    {
        return await context.Orders
            .Include(o => o.Customer)
            .Include(o => o.OrderedProducts)
            .ThenInclude(o => o.Product)
            .ThenInclude(o => o.Category)
            .ToListAsync();
    }

    public async Task<Order?> GetById(int id)
    {
        return await context.Orders
            .Include(o => o.Customer)
            .Include(o => o.OrderedProducts)
            .ThenInclude(o => o.Product)
            .ThenInclude(o => o.Category)
            .FirstOrDefaultAsync(o => o.OrderId == id);
    }

    public async Task<IEnumerable<Order>> GetOrderByCustomerId(int id)
    {
        return await context.Orders
            .Where(o => o.CustomerId == id)
            .Include(o => o.Customer)
            .Include(o => o.OrderedProducts)
            .ThenInclude(o => o.Product)
            .ThenInclude(o => o.Category)
            .ToListAsync();
    }

    public async Task<Order> Update(Order order)
    {
        context.Entry(order).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return order;
    }

    public async Task<Order> Add(Order order)
    {
        context.Orders.Add(order);
        await context.SaveChangesAsync();
        return order;
    }

    public async Task<Order> Delete(int id)
    {
        var order = await context.Orders.FindAsync(id);
        if (order == null)
        {
            return null;
        }

        context.Orders.Remove(order);
        await context.SaveChangesAsync();
        return order;
    }
}