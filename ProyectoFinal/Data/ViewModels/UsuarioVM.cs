using System;

namespace ProyectoFinal.Data.ViewModels
{
    public class UsuarioVM
    {
        public int UsuarioID { get; set; }
        public string Nombre { get; set; }
        public string APaterno { get; set; }
        public string AMaterno { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public string Celular { get; set; }
        public decimal Altura { get; set; }
        public int RolID { get; set; }
    }
    public class ModificarUsuarioVM
    {
        public int UsuarioID { get; set; }
        public string Nombre { get; set; }
        public string APaterno { get; set; }
        public string AMaterno { get; set; }
        public DateTime? FechaNacimiento { get; set; } // Opcional
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public string Celular { get; set; }
        public decimal? Altura { get; set; } // Opcional
    }

    public class EliminarUsuarioVM
    {
        public int UsuarioID { get; set; }
    }

    public class BuscarUsuarioVM
    {
        public string Nombre { get; set; } // Opcional
        public string Email { get; set; } // Opcional
    }

    public class ObtenerUsuariosVM
    {
        public int UsuarioID { get; set; }
        public string Nombre { get; set; }
        public string APaterno { get; set; }
        public string AMaterno { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public decimal? Altura { get; set; }
    }

    public class UsuarioEspecificoVM
    {
        public int UsuarioID { get; set; }
        public string Nombre { get; set; }
        public string AMaterno { get; set; }
        public string APaterno { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public decimal Altura { get; set; }
    }
}
