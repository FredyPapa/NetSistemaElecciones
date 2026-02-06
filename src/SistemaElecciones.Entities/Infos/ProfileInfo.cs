namespace SistemaElecciones.Entities.Infos;

public class ProfileInfo
{
    public int Id { get; set; }
    
    public string Campania { get; set; } = null!;
    public string DniTrabajador { get; set; } = null!;
    public string NombreCompletoTrabajador { get; set; } = null!;
    
    public bool YaVoto { get; set; }
}