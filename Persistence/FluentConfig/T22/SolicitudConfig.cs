using Domain.Models.T22;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.FluentConfig.T22
{
    public class SolicitudConfig
    {
        public SolicitudConfig(EntityTypeBuilder<Solicitud> entity)
        {
            entity.ToTable("Solicitudes", schema: "manipalimentos");
            entity.HasKey(p => p.IdSolicitud);

            entity.HasMany(p => p.CapacitadorSolicitud)
                .WithOne(p => p.Solicitud);

            entity.HasMany(p => p.SeguimientoAuditoriaSolicitud)
                .WithOne(p => p.Solicitud);

            entity.HasOne(p => p.SubsanacionSolicitud)
                .WithOne(p => p.Solicitud);

            entity.HasOne(p => p.CancelacionIncumplimientoSolicitud)
                .WithOne(p => p.Solicitud);

            entity.HasOne(p => p.Estado)
                .WithOne(p => p.Solicitud)
                .HasForeignKey<Solicitud>(p => p.EstadoId)
                .OnDelete(DeleteBehavior.Restrict);
                
            entity.Property(p => p.VcTipoSolicitante).IsRequired();
            entity.Property(p => p.TipoSolicitudId).IsRequired();
            entity.Property(p => p.UsuarioAsignadoValidadorId);
            entity.Property(p => p.UsuarioAsignadoCoordinadorId);
            entity.Property(p => p.UsuarioAsignadoSubdirectorId);
            entity.Property(p => p.UsuarioId).IsRequired();
            entity.Property(p => p.VcNombreUsuario).IsRequired();
            entity.Property(p => p.IntNumeroIdentificacionUsuario).IsRequired();
            entity.Property(p => p.VcDireccionUsuario).IsRequired();
            entity.Property(p => p.DtFechaSolicitud).IsRequired();
            entity.Property(p => p.EstadoId).IsRequired();
            entity.Property(p => p.VcRadicado).HasMaxLength(50);
            
        }
    }
}
