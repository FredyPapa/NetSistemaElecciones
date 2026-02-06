using SistemaElecciones.Dto.Request;
using SistemaElecciones.Dto.Response;

namespace SistemaElecciones.Services.Interfaces;

public interface ICampaniaService
{
    Task<PaginationResponse<CampaniaDtoResponse>> ListAsync();

    Task<BaseResponse<CampaniaDtoRequest>> FindByIdAsync(int id);

    Task<BaseResponse> CreateAsync(CampaniaDtoRequest request);

    Task<BaseResponse> UpdateAsync(int id, CampaniaDtoRequest request);

    Task<BaseResponse> DeleteAsync(int id);
}