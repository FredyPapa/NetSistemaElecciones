using Microsoft.EntityFrameworkCore;
using SistemaElecciones.DataAccess;
using SistemaElecciones.Entities;
using SistemaElecciones.Repositories.Interfaces;

namespace SistemaElecciones.Repositories.Implementaciones;

public class PadronRepository : RepositoryBase<Padron>, IPadronRepository
{
    public PadronRepository(SistemaEleccionesDbContext context) : base(context)
    {
    }
}