using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Data.Services;
using ProyectoFinal.Data.ViewModels;
using System;

namespace ProyectoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetUsuarioClaseController : ControllerBase
    {
        private Det_Usuarios_ClasesService _service;

        public DetUsuarioClaseController(Det_Usuarios_ClasesService service)
        {
            _service = service;
        }

        // Agregar un nuevo detalle usuario-clase
        [HttpPost("add-det_usuario_clase")]
        public IActionResult AgregarDetalleUsuarioClase([FromBody] Det_Usuario_ClaseVM detalleVM)
        {
            try
            {
                _service.AgregarDetalleUsuarioClase(detalleVM);
                return Ok(new { mensaje = "Detalle agregado exitosamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = "Error al agregar el detalle", error = ex.Message });
            }
        }

        // Modificar un detalle existente
        [HttpPut("ModificarDetalle")]
        public IActionResult ModificarDetalleUsuarioClase(int usuarioID, int claseID, [FromBody] DateTime? nuevaFechaInscripcion)
        {
            try
            {
                _service.ModificarDetalleUsuarioClase(usuarioID, claseID, nuevaFechaInscripcion);
                return Ok(new { mensaje = "Detalle modificado exitosamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = "Error al modificar el detalle", error = ex.Message });
            }
        }

        // Eliminar un detalle usuario-clase
        [HttpDelete("EliminarDetalle")]
        public IActionResult EliminarDetalleUsuarioClase(int usuarioID, int claseID)
        {
            try
            {
                _service.EliminarDetalleUsuarioClase(usuarioID, claseID);
                return Ok(new { mensaje = "Detalle eliminado exitosamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = "Error al eliminar el detalle", error = ex.Message });
            }
        }

        // Obtener todos los detalles usuario-clase
        [HttpGet("ObtenerTodos")]
        public IActionResult ObtenerTodosLosDetalles()
        {
            try
            {
                var detalles = _service.ObtenerTodosLosDetalles();
                return Ok(detalles);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = "Error al obtener los detalles", error = ex.Message });
            }
        }

        // Obtener un detalle especÃ­fico por UsuarioID y ClaseID
        [HttpGet("ObtenerDetalle")]
        public IActionResult ObtenerDetalleEspecifico(int usuarioID, int claseID)
        {
            try
            {
                var detalle = _service.ObtenerDetalleEspecifico(usuarioID, claseID);
                if (detalle == null)
                    return NotFound(new { mensaje = "Detalle no encontrado" });

                return Ok(detalle);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = "Error al obtener el detalle", error = ex.Message });
            }
        }
    }
}
