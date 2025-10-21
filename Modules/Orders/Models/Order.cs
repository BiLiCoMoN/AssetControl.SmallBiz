using System.ComponentModel.DataAnnotations.Schema;
using AssetControl.SmallBiz.Modules.Customers.Models;

namespace AssetControl.SmallBiz.Modules.Orders.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public int CustomerId { get; set; }
    [ForeignKey(nameof(CustomerId))]
    public Customer? Customer { get; set; }
    public decimal Total { get; set; }
}
