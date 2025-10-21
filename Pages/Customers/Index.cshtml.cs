using AssetControl.SmallBiz;
using AssetControl.SmallBiz.Modules.Customers.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

public class IndexModel : PageModel
{
    private readonly AppDbContext _db;
    public IndexModel(AppDbContext db) => _db = db;
    public List<Customer> Customers { get; set; } = new();

    public async Task OnGetAsync()
    {
        Customers = await _db.Customers.OrderBy(c => c.Id).ToListAsync();
    }
}
