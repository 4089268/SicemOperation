using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SicemOperation.Entities;

namespace SicemOperation.Data
{
    public class SicemOperationContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Oficina> Oficinas { get; set; }
        public DbSet<Incidencia> Incidencias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<TipoIncidencia> TiposIncidencia { get; set; }

        public DbSet<Organismo> Organismos { get; set; }
        public DbSet<CFETarifa> CFETarifas { get; set; }
        public DbSet<CFEZona> CFEZonas { get; set; }
        public DbSet<CFEProceso> CFEProcesos { get; set; }
        public DbSet<CFEMedidor> CFEMedidores { get; set; }
        public DbSet<CFEConsumo> CFEConsumos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            // * convert all columns in comel case
            foreach( var entity in modelBuilder.Model.GetEntityTypes() )
            {
                foreach( var property in entity.GetProperties() )
                {
                    var _propertyName = property.Name;
                    property.SetColumnName( Char.ToLowerInvariant(_propertyName[0]) + _propertyName.Substring(1) );
                }
            }

            // * office entity
            var oficinaEntity = modelBuilder.Entity<Oficina>();
            oficinaEntity.Property(p => p.UltimaActualizacion)
                .HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAddOrUpdate()
                .IsRequired();

            // * incidence entity
            var incidenciaEntity = modelBuilder.Entity<Incidencia>();
            incidenciaEntity.Property(p => p.Fecha)
                .HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            incidenciaEntity.Property(p => p.UltimaActualizacion)
                .HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAddOrUpdate()
                .IsRequired();
            

            // * defaul test office
            modelBuilder.Entity<Oficina>().HasData(
                new Oficina
                {
                    Id = 1,
                    Nombre = "Oficina de prueba"
                }
            );


            // * default user
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword("password123#");
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = 1,
                    Nombre = "administrador",
                    Correo = "admin@email.com",
                    Password = hashedPassword
                }
            );

            // # default incident types
            modelBuilder.Entity<TipoIncidencia>().HasData(
                new TipoIncidencia { Id = 1, Nombre = "fugaTomaDomiciliaria", Descripcion = "En tomas domiciliarias", Grupo = "Numero de Fugas" },
                new TipoIncidencia { Id = 2, Nombre = "fugaLineaConduccion", Descripcion = "En lineas de Conduccion", Grupo = "Numero de Fugas" },
                new TipoIncidencia { Id = 3, Nombre = "fugaLineaDistribucion", Descripcion = "En redes de distribucion", Grupo = "Numero de Fugas" },
                new TipoIncidencia { Id = 4, Nombre = "fallaAguaPotableElectrica", Descripcion = "Subestaciones electricas", Grupo = "Fallas en equipos electromecanicos en agua potable" },
                new TipoIncidencia { Id = 5, Nombre = "fallaAguaPotableCentroControl", Descripcion = "Centro de control de motores", Grupo = "Fallas en equipos electromecanicos en agua potable" },
                new TipoIncidencia { Id = 6, Nombre = "fallaAguaPotableBombeo", Descripcion = "Equipo de bombeo", Grupo = "Fallas en equipos electromecanicos en agua potable" },
                new TipoIncidencia { Id = 7, Nombre = "fallaAguaResidualElectrica", Descripcion = "Subestaciones electricas", Grupo = "Fallas en equipos electromecanicos en aguas residuales" },
                new TipoIncidencia { Id = 8, Nombre = "fallaAguaResidualCentroControl", Descripcion = "Centro de control de motores", Grupo = "Fallas en equipos electromecanicos en aguas residuales" },
                new TipoIncidencia { Id = 9, Nombre = "fallaAguaResidualBombeo", Descripcion = "Equipo de bombeo", Grupo = "Fallas en equipos electromecanicos en aguas residuales" },
                new TipoIncidencia { Id = 10, Nombre = "recoleccionResidualAtendido", Descripcion = "Rebosamientos de agua residual atendidos", Grupo = "Recoleccion aguas residuales" },
                new TipoIncidencia { Id = 11, Nombre = "recoleccionResidualColector", Descripcion = "Colectores desasolvados (mts)", Grupo = "Recoleccion aguas residuales" },
                new TipoIncidencia { Id = 12, Nombre = "recoleccionResidualVisita", Descripcion = "Pozos de visita desasolvados", Grupo = "Recoleccion aguas residuales" },
                new TipoIncidencia { Id = 13, Nombre = "fallaTratamientoEquipos", Descripcion = "Equipos en pretratamiento", Grupo = "Fallas en plantas de tratamiento de aguas residuales" },
                new TipoIncidencia { Id = 14, Nombre = "fallaTratamientoAereacion", Descripcion = "Sistema de aereacion", Grupo = "Fallas en plantas de tratamiento de aguas residuales" },
                new TipoIncidencia { Id = 15, Nombre = "fallaTratamientoRecirculacion", Descripcion = "Equipos de recirculacion", Grupo = "Fallas en plantas de tratamiento de aguas residuales" },
                new TipoIncidencia { Id = 16, Nombre = "fallaTratamientoSedimentacion", Descripcion = "Sistema de sedimentacion", Grupo = "Fallas en plantas de tratamiento de aguas residuales" },
                new TipoIncidencia { Id = 17, Nombre = "fallaTratamientoDesinfeccion", Descripcion = "Sistema de desinfeccion", Grupo = "Fallas en plantas de tratamiento de aguas residuales" }
            );


            modelBuilder.Entity<Organismo>().HasData(
                new Organismo { Id = 1, Nombre = "CAPA Othon P. Blanco", Direccion = "SN/D", Municipio = "Othon P. Blanco" },
                new Organismo { Id = 2, Nombre = "CAPA Tulum", Direccion = "SN/D", Municipio = "Tulum" },
                new Organismo { Id = 3, Nombre = "CAPA Felipe Carrillo Puerto", Direccion = "SN/D", Municipio = "Felipe Carrillo Puerto" },
                new Organismo { Id = 4, Nombre = "CAPA Bacalar", Direccion = "SN/D", Municipio = "Bacalar" },
                new Organismo { Id = 5, Nombre = "CAPA Jose Maria Morelos", Direccion = "SN/D", Municipio = "Jose Maria Morelos" },
                new Organismo { Id = 6, Nombre = "CAPA Lazaro Cardenas", Direccion = "SN/D", Municipio = "Lazaro Cardenas" },
                new Organismo { Id = 7, Nombre = "CAPA Cozumel", Direccion = "SN/D", Municipio = "Cozumel" }
            );

            modelBuilder.Entity<CFETarifa>().HasData(
                new CFETarifa { Id = 1, Nombre = "GDMTH", Inactivo = false },
                new CFETarifa { Id = 2, Nombre = "GDMTO", Inactivo = false },
                new CFETarifa { Id = 3, Nombre = "PDBT", Inactivo = false }
            );

            modelBuilder.Entity<CFEZona>().HasData(
                new CFEZona { Id = 1, Zona = "URBANA" },
                new CFEZona { Id = 2, Zona = "RURAL" }
            );

            modelBuilder.Entity<CFEProceso>().HasData(
                new CFEProceso { Id = 1, Proceso = "OFICINAS" },
                new CFEProceso { Id = 2, Proceso = "RODUCCIÓN" },
                new CFEProceso { Id = 3, Proceso = "DISTRIBUCIÓN" },
                new CFEProceso { Id = 4, Proceso = "RESIDUAL" },
                new CFEProceso { Id = 5, Proceso = "TRATAMIENTO" }
            );

            modelBuilder.Entity<CFEMedidor>(entity => {

                entity.HasOne(e => e.Organismo)
                    .WithMany()
                    .HasForeignKey(e => e.IdOrganismo)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Tarifa)
                    .WithMany()
                    .HasForeignKey(e => e.IdTarifa)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Proceso)
                    .WithMany()
                    .HasForeignKey(e => e.IdProceso)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Zona)
                    .WithMany()
                    .HasForeignKey(e => e.IdZona)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasData(
                    new CFEMedidor {
                        Id = 1,
                        IdOrganismo = 2,
                        RPU = "812080400696",
                        NumMedidor = "MY727A",
                        Ubicacion = "AV. TULUM/ESCORPION Y COBA",
                        CargaConectada = 200,
                        DemandaContratada = 200,
                        IdTarifa = 1,
                        IdProceso = 1,
                        IdZona = 1,
                        Inactivo = false
                    }
                );
            });

            modelBuilder.Entity<CFEConsumo>(entity => {
                entity.Property( p => p.FechaInicio).HasColumnType("date");
                entity.Property( p => p.FechaFin).HasColumnType("date");

                entity.HasOne(e => e.Medidor)
                    .WithMany()
                    .HasForeignKey(e => e.IdMedidor)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasData(
                    new CFEConsumo {
                        Id = 1,
                        IdMedidor = 1,
                        FechaInicio = new DateTime(2024, 1, 31),
                        FechaFin = new DateTime(2024, 2, 29),
                        Consumo = 30899,
                        Importe = 193705.0m,
                        Demanda = 127,
                        Kvarh = 30510.0m,
                        FpPorc = 94.33,
                        FpMon = 1780.54m,
                        DapMon = 8004.36m,
                        Af = 2024,
                        Mf = 2
                    }
                );
            });

            base.OnModelCreating(modelBuilder);

        }

    }
}
