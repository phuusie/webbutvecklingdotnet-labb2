using Microsoft.EntityFrameworkCore;
using webbutveckling_labb2_phuusie.DataAccess.Interface;
using webbutveckling_labb2_phuusie.Shared.Entities;

namespace webbutveckling_labb2_phuusie.DataAccess.Repositories;

public class CustomerRepository(StoreDbContext context) : IRepository<Customer>
{
    public async Task<IEnumerable<Customer>> GetAll()
    {
        return await context.Customers.ToListAsync();
    }

    public async Task<Customer> GetById(int id)
    {
        return await context.Customers.FindAsync(id);
    }

    public async Task<Customer?> GetCustomerByEmail(string email)
    {
        return await context.Customers.FirstOrDefaultAsync(c => c.Email == email);
    }

    public async Task<IEnumerable<Customer>> GetCustomerByFirstName(string firstName)
    {
        return await context.Customers
            .Where(c => c.FirstName == firstName)
            .ToListAsync();
    }

    public async Task<IEnumerable<Customer>> GetCustomerByLastName(string lastName)
    {
        return await context.Customers
            .Where(c => c.LastName == lastName)
            .ToListAsync();
    }

    public async Task<Customer> Add(Customer customer)
    {
        context.Customers.Add(customer);
        await context.SaveChangesAsync();
        return customer;
    }

    public async Task<Customer> Update(Customer customer)
    {
        context.Entry(customer).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return customer;
    }

    public async Task<Customer> Delete(int id)
    {
        var customer = await context.Customers.FindAsync(id);
        if (customer == null)
        {
            return null;
        }

        context.Customers.Remove(customer);
        await context.SaveChangesAsync();
        return customer;
    }
}