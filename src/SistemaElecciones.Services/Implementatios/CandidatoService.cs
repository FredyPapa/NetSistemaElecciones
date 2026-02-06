using AutoMapper;
using Microsoft.Extensions.Logging;
using SistemaElecciones.Dto.Request;
using SistemaElecciones.Dto.Response;
using SistemaElecciones.Entities;
using SistemaElecciones.Repositories.Interfaces;
using SistemaElecciones.Services.Interfaces;

namespace SistemaElecciones.Services.Implementatios;

public class CandidatoService : ICandidatoService
{
    private readonly ICandidatoRepository _repository;
    private readonly ILogger<CandidatoService> _logger;
    private readonly IMapper _mapper;

    public CandidatoService(ICandidatoRepository repository, ILogger<CandidatoService> logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }
    public async Task<PaginationResponse<CandidatoDtoResponse>> ListAsync()
    {
        var response = new PaginationResponse<CandidatoDtoResponse>();
        try
        {
            var collection = await _repository.ListAsync();

            response.Data = _mapper.Map<ICollection<CandidatoDtoResponse>>(collection);
            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = "Error al listar los candidatos";
            _logger.LogCritical(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
        }

        return response;
    }

    public async Task<BaseResponse<CandidatoDtoRequest>> FindByIdAsync(int id)
    {
        var response = new BaseResponse<CandidatoDtoRequest>();
        try
        {
            var entidad = await _repository.FindAsync(id);

            response.Data = _mapper.Map<CandidatoDtoRequest>(entidad);
            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = "Error al obtener el candidato";
            _logger.LogCritical(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
        }
        return response;
    }

    public async Task<BaseResponse> CreateAsync(CandidatoDtoRequest request)
    {
        var response = new BaseResponse();

        try
        {
            // Codigo
            await _repository.AddAsync(_mapper.Map<Candidato>(request));

            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = "Error al crear el candidato";
            _logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
        }

        return response;
    }

    public async Task<BaseResponse> UpdateAsync(int id, CandidatoDtoRequest request)
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
            response.ErrorMessage = "Error al actualizar el candidato";
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
            response.ErrorMessage = "Error al eliminar el candidato";
            _logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
        }

        return response;
    }
}