using System;

namespace ProyectoFinal.Data.ViewModels
{
    public class ClaseVM
    {
        public int ClaseID { get; set; }
        public string NombreClase { get; set; }    // Nombre de la clase
        public TimeSpan HoraInicio { get; set; }   // Hora de inicio de la clase
        public TimeSpan HoraFin { get; set; }      // Hora de finalización de la clase
        public bool Estado { get; set; }           // Indica si la clase está activa o no
    }

    public class BuscarClaseVM
    {
        public string NombreClase { get; set; }    // Nombre de la clase a buscar (opcional)
        public TimeSpan? HoraInicio { get; set; }  // Filtro por hora de inicio (opcional)
        public TimeSpan? HoraFin { get; set; }     // Filtro por hora de fin (opcional)
        public bool? Estado { get; set; }          // Filtro por estado (opcional)
    }

    public class AgregarClaseVM
    {
        public string NombreClase { get; set; }    // Nombre de la clase
        public TimeSpan HoraInicio { get; set; }   // Hora de inicio de la clase
        public TimeSpan HoraFin { get; set; }      // Hora de finalización de la clase
        public bool Estado { get; set; }           // Indica si la clase está activa o no
    }
    public class ClaseUsuarioVM
    {
        public int UsuarioID { get; set; }         // Identificador del usuario
        public int ClaseID { get; set; }           // Identificador de la clase asociada
        public string NombreClase { get; set; }    // Nombre de la clase
        public bool Estado { get; set; }           // Estado de la asociación (activo/inactivo)
    }

    public class ModificarClaseVM
    {
        public string NombreClase { get; set; }    // Nuevo nombre de la clase (opcional)
        public TimeSpan? HoraInicio { get; set; }  // Nueva hora de inicio (opcional)
        public TimeSpan? HoraFin { get; set; }     // Nueva hora de fin (opcional)
        public bool? Estado { get; set; }          // Nuevo estado de la clase (opcional)
    }

    public class EliminarClaseVM
    {
        public int ClaseID { get; set; }  // Identificador único de la clase que se va a eliminar
    }
}
