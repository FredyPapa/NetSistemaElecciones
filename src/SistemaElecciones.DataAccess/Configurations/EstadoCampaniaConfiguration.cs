using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaElecciones.Common;
using SistemaElecciones.Entities;

namespace SistemaElecciones.DataAccess.Configurations;

public class EstadoCampaniaConfiguration : IEntityTypeConfiguration<EstadoCampania>
{
    public void Configure(EntityTypeBuilder<EstadoCampania> builder)
    {
        //Definimos el nombre de la tabla, que corresponde con el nombre de la clase
        builder.ToTable(nameof(EstadoCampania));
        
        //Data Seeding
        builder.HasData(new List<EstadoCampania>
        {
            new() { Id = 1, Descripcion = "Vigente", usuarioCreacionId = 1, FechaCreacion = Constantes.FechaCreacionDefault },
            new() { Id = 2, Descripcion = "Finalizado", usuarioCreacionId = 1, FechaCreacion = Constantes.FechaCreacionDefault }
        });

        //Filtro para que sólo muestre los registros con Estado true
        builder.HasQueryFilter(p => p.Estado);
    }
}