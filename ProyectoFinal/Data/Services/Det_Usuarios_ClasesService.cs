using ProyectoFinal.Data.Models;
using ProyectoFinal.Data.ViewModels;
using System.Collections.Generic;
using System;
using System.Linq;

namespace ProyectoFinal.Data.Services
{
    public class Det_Usuarios_ClasesService
    {
        private AppDbContext _context;

        public Det_Usuarios_ClasesService(AppDbContext context)
        {
            _context = context;
        }

        // Agregar un nuevo detalle de usuario-clase
        public void AgregarDetalleUsuarioClase(Det_Usuario_ClaseVM detalleVM)
        {
            var detalle = new Det_Usuario_Clase
            {
                UsuarioID = detalleVM.UsuarioID,
                ClaseID = detalleVM.ClaseID,
                FechaInscripcion = detalleVM.FechaInscripcion
            };

            _context.Det_Usuarios_Clases.Add(detalle);
            _context.SaveChanges();
        }

        // Modificar un detalle existente
        public void ModificarDetalleUsuarioClase(int usuarioID, int claseID, DateTime? nuevaFechaInscripcion)
        {
            var detalle = _context.Det_Usuarios_Clases.FirstOrDefault(d => d.UsuarioID == usuarioID && d.ClaseID == claseID);

            if (detalle != null)
            {
                if (nuevaFechaInscripcion.HasValue)
                    detalle.FechaInscripcion = nuevaFechaInscripcion.Value;

                _context.SaveChanges();
            }
        }

        // Eliminar un detalle usuario-clase
        public void EliminarDetalleUsuarioClase(int usuarioID, int claseID)
        {
            var detalle = _context.Det_Usuarios_Clases.FirstOrDefault(d => d.UsuarioID == usuarioID && d.ClaseID == claseID);

            if (detalle != null)
            {
                _context.Det_Usuarios_Clases.Remove(detalle);
                _context.SaveChanges();
            }
        }

        // Obtener todos los detalles usuario-clase
        public List<Det_Usuario_ClaseVM> ObtenerTodosLosDetalles()
        {
            return _context.Det_Usuarios_Clases.Select(d => new Det_Usuario_ClaseVM
            {
                UsuarioID = d.UsuarioID,
                ClaseID = d.ClaseID,
                FechaInscripcion = d.FechaInscripcion
            }).ToList();
        }

        // Obtener un detalle especi­fico por UsuarioID y ClaseID
        public Det_Usuario_ClaseVM ObtenerDetalleEspecifico(int usuarioID, int claseID)
        {
            var detalle = _context.Det_Usuarios_Clases.FirstOrDefault(d => d.UsuarioID == usuarioID && d.ClaseID == claseID);

            if (detalle != null)
            {
                return new Det_Usuario_ClaseVM
                {
                    UsuarioID = detalle.UsuarioID,
                    ClaseID = detalle.ClaseID,
                    FechaInscripcion = detalle.FechaInscripcion
                };
            }

            return null;
        }
    }
}
