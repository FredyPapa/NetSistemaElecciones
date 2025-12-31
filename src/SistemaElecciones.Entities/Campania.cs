namespace SistemaElecciones.Entities;

public class Campania : EntityBase
{
    public string Denominacion { get; set; } = null!;
    public DateOnly FechaInicio { get; set; }
    public TimeOnly HoraInicio { get; set; }
    public DateOnly FechaFin { get; set; }
    public TimeOnly HoraFin { get; set; }
    public int EstadoCampaniaId { get; set; }
    public EstadoCampania EstadoCampania { get; set; } = null!;
    public bool PermiteVotoBlanco { get; set; }
}
