using Godoy.Domain;

var builder = WebApplication.CreateBuilder(args);

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

app.MapGet("/entidades/{id}", (int id) =>
{ 
    PropiedadService service = new PropiedadService();
    return service.Get(id);
})
.WithName("Get")
.WithOpenApi();

app.MapGet("/entidades", () =>
{
    PropiedadService service = new PropiedadService();
    return service.GetAll();
})
.WithName("GetAll")
.WithOpenApi();

app.MapPost("/entidades", (Propiedad entidad) =>
{
    PropiedadService service = new PropiedadService();
    service.Add(entidad);
})
.WithName("Add")
.WithOpenApi();

app.MapPut("/entidades", (Propiedad entidad) =>
{
    PropiedadService service = new PropiedadService();
    service.Update(entidad);
})
.WithName("Update")
.WithOpenApi();

app.MapDelete("/entidades/{id}", (int id) =>
{
    PropiedadService service = new PropiedadService();
    service.Delete(id);
})
.WithName("Delete")
.WithOpenApi();

// Tipos
app.MapGet("/tipos", () =>
{
    TipoPropiedadService service = new TipoPropiedadService();
    return service.GetAll();
})
.WithName("GetAllTipos")
.WithOpenApi();

app.Run();
