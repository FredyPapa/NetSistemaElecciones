namespace SistemaElecciones.Dto.Response;

public class CandidatoDtoResponse
{
    public int Id { get; set; }
    
    // Información de la Campaña
    public int CampaniaId { get; set; }
    public string CampaniaDenominacion { get; set; } = null!;

    // Información del Trabajador
    public int TrabajadorId { get; set; }
    public string TrabajadorNombreCompleto { get; set; } = null!;
    public string TrabajadorNroDocumento { get; set; } = null!;
    public string? TrabajadorFotoUrl { get; set; }

    // Auditoría base
    public bool Estado { get; set; }
}