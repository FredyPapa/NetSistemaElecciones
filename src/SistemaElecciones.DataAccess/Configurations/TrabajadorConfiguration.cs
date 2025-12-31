using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaElecciones.Entities;

namespace SistemaElecciones.DataAccess.Configurations;

public class TrabajadorConfiguration : IEntityTypeConfiguration<Trabajador>
{
    public void Configure(EntityTypeBuilder<Trabajador> builder)
    {
        //Definimos el nombre de la tabla, que corresponde con el nombre de la clase
        builder.ToTable(nameof(Trabajador));

        //Establecemos configuraciones propias de la tabla
        builder.Property(p => p.NroDocumento)
            .HasMaxLength(20);
        builder.Property(p => p.Nombres)
            .HasMaxLength(100);
        builder.Property(p => p.ApellidoPaterno)
            .HasMaxLength(50);
        builder.Property(p => p.ApellidoMaterno)
            .HasMaxLength(50);
        builder.Property(p => p.Correo)
            .HasMaxLength(100);
        builder.Property(p => p.Celular)
            .HasMaxLength(20);
        builder.Property(p=>p.FotoUrl)
            .IsUnicode(false)   //Para que sea varchar en lugar de nvarchar (es decir no aceptará tildes, etc.) 
            .HasMaxLength(500); //Ancho del campo

        //Filtro para que sólo muestre los registros con Estado true
        builder.HasQueryFilter(p => p.Estado);
    }
}