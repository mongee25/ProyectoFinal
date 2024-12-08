using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Data.Services;
using ProyectoFinal.Data.ViewModels;
using System;

[Route("api/[controller]")]
[ApiController]
public class ClaseController : ControllerBase
{
    private ClasesService _claseService;

    public ClaseController(ClasesService claseService)
    {
        _claseService = claseService;
    }

    // Endpoint para agregar una clase
    [HttpPost("Agregar")]
    public IActionResult AgregarClase([FromBody] ClaseVM claseVM)
    {
        try
        {
            _claseService.AgregarClase(claseVM);
            return Ok(new { mensaje = "Clase agregada correctamente." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    // Endpoint para obtener todas las clases
    [HttpGet("obtener-todas-las-clses")]
    public IActionResult ObtenerTodasClases()
    {
        try
        {
            var clases = _claseService.ObtenerTodasClases();
            return Ok(clases);
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    // Endpoint para obtener una clase por ID
    [HttpGet("obtener-user-by-id/{id}")]
    public IActionResult ObternerClaseById([FromQuery] int claseId)
    {
        try
        {
            var clase = _claseService.ObternerClaseById(claseId);
            if (clase != null)
            {
                return Ok(clase);
            }
            return NotFound(new { mensaje = "Clase no encontrada." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    // Endpoint para modificar una clase existente
    [HttpPut("actualizar-by-id/{id}")]
    public IActionResult ModificarClase([FromQuery] int claseId, [FromBody] ModificarClaseVM modificarClaseVM)
    {
        try
        {
            _claseService.ModificarClase(claseId, modificarClaseVM);
            return Ok(new { mensaje = "Clase modificada correctamente." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    // Endpoint para eliminar una clase
    [HttpDelete("Eliminar")]
    public IActionResult EliminarClase([FromQuery] int claseId)
    {
        try
        {
            _claseService.EliminarClase(claseId);
            return Ok(new { mensaje = "Clase eliminada correctamente." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}