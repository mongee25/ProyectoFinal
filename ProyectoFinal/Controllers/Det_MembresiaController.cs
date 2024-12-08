using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ProyectoFinal.Data.Models;
using ProyectoFinal.Data.Services;

namespace ProyectoFinal.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using static ProyectoFinal.Data.ViewModels.Det_MembresiaVM;
    using System;

    [Route("api/[controller]")]
    [ApiController]
    public class Det_MembresiasController : ControllerBase
    {
        private Det_MembresiasController _detalleMembresiaService;

        public Det_MembresiasController(Det_Membresias_Service detalleMembresiaService)
        {
            //_detalleMembresiaService = detalleMembresiaService;
        }

        // Endpoint para agregar un detalle de membresía
        [HttpPost("Agregar")]
        public IActionResult AgregarDetalleMembresia([FromBody] AgregarDetalleMembresiaVM detalleMembresiaVM)
        {
            try
            {
                _detalleMembresiaService.AgregarDetalleMembresia(detalleMembresiaVM);
                return Ok(new { mensaje = "Detalle de membresía agregado correctamente." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // Endpoint para modificar un detalle de membresía
        [HttpPut("Modificar")]
        public IActionResult ModificarDetalleMembresia([FromBody] ModificarDetalleMembresiaVM modificarDetalleVM)
        {
            try
            {
                _detalleMembresiaService.ModificarDetalleMembresia(modificarDetalleVM);
                return Ok(new { mensaje = "Detalle de membresía modificado correctamente." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // Endpoint para buscar detalles de membresías
        //[HttpGet("Buscar")]
        //public IActionResult BuscarDetalles([FromQuery] BuscarDetalleMembresiaVM buscarDetalleVM)
        //{
            
        //}

        // Endpoint para obtener detalles específicos de una membresía de un usuario
        [HttpGet("DetalleEspecifico")]
        public IActionResult ObtenerDetalleEspecifico([FromQuery] int usuarioID, [FromQuery] int membresiaID)
        {
            try
            {
                var detalle = _detalleMembresiaService.ObtenerDetalleEspecifico(usuarioID, membresiaID);
                return Ok(detalle);
            }
            catch (Exception ex)
            {
                return NotFound(new { error = ex.Message });
            }
        }
    }
}
