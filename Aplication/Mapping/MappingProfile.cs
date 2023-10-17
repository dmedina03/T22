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

            CreateMap<ParametroDetalle, ParametroDetalleDto>().ReverseMap();

            CreateMap<Solicitud, SolicitudDtoRequest>().ReverseMap();

            CreateMap<Solicitud, SolicitudBandejaSolicitudesDtoResponse>().ReverseMap();

            CreateMap<DocumentoSolicitud, DocumentoSolicitudDtoRequest>().ReverseMap()
                .ForMember(x => x.UsuarioId, src => src.MapFrom(p => p.UsuarioId));

            CreateMap<CapacitadorSolicitud, CapacitadorSolicitudDtoRequest>().ReverseMap()
                .ForMember(x => x.IntTelefono, src => src.MapFrom(p => p.IntTelefono));

            CreateMap<CapacitadorTipoCapacitacion, CapacitadorTipoCapacitacionDtoRequest>().ReverseMap();

            CreateMap<SpBandejaFuncionarioDto, SolicitudBandejaSolicitudesDtoResponse>().ReverseMap()
                .ForMember(x => x.IdSolicitud, src => src.MapFrom(p => p.IdSolicitud))
                .ForMember(x => x.VcRadicado, src => src.MapFrom(p => p.VcRadicado))
                .ForMember(x => x.VcNombreUsuario, src => src.MapFrom(p => p.VcNombreUsuario))
                .ForMember(x => x.IntNumeroIdentificacionUsuario, src => src.MapFrom(p => p.IntNumeroIdentificacionUsuario))
                .ForMember(x => x.VcNombre, src => src.MapFrom(p => p.VcTipoSolicitud))
                .ForMember(x => x.VcTipoSolicitante, src => src.MapFrom(p => p.VcTipoSolicitante))
                .ForMember(x => x.DtFechaSolicitud, src => src.MapFrom(p => p.DtFechaSolicitud))
                .ForMember(x => x.VcTipoEstado, src => src.MapFrom(p => p.VcTipoEstado));

            CreateMap<TipoCapacitacion, TipoCapacitacionDtoResponse>().ReverseMap();
            CreateMap<SeguimientoAuditoriaSolicitud, SeguimientoAuditoriaSolicitudDtoRequest>().ReverseMap();
            CreateMap<SubsanacionSolicitud, SubsanacionSolicitudDtoRequest>().ReverseMap();
            CreateMap<CancelacionSolicitud, CancelacionIncumplimientoSolicitudDtoRequest>().ReverseMap();
            CreateMap<ResolucionSolicitud, ResolucionSolicitudDtoRequest>().ReverseMap();

            CreateMap<CapacitacionCapacitadorSolicitud, CapacitacionCapacitadorSolicitudDtoRequest>().ReverseMap();
            CreateMap<HorariosCapacitacionSolicitud, HorariosCapacitacionSolicitudDtoRequest>().ReverseMap();

        }
    }
}
