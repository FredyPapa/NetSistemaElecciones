namespace SistemaElecciones.Entities;

public class Padron : EntityBase
{
    public int CampaniaId { get; set; }
    public Campania Campania { get; set; } = null!;
    public int TrabajadorId { get; set; }
    public Trabajador Trabajador { get; set; } = null!;
    public bool EstadoVoto { get; set; }
}