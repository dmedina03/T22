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
    public class CapacitacionCapacitadorSolicitudConfig
    {
        public CapacitacionCapacitadorSolicitudConfig(EntityTypeBuilder<CapacitacionCapacitadorSolicitud> entity)
        {
            entity.ToTable("CapacitacionCapacitadorSolicitudes", schema: "manipalimentos");

            entity.HasKey(p => p.IdCapacitacionSolicitud);

            entity.HasOne(p => p.CapacitadorSolicitud)
                .WithMany(p => p.CapacitacionCapacitador)
                .HasForeignKey(p => p.CapacitadorId);

            entity.HasMany(p => p.HorariosCapacitacionSolicitud)
                .WithOne(p => p.CapacitacionCapacitadorSolcitud)
                .HasForeignKey(p => p.CapacitacionSolicitudId);

            entity.Property(p => p.CapacitadorId).IsRequired();
            entity.Property(p => p.VcPublicoObjetivo).IsRequired();
            entity.Property(p => p.IntNumeroAsistentes).IsRequired();
            entity.Property(p => p.VcTemaCapacitacion).IsRequired();
            entity.Property(p => p.VcMetodologiaCapacitacion).IsRequired();
            entity.Property(p => p.DtFechaCreacionCapacitacion).IsRequired();
            entity.Property(p => p.VcDireccion).IsRequired();
            entity.Property(p => p.VcInformacionAdicional).IsRequired(false);
            entity.Property(p => p.DepartamentoId).IsRequired();
            entity.Property(p => p.CiudadId).IsRequired();
            entity.Property(p => p.UsuarioRevisionId);
            entity.Property(p => p.BlSeguimiento);

        }
    }
}
