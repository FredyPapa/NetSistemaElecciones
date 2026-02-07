using SistemaElecciones.Dto.Request;
using SistemaElecciones.Dto.Response;

namespace SistemaElecciones.WebApp.Proxy.Interfaces;

public interface ICandidatoProxy : ICrudRestHelper<CandidatoDtoRequest,CandidatoDtoResponse>
{
    
}