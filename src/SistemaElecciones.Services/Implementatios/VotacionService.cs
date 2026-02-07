using AutoMapper;
using Microsoft.Extensions.Logging;
using SistemaElecciones.Dto.Request;
using SistemaElecciones.Dto.Response;
using SistemaElecciones.Entities;
using SistemaElecciones.Repositories.Interfaces;
using SistemaElecciones.Services.Interfaces;

namespace SistemaElecciones.Services.Implementatios;

public class VotacionService : IVotacionService
{
    private readonly IVotacionRepository _repository;
    private readonly IPadronRepository _padronRepository;
    private readonly ILogger<VotacionService> _logger;
    private readonly IMapper _mapper;

    public VotacionService(IVotacionRepository repository, IPadronRepository padronRepository,ILogger<VotacionService> logger, IMapper mapper)
    {
        _repository = repository;
        _padronRepository = padronRepository;
        _logger = logger;
        _mapper = mapper;
    }
    
    public async Task<PaginationResponse<VotacionDtoResponse>> ListAsync()
    {
        var response = new PaginationResponse<VotacionDtoResponse>();
        try
        {
            var collection = await _repository.ListAsync();
            response.Data = _mapper.Map<ICollection<VotacionDtoResponse>>(collection);
            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = "Error al listar las votaciones";
            _logger.LogCritical(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
        }
        return response;
    }

    public async Task<BaseResponse> CreateAsync(VotacionDtoRequest request)
    {
        var response = new BaseResponse();
        try
        {
            // Validamos que el trabajador exista en el padrón de la campaña vigente
            var registroPadron = await _padronRepository.ListAsync(p => 
                p.CampaniaId == request.CampaniaId && 
                p.TrabajadorId == request.TrabajadorId);

            var elector = registroPadron.FirstOrDefault();

            if (elector == null)
            {
                response.ErrorMessage = "El trabajador no está habilitado en el padrón de esta campaña";
                return response;
            }

            // Se valida que no haya votado
            if (elector.EstadoVoto)
            {
                response.ErrorMessage = "El usuario ya emitió su voto anteriormente";
                return response;
            }

            // Se registra la votación
            var votacion = _mapper.Map<Votacion>(request);
            await _repository.AddAsync(votacion);

            // Se actualiza el estado del padrón
            elector.EstadoVoto = true;
            elector.usuarioActualizacionId = request.UsuarioId;
            elector.FechaActualizacion = DateTime.Now;

            await _padronRepository.UpdateAsync();

            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = "Error al registrar el voto";
            _logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
        }

        return response;
    }
}