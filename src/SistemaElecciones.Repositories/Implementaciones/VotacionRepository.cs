using Microsoft.EntityFrameworkCore;
using SistemaElecciones.DataAccess;
using SistemaElecciones.Entities;
using SistemaElecciones.Repositories.Interfaces;

namespace SistemaElecciones.Repositories.Implementaciones;

public class VotacionRepository : RepositoryBase<Votacion>, IVotacionRepository
{
    public VotacionRepository(SistemaEleccionesDbContext context) : base(context)
    {
    }
}