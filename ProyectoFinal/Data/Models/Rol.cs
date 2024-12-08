using System.Collections.Generic;

namespace ProyectoFinal.Data.Models
{
    public class Rol
    {
        public int RolID { get; set; }
        public string Nombre { get; set; }
        public ICollection<Usuario> Usuarios { get; set; } // Colección de Usuarios
    }
}
