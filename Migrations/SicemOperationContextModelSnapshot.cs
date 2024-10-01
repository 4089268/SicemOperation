﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SicemOperation.Data;

#nullable disable

namespace SicemOperation.Migrations
{
    [DbContext(typeof(SicemOperationContext))]
    partial class SicemOperationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SicemOperation.Entities.Incidencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Eliminado")
                        .HasColumnType("datetime2")
                        .HasColumnName("eliminado");

                    b.Property<int>("FallTratamientoDesinfeccion")
                        .HasColumnType("int")
                        .HasColumnName("fallTratamientoDesinfeccion");

                    b.Property<int>("FallTratamientoRecirculacion")
                        .HasColumnType("int")
                        .HasColumnName("fallTratamientoRecirculacion");

                    b.Property<int>("FallTratamientoSedimentacion")
                        .HasColumnType("int")
                        .HasColumnName("fallTratamientoSedimentacion");

                    b.Property<int>("FallaAguaPotableBombeo")
                        .HasColumnType("int")
                        .HasColumnName("fallaAguaPotableBombeo");

                    b.Property<int>("FallaAguaPotableCentroControl")
                        .HasColumnType("int")
                        .HasColumnName("fallaAguaPotableCentroControl");

                    b.Property<int>("FallaAguaPotableElectrica")
                        .HasColumnType("int")
                        .HasColumnName("fallaAguaPotableElectrica");

                    b.Property<int>("FallaAguaResidualBombeo")
                        .HasColumnType("int")
                        .HasColumnName("fallaAguaResidualBombeo");

                    b.Property<int>("FallaAguaResidualCentroControl")
                        .HasColumnType("int")
                        .HasColumnName("fallaAguaResidualCentroControl");

                    b.Property<int>("FallaAguaResidualPotableElectrica")
                        .HasColumnType("int")
                        .HasColumnName("fallaAguaResidualPotableElectrica");

                    b.Property<int>("FallaTratamientoAereacion")
                        .HasColumnType("int")
                        .HasColumnName("fallaTratamientoAereacion");

                    b.Property<int>("FallaTratamientoEquipos")
                        .HasColumnType("int")
                        .HasColumnName("fallaTratamientoEquipos");

                    b.Property<DateTime>("Fecha")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("fecha")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("FugaLineaConduccion")
                        .HasColumnType("int")
                        .HasColumnName("fugaLineaConduccion");

                    b.Property<int>("FugaLineaDistribucion")
                        .HasColumnType("int")
                        .HasColumnName("fugaLineaDistribucion");

                    b.Property<int>("FugaTomaDomiciliaria")
                        .HasColumnType("int")
                        .HasColumnName("fugaTomaDomiciliaria");

                    b.Property<int>("OficinaId")
                        .HasColumnType("int")
                        .HasColumnName("oficinaId");

                    b.Property<int>("RecoleccionResidualAtendido")
                        .HasColumnType("int")
                        .HasColumnName("recoleccionResidualAtendido");

                    b.Property<int>("RecoleccionResidualColector")
                        .HasColumnType("int")
                        .HasColumnName("recoleccionResidualColector");

                    b.Property<int>("RecoleccionResidualVisita")
                        .HasColumnType("int")
                        .HasColumnName("recoleccionResidualVisita");

                    b.Property<DateTime>("UltimaActualizacion")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("ultimaActualizacion")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("Id");

                    b.HasIndex("OficinaId");

                    b.ToTable("Incidencia", "Operation");
                });

            modelBuilder.Entity("SicemOperation.Entities.Oficina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Alias")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("alias");

                    b.Property<bool?>("Inactivo")
                        .HasColumnType("bit")
                        .HasColumnName("inactivo");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nombre");

                    b.Property<DateTime>("UltimaActualizacion")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("ultimaActualizacion")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("Id");

                    b.ToTable("Oficinas", "System");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nombre = "Oficina de prueba",
                            UltimaActualizacion = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("SicemOperation.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("correo");

                    b.Property<bool?>("Inactivo")
                        .HasColumnType("bit")
                        .HasColumnName("inactivo");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nombre");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.HasKey("Id");

                    b.ToTable("Usuarios", "System");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Correo = "admin@email.com",
                            Nombre = "administrador",
                            Password = "$2a$11$BYxsQUF3zrUHF7z858ABwOMT.KxMceZAqC07t67Xy.IpxPayP7adu"
                        });
                });

            modelBuilder.Entity("SicemOperation.Entities.Incidencia", b =>
                {
                    b.HasOne("SicemOperation.Entities.Oficina", "Oficina")
                        .WithMany()
                        .HasForeignKey("OficinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Oficina");
                });
#pragma warning restore 612, 618
        }
    }
}
