using AutoMapper;
using Microsoft.Extensions.Logging;
using SistemaElecciones.Dto.Request;
using SistemaElecciones.Dto.Response;
using SistemaElecciones.Entities;
using SistemaElecciones.Repositories.Interfaces;
using SistemaElecciones.Services.Interfaces;

namespace SistemaElecciones.Services.Implementatios;

public class CampaniaService : ICampaniaService
{
    private readonly ICampaniaRepository _repository;
    private readonly ILogger<CampaniaService> _logger;
    private readonly IMapper _mapper;

    public CampaniaService(ICampaniaRepository repository,ILogger<CampaniaService> logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }
    public async Task<PaginationResponse<CampaniaDtoResponse>> ListAsync()
    {
        var response = new PaginationResponse<CampaniaDtoResponse>();
        try
        {
            var collection = await _repository.ListAsync();

            response.Data = _mapper.Map<ICollection<CampaniaDtoResponse>>(collection);
            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = "Error al listar las campañas";
            _logger.LogCritical(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
        }

        return response;
    }

    public async Task<BaseResponse<CampaniaDtoRequest>> FindByIdAsync(int id)
    {
        var response = new BaseResponse<CampaniaDtoRequest>();
        try
        {
            var entidad = await _repository.FindAsync(id);

            response.Data = _mapper.Map<CampaniaDtoRequest>(entidad);
            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = "Error al obtener la campaña";
            _logger.LogCritical(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
        }
        return response;
    }

    public async Task<BaseResponse> CreateAsync(CampaniaDtoRequest request)
    {
        var response = new BaseResponse();

        try
        {
            // Codigo
            await _repository.AddAsync(_mapper.Map<Campania>(request));

            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = "Error al crear la campaña";
            _logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
        }

        return response;
    }

    public async Task<BaseResponse> UpdateAsync(int id, CampaniaDtoRequest request)
    {
        var response = new BaseResponse();

        try
        {
            // Codigo
            var registro = await _repository.FindAsync(id);
            if (registro is not null)
            {
                _mapper.Map(request, registro);

                await _repository.UpdateAsync();
            }

            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = "Error al actualizar la campaña";
            _logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
        }

        return response;
    }

    public async Task<BaseResponse> DeleteAsync(int id)
    {
        var response = new BaseResponse();

        try
        {
            // Codigo

            await _repository.DeleteAsync(id);

            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = "Error al eliminar la campaña";
            _logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
        }

        return response;

    }

}