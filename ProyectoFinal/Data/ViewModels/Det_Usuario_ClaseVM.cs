using System;

namespace ProyectoFinal.Data.ViewModels
{
    public class Det_Usuario_ClaseVM
    {
        public int UsuarioID { get; set; } // ID del Usuario
        public int ClaseID { get; set; }   // ID de la Clase
        public DateTime FechaInscripcion { get; set; } // Fecha de inscripción
    }
}
