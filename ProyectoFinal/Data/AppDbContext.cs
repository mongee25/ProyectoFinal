using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Data.Models;

namespace ProyectoFinal.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Det_Usuario_Clase>()
                .HasOne(b => b.Usuario)
                .WithMany(ba => ba.Det_Usuarios_Clases)
                .HasForeignKey(bi => bi.UsuarioID);

            modelBuilder.Entity<Det_Usuario_Clase>()
                .HasOne(b => b.Clase)
                .WithMany(ba => ba.Det_Usuarios_Clases)
                .HasForeignKey(bi => bi.ClaseID);

            modelBuilder.Entity<Usuario>()
                .HasOne(b => b.Rol)
                .WithMany(ba => ba.Usuarios)
                .HasForeignKey(bi => bi.RolID);

            modelBuilder.Entity<Det_Usuario_Clase>()
            .HasKey(d => new { d.UsuarioID, d.ClaseID }); // Definir clave primaria compuesta


            //Clave compuestas Det_Membresia
            modelBuilder.Entity<Det_Membresia>()
                .HasKey(d => new { d.UsuarioID, d.MembresiaID }); // Clave compuesta
        }
        public DbSet<Clase> Clases { get; set; }
        public DbSet<Det_Membresia> Det_Membresias { get; set; }
        public DbSet<Det_Usuario_Clase> Det_Usuarios_Clases { get; set; }
        public DbSet<Membresia> Membresias { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}
