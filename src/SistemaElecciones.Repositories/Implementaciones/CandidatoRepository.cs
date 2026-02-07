using Microsoft.EntityFrameworkCore;
using SistemaElecciones.DataAccess;
using SistemaElecciones.Entities;
using SistemaElecciones.Repositories.Interfaces;

namespace SistemaElecciones.Repositories.Implementaciones;

public class CandidatoRepository : RepositoryBase<Candidato>, ICandidatoRepository
{
    public CandidatoRepository(SistemaEleccionesDbContext context) : base(context)
    {
    }
    
    public new async Task<ICollection<Candidato>> ListAsync()
    {
        return await Context.Set<Candidato>()
            .Include(x => x.Campania)   // Necesario para CampaniaDenominacion
            .Include(x => x.Trabajador) // Necesario para TrabajadorNombreCompleto
            .AsNoTracking()
            .ToListAsync();
    }
}