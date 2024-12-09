using System;

namespace ProyectoFinal.Data.ViewModels
{
    public class Det_Usuario_ClaseVM
    {
        public int UsuarioID { get; set; } // ID del Usuario
        public int ClaseID { get; set; }   // ID de la Clase
        public DateTime FechaInscripcion { get; set; } // Fecha de inscripción
    }
    public class ModificarDet_Usuario_ClaseVM
    {
        public DateTime FechaInscripcion { get; set; } // Fecha de inscripción
    }
}
