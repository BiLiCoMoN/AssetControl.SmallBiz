using AssetControl.SmallBiz.Modules.Customers.Models;
using AssetControl.SmallBiz.Modules.Products.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetControl.SmallBiz.Data;

public static class SeedData
{
    public static async Task EnsureSeedDataAsync(AppDbContext db)
    {
        // Ensure default generic customer exists with Id = 1
        var defaultCustomer = await db.Customers.FirstOrDefaultAsync(c => c.Id == 1);
        if (defaultCustomer == null)
        {
            defaultCustomer = new Customer { Id = 1, Name = "Consumidor Final", Email = null, Phone = null, Address = "" };
            db.Customers.Add(defaultCustomer);
            await db.SaveChangesAsync();
        }

        // If there are only the default customer, add some sample customers and products for development
        var customerCount = await db.Customers.CountAsync();
        if (customerCount <= 1)
        {
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

        // If using SQLite, ensure sqlite_sequence is updated so AUTOINCREMENT continues from the max id
        try
        {
            if (db.Database.IsSqlite())
            {
                var maxId = await db.Customers.MaxAsync(c => (int?)c.Id) ?? 1;
                var sql = $"INSERT OR REPLACE INTO sqlite_sequence(name, seq) VALUES('Customers', {maxId});";
                await db.Database.ExecuteSqlRawAsync(sql);
            }
        }
        catch
        {
            // ignore sequence update failures (not critical)
        }
    }
}
