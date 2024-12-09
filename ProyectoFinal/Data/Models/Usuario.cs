using System;
using Microsoft.VisualBasic;
using System.Collections.Generic;

namespace ProyectoFinal.Data.Models
{
    public class Usuario
    {
        public int UsuarioID { get; set; }
        public string Nombre { get; set; }
        public string APaterno { get; set; }
        public string AMaterno { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public string Celular { get; set; }
        public decimal Altura { get; set; }
        public int RolID { get; set; }

        //MAPEO
        public Rol Rol { get; set; } // Navegación

        // Relación con Det_Usuarios_Clases
        public ICollection<Det_Usuario_Clase> Det_Usuarios_Clases { get; set; }
        public ICollection<Det_Membresia> Det_Membresias { get; set; }
    }
}
