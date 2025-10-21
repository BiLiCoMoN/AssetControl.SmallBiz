using AssetControl.SmallBiz;
using AssetControl.SmallBiz.Modules.Customers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class DeleteModel : PageModel
{
    private readonly AppDbContext _db;
    public DeleteModel(AppDbContext db) => _db = db;
    public Customer? Customer { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Customer = await _db.Customers.FindAsync(id);
        if (Customer is null) return RedirectToPage("Index");
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        var c = await _db.Customers.FindAsync(id);
        if (c != null)
        {
            _db.Customers.Remove(c);
            await _db.SaveChangesAsync();
        }
        return RedirectToPage("Index");
    }
}
