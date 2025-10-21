using AssetControl.SmallBiz.Modules.Orders.Models;
using AssetControl.SmallBiz.Modules.Orders.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class OrdersIndexModel : PageModel
{
    private readonly IOrderService _service;
    public OrdersIndexModel(IOrderService service) => _service = service;
    public List<Order> Orders { get; set; } = new();

    public async Task OnGetAsync()
    {
        Orders = await _service.GetAllAsync();
    }
}
