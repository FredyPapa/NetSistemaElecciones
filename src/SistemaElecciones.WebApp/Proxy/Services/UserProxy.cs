using SistemaElecciones.Dto.Request;
using SistemaElecciones.Dto.Response;
using SistemaElecciones.WebApp.Proxy.Interfaces;

namespace SistemaElecciones.WebApp.Proxy.Services;

public class UserProxy: RestBase, IUserProxy
{
    public UserProxy(HttpClient httpClient) 
        : base("api/User",httpClient)
    {
    }

    public async Task<LoginDtoResponse> Login(LoginDtoRequest request)
    {
        var response = await SendAsync<LoginDtoRequest, LoginDtoResponse>(request,HttpMethod.Post,"login");
        return response;
    }

    public async Task Register(RegisterUserDto request)
    {
        var response = await SendAsync<RegisterUserDto, BaseResponse>(request,HttpMethod.Post,"register");

        if (!response.Success)
            throw new ApplicationException(response.ErrorMessage);
    }
}