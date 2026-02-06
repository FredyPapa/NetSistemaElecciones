using AutoMapper;
using Microsoft.Extensions.Logging;
using SistemaElecciones.Dto.Request;
using SistemaElecciones.Dto.Response;
using SistemaElecciones.Entities;
using SistemaElecciones.Repositories.Interfaces;
using SistemaElecciones.Services.Interfaces;

namespace SistemaElecciones.Services.Implementatios;

public class PadronService : IPadronService
{
    private readonly IPadronRepository _repository;
    private readonly ILogger<PadronService> _logger;
    private readonly IMapper _mapper;

    public PadronService(IPadronRepository repository, ILogger<PadronService> logger,IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }
    
    public async Task<PaginationResponse<PadronDtoResponse>> ListAsync()
    {
        var response = new PaginationResponse<PadronDtoResponse>();
        try
        {
            var collection = await _repository.ListAsync();

            response.Data = _mapper.Map<ICollection<PadronDtoResponse>>(collection);
            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = "Error al listar el Padrón";
            _logger.LogCritical(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
        }

        return response;
    }

    public async Task<BaseResponse<PadronDtoRequest>> FindByIdAsync(int id)
    {
        var response = new BaseResponse<PadronDtoRequest>();
        try
        {
            var entidad = await _repository.FindAsync(id);

            response.Data = _mapper.Map<PadronDtoRequest>(entidad);
            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = "Error al obtener el registro del Padron";
            _logger.LogCritical(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
        }
        return response;
    }

    public async Task<BaseResponse> CreateAsync(PadronDtoRequest request)
    {
        var response = new BaseResponse();

        try
        {
            // Codigo
            await _repository.AddAsync(_mapper.Map<Padron>(request));

            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = "Error al crear el registro del padrón";
            _logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
        }

        return response;
    }

    public async Task<BaseResponse> UpdateAsync(int id, PadronDtoRequest request)
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
            response.ErrorMessage = "Error al actualizar el registro del padrón";
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
            response.ErrorMessage = "Error al eliminar el registro del padrón";
            _logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
        }

        return response;
    }
}