using AssetControl.SmallBiz.Modules.Customers.Dtos;
using AssetControl.SmallBiz.Modules.Customers.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class EditModel : PageModel
{
    private readonly ICustomerService _service;
    public EditModel(ICustomerService service) => _service = service;

    [BindProperty]
    public CustomerUpdateDto Customer { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var c = await _service.GetByIdAsync(id);
        if (c is null) return RedirectToPage("Index");
        Customer = new CustomerUpdateDto { Name = c.Name, Email = c.Email, Phone = c.Phone, Address = c.Address };
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        if (!ModelState.IsValid) return Page();
        await _service.UpdateAsync(id, Customer);
        return RedirectToPage("Index");
    }
}
