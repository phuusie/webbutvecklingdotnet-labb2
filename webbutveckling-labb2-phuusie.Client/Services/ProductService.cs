using webbutveckling_labb2_phuusie.Shared.DTOs.CategoryDTOs;
using webbutveckling_labb2_phuusie.Shared.DTOs.ProductDTOs;

namespace webbutveckling_labb2_phuusie.Client.Services;

public class ProductService
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly HttpClient _http;

    public List<GetProductsDto?> Products { get; set; } = new();
    public List<GetProductCategoriesDto> Categories { get; set; } = new();

    public ProductService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
        _http = _clientFactory.CreateClient("storeApi");
    }

    public async Task<List<GetProductsDto?>> LoadProducts()
    {
        var response = await _http.GetAsync("products");
        Products = await response.Content.ReadFromJsonAsync<List<GetProductsDto>>();
        return Products;
    }

    public async Task<List<GetProductCategoriesDto>> LoadCategories()
    {
        var response = await _http.GetAsync("/products/categories");
        Categories = await response.Content.ReadFromJsonAsync<List<GetProductCategoriesDto>>();
        return Categories;
    }

    public async Task AddProduct(PostProductDto product)
    {
        await _http.PostAsJsonAsync("products", product);
        await LoadProducts();
    }

    public async Task AddCategory(PostProdutCategoryDto category)
    {
        await _http.PostAsJsonAsync("products/categories", category);
        await LoadCategories();
    }

    public async Task UpdateProduct(PutProductDto product)
    {
        await _http.PutAsJsonAsync($"products/id={product.ProductId}", product);
    }

    public async Task UpdateCategory(PutProductCategoryDto category)
    {
        await _http.PutAsJsonAsync($"products/categories/id={category.Id}", category);
    }

    public async Task DeleteProduct(int id)
    {
        await _http.DeleteAsync($"products/id={id}");
        Products.Remove(Products.FirstOrDefault(p => p.ProductId == id));
    }

    public async Task DeleteCategory(int id)
    {
        await _http.DeleteAsync($"products/categories/id={id}");
        Categories.Remove(Categories.FirstOrDefault(c => c.CategoryId == id));
    }

}