using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SistemaElecciones.DataAccess;

public class AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options)
    : IdentityDbContext<EleccionesIdentityUser>(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        //Fluent API de EF Core
        builder.Entity<EleccionesIdentityUser>(e => e.ToTable("Usuario")); //En lugar del nombre de tabla AspNetUser
        builder.Entity<IdentityRole>(e => e.ToTable("Rol")); //En lugar del nombre de tabla AspNetRoles
        builder.Entity<IdentityUserRole<string>>(e => e.ToTable("UsuarioRol")); //En lugar del nombre de tabla AspNetUserRoles
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);

        configurationBuilder.Properties<string>().HaveMaxLength(150);
    }
}