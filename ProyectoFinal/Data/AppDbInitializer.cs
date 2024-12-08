using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ProyectoFinal.Data.Models;
using System;
using System.Linq;

namespace ProyectoFinal.Data
{
    public class AppDbInitializer
    {
        //Metodo que agrega datos a nuestra BD
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Roles.Any())
                {
                    context.Roles.AddRange(new Rol()
                    {
                        Nombre = "Administrador"
                    },
                    new Rol()
                    {
                        Nombre = "Usuario"
                    });
                }

                if (!context.Usuarios.Any())
                {
                    context.Usuarios.AddRange(new Usuario()
                    {
                        Nombre = "Alexa Marian",
                        APaterno = "Gastelum",
                        AMaterno = "Diaz",
                        FechaNacimiento = DateTime.Parse("2005-12-05"),
                        Email = "alexagastelum577@gmail.com",
                        Contraseña = "aletsita",
                        Celular = "6442198090",
                        Altura = 163,
                        RolID = 1
                    },
                    new Usuario()
                    {
                        Nombre = "Emiliano",
                        APaterno = "Monge",
                        AMaterno = "Osuna",
                        FechaNacimiento = DateTime.Parse("2005-12-05"),
                        Email = "emilianomongeosuna@gmail.com",
                        Contraseña = "emimonge",
                        Celular = "6441765393",
                        Altura = 168,
                        RolID = 2
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
