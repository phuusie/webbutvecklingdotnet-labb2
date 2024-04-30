using Microsoft.EntityFrameworkCore;
using webbutveckling_labb2_phuusie.Shared.Entities;

namespace webbutveckling_labb2_phuusie.DataAccess.Repositories;

public class OrderProductRepository(StoreDbContext context)
{
    public async Task<IQueryable<OrderProduct>> GetAll()
    {
        return context.OrderProducts
            .Include(op => op.Product);
    }

    public async Task<OrderProduct?> GetById(int id)
    {
        return await context.OrderProducts
            .Include(op => op.Product)
            .FirstOrDefaultAsync(op => op.OrderId == id);
    }

    public async Task<OrderProduct> Add(OrderProduct orderProduct)
    {
        context.OrderProducts.Add(orderProduct);
        await context.SaveChangesAsync();
        return orderProduct;
    }

    public async Task<OrderProduct> Delete(int id)
    {
        var orderProduct = await context.OrderProducts.FindAsync(id);
        if (orderProduct == null)
        {
            return null;
        }

        context.OrderProducts.Remove(orderProduct);
        await context.SaveChangesAsync();
        return orderProduct;
    }
}