using AssetControl.SmallBiz.Modules.Orders.Models;

namespace AssetControl.SmallBiz.Modules.Orders.Services;

public interface IOrderService
{
    Task<List<Order>> GetAllAsync();
}
