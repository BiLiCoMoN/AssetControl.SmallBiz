using AssetControl.SmallBiz;
using AssetControl.SmallBiz.Modules.Customers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class CreateModel : PageModel
{
    private readonly AppDbContext _db;
    public CreateModel(AppDbContext db) => _db = db;
    [BindProperty]
    public Customer Customer { get; set; } = new();

    public void OnGet() { }

    public async Task<IActionResult> OnPostAsync()
    {
        if (string.IsNullOrWhiteSpace(Customer.Name)) return Page();
        _db.Customers.Add(Customer);
        await _db.SaveChangesAsync();
        return RedirectToPage("Index");
    }
}
