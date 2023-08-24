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

            CreateMap<DocumentoSolicitud, DocumentoSolicitudDTORequest>().ReverseMap();

            CreateMap<CapacitadorSolicitud, CapacitadorSolicitudDTORequest>().ReverseMap()
                .ForMember(x => x.IntTelefono, src => src.MapFrom(p => p.IntTelefono));
            CreateMap<CapacitadorTipoCapacitacion, CapacitadorTipoCapacitacionDTORequest>().ReverseMap();
            CreateMap<TipoCapacitacion, TipoCapacitacionDTOResponse>().ReverseMap();
                
            

        }
    }
}
