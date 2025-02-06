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

app.MapGet("/propiedades/{id}", (int id) =>
{ 
    PropiedadService propiedadService = new PropiedadService();
    return propiedadService.Get(id);
})
.WithName("GetPropiedad")
.WithOpenApi();

app.MapGet("/propiedades", () =>
{
    PropiedadService propiedadService = new PropiedadService();
    return propiedadService.GetAll();
})
.WithName("GetAllPropiedades")
.WithOpenApi();

app.MapPost("/propiedades", (Propiedad propiedad) =>
{
    PropiedadService propiedadService = new PropiedadService();
    propiedadService.Add(propiedad);
})
.WithName("AddPropiedad")
.WithOpenApi();

app.MapPut("/propiedades", (Propiedad propiedad) =>
{
    PropiedadService propiedadService = new PropiedadService();
    propiedadService.Update(propiedad);
})
.WithName("UpdatePropiedad")
.WithOpenApi();

app.MapDelete("/propiedades/{id}", (int id) =>
{
    PropiedadService propiedadService = new PropiedadService();
    propiedadService.Delete(id);
})
.WithName("DeletePropiedad")
.WithOpenApi();

// Tipos de propiedades
app.MapGet("/tipos-propiedades", () =>
{
    TipoPropiedadService tipoPropiedadService = new TipoPropiedadService();
    return tipoPropiedadService.GetAll();
})
.WithName("GetAllTiposPropiedades")
.WithOpenApi();

app.Run();
