using Microsoft.EntityFrameworkCore;
using SistemaElecciones.Entities;

namespace SistemaElecciones.DataAccess;

public static class TrabajadorDataSeeder
{
    public static async Task SeedAsync(SistemaEleccionesDbContext context)
    {
        // 1. Seed de Sexo (Requisito para Trabajador)
        if (!await context.Set<Sexo>().AnyAsync())
        {
            var sexos = new List<Sexo>
            {
                new Sexo { Descripcion = "Masculino" },
                new Sexo { Descripcion = "Femenino" }
            };
            await context.Set<Sexo>().AddRangeAsync(sexos);
            await context.SaveChangesAsync();
        }

        // 2. Seed de Trabajadores
        if (!await context.Set<Trabajador>().AnyAsync())
        {
            // Obtenemos el ID de Sexo para vincular
            var sexoMasculino = await context.Set<Sexo>().FirstAsync(s => s.Descripcion == "Masculino");
            var sexoFemenino = await context.Set<Sexo>().FirstAsync(s => s.Descripcion == "Femenino");

            var trabajadores = new List<Trabajador>
            {
                new Trabajador 
                { 
                    NroDocumento = "12345678", 
                    Nombres = "Fredy", 
                    ApellidoPaterno = "Luis", 
                    ApellidoMaterno = "Wolf", 
                    SexoId = sexoMasculino.Id,
                    Correo = "fredy.luis.wolf@gmail.com",
                    Celular = "999888777",
                    usuarioCreacionId = 1 // ID del admin creado en tu otro seeder
                },
                new Trabajador 
                { 
                    NroDocumento = "87654321", 
                    Nombres = "Magda", 
                    ApellidoPaterno = "Lopez", 
                    ApellidoMaterno = "Perez", 
                    SexoId = sexoFemenino.Id,
                    Correo = "magda@ejemplo.com",
                    Celular = "999111222",
                    usuarioCreacionId = 1
                }
            };

            await context.Set<Trabajador>().AddRangeAsync(trabajadores);
            await context.SaveChangesAsync();
        }
    }
}