using System;
using System.Collections.Generic;

namespace ProyectoFinal.Data.Models
{
    public class Membresia
    {
        public int MembresiaID { get; set; }
        public string NombreMembresia { get; set; }
        public string DescripcionMembresia { get; set; }
        public decimal Precio { get; set; }
        public int TotalDiasValidacion { get; set; }

        public ICollection<Det_Membresia> Det_Membresias { get; set; }
    }
}
