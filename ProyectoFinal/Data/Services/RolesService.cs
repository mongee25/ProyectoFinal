using ProyectoFinal.Data.Models;
using ProyectoFinal.Data.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoFinal.Data.Services
{
    public class RolesService
    {
        private AppDbContext _context;

        public RolesService(AppDbContext context)
        {
            _context = context;
        }

        // Método para agregar un nuevo rol
        public void AddRol(RolVM rol)
        {
            var _rol = new Rol()
            {
                Nombre = rol.Nombre
            };
            _context.Roles.Add(_rol);
            _context.SaveChanges();
        }

        // Método para obtener todos los roles
        public List<RolVM> GetAllRoles()
        {
            var _roles = _context.Roles.Select(r => new RolVM()
            {
                Nombre = r.Nombre
            }).ToList();

            return _roles;
        }

        // Método para obtener un rol por ID
        public RolVM GetRolById(int rolId)
        {
            var _rol = _context.Roles.Where(r => r.RolID == rolId).Select(r => new RolVM()
            {
                Nombre = r.Nombre
            }).FirstOrDefault();

            return _rol;
        }

        // Método para actualizar un rol existente
        public void UpdateRol(int rolId, ModificarRolVM rol)
        {
            var _rol = _context.Roles.FirstOrDefault(r => r.RolID == rolId);
            if (_rol != null)
            {
                _rol.Nombre = rol.Nombre ?? _rol.Nombre;
                _context.SaveChanges();
            }
        }

        // Método para eliminar un rol
        public void DeleteRol(int rolId)
        {
            var _rol = _context.Roles.FirstOrDefault(r => r.RolID == rolId);
            if (_rol != null)
            {
                _context.Roles.Remove(_rol);
                _context.SaveChanges();
            }
        }
    }
}
