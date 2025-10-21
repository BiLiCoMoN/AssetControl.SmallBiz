using AssetControl.SmallBiz.Modules.Products.Models;
using AssetControl.SmallBiz.Modules.Products.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class ProductsIndexModel : PageModel
{
    private readonly IProductService _service;
    public ProductsIndexModel(IProductService service) => _service = service;
    public List<Product> Products { get; set; } = new();

    public async Task OnGetAsync()
    {
        Products = await _service.GetAllAsync();
    }
}
