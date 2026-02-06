namespace SistemaElecciones.Dto.Request;

public class PadronDtoRequest
{
    public int Id { get; set; } 

    public int CampaniaId { get; set; }

    public int TrabajadorId { get; set; }

    public bool EstadoVoto { get; set; } 

    public int UsuarioId { get; set; } // Para auditoría 
}