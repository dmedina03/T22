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

            entity.Property(p => p.CapacitadorId).IsRequired();
            entity.Property(p => p.VcPublicoObjetivo).IsRequired();
            entity.Property(p => p.IntNumeroAsistentes).IsRequired();
            entity.Property(p => p.VcTemaCapacitacion).IsRequired();
            entity.Property(p => p.VcMetodologiaCapacitacion).IsRequired();
            entity.Property(p => p.DtFechaCapacitacion).IsRequired();
            entity.Property(p => p.ViaPrincipalId).IsRequired();
            entity.Property(p => p.IntNumeroPpl).IsRequired();
            entity.Property(p => p.CharLetraPpl);
            entity.Property(p => p.VcBis).IsRequired(false);
            entity.Property(p => p.CardinalidadPplId);
            entity.Property(p => p.ComplementoId).IsRequired();
            entity.Property(p => p.CharLetraComp);
            entity.Property(p => p.IntNumeroComp).IsRequired();
            entity.Property(p => p.IntPlaca).IsRequired();
            entity.Property(p => p.CardinalidadCompId);
            entity.Property(p => p.VcInformacionAdicional).IsRequired(false);
            entity.Property(p => p.DepartamentoId).IsRequired();
            entity.Property(p => p.CiudadId).IsRequired();
            entity.Property(p => p.UsuarioRevisionId);
            entity.Property(p => p.BlSeguimiento);

        }
    }
}
