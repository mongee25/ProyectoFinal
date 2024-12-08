using System;

namespace ProyectoFinal.Data.Models
{
    public class Det_Membresia
    {
        public int UsuarioID { get; set; }
        public Usuario Usuario { get; set; } // Propiedad de navegación
        public int MembresiaID { get; set; }
        public Membresia Membresia { get; set; } // Propiedad de navegación
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public bool Estado { get; set; } // true para activa, false para inactiva
    }
}
