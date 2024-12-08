using System;
using System.Collections.Generic;

namespace ProyectoFinal.Data.Models
{
    public class Clase
    {
        public int ClaseID { get; set; }
        public string NombreClase { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public bool Estado { get; set; }

        // Relación con Det_Usuarios_Clases
        public ICollection<Det_Usuario_Clase> Det_Usuarios_Clases { get; set; }
    }
}
