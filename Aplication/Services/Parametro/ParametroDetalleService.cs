using AutoMapper;
using Domain.DTOs.Response.Parametro;
using Domain.Models.Parametro;
using Dominio.DTOs.Response.ResponseBase;
using Persistence.Repository.IRepositories.Generic;
using Persistence.Repository.IRepositories.IParametroRepository;
using Persistence.Repository.IRepositories.IT22;
using Persistence.Repository.Repositories.ParametroRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services.Parametro
{
    public class ParametroDetalleService : IParametroDetalleService
    {
        private readonly IParametroDetalleRepository _parametroDetalleRepository;
        private readonly ISolicitudRespository _solicitudRepository;
        private readonly IParametroRepository _parametroRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ParametroDetalleService(IParametroDetalleRepository parametroDetalleRepository, ISolicitudRespository solicitudRepository, IParametroRepository parametroRepository,
            IMapper mapper, IUnitOfWork unitOfWork)
        {
            _parametroDetalleRepository = parametroDetalleRepository;
            _solicitudRepository = solicitudRepository;
            _parametroRepository = parametroRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseBase<List<ParametroDetalleDTO>>> GetTipoSolicitud(int Id)
        {
            var query = await _solicitudRepository.GetAsync(x => x.UsuarioId == Id);

            var solicitud = (await listarPorCodigoInterno("bTipoSolicitud")).Data;

            if (query is not null)
            {
                return new ResponseBase<List<ParametroDetalleDTO>>(HttpStatusCode.OK, "OK", solicitud, solicitud.Count());

            }
            
            var lista = new List<ParametroDetalleDTO>();
            lista.Add(solicitud.ElementAt(0));

            return new ResponseBase<List<ParametroDetalleDTO>>(HttpStatusCode.OK, "OK", lista, lista.Count());
        }

        public async Task<ResponseBase<List<ParametroDetalleDTO>>> listarPorCodigoInterno(string codigoInterno)
        {
            var resultQueryParamento = await _parametroRepository.GetAsync(prop => prop.VcCodigoInterno == codigoInterno);

            if (resultQueryParamento != null)
            {
                var listado = await _parametroDetalleRepository.GetAllAsync(prop => prop.ParametroId == resultQueryParamento.IdParametro);

                if (listado != null)
                {
                    return new ResponseBase<List<ParametroDetalleDTO>>(HttpStatusCode.OK, "OK", _mapper.Map<List<ParametroDetalleDTO>>(listado), listado.Count());
                }
            }
            return new ResponseBase<List<ParametroDetalleDTO>>(HttpStatusCode.InternalServerError, "Ocurrio un error, No se puede listar los parametros", new List<ParametroDetalleDTO>(), 0);
        }

        public async Task<ResponseBase<List<ParametroDetalleDTO>>> listarPorCodigoInternoIdPadre(string codigoInterno, long idPadre)
        {
            var resultQueryParamento = await _parametroRepository.GetAsync(prop => prop.VcCodigoInterno == codigoInterno);

            if (resultQueryParamento != null)
            {
                var listado = await _parametroDetalleRepository.GetAllAsync(prop => prop.ParametroId == resultQueryParamento.IdParametro && prop.IdPadre == idPadre);

                if (listado != null)
                {
                    return new ResponseBase<List<ParametroDetalleDTO>>(HttpStatusCode.OK, "OK", _mapper.Map<List<ParametroDetalleDTO>>(listado), listado.Count());
                }

            }

            return new ResponseBase<List<ParametroDetalleDTO>>(HttpStatusCode.InternalServerError, "Ocurrio un error, No se puede listar los parametros", new List<ParametroDetalleDTO>(), 0);
        }


    }
}
