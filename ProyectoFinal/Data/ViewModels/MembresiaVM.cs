﻿namespace ProyectoFinal.Data.ViewModels
{
    public class MembresiaVM
    {
        public int MembresiaID { get; set; }
        public string NombreMembresia { get; set; } // Nombre de la membresía
        public string DescripcionMembresia { get; set; } // Descripción de la membresía
        public decimal Precio { get; set; } // Precio de la membresía
        public int TotalDiasValidacion { get; set; } // Días de validación
    }

    // ViewModel para modificar los datos de una membresía
    public class ModificarMembresiaVM
    {
        public int MembresiaID { get; set; } // Identificador único de la membresía
        public string? NombreMembresia { get; set; } // Nuevo nombre (opcional)
        public string? DescripcionMembresia { get; set; } // Nueva descripción (opcional)
        public decimal? Precio { get; set; } // Nuevo precio (opcional)
        public int? TotalDiasValidacion { get; set; } // Nuevo total de días de validación (opcional)
    }

    // ViewModel para eliminar una membresía
    public class EliminarMembresiaVM
    {
        public int MembresiaID { get; set; } // Identificador único de la membresía
    }


    public class ObtenerMembresiasVM
    {
        public int MembresiaID { get; set; }
        public string NombreMembresia { get; set; }
        public string DescripcionMembresia { get; set; }
        public decimal? Precio { get; set; }
        public int? TotalDiasValidacion { get; set; } 
    }
}
