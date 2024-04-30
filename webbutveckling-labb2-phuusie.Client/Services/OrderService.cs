using webbutveckling_labb2_phuusie.Shared.DTOs.OrderDTOs;

namespace webbutveckling_labb2_phuusie.Client.Services;

public class OrderService
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly HttpClient _http;

    public List<GetOrderDto> Orders { get; set; } = new();
    public List<GetOrderProductsDto> OrderProducts { get; set; } = new();
    public GetOrderDto Order { get; set; } = new();

    public OrderService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
        _http = _clientFactory.CreateClient("storeApi");
    }

    public async Task<List<GetOrderDto>> LoadOrders()
    {
        var response = await _http.GetAsync("orders");
        Orders = await response.Content.ReadFromJsonAsync<List<GetOrderDto>>();
        return Orders;
    }

    public async Task<List<GetOrderProductsDto>> LoadOrderProducts()
    {
        var response = await _http.GetAsync("orders/products");
        OrderProducts = await response.Content.ReadFromJsonAsync<List<GetOrderProductsDto>>();
        return OrderProducts;
    }

    public async Task<GetOrderDto> GetOrder(int id)
    {
        var response = await _http.GetAsync($"orders/id={id}");
        Order = await response.Content.ReadFromJsonAsync<GetOrderDto>();
        return Order;
    }

    public async Task PlaceOrder(PostOrderDto postOrder)
    {
        await _http.PostAsJsonAsync("orders", postOrder);
        await LoadOrders();
    }

    public async Task AddProductToOrder(PostOrderProductsDto postOrderProduct)
    {
        await _http.PostAsJsonAsync("orders/products", postOrderProduct);
    }

    public async Task DeleteOrder(int id)
    {
        await _http.DeleteAsync($"orders/id={id}");
    }
}