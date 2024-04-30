using webbutveckling_labb2_phuusie.Shared.DTOs.ProductDTOs;

namespace webbutveckling_labb2_phuusie.Client.Services;

public class CartService
{
    private List<GetProductsDto> _cart = new();

    public List<GetProductsDto> Cart => _cart;


    public async Task<List<GetProductsDto>> GetCart()
    {
        return _cart;
    }

    public async Task AddToCart(GetProductsDto product)
    {
        _cart.Add(product);
    }

    public async Task RemoveFromCart(GetProductsDto product)
    {
        _cart.Remove(product);
    }

    public async Task ClearCart()
    {
        _cart.Clear();
    }

}