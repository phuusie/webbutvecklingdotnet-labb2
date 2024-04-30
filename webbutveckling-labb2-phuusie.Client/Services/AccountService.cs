using webbutveckling_labb2_phuusie.Shared.DTOs.CustomerDTOs;
namespace webbutveckling_labb2_phuusie.Client.Services;

public class AccountService
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly HttpClient _http;
    private GetCustomerAccountDto _account = new();
    private List<GetCustomerDto>? _accounts = new();

    public GetCustomerAccountDto Account => _account;
    public bool IsLoggedIn { get; set; }

    public AccountService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
        _http = _clientFactory.CreateClient("storeApi");
    }

    public async Task<bool> Login(string email, string password)
    {
        var response = await _http.GetAsync($"customers");
        _accounts = await response.Content.ReadFromJsonAsync<List<GetCustomerDto>>();

        foreach (var account in _accounts)
        {
            if (account.Email == email && account.Password == password)
            {
                _account = new()
                {
                    Id = account.CustomerId,
                    FirstName = account.FirstName,
                    LastName = account.LastName,
                    Email = account.Email,
                    Password = account.Password,
                    IsAdmin = account.IsAdmin
                };
                return IsLoggedIn = true;
            }
        }
        return IsLoggedIn = false;
    }

    public async Task Logout()
    {
        IsLoggedIn = false;
        _account = new();
    }

    public async Task<GetCustomerAccountDto> GetAccount()
    {
        return _account;
    }
}