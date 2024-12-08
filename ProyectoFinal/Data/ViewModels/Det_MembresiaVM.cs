using System;

namespace ProyectoFinal.Data.ViewModels
{
    public class Det_MembresiaVM
    {
        public class AgregarDetalleMembresiaVM
        {
            public int UsuarioID { get; set; }       // Identificador del usuario
            public int MembresiaID { get; set; }     // Identificador de la membresía
            public DateTime FechaCreacion { get; set; } // Fecha de creación de la membresía
            public DateTime FechaExpiracion { get; set; } // Fecha de expiración de la membresía
            public bool Estado { get; set; }         // Estado de la membresía (activa o inactiva)
        }

        // ViewModel para modificar un detalle de membresía
        public class ModificarDetalleMembresiaVM
        {
            public int UsuarioID { get; set; }       // Identificador del usuario
            public int MembresiaID { get; set; }     // Identificador de la membresía
            public DateTime? FechaCreacion { get; set; } // Nueva fecha de creación (opcional)
            public DateTime? FechaExpiracion { get; set; } // Nueva fecha de expiración (opcional)
            public bool? Estado { get; set; }        // Nuevo estado de la membresía (opcional)
        }

        // ViewModel para buscar detalles de membresía
        public class BuscarDetalleMembresiaVM
        {
            public int? UsuarioID { get; set; }      // Filtro por ID de usuario (opcional)
            public int? MembresiaID { get; set; }    // Filtro por ID de membresía (opcional)
            public bool? Estado { get; set; }        // Filtro por estado (opcional)
        }

        // ViewModel para vista general de detalles de membresía
        public class DetalleMembresiaGeneralVM
        {
            public int UsuarioID { get; set; }       // Identificador del usuario
            public string NombreUsuario { get; set; } // Nombre del usuario
            public int MembresiaID { get; set; }     // Identificador de la membresía
            public string NombreMembresia { get; set; } // Nombre de la membresía
            public DateTime FechaCreacion { get; set; } // Fecha de creación de la membresía
            public DateTime FechaExpiracion { get; set; } // Fecha de expiración de la membresía
            public bool Estado { get; set; }         // Estado de la membresía (activa o inactiva)
        }

        // ViewModel para ver detalles específicos de una membresía de un usuario
        public class DetalleMembresiaEspecificoVM
        {
            public int UsuarioID { get; set; }       // Identificador del usuario
            public string NombreUsuario { get; set; } // Nombre del usuario
            public int MembresiaID { get; set; }     // Identificador de la membresía
            public string NombreMembresia { get; set; } // Nombre de la membresía
            public DateTime FechaCreacion { get; set; } // Fecha de creación de la membresía
            public DateTime FechaExpiracion { get; set; } // Fecha de expiración de la membresía
            public bool Estado { get; set; }         // Estado de la membresía (activa o inactiva)
        }
    }
}
