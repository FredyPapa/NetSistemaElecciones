using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaElecciones.Entities;

namespace SistemaElecciones.DataAccess.Configurations;

public class PadronConfiguration : IEntityTypeConfiguration<Padron>
{
    public void Configure(EntityTypeBuilder<Padron> builder)
    {
        //Definimos el nombre de la tabla, que corresponde con el nombre de la clase
        builder.ToTable(nameof(Padron));

        //Filtro para que sólo muestre los registros con Estado true
        builder.HasQueryFilter(p => p.Estado);
    }
}