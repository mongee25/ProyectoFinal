using System;
using Microsoft.VisualBasic;
using System.Collections.Generic;

namespace ProyectoFinal.Data.Models
{
    public class Usuarios
    {
        public int UsuarioID { get; set; }
        public string Nombre { get; set; }
        public string AMaterno { get; set; }
        public string APaterno { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public string Celular { get; set; }
        public decimal Altura { get; set; }
    }
}
