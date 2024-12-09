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
    [HttpPost("agregar-clase")]
    public IActionResult AgregarClase([FromBody] AgregarClaseVM agregarClaseVM)
    {
        try
        {
            _claseService.AgregarClase(agregarClaseVM);
            return Ok(new { mensaje = "Clase agregada correctamente." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    // Endpoint para obtener todas las clases
    [HttpGet("obtener-todas-las-clases")]
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
    [HttpGet("obtener-clase-by-id/{id}")]
    public IActionResult ObternerClaseById(int id)
    {
        try
        {
            var clase = _claseService.ObternerClaseById(id);
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
    [HttpPut("actualizar-clase-by-id/{id}")]
    public IActionResult ModificarClase(int id, [FromBody] ModificarClaseVM modificarClaseVM)
    {
        try
        {
            _claseService.ModificarClase(id, modificarClaseVM);
            return Ok(new { mensaje = "Clase modificada correctamente." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    // Endpoint para eliminar una clase
    [HttpDelete("eliminar-clase-by-id/{id}")]
    public IActionResult EliminarClase(int id)
    {
        try
        {
            _claseService.EliminarClase(id);
            return Ok(new { mensaje = "Clase eliminada correctamente." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}