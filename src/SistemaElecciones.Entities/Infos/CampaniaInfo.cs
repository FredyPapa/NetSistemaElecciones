namespace SistemaElecciones.Entities.Infos;

public class CampaniaInfo
{
    public int Id { get; set; }
    public string Denominacion { get; set; } = null!;
    public DateOnly FechaInicio { get; set; } = default!;
    public TimeOnly HoraInicio { get; set; } = default!;
    public DateOnly FechaFin { get; set; } = default!;
    public TimeOnly HoraFin { get; set; } = default!;
    public string EstadoCampaniaId { get; set; }  = null!;
    public string PermiteVotoBlanco { get; set; }  = null!;
}