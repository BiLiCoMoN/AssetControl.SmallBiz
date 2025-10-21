using AssetControl.SmallBiz.Modules.Customers.Models;
using AssetControl.SmallBiz.Modules.Customers.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class DeleteModel : PageModel
{
    private readonly ICustomerService _service;
    public DeleteModel(ICustomerService service) => _service = service;
    public Customer? Customer { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Customer = await _service.GetByIdAsync(id);
        if (Customer is null) return RedirectToPage("Index");
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        await _service.DeleteAsync(id);
        return RedirectToPage("Index");
    }
}
