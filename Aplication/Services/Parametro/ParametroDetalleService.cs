using Aplication.Utilities.Enum;
using AutoMapper;
using Domain.DTOs.Response.Parametro;
using Dominio.DTOs.Response.ResponseBase;
using Persistence.Repository.IRepositories.IParametroRepository;
using Persistence.Repository.IRepositories.IT22;
using System.Net;

namespace Aplication.Services.Parametro
{
    public class ParametroDetalleService : IParametroDetalleService
    {
        private readonly IParametroDetalleRepository _parametroDetalleRepository;
        private readonly ISolicitudRespository _solicitudRepository;
        private readonly IParametroRepository _parametroRepository;
        private readonly IMapper _mapper;

        public ParametroDetalleService(IParametroDetalleRepository parametroDetalleRepository, ISolicitudRespository solicitudRepository, IParametroRepository parametroRepository,
            IMapper mapper)
        {
            _parametroDetalleRepository = parametroDetalleRepository;
            _solicitudRepository = solicitudRepository;
            _parametroRepository = parametroRepository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<List<ParametroDetalleDto>>> GetTipoSolicitud(string Id)
        {
            var query = await _solicitudRepository.GetAsync(x => x.UsuarioId.ToString().ToLower() == Id.ToLower());

            List<ParametroDetalleDto>? solicitud = (await listarPorCodigoInterno("bTipoSolicitud")).Data;

            ParametroDetalleDto element = new();

            if (query is not null)
            {
                return new ResponseBase<List<ParametroDetalleDto>>(HttpStatusCode.OK, "OK", solicitud, solicitud == null ? 0 :  solicitud.Count);
            }

            if (solicitud != null)
            {
                element = solicitud.ElementAt(0);
            }
            var lista = new List<ParametroDetalleDto>
            {
                element
            };

            return new ResponseBase<List<ParametroDetalleDto>>(HttpStatusCode.OK, "OK", lista, lista.Count);
        }

        public async Task<ResponseBase<List<ParametroDetalleDto>>> GetResultadoValidacion(int SolicitudId)
        {
            var query = (await _solicitudRepository.GetAsync(x => x.IdSolicitud == SolicitudId)).EstadoId;

            var resultadoValidacion = (await listarPorCodigoInterno("bResultadoValidacion")).Data;

            var lista = new List<ParametroDetalleDto>();

            if (query == (int)EnumEstado.Aprobado)
            {
                if (resultadoValidacion != null)
                {
                    resultadoValidacion = resultadoValidacion.Where(x => x.VcNombre.Contains("incumplimiento")).ToList();
                    lista.Add(resultadoValidacion.ElementAt(0));
                }

                return new ResponseBase<List<ParametroDetalleDto>>(HttpStatusCode.OK, "OK", lista, lista.Count);
            }
            else
            {
                if (resultadoValidacion != null)
                {
                    var result = resultadoValidacion.First(x => x.VcNombre.ToUpper().Contains("incumplimiento".ToUpper()));
                    resultadoValidacion.Remove(result);

                    result = resultadoValidacion.First(x => x.VcNombre.ToUpper().Contains("recurso".ToUpper()));
                    resultadoValidacion.Remove(result);

                    resultadoValidacion = resultadoValidacion.OrderBy(x => x.IdParametroDetalle).ToList();
                }

                return new ResponseBase<List<ParametroDetalleDto>>(HttpStatusCode.OK, "OK", resultadoValidacion, resultadoValidacion == null ? 0 : resultadoValidacion.Count);

            }
        }

        public async Task<ResponseBase<List<ParametroDetalleDto>>> listarPorCodigoInterno(string codigoInterno)
        {
            var resultQueryParamento = await _parametroRepository.GetAsync(prop => prop.VcCodigoInterno == codigoInterno);

            if (resultQueryParamento != null)
            {
                var listado = await _parametroDetalleRepository.GetAllAsync(prop => prop.ParametroId == resultQueryParamento.IdParametro);

                if (listado != null)
                {
                    return new ResponseBase<List<ParametroDetalleDto>>(HttpStatusCode.OK, "OK", _mapper.Map<List<ParametroDetalleDto>>(listado), listado.Count());
                }
            }
            return new ResponseBase<List<ParametroDetalleDto>>(HttpStatusCode.InternalServerError, "Ocurrio un error, No se puede listar los parametros", new List<ParametroDetalleDto>(), 0);
        }

        public async Task<ResponseBase<List<ParametroDetalleDto>>> listarPorCodigoInternoIdPadre(string codigoInterno, long idPadre)
        {
            var resultQueryParamento = await _parametroRepository.GetAsync(prop => prop.VcCodigoInterno == codigoInterno);

            if (resultQueryParamento != null)
            {
                var listado = await _parametroDetalleRepository.GetAllAsync(prop => prop.ParametroId == resultQueryParamento.IdParametro && prop.IdPadre == idPadre);

                if (listado != null)
                {
                    return new ResponseBase<List<ParametroDetalleDto>>(HttpStatusCode.OK, "OK", _mapper.Map<List<ParametroDetalleDto>>(listado), listado.Count());
                }

            }

            return new ResponseBase<List<ParametroDetalleDto>>(HttpStatusCode.InternalServerError, "Ocurrio un error, No se puede listar los parametros", new List<ParametroDetalleDto>(), 0);
        }


    }
}
