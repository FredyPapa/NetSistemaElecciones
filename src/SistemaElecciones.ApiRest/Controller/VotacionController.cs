using Microsoft.AspNetCore.Mvc;
using SistemaElecciones.Dto.Request;
using SistemaElecciones.Services.Interfaces;

namespace SistemaElecciones.ApiRest.Controller;

[Route("api/[controller]")]
[ApiController]
public class VotacionController : ControllerBase
{
    private readonly IVotacionService _service;

    public VotacionController(IVotacionService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var response = await _service.ListAsync();
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] VotacionDtoRequest request)
    {
        var response = await _service.CreateAsync(request);
        
        return Ok(response);
    }
}