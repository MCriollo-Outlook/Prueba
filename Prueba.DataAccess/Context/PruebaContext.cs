using Prueba.Entity;
using Prueba.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Text;

namespace Prueba.DataAccess.Context
{
    public partial class PruebaContext : DbContext
    {
        public PruebaContext() 
            : base ("name=PruebaContext")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.ValidateOnSaveEnabled = false;
        }

        public virtual DbSet<Deportista> Deportista { get; set; }
        public virtual DbSet<Pais> Pais { get; set; }
        public virtual DbSet<Modalidad> Modalidad { get; set; }
        public virtual DbSet<DeportistaModalidad> DeportistaModalidad { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            #region Deportista
            modelBuilder.Entity<Deportista>()
                    .Property(e => e.Name)
                    .IsUnicode(false);
            #endregion

            #region Pais
            modelBuilder.Entity<Pais>()
                    .Property(e => e.Name)
                    .IsUnicode(false);
            #endregion

            #region Modalidad
            modelBuilder.Entity<Modalidad>()
                    .Property(e => e.Name)
                    .IsUnicode(false);
            #endregion

            #region DeportistaModalidad
            
            #endregion
        }
    }
}
