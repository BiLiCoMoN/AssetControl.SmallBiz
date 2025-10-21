using AssetControl.SmallBiz.Modules.Customers.Models;

namespace AssetControl.SmallBiz.Modules.Customers.Services;

public interface ICustomerService
{
    Task<List<Customer>> GetAllAsync();
    Task<Customer?> GetByIdAsync(int id);
    Task<Customer> CreateAsync(Customer customer);
    Task UpdateAsync(Customer customer);
    Task DeleteAsync(int id);
}
