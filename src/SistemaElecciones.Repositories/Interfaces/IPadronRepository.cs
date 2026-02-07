using SistemaElecciones.Entities;

namespace SistemaElecciones.Repositories.Interfaces;

public interface IPadronRepository : IRepositoryBase<Padron>
{
    Task<ICollection<Padron>> ListAsync();
}