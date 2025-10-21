using AssetControl.SmallBiz;
using AssetControl.SmallBiz.Modules.Customers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class EditModel : PageModel
{
    private readonly AppDbContext _db;
    public EditModel(AppDbContext db) => _db = db;
    [BindProperty]
    public Customer Customer { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var c = await _db.Customers.FindAsync(id);
        if (c is null) return RedirectToPage("Index");
        Customer = c;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var existing = await _db.Customers.FindAsync(Customer.Id);
        if (existing is null) return RedirectToPage("Index");
        existing.Name = Customer.Name;
        existing.Email = Customer.Email;
        existing.Phone = Customer.Phone;
        existing.Address = Customer.Address;
        await _db.SaveChangesAsync();
        return RedirectToPage("Index");
    }
}
