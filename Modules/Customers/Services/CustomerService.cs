using AssetControl.SmallBiz.Modules.Customers.Models;
using AssetControl.SmallBiz.Modules.Customers.Dtos;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AssetControl.SmallBiz.Modules.Customers.Services;

public class CustomerService : ICustomerService
{
    private readonly AppDbContext _db;
    private readonly IMapper _mapper;
    public CustomerService(AppDbContext db, IMapper mapper) { _db = db; _mapper = mapper; }

    public async Task<List<CustomerReadDto>> GetAllAsync()
    {
        var entities = await _db.Customers.OrderBy(c => c.Id).ToListAsync();
        return _mapper.Map<List<CustomerReadDto>>(entities);
    }

    public async Task<CustomerReadDto?> GetByIdAsync(int id)
    {
        var entity = await _db.Customers.FindAsync(id);
        return entity == null ? null : _mapper.Map<CustomerReadDto>(entity);
    }

    public async Task<CustomerReadDto> CreateAsync(CustomerCreateDto dto)
    {
        var entity = _mapper.Map<Customer>(dto);
        _db.Customers.Add(entity);
        await _db.SaveChangesAsync();
        return _mapper.Map<CustomerReadDto>(entity);
    }

    public async Task UpdateAsync(int id, CustomerUpdateDto dto)
    {
        var existing = await _db.Customers.FindAsync(id);
        if (existing == null) return;
        _mapper.Map(dto, existing);
        _db.Customers.Update(existing);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var c = await _db.Customers.FindAsync(id);
        if (c != null) { _db.Customers.Remove(c); await _db.SaveChangesAsync(); }
    }
}
