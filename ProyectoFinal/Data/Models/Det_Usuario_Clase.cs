using System;

namespace ProyectoFinal.Data.Models
{
    public class Det_Usuario_Clase
    {
        public int UsuarioID { get; set; } // Clave foránea
        public Usuario Usuario { get; set; } // Propiedad de navegación

        public int ClaseID { get; set; } // Clave foránea
        public Clase Clase { get; set; } // Propiedad de navegación

        public DateTime FechaInscripcion { get; set; } // Fecha de inscripción
    }
}
