using Microsoft.EntityFrameworkCore;
using webbutveckling_labb2_phuusie.DataAccess.Interface;
using webbutveckling_labb2_phuusie.Shared.Entities;

namespace webbutveckling_labb2_phuusie.DataAccess.Repositories;

public class ProductRepository(StoreDbContext context) : IRepository<Product>
{
    public async Task<IEnumerable<Product>> GetAll()
    {
        return await context.Products
            .Include(p => p.Category)
            .ToListAsync();
    }

    public async Task<Product?> GetById(int id)
    {
        return await context.Products
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.ProductId == id);
    }

    public async Task<Product?> GetProductByName(string name)
    {

        return await context.Products
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p =>p.Name == name);
    }


    public async Task<IEnumerable<Product?>> GetProductByCategoryId(int categoryId)
    {
        return await context.Products
            .Where(c => c.CategoryId == categoryId)
            .Include(p => p.Category)
            .ToListAsync();
    }

    public async Task<Product> Add(Product product)
    {
        context.Products.Add(product);
        await context.SaveChangesAsync();
        return product;
    }

    public async Task<Product> Update(Product product)
    {
        context.Entry(product).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return product;
    }

    public async Task<Product> Delete(int id)
    {
        var product = await context.Products.FindAsync(id);
        if (product == null)
        {
            return null;
        }

        context.Products.Remove(product);
        await context.SaveChangesAsync();
        return product;
    }
}