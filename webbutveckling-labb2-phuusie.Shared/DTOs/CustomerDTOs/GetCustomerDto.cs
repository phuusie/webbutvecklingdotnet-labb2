namespace webbutveckling_labb2_phuusie.Shared.DTOs.CustomerDTOs;

public class GetCustomerDto
{
    public int CustomerId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string Phone { get; set; }

    public string Address { get; set; }

    public string PostalCode { get; set; }

    public string City { get; set; }

    public string Country { get; set; }
    
    public bool IsAdmin { get; set; }
}