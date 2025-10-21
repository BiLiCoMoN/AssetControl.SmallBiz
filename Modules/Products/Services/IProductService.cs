using AssetControl.SmallBiz.Modules.Products.Models;

namespace AssetControl.SmallBiz.Modules.Products.Services;

public interface IProductService
{
    Task<List<Product>> GetAllAsync();
}
