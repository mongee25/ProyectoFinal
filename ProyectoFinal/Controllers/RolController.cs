using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Data.Services;
using ProyectoFinal.Data.ViewModels;
using System;

namespace ProyectoFinal.Controllers
{
    public class RolController : ControllerBase
    {
        private RolesService _service;

        public RolController(RolesService service)
        {
            _service = service;
        }

        // Agregar un nuevo rol
        [HttpPost("AgregarRol")]
        public IActionResult AgregarRol([FromBody] RolVM rol)
        {
            try
            {
                _service.AddRol(rol);
                return Ok(new { mensaje = "Rol agregado exitosamente." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = "Error al agregar el rol.", error = ex.Message });
            }
        }

        // Obtener todos los roles
        [HttpGet("obtener-roles")]
        public IActionResult ObtenerTodosLosRoles()
        {
            try
            {
                var roles = _service.GetAllRoles();
                return Ok(roles);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = "Error al obtener los roles.", error = ex.Message });
            }
        }

        // Obtener un rol por ID
        [HttpGet("ObtenerRol/{rolId}")]
        public IActionResult ObtenerRolPorId(int rolId)
        {
            try
            {
                var rol = _service.GetRolById(rolId);
                if (rol == null)
                    return NotFound(new { mensaje = "Rol no encontrado." });

                return Ok(rol);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = "Error al obtener el rol.", error = ex.Message });
            }
        }

        // Actualizar un rol existente
        [HttpPut("ActualizarRol/{rolId}")]
        public IActionResult ActualizarRol(int rolId, [FromBody] ModificarRolVM rol)
        {
            try
            {
                _service.UpdateRol(rolId, rol);
                return Ok(new { mensaje = "Rol actualizado exitosamente." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = "Error al actualizar el rol.", error = ex.Message });
            }
        }

        // Eliminar un rol
        [HttpDelete("EliminarRol/{rolId}")]
        public IActionResult EliminarRol(int rolId)
        {
            try
            {
                _service.DeleteRol(rolId);
                return Ok(new { mensaje = "Rol eliminado exitosamente." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = "Error al eliminar el rol.", error = ex.Message });
            }
        }
    }
}
