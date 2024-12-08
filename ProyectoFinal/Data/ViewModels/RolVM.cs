namespace ProyectoFinal.Data.ViewModels
{
    public class RolVM
    {
        public int RolID { get; set; }
        public string Nombre { get; set; }
    }
    public class ModificarRolVM
    {
        public int? RolID { get; set; } // Si es nulo, es para crear un nuevo rol
        public string Nombre { get; set; } // Nombre del rol
    }


    public class BuscarRolVM
    {
        public int? RolID { get; set; } // RolID es opcional para la búsqueda por ID
        public string Nombre { get; set; } // Nombre del rol, puede ser usado para buscar roles por nombre
    }

    public class EliminarRolVM
    {
        public int RolID { get; set; } // RolID del rol a eliminar
    }
}
