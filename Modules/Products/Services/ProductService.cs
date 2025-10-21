using AssetControl.SmallBiz.Modules.Products.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetControl.SmallBiz.Modules.Products.Services;

public class ProductService : IProductService
{
    private readonly AppDbContext _db;
    public ProductService(AppDbContext db) => _db = db;

    public async Task<List<Product>> GetAllAsync() => await _db.Products.OrderBy(p => p.Id).ToListAsync();
}
