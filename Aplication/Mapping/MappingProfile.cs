using AutoMapper;
using Domain.DTOs.Request.T22;
using Domain.DTOs.Response.Parametro;
using Domain.DTOs.Response.T22;
using Domain.Models.Parametro;
using Domain.Models.T22;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {

            CreateMap<ParametroDetalle, ParametroDetalleDTO>().ReverseMap();

            CreateMap<Solicitud, SolicitudDTORequest>().ReverseMap();

            CreateMap<Solicitud, SolicitudBandejaSolicitudesDTOResponse>().ReverseMap();

            CreateMap<DocumentoSolicitud, DocumentoSolicitudDTORequest>().ReverseMap()
                .ForMember(x => x.UsuarioId, src => src.MapFrom(p => p.UsuarioId));

            CreateMap<CapacitadorSolicitud, CapacitadorSolicitudDTORequest>().ReverseMap()
                .ForMember(x => x.IntTelefono, src => src.MapFrom(p => p.IntTelefono));

            CreateMap<CapacitadorTipoCapacitacion, CapacitadorTipoCapacitacionDTORequest>().ReverseMap();
                //.ForMember(x => x.IdCapacitadorSolicitud, src => src.MapFrom(p => p.IdCapacitadorSolicitud));

            CreateMap<TipoCapacitacion, TipoCapacitacionDTOResponse>().ReverseMap();
            CreateMap<SeguimientoAuditoriaSolicitud, SeguimientoAuditoriaSolicitudDTORequest>().ReverseMap();
            CreateMap<SubsanacionSolicitud, SubsanacionSolicitudDTORequest>().ReverseMap();
            CreateMap<CancelacionSolicitud, CancelacionIncumplimientoSolicitudDTORequest>().ReverseMap();
            CreateMap<ResolucionSolicitud, ResolucionSolicitudDTORequest>().ReverseMap();

            CreateMap<CapacitacionCapacitadorSolicitud, CapacitacionCapacitadorSolicitudDTORequest>().ReverseMap();
            CreateMap<HorariosCapacitacionSolicitud, HorariosCapacitacionSolicitudDTORequest>().ReverseMap();

        }
    }
}
