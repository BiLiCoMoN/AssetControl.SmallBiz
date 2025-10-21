using AssetControl.SmallBiz.Modules.Customers.Dtos;
using AssetControl.SmallBiz.Modules.Customers.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel : PageModel
{
    private readonly ICustomerService _service;
    public IndexModel(ICustomerService service) => _service = service;
    public List<CustomerReadDto> Customers { get; set; } = new();

    public async Task OnGetAsync()
    {
        Customers = await _service.GetAllAsync();
    }
}
