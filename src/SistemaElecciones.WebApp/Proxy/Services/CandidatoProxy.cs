using SistemaElecciones.Dto.Request;
using SistemaElecciones.Dto.Response;
using SistemaElecciones.WebApp.Proxy.Interfaces;

namespace SistemaElecciones.WebApp.Proxy.Services;

public class CandidatoProxy : CrudRestHelperBase<CandidatoDtoRequest,CandidatoDtoResponse>, ICandidatoProxy
{
    public CandidatoProxy(HttpClient httpClient)
        : base("api/Candidatos", httpClient)
    {
        
    }
}