namespace SistemaElecciones.Dto.Response;

public class VotacionDtoResponse
{
    public int Id { get; set; }
    public string CampaniaDenominacion { get; set; } = null!;
    public string CandidatoNombreCompleto { get; set; } = null!;
    public DateTime FechaVoto { get; set; }
}