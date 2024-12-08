﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoFinal.Data;

namespace ProyectoFinal.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241204160659_FinalMigration")]
    partial class FinalMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProyectoFinal.Data.Models.Clase", b =>
                {
                    b.Property<int>("ClaseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<TimeSpan>("HoraFin")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("HoraInicio")
                        .HasColumnType("time");

                    b.Property<string>("NombreClase")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClaseID");

                    b.ToTable("Clases");
                });

            modelBuilder.Entity("ProyectoFinal.Data.Models.Det_Membresia", b =>
                {
                    b.Property<int>("UsuarioID")
                        .HasColumnType("int");

                    b.Property<int>("MembresiaID")
                        .HasColumnType("int");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaExpiracion")
                        .HasColumnType("datetime2");

                    b.HasKey("UsuarioID", "MembresiaID");

                    b.HasIndex("MembresiaID");

                    b.ToTable("Det_Membresias");
                });

            modelBuilder.Entity("ProyectoFinal.Data.Models.Det_Usuario_Clase", b =>
                {
                    b.Property<int>("UsuarioID")
                        .HasColumnType("int");

                    b.Property<int>("ClaseID")
                        .HasColumnType("int");

                    b.Property<string>("AMaterno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("APaterno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaInscripcion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreClase")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UsuarioID", "ClaseID");

                    b.HasIndex("ClaseID");

                    b.ToTable("Det_Usuarios_Clases");
                });

            modelBuilder.Entity("ProyectoFinal.Data.Models.Membresia", b =>
                {
                    b.Property<int>("MembresiaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DescripcionMembresia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreMembresia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TotalDiasValidacion")
                        .HasColumnType("int");

                    b.HasKey("MembresiaID");

                    b.ToTable("Membresias");
                });

            modelBuilder.Entity("ProyectoFinal.Data.Models.Rol", b =>
                {
                    b.Property<int>("RolID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RolID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("ProyectoFinal.Data.Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AMaterno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("APaterno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Altura")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Celular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contraseña")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MembresiaID")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RolID")
                        .HasColumnType("int");

                    b.HasKey("UsuarioID");

                    b.HasIndex("MembresiaID");

                    b.HasIndex("RolID");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ProyectoFinal.Data.Models.Det_Membresia", b =>
                {
                    b.HasOne("ProyectoFinal.Data.Models.Membresia", "Membresia")
                        .WithMany("Det_Membresias")
                        .HasForeignKey("MembresiaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoFinal.Data.Models.Usuario", "Usuario")
                        .WithMany("Det_Membresias")
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Membresia");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ProyectoFinal.Data.Models.Det_Usuario_Clase", b =>
                {
                    b.HasOne("ProyectoFinal.Data.Models.Clase", "Clase")
                        .WithMany("Det_Usuarios_Clases")
                        .HasForeignKey("ClaseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoFinal.Data.Models.Usuario", "Usuario")
                        .WithMany("Det_Usuarios_Clases")
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clase");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ProyectoFinal.Data.Models.Usuario", b =>
                {
                    b.HasOne("ProyectoFinal.Data.Models.Membresia", "Membresia")
                        .WithMany()
                        .HasForeignKey("MembresiaID");

                    b.HasOne("ProyectoFinal.Data.Models.Rol", "Rol")
                        .WithMany("Usuarios")
                        .HasForeignKey("RolID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Membresia");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("ProyectoFinal.Data.Models.Clase", b =>
                {
                    b.Navigation("Det_Usuarios_Clases");
                });

            modelBuilder.Entity("ProyectoFinal.Data.Models.Membresia", b =>
                {
                    b.Navigation("Det_Membresias");
                });

            modelBuilder.Entity("ProyectoFinal.Data.Models.Rol", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("ProyectoFinal.Data.Models.Usuario", b =>
                {
                    b.Navigation("Det_Membresias");

                    b.Navigation("Det_Usuarios_Clases");
                });
#pragma warning restore 612, 618
        }
    }
}
