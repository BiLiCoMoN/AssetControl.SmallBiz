using AssetControl.SmallBiz.Modules.Orders.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetControl.SmallBiz.Modules.Orders.Services;

public class OrderService : IOrderService
{
    private readonly AppDbContext _db;
    public OrderService(AppDbContext db) => _db = db;

    public async Task<List<Order>> GetAllAsync() => await _db.Orders.Include(o=>o.Customer).OrderByDescending(o=>o.CreatedAt).ToListAsync();
}
