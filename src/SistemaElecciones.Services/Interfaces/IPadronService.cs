using SistemaElecciones.Dto.Request;
using SistemaElecciones.Dto.Response;

namespace SistemaElecciones.Services.Interfaces;

public interface IPadronService
{
    Task<PaginationResponse<PadronDtoResponse>> ListAsync();

    Task<BaseResponse<PadronDtoRequest>> FindByIdAsync(int id);

    Task<BaseResponse> CreateAsync(PadronDtoRequest request);

    Task<BaseResponse> UpdateAsync(int id, PadronDtoRequest request);

    Task<BaseResponse> DeleteAsync(int id);
}