namespace webbutveckling_labb2_phuusie.Shared.DTOs.CustomerDTOs;

public class GetCustomerAccountDto
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public bool IsAdmin { get; set; }
}