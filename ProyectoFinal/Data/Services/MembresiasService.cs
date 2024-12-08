using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoFinal.Data.Models;
using ProyectoFinal.Data.ViewModels;

namespace ProyectoFinal.Data.Services
{
    public class MembresiasService
    {
        private AppDbContext _context;

        public MembresiasService(AppDbContext context)
        {
            _context = context;
        }

        // Método para agregar una nueva membresía
        public void AgregarMembresia(MembresiaVM membresiaVM)
        {
            var membresia = new Membresia
            {
                NombreMembresia = membresiaVM.NombreMembresia,
                DescripcionMembresia = membresiaVM.DescripcionMembresia,
                Precio = membresiaVM.Precio,
                TotalDiasValidacion = membresiaVM.TotalDiasValidacion
            };

            _context.Membresias.Add(membresia);
            _context.SaveChanges();
        }

        // Método para modificar una membresía existente
        public void ModificarMembresia(ModificarMembresiaVM modificarMembresiaVM)
        {
            var membresia = _context.Membresias.FirstOrDefault(m => m.MembresiaID == modificarMembresiaVM.MembresiaID);

            if (membresia != null)
            {
                membresia.NombreMembresia = modificarMembresiaVM.NombreMembresia ?? membresia.NombreMembresia;
                membresia.DescripcionMembresia = modificarMembresiaVM.DescripcionMembresia ?? membresia.DescripcionMembresia;
                membresia.Precio = modificarMembresiaVM.Precio ?? membresia.Precio;
                membresia.TotalDiasValidacion = modificarMembresiaVM.TotalDiasValidacion ?? membresia.TotalDiasValidacion;

                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Membresía no encontrada.");
            }
        }

        // Método para eliminar una membresía
        public void EliminarMembresia(int membresiaID)
        {
            var membresia = _context.Membresias.FirstOrDefault(m => m.MembresiaID == membresiaID);

            if (membresia != null)
            {
                _context.Membresias.Remove(membresia);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Membresía no encontrada.");
            }
        }

        // Método para buscar membresías con filtros opcionales
        public List<MembresiaVM> BuscarMembresias(BuscarMembresiaVM buscarMembresiaVM)
        {
            var query = _context.Membresias.AsQueryable();

            if (!string.IsNullOrEmpty(buscarMembresiaVM.NombreMembresia))
            {
                query = query.Where(m => m.NombreMembresia.Contains(buscarMembresiaVM.NombreMembresia));
            }
            if (buscarMembresiaVM.Precio.HasValue)
            {
                query = query.Where(m => m.Precio <= buscarMembresiaVM.Precio.Value);
            }
            if (buscarMembresiaVM.DiasValidacion.HasValue)
            {
                query = query.Where(m => m.TotalDiasValidacion >= buscarMembresiaVM.DiasValidacion.Value);
            }

            return query.Select(m => new MembresiaVM
            {
                NombreMembresia = m.NombreMembresia,
                DescripcionMembresia = m.DescripcionMembresia,
                Precio = m.Precio,
                TotalDiasValidacion = m.TotalDiasValidacion
            }).ToList();
        }

        // Método para obtener una membresía específica por ID
        public MembresiaVM GetMembresiaById(int membresiaID)
        {
            var membresia = _context.Membresias.FirstOrDefault(m => m.MembresiaID == membresiaID);

            if (membresia != null)
            {
                return new MembresiaVM
                {
                    NombreMembresia = membresia.NombreMembresia,
                    DescripcionMembresia = membresia.DescripcionMembresia,
                    Precio = membresia.Precio,
                    TotalDiasValidacion = membresia.TotalDiasValidacion
                };
            }

            throw new Exception("Membresía no encontrada.");
        }
    }
}
