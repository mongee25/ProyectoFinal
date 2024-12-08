using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Data.Services;
using ProyectoFinal.Data.ViewModels;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly UsuariosService _usuariosService;

    public UsuariosController(UsuariosService usuariosService)
    {
        _usuariosService = usuariosService;
    }

    // Agregar un nuevo usuario
    [HttpPost("agregar-usuario")]
    public IActionResult AgregarUsuario([FromBody] UsuarioVM usuarioVM)
    {
        if (usuarioVM == null)
        {
            return BadRequest("Los datos del usuario son necesarios.");
        }

        _usuariosService.AgregarUsuario(usuarioVM);
        return Ok("Usuario agregado correctamente.");
    }

    // Modificar un usuario existente
    [HttpPut("modificar-usuario/{usuarioID}")]
    public IActionResult ModificarUsuario(int usuarioID, [FromBody] ModificarUsuarioVM modificarVM)
    {
        if (modificarVM == null)
        {
            return BadRequest("Los datos del usuario son necesarios.");
        }

        _usuariosService.ModificarUsuario(modificarVM);
        return Ok("Usuario modificado correctamente.");
    }

    // Eliminar un usuario
    [HttpDelete("eliminar-usuario/{usuarioID}")]
    public IActionResult EliminarUsuario(int usuarioID)
    {
        var eliminarVM = new EliminarUsuarioVM { UsuarioID = usuarioID };
        _usuariosService.EliminarUsuario(eliminarVM);
        return Ok("Usuario eliminado correctamente.");
    }

    // Buscar usuarios (Vista general)
    [HttpGet("get-all-users")]
    public IActionResult GetlAllUsers()
    {
        var allusuarios = _usuariosService.GetlAllUsers();
        return Ok(allusuarios);
    }

    // Obtener un usuario específico
    [HttpGet("obtener-usuario/{usuarioID}")]
    public IActionResult ObtenerUsuarioEspecifico(int usuarioID)
    {
        var usuario = _usuariosService.ObtenerUsuarioEspecifico(usuarioID);
        if (usuario == null)
        {
            return NotFound("Usuario no encontrado.");
        }

        return Ok(usuario);
    }
}
