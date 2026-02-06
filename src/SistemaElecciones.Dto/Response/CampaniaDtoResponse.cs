namespace SistemaElecciones.Dto.Response;

public class CampaniaDtoResponse
{
    public int Id { get; set; }
    public string Denominacion { get; set; } = null!;
    public string FechaInicio { get; set; } = null!;
    public string HoraInicio { get; set; } = null!;
    public string FechaFin { get; set; } = null!;
    public string HoraFin { get; set; } = null!;
    public string EstadoCampaniaId { get; set; }  = null!;
    public string PermiteVotoBlanco { get; set; }  = null!;
}