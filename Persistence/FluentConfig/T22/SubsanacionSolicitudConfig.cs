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
    public class SubsanacionSolicitudConfig
    {
        public SubsanacionSolicitudConfig(EntityTypeBuilder<SubsanacionSolicitud> entity)
        {
            entity.ToTable("SubsanacionSolicitudes", schema: "manipalimentos") ;
            entity.HasKey(p => p.IdSubsanacion);

            entity.HasOne(p => p.Solicitud)
                .WithOne(p => p.SubsanacionSolicitud)
                .HasForeignKey<SubsanacionSolicitud>(p => p.SolicitudId);

            entity.Property(p => p.SolicitudId).IsRequired();
            entity.Property(p => p.DtFechaSubsanacion).IsRequired();
            entity.Property(p => p.VcSubsanacion).IsRequired();
            entity.Property(p => p.UsuarioId).IsRequired();
            entity.Property(p => p.EstadoId).IsRequired();
        }
    }
}
