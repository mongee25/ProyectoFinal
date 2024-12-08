using ProyectoFinal.Data.Models;
using ProyectoFinal.Data.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoFinal.Data.Services
{
    public class ClasesService
    {
        private AppDbContext _context;

        public ClasesService(AppDbContext context)
        {
            _context = context;
        }

        // Método para agregar una nueva clase
        public void AgregarClase(ClaseVM clase)
        {
            var _clase = new Clase()
            {
                NombreClase = clase.NombreClase,
                HoraInicio = clase.HoraInicio,
                HoraFin = clase.HoraFin,
                Estado = clase.Estado
            };
            _context.Clases.Add(_clase);
            _context.SaveChanges();
        }

        // Método para obtener todas las clases
        public List<ClaseVM> ObtenerTodasClases()
        {
            var _clases = _context.Clases.Select(c => new ClaseVM()
            {
                NombreClase = c.NombreClase,
                HoraInicio = c.HoraInicio,
                HoraFin = c.HoraFin,
                Estado = c.Estado
            }).ToList();

            return _clases;
        }

        // Método para obtener una clase por ID
        public ClaseVM ObternerClaseById(int claseId)
        {
            var _clase = _context.Clases.Where(c => c.ClaseID == claseId).Select(c => new ClaseVM()
            {
                NombreClase = c.NombreClase,
                HoraInicio = c.HoraInicio,
                HoraFin = c.HoraFin,
                Estado = c.Estado
            }).FirstOrDefault();

            return _clase;
        }

        // Método para actualizar una clase existente
        public void ModificarClase(int claseId, ModificarClaseVM clase)
        {
            var _clase = _context.Clases.FirstOrDefault(c => c.ClaseID == claseId);
            if (_clase != null)
            {
                _clase.NombreClase = clase.NombreClase ?? _clase.NombreClase;
                _clase.HoraInicio = clase.HoraInicio ?? _clase.HoraInicio;
                _clase.HoraFin = clase.HoraFin ?? _clase.HoraFin;
                _clase.Estado = clase.Estado ?? _clase.Estado;

                _context.SaveChanges();
            }
        }

        // Método para eliminar una clase
        public void EliminarClase(int claseId)
        {
            var _clase = _context.Clases.FirstOrDefault(c => c.ClaseID == claseId);
            if (_clase != null)
            {
                _context.Clases.Remove(_clase);
                _context.SaveChanges();
            }
        }
    }
}
