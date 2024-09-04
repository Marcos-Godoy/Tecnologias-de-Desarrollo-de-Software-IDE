using Microsoft.EntityFrameworkCore;
using Unidad6Capitulo1.Data;
using Unidad6Capitulo1.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<UniversidadContext>(); //< --insertar
builder.Services.AddEndpointsApiExplorer(); //< --insertar
builder.Services.AddSwaggerGen(); //< --insertar

var app = builder.Build();

app.UseSwagger(); //< --insertar
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Universidad API V1");
    c.RoutePrefix = string.Empty; // Opcional: hace que Swagger UI esté en la raíz
}); //< --insertar

//app.MapGet("/", () => "Hello World!");

// Definio los endpoints ABMC/CRUD para `Alumno`

// Obtener todos los alumnos (GET /alumnos)
app.MapGet("/alumnos", async (UniversidadContext context) =>
    await context.Alumnos.ToListAsync()
        is List<Alumno> alumnos && alumnos.Any()
            ? Results.Ok(alumnos)
            : Results.NoContent());

// Obtener un alumno por ID (GET /alumnos/{id})
app.MapGet("/alumnos/{id}", async (int id, UniversidadContext context) =>
    await context.Alumnos.FindAsync(id) is Alumno alumno
        ? Results.Ok(alumno)
        : Results.NotFound());

// Crear un nuevo alumno (POST /alumnos)
app.MapPost("/alumnos", async (Alumno alumno, UniversidadContext context) =>
{
    context.Alumnos.Add(alumno);
    await context.SaveChangesAsync();

    return Results.Created($"/alumnos/{alumno.Id}", alumno);
});

// Actualizar un alumno existente (PUT /alumnos/{id})
app.MapPut("/alumnos/{id}", async (int id, Alumno updatedAlumno, UniversidadContext context) =>
{
    var alumno = await context.Alumnos.FindAsync(id);
    if (alumno is null) return Results.NotFound();

    alumno.Apellido = updatedAlumno.Apellido;
    alumno.Nombre = updatedAlumno.Nombre;
    alumno.Legajo = updatedAlumno.Legajo;
    alumno.Direccion = updatedAlumno.Direccion;

    await context.SaveChangesAsync();
    return Results.NoContent();
});

// Eliminar un alumno existente (DELETE /alumnos/{id})
app.MapDelete("/alumnos/{id}", async (int id, UniversidadContext context) =>
{
    var alumno = await context.Alumnos.FindAsync(id);
    if (alumno is null) return Results.NotFound();

    context.Alumnos.Remove(alumno);
    await context.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();

// En el archivo Program.cs, registrar el contexto con la base de datos y
// los servicios de OpenAPI / Swagger a continuación de la creación del builder de la siguiente manera:
