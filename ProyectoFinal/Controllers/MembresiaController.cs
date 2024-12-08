using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Data.Services;
using ProyectoFinal.Data.ViewModels;
using System;

namespace ProyectoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembresiaController : ControllerBase
    {
        private MembresiasService _membresiaService;

        public MembresiaController(MembresiasService service)
        {
            _membresiaService = service;
        }

        // Agregar una nueva membresía
        [HttpPost("AgregarMembresia")]
        public IActionResult AgregarMembresia([FromBody] MembresiaVM membresiaVM)
        {
            try
            {
                _membresiaService.AgregarMembresia(membresiaVM);
                return Ok(new { mensaje = "Membresía agregada exitosamente." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = "Error al agregar la membresía.", error = ex.Message });
            }
        }

        // Modificar una membresía existente
        [HttpPut("ModificarMembresia")]
        public IActionResult ModificarMembresia([FromBody] ModificarMembresiaVM modificarMembresiaVM)
        {
            try
            {
                _membresiaService.ModificarMembresia(modificarMembresiaVM);
                return Ok(new { mensaje = "Membresía modificada exitosamente." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = "Error al modificar la membresía.", error = ex.Message });
            }
        }

        // Eliminar una membresía
        [HttpDelete("EliminarMembresia/{membresiaID}")]
        public IActionResult EliminarMembresia(int membresiaID)
        {
            try
            {
                _membresiaService.EliminarMembresia(membresiaID);
                return Ok(new { mensaje = "Membresía eliminada exitosamente." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = "Error al eliminar la membresía.", error = ex.Message });
            }
        }

        // Buscar membresías con filtros opcionales
        [HttpPost("BuscarMembresias")]
        public IActionResult BuscarMembresias([FromBody] BuscarMembresiaVM buscarMembresiaVM)
        {
            try
            {
                var membresias = _membresiaService.BuscarMembresias(buscarMembresiaVM);
                return Ok(membresias);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = "Error al buscar las membresías.", error = ex.Message });
            }
        }

        // Obtener una membresía específica por ID
        [HttpGet("GetMembresia/{membresiaID}")]
        public IActionResult GetMembresiaById(int membresiaID)
        {
            try
            {
                var membresia = _membresiaService.GetMembresiaById(membresiaID);
                return Ok(membresia);
            }
            catch (Exception ex)
            {
                return NotFound(new { mensaje = "Error al obtener la membresía.", error = ex.Message });
            }
        }
    }
}
