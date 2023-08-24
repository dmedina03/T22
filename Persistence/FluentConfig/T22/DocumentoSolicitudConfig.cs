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
    public class DocumentoSolicitudConfig
    {
        public DocumentoSolicitudConfig(EntityTypeBuilder<DocumentoSolicitud> entity)
        {
            entity.ToTable("DocumentoSolicitudes");
            entity.HasKey(p => p.IdDocumento);

            entity.Property(p => p.SolicitudId).IsRequired();
            entity.Property(p => p.UsuarioId).IsRequired();
            entity.Property(p => p.TipoDocumentoId).IsRequired();
            entity.Property(p => p.VcNombreDocumento).IsRequired().HasMaxLength(150);
            entity.Property(p => p.DtFechaCargue).IsRequired();
            entity.Property(p => p.VcPath).IsRequired();
            entity.Property(p => p.IntVersion).IsRequired();
            entity.Property(p => p.BlUsuarioVentanilla);
            entity.Property(p => p.BlIsValid);
            
        }
    }
}
