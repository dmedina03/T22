﻿using Domain.DTOs.Response.T22;
using Domain.Models;
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

        public DbSet<Parametro> Parametro { get; set; }
        public DbSet<ParametroDetalle> ParametroDetalle { get; set; }
        public DbSet<Solicitud> Solicitud { get; set; }
        public DbSet<TipoCapacitacion> TipoCapacitacion { get; set; }
        public DbSet<SeguimientoAuditoriaSolicitud> SeguimientoAuditoriaSolicitud { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<DocumentoSolicitud> DocumentoSolicitud { get; set; }
        public DbSet<CapacitadorTipoCapacitacion> CapacitadorTipoCapacitacion { get; set; }
        public DbSet<CapacitadorSolicitud> CapacitadorSolicitud { get; set; }
        public DbSet<CancelacionSolicitud> CancelacionSolicitud { get; set; }
        public DbSet<SubsanacionSolicitud> SubsanacionSolicitud { get; set; }
        public DbSet<Firma> Firma { get; set; }
        public DbSet<FormatoPlantilla> FormatoPlantilla { get; set; }
        public DbSet<ResolucionSolicitud> ResolucionSolicitud { get; set; }
        public DbSet<CapacitacionCapacitadorSolicitud> CapacitacionCapacitadorSolicitud { get; set; }
        public DbSet<HorariosCapacitacionSolicitud> HorariosCapacitacionSolicitud { get; set; }
        public DbSet<SpBandejaFuncionarioDto> SpBandejaFuncionarioDto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //entidades config
#pragma warning disable // Do not ignore method results
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
