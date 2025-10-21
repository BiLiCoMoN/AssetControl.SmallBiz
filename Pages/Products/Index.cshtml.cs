using AssetControl.SmallBiz;
using AssetControl.SmallBiz.Modules.Products.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

public class ProductsIndexModel : PageModel
{
    private readonly AppDbContext _db;
    public ProductsIndexModel(AppDbContext db) => _db = db;
    public List<Product> Products { get; set; } = new();

    public async Task OnGetAsync()
    {
        Products = await _db.Products.OrderBy(p => p.Id).ToListAsync();
    }
}
