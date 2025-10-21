using AssetControl.SmallBiz;
using AssetControl.SmallBiz.Modules.Orders.Models;
using AssetControl.SmallBiz.Modules.Customers.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

public class OrdersIndexModel : PageModel
{
    private readonly AppDbContext _db;
    public OrdersIndexModel(AppDbContext db) => _db = db;
    public List<Order> Orders { get; set; } = new();

    public async Task OnGetAsync()
    {
        Orders = await _db.Orders.Include(o => o.Customer).OrderByDescending(o => o.CreatedAt).ToListAsync();
    }
}
