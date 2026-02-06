namespace SistemaElecciones.Dto.Response;

public class PadronDtoResponse
{
    public int Id { get; set; }
    
    public int CampaniaId { get; set; }
    public string CampaniaDenominacion { get; set; } = null!;

    public int TrabajadorId { get; set; }
    public string TrabajadorNombreCompleto { get; set; } = null!;
    public string TrabajadorNroDocumento { get; set; } = null!;

    public bool EstadoVoto { get; set; }
    public bool Estado { get; set; } 
}