using AssetControl.SmallBiz.Models;

namespace AssetControl.SmallBiz.Data;

public static class SeedData
{
    public static async Task EnsureSeedDataAsync(AppDbContext db)
    {
        // simple guard
        if (await db.Customers.AnyAsync()) return;

        var customers = new List<Customer>
        {
            new Customer { Name = "ACME Industries", Email = "contact@acme.com", Phone = "(11) 99999-0001", Address = "Rua A, 123" },
            new Customer { Name = "Loja do João", Email = "joao@lojajoao.com", Phone = "(11) 99999-0002", Address = "Av. B, 456" },
            new Customer { Name = "Oficina Silva", Email = "contato@oficinasilva.com", Phone = "(11) 99999-0003", Address = "R. Oficinas, 78" }
        };

        var products = new List<Product>
        {
            new Product { Name = "Parafuso M8", Description = "Parafuso metálico", Price = 0.10M, Stock = 1000 },
            new Product { Name = "Motor elétrico", Description = "Motor 220V", Price = 350.00M, Stock = 10 }
        };

        await db.Customers.AddRangeAsync(customers);
        await db.Products.AddRangeAsync(products);
        await db.SaveChangesAsync();
    }
}
