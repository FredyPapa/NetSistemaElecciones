using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using SistemaElecciones.Entities;

namespace SistemaElecciones.DataAccess;

public class SistemaEleccionesDbContext(DbContextOptions<SistemaEleccionesDbContext> options) : DbContext(options)
{
    // Agrega esta línea para que EF reconozca la entidad
    public DbSet<Votacion> Votaciones { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);
        configurationBuilder.Properties<string>()
            .HaveMaxLength(250);
        configurationBuilder.Conventions.Remove<SqlServerOnDeleteConvention>();
    }
}
