using webbutveckling_labb2_phuusie.DataAccess.Repositories;
using webbutveckling_labb2_phuusie.Shared.Entities;

namespace webbutveckling_labb2_phuusie.Api.Endpoints;

public static class CustomerEndpointExtensions
{
    public static IEndpointRouteBuilder MapCustomerEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/customers");

        group.MapGet("", GetAllCustomers);
        group.MapGet("/id={id}", GetCustomerById);
        group.MapGet("/email={email}", GetCustomerByEmail);
        group.MapPost("", AddCustomer);
        group.MapPut("/id={id}", UpdateCustomer);
        group.MapDelete("/id={id}", DeleteCustomer);

        return app;
    }

    private static async Task<IEnumerable<Customer>> GetAllCustomers(CustomerRepository repo)
    {
        return await repo.GetAll();
    }

    private static async Task<Customer> GetCustomerById(CustomerRepository repo, int id)
    {
        return await repo.GetById(id);
    }

    private static async Task<Customer?> GetCustomerByEmail(CustomerRepository repo, string email)
    {
        return await repo.GetCustomerByEmail(email);
    }

    private static async Task<Customer> AddCustomer(CustomerRepository repo, Customer customer)
    {
        return await repo.Add(customer);
    }

    private static async Task<Customer> UpdateCustomer(CustomerRepository repo, Customer customer, int id)
    {
        var existingCustomer = await repo.GetById(id);

        existingCustomer.FirstName = customer.FirstName;
        existingCustomer.LastName = customer.LastName;
        existingCustomer.Email = customer.Email;
        existingCustomer.Password = customer.Password;
        existingCustomer.Phone = customer.Phone;
        existingCustomer.Address = customer.Address;
        existingCustomer.PostalCode = customer.PostalCode;
        existingCustomer.City = customer.City;
        existingCustomer.Country = customer.Country;

        return await repo.Update(existingCustomer);
    }

    private static async Task<Customer> DeleteCustomer(CustomerRepository repo, int id)
    {
        return await repo.Delete(id);
    }
}