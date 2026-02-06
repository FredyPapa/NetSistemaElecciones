using SistemaElecciones.Dto.Request;
using SistemaElecciones.Dto.Response;

namespace SistemaElecciones.Services.Interfaces;

public interface ICandidatoService
{
    Task<PaginationResponse<CandidatoDtoResponse>> ListAsync();

    Task<BaseResponse<CandidatoDtoRequest>> FindByIdAsync(int id);

    Task<BaseResponse> CreateAsync(CandidatoDtoRequest request);

    Task<BaseResponse> UpdateAsync(int id, CandidatoDtoRequest request);

    Task<BaseResponse> DeleteAsync(int id);
}