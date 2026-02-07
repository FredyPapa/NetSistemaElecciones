namespace SistemaElecciones.Dto.Request;

public class CampaniaDtoRequest
{
    public string Denominacion { get; set; } = null!;
    public DateOnly FechaInicio { get; set; } = DateOnly.FromDateTime(DateTime.Today);
    public TimeOnly HoraInicio { get; set; } = TimeOnly.FromDateTime(DateTime.Now);
    public DateOnly FechaFin { get; set; } = DateOnly.FromDateTime(DateTime.Today);
    public TimeOnly HoraFin { get; set; } = TimeOnly.FromDateTime(DateTime.Now);
    public int EstadoCampaniaId { get; set; }
    //public int PermiteVotoBlanco { get; set; }
    public bool PermiteVotoBlanco { get; set; }
    public int UsuarioCreacionId { get; set; }
    public DateOnly FechaCreacion { get; set; } = DateOnly.FromDateTime(DateTime.Today);
}