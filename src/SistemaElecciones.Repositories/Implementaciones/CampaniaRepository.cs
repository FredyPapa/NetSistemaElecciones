using Microsoft.EntityFrameworkCore;
using SistemaElecciones.DataAccess;
using SistemaElecciones.Entities;
using SistemaElecciones.Repositories.Interfaces;

namespace SistemaElecciones.Repositories.Implementaciones;

public class CampaniaRepository : RepositoryBase<Campania>,ICampaniaRepository
{
    public CampaniaRepository(SistemaEleccionesDbContext context) : base(context)
    {
    }
}