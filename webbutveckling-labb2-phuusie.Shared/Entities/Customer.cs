using System.ComponentModel.DataAnnotations;

namespace webbutveckling_labb2_phuusie.Shared.Entities;

public class Customer
{
    [Key]
    public int CustomerId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
    [EmailAddress]
    public string Email { get; set; }

    public string Password { get; set; }

    [Phone]
    public string Phone { get; set; }

    public string Address { get; set; }

    public string PostalCode { get; set; }

    public string City { get; set; }

    public string Country { get; set; }

    public bool isAdmin { get; set; }
}