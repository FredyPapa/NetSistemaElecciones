using SistemaElecciones.Dto.Request;
using SistemaElecciones.Dto.Response;
using SistemaElecciones.WebApp.Proxy.Interfaces;

namespace SistemaElecciones.WebApp.Proxy.Services;

public class CampaniaProxy : CrudRestHelperBase<CampaniaDtoRequest,CampaniaDtoResponse>, ICampaniaProxy
{
    public CampaniaProxy(HttpClient httpClient) 
        : base("api/Campanias", httpClient)
    {
    }

}