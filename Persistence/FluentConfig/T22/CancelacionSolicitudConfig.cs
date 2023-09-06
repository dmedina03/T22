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
    public class CancelacionSolicitudConfig
    {
        public CancelacionSolicitudConfig(EntityTypeBuilder<CancelacionSolicitud> entity) 
        {
            entity.ToTable("CancelacionSolicitudes", schema: "manipalimentos");
            entity.HasKey(p => p.IdCancelacion);

            entity.HasOne(p => p.Solicitud)
                .WithOne(p => p.CancelacionIncumplimientoSolicitud)
                .HasForeignKey<CancelacionSolicitud>(p => p.SolicitudId);

            entity.Property(p => p.SolicitudId).IsRequired();
            entity.Property(p => p.DtFechaCancelacion).IsRequired();
            entity.Property(p => p.VcCancelacion).IsRequired();
            entity.Property(p => p.UsuarioId).IsRequired();
            entity.Property(p => p.VcNombreUsuario).IsRequired();
            entity.Property(p => p.EstadoId).IsRequired();

        }
    }
}
