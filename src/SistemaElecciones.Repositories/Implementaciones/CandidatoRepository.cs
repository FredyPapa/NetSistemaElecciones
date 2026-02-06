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
}