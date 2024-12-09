using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Data.Models;
using ProyectoFinal.Data.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoFinal.Data.Services
{
    public class UsuariosService
    {
        private AppDbContext _context;

        public UsuariosService(AppDbContext context)
        {
            _context = context;
        }

        // Agregar un nuevo usuario
        public void AgregarUsuario(UsuarioVM usuarioVM)
        {
            var usuario = new Usuario
            {
                Nombre = usuarioVM.Nombre,
                APaterno = usuarioVM.APaterno,
                AMaterno = usuarioVM.AMaterno,
                FechaNacimiento = usuarioVM.FechaNacimiento,
                Email = usuarioVM.Email,
                Contraseña = usuarioVM.Contraseña,
                Celular = usuarioVM.Celular,
                Altura = usuarioVM.Altura,
                RolID = usuarioVM.RolID
            };

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        // Modificar un usuario existente
        public void ModificarUsuario(ModificarUsuarioVM modificarVM)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.UsuarioID == modificarVM.UsuarioID);
            if (usuario != null)
            {
                usuario.Nombre = modificarVM.Nombre ?? usuario.Nombre;
                usuario.APaterno = modificarVM.APaterno ?? usuario.APaterno;
                usuario.AMaterno = modificarVM.AMaterno ?? usuario.AMaterno;
                usuario.FechaNacimiento = modificarVM.FechaNacimiento ?? usuario.FechaNacimiento;
                usuario.Email = modificarVM.Email ?? usuario.Email;
                usuario.Contraseña = modificarVM.Contraseña ?? usuario.Contraseña;
                usuario.Celular = modificarVM.Celular ?? usuario.Celular;
                usuario.Altura = modificarVM.Altura ?? usuario.Altura;

                _context.SaveChanges();
            }
        }

        // Eliminar un usuario
        public void EliminarUsuario(EliminarUsuarioVM eliminarVM)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.UsuarioID == eliminarVM.UsuarioID);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                _context.SaveChanges();
            }
        }

        //Método que nos permite obtener una lista de todos los libros en la BD
        public List<ObtenerUsuariosVM> GetlAllUsers()
        {
            var usuarios = _context.Usuarios.Select(c => new ObtenerUsuariosVM()
            {
                UsuarioID = c.UsuarioID,
                Nombre = c.Nombre,
                APaterno = c.APaterno,
                AMaterno = c.AMaterno,
                FechaNacimiento = c.FechaNacimiento,
                Email = c.Email,
                Celular = c.Celular,
                Altura = c.Altura,
                RolID = c.RolID,
                MembresiaID = c.Det_Membresias.Any() ? c.Det_Membresias.FirstOrDefault().MembresiaID : 0
            }).ToList();

            return usuarios;
        }

        // Obtener un usuario específico
        public UsuarioEspecificoVM ObtenerUsuarioEspecifico(int usuarioID)
        {
            var usuario = _context.Usuarios
                          .Include(u => u.Det_Membresias)  // Eager Loading para incluir la relación Det_Membresias
                          .FirstOrDefault(u => u.UsuarioID == usuarioID);

            if (usuario != null)
            {
                return new UsuarioEspecificoVM
                {
                    UsuarioID = usuario.UsuarioID,
                    Nombre = usuario.Nombre ?? "No disponible",
                    APaterno = usuario.APaterno ?? "No disponible",
                    AMaterno = usuario.AMaterno ?? "No disponible",
                    FechaNacimiento = usuario.FechaNacimiento,
                    Email = usuario.Email ?? "No disponible",
                    Celular = usuario.Celular ?? "No disponible",
                    Altura = usuario.Altura,
                    RolID = usuario.RolID,
                    // Si Det_Membresias no está vacío, obtiene el primer MembresiaID asociado
                    MembresiaID = usuario.Det_Membresias.Any() ? usuario.Det_Membresias.FirstOrDefault().MembresiaID : 0
                };
            }

            return null;
        }
    }

}
