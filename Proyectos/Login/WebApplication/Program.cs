using Dominio;

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

app.MapPost("/login", (UsuarioLoginDto login) =>
{
    UsuarioService service = new UsuarioService();
    bool esValido = service.ValidarUsuario(login.Username, login.Password);
    return Results.Ok(esValido);
})
.WithName("Validar").WithOpenApi();


app.Run();
