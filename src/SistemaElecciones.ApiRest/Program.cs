using Microsoft.EntityFrameworkCore;
using SistemaElecciones.DataAccess;
using SistemaElecciones.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenApi();

//Agregamos la referencia al DbContext
builder.Services.AddDbContext<SistemaEleccionesDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

//Ejemplo con EF Core
app.MapGet("/api/estadosCampania", (SistemaEleccionesDbContext context) =>
{
    var estadosCampania = context.Set<EstadoCampania>()
        .ToList();
    return Results.Ok(estadosCampania);
});

app.Run();
