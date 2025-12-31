namespace SistemaElecciones.Entities;

public class Trabajador : EntityBase
{
    public string NroDocumento { get; set; } = null!;
    public string Nombres { get; set; } = null!;
    public string ApellidoPaterno { get; set; } = null!;
    public string ApellidoMaterno { get; set; } = null!;
    public int SexoId { get; set; }
    public Sexo Sexo { get; set; } = null!;
    public string Correo { get; set; } = null!;
    public string? Celular { get; set; } = null!;
    public string? FotoUrl { get; set; }
}
