using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ParcialDb: DbContext
    {
        public ParcialDb() : base("ConStr")
        {

        }

        public DbSet<Retenciones> Retencion { get; set; }
        public DbSet<TiposEmails> TipoEmail { get; set; }
        public DbSet<Empleados> Empleado { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entidades.Retenciones>()
                .HasMany(retencion => retencion.Empleados)
                .WithMany(empleado => empleado.Retenciones)
                .Map(empleadoRetencion =>
                {
                    empleadoRetencion.MapLeftKey("EmpleadoId");
                    empleadoRetencion.MapRightKey("RetencionId");
                    empleadoRetencion.ToTable("EmpleadosRetenciones");
                });
        }
    }
}
