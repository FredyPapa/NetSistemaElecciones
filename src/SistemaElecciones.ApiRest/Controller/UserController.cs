using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaElecciones.Dto.Request;
using SistemaElecciones.Services.Interfaces;

namespace SistemaElecciones.ApiRest.Controller
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService service,  ILogger<UserController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDtoRequest request)
        {
            var response = await _service.LoginAsync(request);

            _logger.LogInformation("Se inició sesión desde {RequestID}", HttpContext.Connection.Id);
   
            return response.Success ? Ok(response) : Unauthorized(response);
        }
    }
}
