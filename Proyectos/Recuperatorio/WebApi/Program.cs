using Domain;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Agregar esta linea para centralizar el string de conexion
//builder.Services.AddDbContext<ProductoContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpLogging(o => { });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpLogging();
}
app.UseHttpsRedirection();

app.MapGet("/productos", () =>
{
    ProductoService productoService = new ProductoService();
    return productoService.GetAll();
})
.WithName("GetAllProductos")
.WithOpenApi();

app.MapPost("/productos", (Producto producto) =>
{
    ProductoService productoService = new ProductoService();
    productoService.Add(producto);
})
.WithName("AddProducto")
.WithOpenApi();

app.MapPut("/productos", (Producto producto) =>
{
    ProductoService productoService = new ProductoService();
    productoService.Update(producto);
})
.WithName("UpdateProducto")
.WithOpenApi();

app.MapGet("/productos/{id}", (int id) =>
{
    ProductoService productoService = new ProductoService();
    return productoService.Get(id);
})
.WithName("GetProducto")
.WithOpenApi();

app.MapDelete("/productos/{id}", (int id) =>
{
    ProductoService productoService = new ProductoService();
    productoService.Delete(id);
})
.WithName("DeleteProducto")
.WithOpenApi();

app.Run();