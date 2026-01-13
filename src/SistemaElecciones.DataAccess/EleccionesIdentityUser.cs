using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace SistemaElecciones.DataAccess;

public class EleccionesIdentityUser : IdentityUser
{
    [StringLength(100)]
    public string NombreCompleto { get; set; } = string.Empty;
}