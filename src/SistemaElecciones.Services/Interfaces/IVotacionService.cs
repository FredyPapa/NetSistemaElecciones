using SistemaElecciones.Dto.Request;
using SistemaElecciones.Dto.Response;

namespace SistemaElecciones.Services.Interfaces;

public interface IVotacionService
{
    // Listar todos los votos realizados
    Task<PaginationResponse<VotacionDtoResponse>> ListAsync();

    // Registrar un nuevo voto
    Task<BaseResponse> CreateAsync(VotacionDtoRequest request);
    
}