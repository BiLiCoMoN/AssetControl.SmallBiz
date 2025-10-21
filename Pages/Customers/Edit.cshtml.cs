using AssetControl.SmallBiz.Modules.Customers.Models;
using AssetControl.SmallBiz.Modules.Customers.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class EditModel : PageModel
{
    private readonly ICustomerService _service;
    public EditModel(ICustomerService service) => _service = service;
    [BindProperty]
    public Customer Customer { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var c = await _service.GetByIdAsync(id);
        if (c is null) return RedirectToPage("Index");
        Customer = c;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var existing = await _service.GetByIdAsync(Customer.Id);
        if (existing is null) return RedirectToPage("Index");
        existing.Name = Customer.Name;
        existing.Email = Customer.Email;
        existing.Phone = Customer.Phone;
        existing.Address = Customer.Address;
        await _service.UpdateAsync(existing);
        return RedirectToPage("Index");
    }
}
