using webbutveckling_labb2_phuusie.Shared.DTOs.CustomerDTOs;

namespace webbutveckling_labb2_phuusie.Client.Services;

public class CustomerService
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly HttpClient _http;

    public List<GetCustomerDto?> Customers { get; set; } = new();

    public CustomerService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
        _http = _clientFactory.CreateClient("storeApi");
    }

    public async Task<List<GetCustomerDto?>> LoadCustomers()
    {
        var response = await _http.GetAsync($"customers");
        Customers = await response.Content.ReadFromJsonAsync<List<GetCustomerDto>>();
        return Customers;
    }

    public async Task RegisterCustomer(PostCustomerDto customer)
    {
        await LoadCustomers();

        if (Customers.Count == 0)
        {
            customer.IsAdmin = true;
        }

        await _http.PostAsJsonAsync("customers", customer);
    }

    public async Task UpdateCustomer(PutCustomerDto customer)
    {
        await _http.PutAsJsonAsync($"customers/id={customer.CustomerId}", customer);
    }

    public async Task DeleteCustomer(int id)
    {
        await _http.DeleteAsync($"customers/id={id}");
        Customers.Remove(Customers.FirstOrDefault(c => c.CustomerId == id));
    }
}