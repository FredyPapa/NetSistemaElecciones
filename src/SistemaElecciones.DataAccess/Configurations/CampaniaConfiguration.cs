using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaElecciones.Entities;

namespace SistemaElecciones.DataAccess.Configurations;

public class CampaniaConfiguration : IEntityTypeConfiguration<Campania>
{
    public void Configure(EntityTypeBuilder<Campania> builder)
    {
        //Definimos el nombre de la tabla, que corresponde con el nombre de la clase
        builder.ToTable(nameof(Campania));

        //Filtro para que sólo muestre los registros con Estado true
        builder.HasQueryFilter(p => p.Estado);
    }
}