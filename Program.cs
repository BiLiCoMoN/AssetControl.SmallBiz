using AssetControl.SmallBiz;
using AssetControl.SmallBiz.Modules.Customers.Models;
using AssetControl.SmallBiz.Modules.Customers.Dtos;
using AssetControl.SmallBiz.Modules.Products.Models;
using AssetControl.SmallBiz.Modules.Orders.Models;
using AssetControl.SmallBiz.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configure SQLite DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Default") ?? "Data Source=smallbiz.db"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add Razor Pages
builder.Services.AddRazorPages();
// Register module services
builder.Services.AddScoped<AssetControl.SmallBiz.Modules.Customers.Services.ICustomerService, AssetControl.SmallBiz.Modules.Customers.Services.CustomerService>();
builder.Services.AddScoped<AssetControl.SmallBiz.Modules.Products.Services.IProductService, AssetControl.SmallBiz.Modules.Products.Services.ProductService>();
builder.Services.AddScoped<AssetControl.SmallBiz.Modules.Orders.Services.IOrderService, AssetControl.SmallBiz.Modules.Orders.Services.OrderService>();
// AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Apply EF Core migrations at startup (preferred over EnsureCreated)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
    // seed data for development/testing
    await SeedData.EnsureSeedDataAsync(db);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/health", () => Results.Ok(new { status = "ok" }));
// Root endpoint to avoid 404 at "/" and provide quick links
app.MapGet("/", (HttpRequest req) => Results.Ok(new
{
    name = "AssetControl.SmallBiz",
    health = "/health",
    customers = "/api/customers",
    swagger = req.Scheme + "://" + req.Host + "/swagger/index.html"
}));

// Map Razor Pages
app.MapRazorPages();

app.MapGet("/api/customers", async (AppDbContext db) => await db.Customers.ToListAsync());

app.MapGet("/api/customers/{id:int}", async (int id, AppDbContext db) =>
    await db.Customers.FindAsync(id) is Customer customer ? Results.Ok(customer) : Results.NotFound());

app.MapPost("/api/customers", async (CustomerCreateDto dto, AppDbContext db) =>
{
    if (string.IsNullOrWhiteSpace(dto.Name)) return Results.BadRequest("Name is required");

    var customer = new Customer
    {
        Name = dto.Name,
        Email = dto.Email,
        Phone = dto.Phone,
        Address = dto.Address
    };

    db.Customers.Add(customer);
    await db.SaveChangesAsync();
    return Results.Created($"/api/customers/{customer.Id}", customer);
});

app.MapPut("/api/customers/{id:int}", async (int id, CustomerUpdateDto dto, AppDbContext db) =>
{
    var customer = await db.Customers.FindAsync(id);
    if (customer is null) return Results.NotFound();

    if (!string.IsNullOrWhiteSpace(dto.Name)) customer.Name = dto.Name;
    if (dto.Email != null) customer.Email = dto.Email;
    if (dto.Phone != null) customer.Phone = dto.Phone;
    if (dto.Address != null) customer.Address = dto.Address;

    await db.SaveChangesAsync();
    return Results.Ok(customer);
});

app.MapDelete("/api/customers/{id:int}", async (int id, AppDbContext db) =>
{
    var customer = await db.Customers.FindAsync(id);
    if (customer is null) return Results.NotFound();
    db.Customers.Remove(customer);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();
