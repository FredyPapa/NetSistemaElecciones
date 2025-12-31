namespace SistemaElecciones.Entities;

public class Votacion : EntityBase
{
    public int CampaniaId { get; set; }
    public Campania Campania { get; set; } = null!;
    public int CandidatoId { get; set; }
    public Candidato Candidato { get; set; } = null!;
}