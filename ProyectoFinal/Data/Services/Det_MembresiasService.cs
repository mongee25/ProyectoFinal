﻿using ProyectoFinal.Data.Models;
using static ProyectoFinal.Data.ViewModels.Det_MembresiaVM;
using System.Collections.Generic;
using System.Linq;
using System;
using ProyectoFinal.Data.ViewModels;

namespace ProyectoFinal.Data.Services
{
    public class Det_Membresias_Service
    {
        private readonly AppDbContext _context;

        public Det_Membresias_Service(AppDbContext context)
        {
            _context = context;
        }

        // Método para agregar un nuevo detalle de membresía
        public void AgregarDetalleMembresia(AgregarDetalleMembresiaVM detalleMembresiaVM)
        {
            var detalle = new Det_Membresia
            {
                UsuarioID = detalleMembresiaVM.UsuarioID,
                MembresiaID = detalleMembresiaVM.MembresiaID,
                FechaCreacion = detalleMembresiaVM.FechaCreacion,
                FechaExpiracion = detalleMembresiaVM.FechaExpiracion,
                Estado = detalleMembresiaVM.Estado
            };

            _context.Det_Membresias.Add(detalle);
            _context.SaveChanges();
        }

        // Método para modificar un detalle de membresía
        public void ActualizarDetalleMembresia(int idM, int idU, ModificarDetalleMembresiaVM modificarDetalleVM)
        {
            var detalle = _context.Det_Membresias.FirstOrDefault(d =>
                d.UsuarioID == modificarDetalleVM.UsuarioID &&
                d.MembresiaID == modificarDetalleVM.MembresiaID);

            if (detalle != null)
            {
                detalle.FechaCreacion = modificarDetalleVM.FechaCreacion ?? detalle.FechaCreacion;
                detalle.FechaExpiracion = modificarDetalleVM.FechaExpiracion ?? detalle.FechaExpiracion;
                detalle.Estado = modificarDetalleVM.Estado ?? detalle.Estado;

                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Detalle de membresía no encontrado.");
            }
        }

        // Método para buscar detalles de membresías con filtros opcionales
        public List<DetalleMembresiaGeneralVM> BuscarDetallesMembresias()
        {
            var detmembresia = _context.Det_Membresias.Select(c => new DetalleMembresiaGeneralVM()
            {
                MembresiaID = c.MembresiaID,
                UsuarioID = c.UsuarioID,
                FechaCreacion = c.FechaCreacion,
                FechaExpiracion = c.FechaExpiracion,
                Estado = c.Estado
            }).ToList();

            return detmembresia;
        }

        // Método para obtener detalles específicos de una membresía de un usuario
        public DetalleMembresiaEspecificoVM ObtenerDetalleEspecifico(int usuarioID, int membresiaID)
        {
            var detalle = _context.Det_Membresias.Where(d =>
                d.UsuarioID == usuarioID &&
                d.MembresiaID == membresiaID)
                .Select(d => new DetalleMembresiaEspecificoVM
                {
                    UsuarioID = d.UsuarioID,
                    NombreUsuario = d.Usuario.Nombre,
                    MembresiaID = d.MembresiaID,
                    NombreMembresia = d.Membresia.NombreMembresia,
                    FechaCreacion = d.FechaCreacion,
                    FechaExpiracion = d.FechaExpiracion,
                    Estado = d.Estado
                }).FirstOrDefault();

            if (detalle == null)
            {
                throw new Exception("Detalle de membresía no encontrado.");
            }

            return detalle;
        }
    }
}
