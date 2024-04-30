using webbutveckling_labb2_phuusie.DataAccess.Repositories;
using webbutveckling_labb2_phuusie.Shared.Entities;

namespace webbutveckling_labb2_phuusie.Api.Endpoints;

public static class ProductEndpointExtensions
{
    public static IEndpointRouteBuilder MapProductEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/products");

        group.MapGet("", GetAllProducts);
        group.MapGet("/id={id}", GetProductById);
        group.MapGet("/name={name}", GetProductByName);
        group.MapGet("/categories={categoryId}", GetProductByCategoryId);
        group.MapPost("", AddProduct);
        group.MapPut("/id={id}", UpdateProduct);
        group.MapDelete("/id={id}", DeleteProduct);
        return app;
    }

    private static async Task<IEnumerable<Product>> GetAllProducts(ProductRepository repo)
    {
        return await repo.GetAll();
    }

    private static async Task<Product> GetProductById(ProductRepository service, int id)
    {
        return await service.GetById(id);
    }

    private static async Task<Product> GetProductByName(ProductRepository service, string name)
    {
        return await service.GetProductByName(name);
    }

    private static async Task<IEnumerable<Product>> GetProductByCategoryId(ProductRepository service, int categoryId)
    {
        return await service.GetProductByCategoryId(categoryId);
    }

    private static async Task<Product> AddProduct(ProductRepository service, Product product)
    {
        return await service.Add(product);
    }

    private static async Task<Product> UpdateProduct(ProductRepository service, Product updatedProduct, int id)
    {
        var existingProduct = await service.GetById(id);

        existingProduct.Name = updatedProduct.Name;
        existingProduct.Description = updatedProduct.Description;
        existingProduct.Price = updatedProduct.Price;
        existingProduct.CategoryId = updatedProduct.CategoryId;
        existingProduct.Image = updatedProduct.Image;
        existingProduct.IsInStorage = updatedProduct.IsInStorage;
        return await service.Update(existingProduct);
    }

    private static async Task<Product> DeleteProduct(ProductRepository service, int id)
    {
        return await service.Delete(id);
    }
}