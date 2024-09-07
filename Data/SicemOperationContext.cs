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
            

            // * Seed DB
            modelBuilder.Entity<Oficina>().HasData(
                new Oficina
                {
                    Id = 1,
                    Nombre = "Oficina de prueba"
                }
            );

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = 1,
                    Nombre = "admin",
                    Correo = "admin@email.com",
                    Password = "admin"
                }
            );

            base.OnModelCreating(modelBuilder);

        }

    }
}