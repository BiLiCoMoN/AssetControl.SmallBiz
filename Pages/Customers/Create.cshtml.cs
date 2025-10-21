using AssetControl.SmallBiz.Modules.Customers.Models;
using AssetControl.SmallBiz.Modules.Customers.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class CreateModel : PageModel
{
    private readonly ICustomerService _service;
    public CreateModel(ICustomerService service) => _service = service;
    [BindProperty]
    public Customer Customer { get; set; } = new();

    public void OnGet() { }

    public async Task<IActionResult> OnPostAsync()
    {
        if (string.IsNullOrWhiteSpace(Customer.Name)) return Page();
        await _service.CreateAsync(Customer);
        return RedirectToPage("Index");
    }
}
