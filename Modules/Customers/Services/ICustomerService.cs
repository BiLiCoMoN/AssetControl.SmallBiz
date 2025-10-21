using AssetControl.SmallBiz.Modules.Customers.Dtos;

namespace AssetControl.SmallBiz.Modules.Customers.Services;

public interface ICustomerService
{
    Task<List<CustomerReadDto>> GetAllAsync();
    Task<CustomerReadDto?> GetByIdAsync(int id);
    Task<CustomerReadDto> CreateAsync(CustomerCreateDto dto);
    Task UpdateAsync(int id, CustomerUpdateDto dto);
    Task DeleteAsync(int id);
}
