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


            base.OnModelCreating(modelBuilder);

        }

    }
}
