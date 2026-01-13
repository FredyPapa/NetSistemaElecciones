using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SistemaElecciones.Common;

namespace SistemaElecciones.DataAccess;

public static class UserDataSeeder
{
    public static async Task SeedAsync(IServiceProvider service)
    {
        var userManager = service.GetRequiredService<UserManager<EleccionesIdentityUser>>();
        var roleManager = service.GetRequiredService<RoleManager<IdentityRole>>();
        
        //Creamos los roles
        await roleManager.CreateAsync(new IdentityRole(Constantes.RolAdministrador));
        await roleManager.CreateAsync(new IdentityRole(Constantes.RolVotante));

        //Creamos el usuario administrador
        var adminUser = new EleccionesIdentityUser()
        {
            NombreCompleto = "Administrador del Sistema",
            UserName = "Administrador",
            Email = "fredy.luis.wolf@gmail.com",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            PhoneNumber = "0000000000"
        };

        var result = await userManager.CreateAsync(adminUser, "Elecciones2026.");
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(adminUser, Constantes.RolAdministrador);
        }

    }
}