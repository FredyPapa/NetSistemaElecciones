using System.ComponentModel.DataAnnotations;

namespace SistemaElecciones.Entities;

public class EntityBase
{
    [Key]
    public int Id { get; set; }
    public bool Estado { get; set; }
    public int usuarioCreacionId { get; set; }
    public DateTime FechaCreacion { get; set; }
    public int? usuarioActualizacionId { get; set; }
    public DateTime? FechaActualizacion { get; set; }

    protected EntityBase()
    {
        Estado = true;
        FechaCreacion = DateTime.UtcNow;
    }
}