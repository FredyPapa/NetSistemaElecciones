using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using Scrutor;
using SistemaElecciones.Common.Configuration;
using SistemaElecciones.DataAccess;
using SistemaElecciones.Entities;
using SistemaElecciones.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

//Agregamos los CORS
string corsConfiguration = "EleccionesCORS";

//Agregamos los controladores
builder.Services.AddControllers();

// Add services to the container.
builder.Services.AddOpenApi();

//Configuración de CORS (políticas)
builder.Services.AddCors(policy =>
{
    policy.AddPolicy(corsConfiguration, p =>
    {
        p.AllowAnyOrigin();
        p.AllowAnyHeader();
        p.AllowAnyMethod();
    });
});

//Agregamos la referencia al DbContext
builder.Services.AddDbContext<SistemaEleccionesDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
//Agregarmos la referencia al DBContext de Identity
builder.Services.AddDbContext<AuthenticationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), // Usa la misma cadena de conexión por lo cual las tablas se crearán en la misma BD
        c => c.MigrationsHistoryTable("SecurityMigrations")); //Aquí definimos el nombre de la tabla de migración para este contexto
});

//Configuración de Scrutor para el mapeo de las interfaces e implementaciones
builder.Services.Scan(s => s
    .FromAssemblies(typeof(IUserService).Assembly)
    .AddClasses(publicOnly:false)
    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
    .AsMatchingInterface()
    .WithScopedLifetime()
);

//Configuramos ASP.NET Identity Core
builder.Services.AddIdentity<EleccionesIdentityUser, IdentityRole>(polices =>
{
    polices.Password.RequireDigit = false;
    polices.Password.RequiredLength = 8;
    polices.Password.RequireLowercase = true;
    polices.Password.RequireNonAlphanumeric = false;
    polices.Password.RequireUppercase = true;

    polices.User.RequireUniqueEmail = true;

    //Políticas del bloqueo de cuenta
    polices.Lockout.AllowedForNewUsers = true;
    polices.Lockout.MaxFailedAccessAttempts = 3;
    polices.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
})
.AddEntityFrameworkStores<AuthenticationDbContext>()
.AddDefaultTokenProviders();

//Configuramos el contexto de seguridad del API
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    var secretKey = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"] 
                                           ?? throw new InvalidOperationException("No se ha configurado la llave secreta JWT."));

    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(secretKey)
    };
});

//Mapea el contenido de la configuración en una clase fuertemente tipada
builder.Services.Configure<AppSettings>(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(); //Para exponer los endpoints (similar a Swagger)
}

app.UseHttpsRedirection();  //Redirecciona HTTP a HTTPS en caso exista

app.UseRouting();

//Agregamos el Middelware correspondiente al CORS
app.UseCors(corsConfiguration);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

//Ejemplo con EF Core
app.MapGet("/api/estadosCampania", (SistemaEleccionesDbContext context) =>
{
    var estadosCampania = context.Set<EstadoCampania>()
        .ToList();
    return Results.Ok(estadosCampania);
});

//Hacemos el llamado al DataSeeding

await using (var scope = app.Services.CreateAsyncScope())
{
    await UserDataSeeder.SeedAsync(scope.ServiceProvider);
}

//Se ejecuta la Aplicación
app.Run();
