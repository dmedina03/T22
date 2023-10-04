using Domain.DTOs.Response.T22;
using Domain.Models.Parametro;
using Domain.Models.T22;
using Microsoft.EntityFrameworkCore;
using Persistence.Context.Seed;
using Persistence.FluentConfig.ParametroConfig;
using Persistence.FluentConfig.T22;
using Persistence.Repository.IRepositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Persistence.Context
{
    public class ApplicationDbContext : DbContext, IUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions options): base(options)
        {
            
        }

        //DbSet de las entidades
        DbSet<Parametro> Parametro { get; set; }
        DbSet<ParametroDetalle> ParametroDetalle { get; set; }
        DbSet<Solicitud> Solicitud { get; set; }
        DbSet<TipoCapacitacion> TipoCapacitacion { get; set; }
        DbSet<SeguimientoAuditoriaSolicitud> SeguimientoAuditoriaSolicitud { get; set; }
        DbSet<Estado> Estado { get; set; }
        DbSet<DocumentoSolicitud> DocumentoSolicitud { get; set; }
        DbSet<CapacitadorTipoCapacitacion> CapacitadorTipoCapacitacion { get; set; }
        DbSet<CapacitadorSolicitud> CapacitadorSolicitud { get; set; }
        DbSet<CancelacionSolicitud> CancelacionSolicitud { get; set; }
        DbSet<SubsanacionSolicitud> SubsanacionSolicitud { get; set; }
        DbSet<Firma> Firma { get; set; }
        DbSet<FormatoPlantilla> FormatoPlantilla { get; set; }
        DbSet<ResolucionSolicitud> ResolucionSolicitud { get; set; }
        DbSet<CapacitacionCapacitadorSolicitud> CapacitacionCapacitadorSolicitud { get; set; }
        DbSet<HorariosCapacitacionSolicitud> HorariosCapacitacionSolicitud { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //entidades config
            new ParametroConfig(modelBuilder.Entity<Parametro>());
            new ParametroDetalleConfig(modelBuilder.Entity<ParametroDetalle>());
            new SolicitudConfig(modelBuilder.Entity<Solicitud>());
            new TipoCapacitacionConfig(modelBuilder.Entity<TipoCapacitacion>());
            new SeguimientoAuditoriaSolicitudConfig(modelBuilder.Entity<SeguimientoAuditoriaSolicitud>());
            new EstadoConfig(modelBuilder.Entity<Estado>());
            new DocumentoSolicitudConfig(modelBuilder.Entity<DocumentoSolicitud>());
            new CapacitadorTipoCapacitacionConfig(modelBuilder.Entity<CapacitadorTipoCapacitacion>());
            new CapacitadorSolicitudConfig(modelBuilder.Entity<CapacitadorSolicitud>());
            new CancelacionSolicitudConfig(modelBuilder.Entity<CancelacionSolicitud>());
            new SubsanacionSolicitudConfig(modelBuilder.Entity<SubsanacionSolicitud>());
            new FirmaConfig(modelBuilder.Entity<Firma>());
            new FormatoPlantillaConfig(modelBuilder.Entity<FormatoPlantilla>());
            new ResolucionSolicitudConfig(modelBuilder.Entity<ResolucionSolicitud>());
            new CapacitacionCapacitadorSolicitudConfig(modelBuilder.Entity<CapacitacionCapacitadorSolicitud>());
            new HorariosCapacitacionSolicitudConfig(modelBuilder.Entity<HorariosCapacitacionSolicitud>());

            //Seeds
            new TipoCapacitacionSeedConfig(modelBuilder.Entity<TipoCapacitacion>());
            new EstadoSeedConfig(modelBuilder.Entity<Estado>());
            //new ParametroSeedConfig(modelBuilder.Entity<Parametro>());
            //new TipoResolucionSeedConfig(modelBuilder.Entity<ParametroDetalle>());
            //new ResultadoValidacionSeedConfig(modelBuilder.Entity<ParametroDetalle>());
            //new TipoSolicitudSeedConfig(modelBuilder.Entity<ParametroDetalle>());
            //new ReportesSeedConfig(modelBuilder.Entity<ParametroDetalle>());

        }

        public void Commit()
        {
            try
            {
                using var transactionScope = new TransactionScope();
                SaveChanges();
                transactionScope.Complete();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ex.Entries.Single().Reload();
            }
        }

        public async Task CommitAsync()
        {
            try
            {
                using var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
                await SaveChangesAsync();
                transactionScope.Complete();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ex.Entries.Single().Reload();
            }
        }

        public DbContext GetContext()
        {
            return this;
        }

        public DbSet<TEntity> GetSet<TId, TEntity>()
            where TId : struct
            where TEntity : class
        {
            return Set<TEntity>();
        }
    }
}
