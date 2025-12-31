using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaElecciones.Common;
using SistemaElecciones.Entities;

namespace SistemaElecciones.DataAccess.Configurations;

public class SexoConfiguration : IEntityTypeConfiguration<Sexo>
{
    public void Configure(EntityTypeBuilder<Sexo> builder)
    {
        //Definimos el nombre de la tabla, que corresponde con el nombre de la clase
        builder.ToTable(nameof(Sexo));

        //Data Seeding
        builder.HasData(new List<Sexo>
        {
            new() { Id = 1, Descripcion = "Masculino", usuarioCreacionId = 1, FechaCreacion = Constantes.FechaCreacionDefault},
            new() { Id = 2, Descripcion = "Femenino", usuarioCreacionId = 1, FechaCreacion = Constantes.FechaCreacionDefault }
        });
        
        //Filtro para que sólo muestre los registros con Estado true
        builder.HasQueryFilter(p => p.Estado);
    }
}