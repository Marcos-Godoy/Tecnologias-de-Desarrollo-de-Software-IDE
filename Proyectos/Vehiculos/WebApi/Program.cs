using Dominio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpLogging(o => { });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpLogging();
}

app.UseHttpsRedirection();


#region Vehiculos

app.MapGet("/vehiculos/{id}", (int id) =>
{
    VehiculoService vehiculoService = new VehiculoService();

    return vehiculoService.Get(id);
})
.WithName("GetVehiculo")
.WithOpenApi();

app.MapGet("/vehiculos", () =>
{
    VehiculoService vehiculoService = new VehiculoService();

    return vehiculoService.GetAll();
})
.WithName("GetAllVehiculos")
.WithOpenApi();

app.MapPost("/vehiculos", (Vehiculo vehiculo) =>
{
    VehiculoService vehiculoService = new VehiculoService();

    vehiculoService.Add(vehiculo);
})
.WithName("AddVehiculo")
.WithOpenApi();

app.MapPut("/vehiculos", (Vehiculo vehiculo) =>
{
    VehiculoService vehiculoService = new VehiculoService();

    vehiculoService.Update(vehiculo);
})
.WithName("UpdateVehiculo")
.WithOpenApi();

app.MapDelete("/vehiculos/{id}", (int id) =>
{
    VehiculoService vehiculoService = new VehiculoService();

    vehiculoService.Delete(id);
})
.WithName("DeleteVehiculo")
.WithOpenApi();

#endregion 

#region TipoPropiedades

app.MapGet("/tipos-propiedades", () =>
{
    TipoPropiedadService tipoPropiedadService = new TipoPropiedadService();

    return tipoPropiedadService.GetAll();
})
.WithName("GetAllTiposPropiedades")
.WithOpenApi();
#endregion 

app.Run();

/*var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
*/