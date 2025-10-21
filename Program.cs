using AssetControl.SmallBiz;
using AssetControl.SmallBiz.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configure SQLite DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Default") ?? "Data Source=smallbiz.db"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Ensure database created
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
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

app.MapGet("/api/customers", async (AppDbContext db) => await db.Customers.ToListAsync());

app.MapGet("/api/customers/{id:int}", async (int id, AppDbContext db) =>
    await db.Customers.FindAsync(id) is Customer customer ? Results.Ok(customer) : Results.NotFound());

app.MapPost("/api/customers", async (Customer customer, AppDbContext db) =>
{
    db.Customers.Add(customer);
    await db.SaveChangesAsync();
    return Results.Created($"/api/customers/{customer.Id}", customer);
});

app.Run();
