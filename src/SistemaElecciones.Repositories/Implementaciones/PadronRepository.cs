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
    
    public new async Task<ICollection<Padron>> ListAsync()
    {
        return await Context.Set<Padron>()
            .Include(x => x.Campania)  
            .Include(x => x.Trabajador)
            .AsNoTracking()
            .ToListAsync();
    }
}