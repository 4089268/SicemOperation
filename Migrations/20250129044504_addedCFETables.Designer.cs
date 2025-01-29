﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SicemOperation.Data;

#nullable disable

namespace SicemOperation.Migrations
{
    [DbContext(typeof(SicemOperationContext))]
    [Migration("20250129044504_addedCFETables")]
    partial class addedCFETables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SicemOperation.Entities.CFEConsumo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Af")
                        .HasColumnType("int")
                        .HasColumnName("af");

                    b.Property<int>("Consumo")
                        .HasColumnType("int")
                        .HasColumnName("consumo");

                    b.Property<decimal>("DapMon")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("dapMon");

                    b.Property<int>("Demanda")
                        .HasColumnType("int")
                        .HasColumnName("demanda");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("date")
                        .HasColumnName("fechaFin");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("date")
                        .HasColumnName("fechaInicio");

                    b.Property<decimal>("FpMon")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("fpMon");

                    b.Property<double>("FpPorc")
                        .HasColumnType("float")
                        .HasColumnName("fpPorc");

                    b.Property<int>("IdMedidor")
                        .HasColumnType("int")
                        .HasColumnName("idMedidor");

                    b.Property<decimal>("Importe")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("importe");

                    b.Property<decimal>("Kvarh")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("kvarh");

                    b.Property<int>("Mf")
                        .HasColumnType("int")
                        .HasColumnName("mf");

                    b.HasKey("Id");

                    b.HasIndex("IdMedidor");

                    b.ToTable("Opr_Consumos", "CFE");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Af = 2024,
                            Consumo = 30899,
                            DapMon = 8004.36m,
                            Demanda = 127,
                            FechaFin = new DateTime(2024, 2, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FechaInicio = new DateTime(2024, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FpMon = 1780.54m,
                            FpPorc = 94.329999999999998,
                            IdMedidor = 1,
                            Importe = 193705.0m,
                            Kvarh = 30510.0m,
                            Mf = 2
                        });
                });

            modelBuilder.Entity("SicemOperation.Entities.CFEMedidor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CargaConectada")
                        .HasColumnType("int")
                        .HasColumnName("cargaConectada");

                    b.Property<int>("DemandaContratada")
                        .HasColumnType("int")
                        .HasColumnName("demandaContratada");

                    b.Property<int>("IdOrganismo")
                        .HasColumnType("int")
                        .HasColumnName("idOrganismo");

                    b.Property<int>("IdProceso")
                        .HasColumnType("int")
                        .HasColumnName("idProceso");

                    b.Property<int>("IdTarifa")
                        .HasColumnType("int")
                        .HasColumnName("idTarifa");

                    b.Property<int>("IdZona")
                        .HasColumnType("int")
                        .HasColumnName("idZona");

                    b.Property<bool>("Inactivo")
                        .HasColumnType("bit")
                        .HasColumnName("inactivo");

                    b.Property<string>("Latitud")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("latitud");

                    b.Property<string>("Longitud")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("longitud");

                    b.Property<string>("NumMedidor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("numMedidor");

                    b.Property<string>("RPU")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("rPU");

                    b.Property<string>("Ubicacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ubicacion");

                    b.HasKey("Id");

                    b.HasIndex("IdOrganismo");

                    b.HasIndex("IdProceso");

                    b.HasIndex("IdTarifa");

                    b.HasIndex("IdZona");

                    b.ToTable("Cat_Medidores", "CFE");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CargaConectada = 200,
                            DemandaContratada = 200,
                            IdOrganismo = 2,
                            IdProceso = 1,
                            IdTarifa = 1,
                            IdZona = 1,
                            Inactivo = false,
                            NumMedidor = "MY727A",
                            RPU = "812080400696",
                            Ubicacion = "AV. TULUM/ESCORPION Y COBA"
                        });
                });

            modelBuilder.Entity("SicemOperation.Entities.CFEProceso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Proceso")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("proceso");

                    b.HasKey("Id");

                    b.ToTable("Cat_Procesos", "CFE");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Proceso = "OFICINAS"
                        },
                        new
                        {
                            Id = 2,
                            Proceso = "RODUCCIÓN"
                        },
                        new
                        {
                            Id = 3,
                            Proceso = "DISTRIBUCIÓN"
                        },
                        new
                        {
                            Id = 4,
                            Proceso = "RESIDUAL"
                        },
                        new
                        {
                            Id = 5,
                            Proceso = "TRATAMIENTO"
                        });
                });

            modelBuilder.Entity("SicemOperation.Entities.CFETarifa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Inactivo")
                        .HasColumnType("bit")
                        .HasColumnName("inactivo");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nombre");

                    b.HasKey("Id");

                    b.ToTable("Cat_Tarifas", "CFE");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Inactivo = false,
                            Nombre = "GDMTH"
                        },
                        new
                        {
                            Id = 2,
                            Inactivo = false,
                            Nombre = "GDMTO"
                        },
                        new
                        {
                            Id = 3,
                            Inactivo = false,
                            Nombre = "PDBT"
                        });
                });

            modelBuilder.Entity("SicemOperation.Entities.CFEZona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Zona")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("zona");

                    b.HasKey("Id");

                    b.ToTable("Cat_Zonas", "CFE");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Zona = "URBANA"
                        },
                        new
                        {
                            Id = 2,
                            Zona = "RURAL"
                        });
                });

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

                    b.Property<DateTime>("Fecha")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("fecha")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("OficinaId")
                        .HasColumnType("int")
                        .HasColumnName("oficinaId");

                    b.Property<int>("TipoIncidenciaId")
                        .HasColumnType("int")
                        .HasColumnName("tipoIncidenciaId");

                    b.Property<DateTime>("UltimaActualizacion")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("ultimaActualizacion")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int")
                        .HasColumnName("usuarioId");

                    b.Property<int>("Valor")
                        .HasColumnType("int")
                        .HasColumnName("valor");

                    b.HasKey("Id");

                    b.HasIndex("OficinaId");

                    b.HasIndex("TipoIncidenciaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Opr_Incidencia", "Operation");
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

            modelBuilder.Entity("SicemOperation.Entities.Organismo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("direccion");

                    b.Property<string>("Municipio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("municipio");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nombre");

                    b.HasKey("Id");

                    b.ToTable("Cat_Organismos", "Global");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Direccion = "SN/D",
                            Municipio = "Othon P. Blanco",
                            Nombre = "CAPA Othon P. Blanco"
                        },
                        new
                        {
                            Id = 2,
                            Direccion = "SN/D",
                            Municipio = "Tulum",
                            Nombre = "CAPA Tulum"
                        },
                        new
                        {
                            Id = 3,
                            Direccion = "SN/D",
                            Municipio = "Felipe Carrillo Puerto",
                            Nombre = "CAPA Felipe Carrillo Puerto"
                        },
                        new
                        {
                            Id = 4,
                            Direccion = "SN/D",
                            Municipio = "Bacalar",
                            Nombre = "CAPA Bacalar"
                        },
                        new
                        {
                            Id = 5,
                            Direccion = "SN/D",
                            Municipio = "Jose Maria Morelos",
                            Nombre = "CAPA Jose Maria Morelos"
                        },
                        new
                        {
                            Id = 6,
                            Direccion = "SN/D",
                            Municipio = "Lazaro Cardenas",
                            Nombre = "CAPA Lazaro Cardenas"
                        },
                        new
                        {
                            Id = 7,
                            Direccion = "SN/D",
                            Municipio = "Cozumel",
                            Nombre = "CAPA Cozumel"
                        });
                });

            modelBuilder.Entity("SicemOperation.Entities.TipoIncidencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("descripcion");

                    b.Property<string>("Grupo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("grupo");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nombre");

                    b.HasKey("Id");

                    b.ToTable("Cat_Incidencia", "Operation");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "En tomas domiciliarias",
                            Grupo = "Numero de Fugas",
                            Nombre = "fugaTomaDomiciliaria"
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "En lineas de Conduccion",
                            Grupo = "Numero de Fugas",
                            Nombre = "fugaLineaConduccion"
                        },
                        new
                        {
                            Id = 3,
                            Descripcion = "En redes de distribucion",
                            Grupo = "Numero de Fugas",
                            Nombre = "fugaLineaDistribucion"
                        },
                        new
                        {
                            Id = 4,
                            Descripcion = "Subestaciones electricas",
                            Grupo = "Fallas en equipos electromecanicos en agua potable",
                            Nombre = "fallaAguaPotableElectrica"
                        },
                        new
                        {
                            Id = 5,
                            Descripcion = "Centro de control de motores",
                            Grupo = "Fallas en equipos electromecanicos en agua potable",
                            Nombre = "fallaAguaPotableCentroControl"
                        },
                        new
                        {
                            Id = 6,
                            Descripcion = "Equipo de bombeo",
                            Grupo = "Fallas en equipos electromecanicos en agua potable",
                            Nombre = "fallaAguaPotableBombeo"
                        },
                        new
                        {
                            Id = 7,
                            Descripcion = "Subestaciones electricas",
                            Grupo = "Fallas en equipos electromecanicos en aguas residuales",
                            Nombre = "fallaAguaResidualElectrica"
                        },
                        new
                        {
                            Id = 8,
                            Descripcion = "Centro de control de motores",
                            Grupo = "Fallas en equipos electromecanicos en aguas residuales",
                            Nombre = "fallaAguaResidualCentroControl"
                        },
                        new
                        {
                            Id = 9,
                            Descripcion = "Equipo de bombeo",
                            Grupo = "Fallas en equipos electromecanicos en aguas residuales",
                            Nombre = "fallaAguaResidualBombeo"
                        },
                        new
                        {
                            Id = 10,
                            Descripcion = "Rebosamientos de agua residual atendidos",
                            Grupo = "Recoleccion aguas residuales",
                            Nombre = "recoleccionResidualAtendido"
                        },
                        new
                        {
                            Id = 11,
                            Descripcion = "Colectores desasolvados (mts)",
                            Grupo = "Recoleccion aguas residuales",
                            Nombre = "recoleccionResidualColector"
                        },
                        new
                        {
                            Id = 12,
                            Descripcion = "Pozos de visita desasolvados",
                            Grupo = "Recoleccion aguas residuales",
                            Nombre = "recoleccionResidualVisita"
                        },
                        new
                        {
                            Id = 13,
                            Descripcion = "Equipos en pretratamiento",
                            Grupo = "Fallas en plantas de tratamiento de aguas residuales",
                            Nombre = "fallaTratamientoEquipos"
                        },
                        new
                        {
                            Id = 14,
                            Descripcion = "Sistema de aereacion",
                            Grupo = "Fallas en plantas de tratamiento de aguas residuales",
                            Nombre = "fallaTratamientoAereacion"
                        },
                        new
                        {
                            Id = 15,
                            Descripcion = "Equipos de recirculacion",
                            Grupo = "Fallas en plantas de tratamiento de aguas residuales",
                            Nombre = "fallaTratamientoRecirculacion"
                        },
                        new
                        {
                            Id = 16,
                            Descripcion = "Sistema de sedimentacion",
                            Grupo = "Fallas en plantas de tratamiento de aguas residuales",
                            Nombre = "fallaTratamientoSedimentacion"
                        },
                        new
                        {
                            Id = 17,
                            Descripcion = "Sistema de desinfeccion",
                            Grupo = "Fallas en plantas de tratamiento de aguas residuales",
                            Nombre = "fallaTratamientoDesinfeccion"
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
                            Password = "$2a$11$VWrSRkO2CvFke3lPkbn1fOzHC98e13lE0Pei9gn27UEDUI/odjBly"
                        });
                });

            modelBuilder.Entity("SicemOperation.Entities.CFEConsumo", b =>
                {
                    b.HasOne("SicemOperation.Entities.CFEMedidor", "Medidor")
                        .WithMany()
                        .HasForeignKey("IdMedidor")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Medidor");
                });

            modelBuilder.Entity("SicemOperation.Entities.CFEMedidor", b =>
                {
                    b.HasOne("SicemOperation.Entities.Organismo", "Organismo")
                        .WithMany()
                        .HasForeignKey("IdOrganismo")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SicemOperation.Entities.CFEProceso", "Proceso")
                        .WithMany()
                        .HasForeignKey("IdProceso")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SicemOperation.Entities.CFETarifa", "Tarifa")
                        .WithMany()
                        .HasForeignKey("IdTarifa")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SicemOperation.Entities.CFEZona", "Zona")
                        .WithMany()
                        .HasForeignKey("IdZona")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Organismo");

                    b.Navigation("Proceso");

                    b.Navigation("Tarifa");

                    b.Navigation("Zona");
                });

            modelBuilder.Entity("SicemOperation.Entities.Incidencia", b =>
                {
                    b.HasOne("SicemOperation.Entities.Oficina", "Oficina")
                        .WithMany()
                        .HasForeignKey("OficinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SicemOperation.Entities.TipoIncidencia", "TipoIncidencia")
                        .WithMany()
                        .HasForeignKey("TipoIncidenciaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SicemOperation.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Oficina");

                    b.Navigation("TipoIncidencia");

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
