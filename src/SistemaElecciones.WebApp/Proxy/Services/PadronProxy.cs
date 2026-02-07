using SistemaElecciones.Dto.Request;
using SistemaElecciones.Dto.Response;
using SistemaElecciones.WebApp.Proxy.Interfaces;

namespace SistemaElecciones.WebApp.Proxy.Services;

public class PadronProxy : CrudRestHelperBase<PadronDtoRequest, PadronDtoResponse>, IPadronProxy
{
    public PadronProxy(HttpClient httpClient) 
        : base("api/Padron", httpClient)
    {
    }
}