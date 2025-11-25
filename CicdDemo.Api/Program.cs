using CicdDemo.Core;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddSingleton<IProductRepository, InMemoryProductRepository>();
builder.Services.AddScoped<ProductService>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapPost("/products", (ProductService service, ProductRequest req) =>
{
    var product = service.Create(req.Name, req.Price);
    return Results.Created($"/products/{product.Id}", product);
});

app.MapPut("/products/{id:guid}/price", (ProductService service, Guid id, decimal newPrice) =>
{
    var updated = service.UpdatePrice(id, newPrice);
    return Results.Ok(updated);
});

app.MapGet("/products", (ProductService service) =>
{
    return Results.Ok(service.GetAll());
});

app.UseHttpsRedirection();

app.Run();
record ProductRequest(string Name, decimal Price);
