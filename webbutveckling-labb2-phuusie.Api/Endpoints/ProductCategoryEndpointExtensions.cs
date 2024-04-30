using webbutveckling_labb2_phuusie.DataAccess.Repositories;
using webbutveckling_labb2_phuusie.Shared.Entities;

namespace webbutveckling_labb2_phuusie.Api.Endpoints;

public static class ProductCategoryEndpointExtensions
{
    public static IEndpointRouteBuilder MapProductCategoryEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/products/categories");

        group.MapGet("", GetAllCategories);
        group.MapGet("/id={id}", GetCategory);
        group.MapPost("", AddCategory);
        group.MapPut("/id={id}", UpdateCategory);
        group.MapDelete("/id={id}", DeleteCategory);

        return app;
    }

    private static async Task<IEnumerable<ProductCategory?>> GetAllCategories(ProductCategoryRepository repo)
    {
        return await repo.GetAll();
    }

    private static async Task<ProductCategory?> GetCategory(ProductCategoryRepository service, int id)
    {
        return await service.GetById(id);
    }

    private static async Task<ProductCategory?> AddCategory(ProductCategoryRepository service, ProductCategory? category)
    {
        return await service.Add(category);
    }

    private static async Task<ProductCategory?> UpdateCategory(ProductCategoryRepository service, ProductCategory updatedCategory, int id)
    {
        var existingCategory = await service.GetById(id);

        existingCategory.Name = updatedCategory.Name;

        return await service.Update(existingCategory);
    }

    private static async Task<ProductCategory> DeleteCategory(ProductCategoryRepository service, int id)
    {
        return await service.Delete(id);
    }
}