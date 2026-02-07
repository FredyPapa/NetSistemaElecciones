using SistemaElecciones.Entities;

namespace SistemaElecciones.Repositories.Interfaces;

public interface ICandidatoRepository : IRepositoryBase<Candidato>
{
    Task<ICollection<Candidato>> ListAsync();
}