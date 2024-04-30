using Microsoft.EntityFrameworkCore;
using webbutveckling_labb2_phuusie.DataAccess.Interface;
using webbutveckling_labb2_phuusie.Shared.Entities;

namespace webbutveckling_labb2_phuusie.DataAccess.Repositories;

public class ProductCategoryRepository(StoreDbContext context) : IRepository<ProductCategory>
{
    public async Task<IEnumerable<ProductCategory?>> GetAll()
    {
        return await context.Categories.ToListAsync();
    }

    public async Task<ProductCategory> GetById(int id)
    {
        return await context.Categories.FindAsync(id);
    }

    public async Task<ProductCategory?> Add(ProductCategory? category)
    {
        context.Categories.Add(category);
        await context.SaveChangesAsync();
        return category;
    }

    public async Task<ProductCategory?> Update(ProductCategory? category)
    {
        context.Entry(category).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return category;
    }

    public async Task<ProductCategory> Delete(int id)
    {
        var category = await context.Categories.FindAsync(id);
        if (category == null)
        {
            return null;
        }

        context.Categories.Remove(category);
        await context.SaveChangesAsync();
        return category;
    }
}