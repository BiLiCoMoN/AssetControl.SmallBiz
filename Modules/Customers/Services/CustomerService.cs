using AssetControl.SmallBiz.Modules.Customers.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetControl.SmallBiz.Modules.Customers.Services;

public class CustomerService : ICustomerService
{
    private readonly AppDbContext _db;
    public CustomerService(AppDbContext db) => _db = db;

    public async Task<List<Customer>> GetAllAsync() => await _db.Customers.OrderBy(c => c.Id).ToListAsync();

    public async Task<Customer?> GetByIdAsync(int id) => await _db.Customers.FindAsync(id);

    public async Task<Customer> CreateAsync(Customer customer)
    {
        _db.Customers.Add(customer);
        await _db.SaveChangesAsync();
        return customer;
    }

    public async Task UpdateAsync(Customer customer)
    {
        _db.Customers.Update(customer);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var c = await _db.Customers.FindAsync(id);
        if (c != null) { _db.Customers.Remove(c); await _db.SaveChangesAsync(); }
    }
}
