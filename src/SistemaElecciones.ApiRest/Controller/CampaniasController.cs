using Microsoft.AspNetCore.Mvc;
using SistemaElecciones.Dto.Request;
using SistemaElecciones.Services.Interfaces;

namespace SistemaElecciones.ApiRest.Controller;

[Route("api/[controller]")]
[ApiController]
public class CampaniasController : ControllerBase
{
    private readonly ICampaniaService _service;

    public CampaniasController(ICampaniaService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _service.ListAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await _service.FindByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CampaniaDtoRequest request)
    {
        return Ok(await _service.CreateAsync(request));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(int id, CampaniaDtoRequest request)
    {
        return Ok(await _service.UpdateAsync(id, request));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await _service.DeleteAsync(id));
    }
}