using System.ComponentModel.DataAnnotations;

namespace SistemaElecciones.UnitTests;

public class EntityBase
{
    [Key]
    public int Id { get; set; }
    public bool Estado { get; set; }
    public int IdUsuarioCreacion { get; set; }
    public DateTime FechaCreacion { get; set; }
    
    protected  EntityBase()
    {
        FechaCreacion = DateTime.UtcNow;
        Estado = true;
    }
}