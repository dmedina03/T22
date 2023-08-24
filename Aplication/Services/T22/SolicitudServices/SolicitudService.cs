using Aplication.Services.T22.DocumentoSolicitudServices.Validation;
using Aplication.Utilities.Enum;
using AutoMapper;
using Domain.DTOs.Request.T22;
using Domain.DTOs.Response.Parametro;
using Domain.DTOs.Response.T22;
using Domain.Models.Parametro;
using Domain.Models.T22;
using Dominio.DTOs.Response.ResponseBase;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Persistence.Repository.IRepositories.Generic;
using Persistence.Repository.IRepositories.IParametroRepository;
using Persistence.Repository.IRepositories.IT22;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Aplication.Services.T22.SolicitudServices
{
    public class SolicitudService : ISolicitudService
    {
        private readonly ISolicitudRespository _solicitudRespository;
        private readonly ICapacitadorSolicitudRepository _capacitadorSolicitudRespository;
        private readonly IEstadoRepository _estadoRepository;
        private readonly IDocumentoSolicitudRepository _documentoSolicitudRepository;
        private readonly IParametroDetalleRepository _parametroDetalleRepository;
        private readonly IValidator<SolicitudDTORequest> _validatorSolicitud;
        private readonly IValidator<IEnumerable<DocumentoSolicitud>> _validatorDocumento;

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public SolicitudService(ISolicitudRespository solicitudRespository, IValidator<SolicitudDTORequest> validatorSolicitud, IMapper mapper,
            IUnitOfWork unitOfWork, ICapacitadorSolicitudRepository capacitadorSolicitudRespository, IDocumentoSolicitudRepository documentoSolicitudRepository,
            IValidator<IEnumerable<DocumentoSolicitud>> validatorDocumento, IEstadoRepository estadoRepository, IParametroDetalleRepository parametroDetalleRepository)
        {
            _solicitudRespository = solicitudRespository;
            _validatorSolicitud = validatorSolicitud;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _capacitadorSolicitudRespository = capacitadorSolicitudRespository;
            _documentoSolicitudRepository = documentoSolicitudRepository;
            _validatorDocumento = validatorDocumento;
            _estadoRepository = estadoRepository;
            _parametroDetalleRepository = parametroDetalleRepository;
        }
        public async Task<ResponseBase<bool>> CreateAsync(SolicitudDTORequest request)
        {
            var result = await _validatorSolicitud.ValidateAsync(request, opt => opt.IncludeRuleSets("Create"));
            if (!result.IsValid)
            {
                return new ResponseBase<bool>(HttpStatusCode.BadRequest, message: "Ocurrio un error, verifique nuevamente", result.ToDictionary());
            }

            var entitySolicitud = _mapper.Map<Solicitud>(request);

            await _solicitudRespository.AddAsync(entitySolicitud);

            if (entitySolicitud.CapacitadorSolicitud.Count() != request.CapacitadorSolicitud.Count())
            {
                return new ResponseBase<bool>(HttpStatusCode.BadRequest, message: "Ocurrio un error, verifique nuevamente", false);
            }
            //asignación de estado
            entitySolicitud.EstadoId = (int)EstadoEnum.EnRevision;

            await _unitOfWork.CommitAsync();

            List<DocumentoSolicitud> listaDocs = new();

            for (int i = 0; i < request.CapacitadorSolicitud.Count(); i++)
            {
                var capacitadorID = entitySolicitud.CapacitadorSolicitud.ElementAt(i).IdCapacitadorSolicitud;
                var solicitudID = entitySolicitud.CapacitadorSolicitud.ElementAt(i).SolicitudId;

                foreach (var doc in request.CapacitadorSolicitud.ElementAt(i).DocumentoSolicitud)
                {
                    listaDocs.Add(new DocumentoSolicitud
                    {
                        IdDocumento = doc.IdDocumento,
                        SolicitudId = solicitudID,
                        UsuarioId = capacitadorID,
                        TipoDocumentoId = doc.TipoDocumentoId,
                        VcNombreDocumento = doc.VcNombreDocumento,
                        DtFechaCargue = doc.DtFechaCargue,
                        VcPath = doc.VcPath,
                        IntVersion = doc.IntVersion,
                        BlUsuarioVentanilla = false,
                        BlIsValid = false
                    });

                }

            }
            result = await _validatorDocumento.ValidateAsync(listaDocs, opt => opt.IncludeRuleSets("Any"));

            if (!result.IsValid)
            {
                await _solicitudRespository.DeleteAsync(entitySolicitud.IdSolicitud);
                return new ResponseBase<bool>(HttpStatusCode.BadRequest, message: "Ocurrio un error, verifique nuevamente", result.ToDictionary());
            }

            await _documentoSolicitudRepository.AddRangeAsync(listaDocs);
            await _unitOfWork.CommitAsync();

            return new ResponseBase<bool>(HttpStatusCode.OK, "OK", true, default);


        }

        public async Task<ResponseBase<List<SolicitudBandejaCiudadanoDTOResponse>>> GetSolicitudesByRadicado(int usuarioId, string? radicado)
        {
            var query = (await _solicitudRespository.GetAllAsync(x => x.UsuarioId == usuarioId)).ToList();

            if (radicado != null)
            {
                query = query.Where(x => x.VcRadicado == radicado).ToList();
            }

            List<SolicitudBandejaCiudadanoDTOResponse> lista = new();

            foreach (var item in query)
            {

                lista.Add(new SolicitudBandejaCiudadanoDTOResponse
                {
                    IdSolcitud = item.IdSolicitud,
                    VcRadicado = item.VcRadicado,
                    VcEstado = (await _estadoRepository.GetAsync(x => x.IdEstado == item.EstadoId)).VcTipoEstado,
                    DtFechaSolicitud = item.DtFechaSolicitud.ToString("dd/MM/yyyy"),
                    VcNombreTramite = "Autorización para capacitadores de manipuladores de alimentos",
                    AccionesPermitidas = GetAccionesPermitidasByEstadoId(item.EstadoId),
                    TiempoAtencionRestante = ""
                });

            }

            return new ResponseBase<List<SolicitudBandejaCiudadanoDTOResponse>>(HttpStatusCode.OK, "OK", lista,lista.Count());

        }

        public async Task<ResponseBase<List<SolicitudBandejaSolicitudesDTOResponse>>> GetSolicitudesBandejaValidador(int? UsuarioAsignadoId)
        {

            var data = (_unitOfWork.GetSet<int,Solicitud>().FromSqlInterpolated($"EXEC ObtenerSolicitudesBandejaValidador {UsuarioAsignadoId}")).ToList();

            List<SolicitudBandejaSolicitudesDTOResponse> lista = new();

            foreach (var item in data)
            {
                lista.Add(new SolicitudBandejaSolicitudesDTOResponse
                {
                    IdSolicitud = item.IdSolicitud,
                    VcRadicado = item.VcRadicado,
                    VcNombreUsuario = item.VcNombreUsuario,
                    IntNumeroIdentificacionUsuario = item.IntNumeroIdentificacionUsuario,
                    VcTipoSolicitud = (await _parametroDetalleRepository.GetAsync(x => x.IdParametroDetalle == item.TipoSolicitudId)).VcNombre,
                    VcTipoSolicitante = item.VcTipoSolicitante,
                    DtFechaSolicitud = item.DtFechaSolicitud.ToString("dd/MM/yyyy"),
                    VcTipoEstado = (await _estadoRepository.GetAsync(x => x.IdEstado == item.EstadoId)).VcTipoEstado,
                    
                });
            }

            return new ResponseBase<List<SolicitudBandejaSolicitudesDTOResponse>>(HttpStatusCode.OK, "OK", lista, lista.Count());
        }
        public async Task<ResponseBase<List<SolicitudBandejaSolicitudesDTOResponse>>> GetSolicitudesBandejaCoordinador(int? UsuarioAsignadoId)
        {

            var data = (_unitOfWork.GetSet<int,Solicitud>().FromSqlInterpolated($"EXEC ObtenerSolicitudesBandejaCoordinador {UsuarioAsignadoId}")).ToList();
            //Falta poner el nombre de resultado de validación
            var lista = await MapToBandejaSolicitud(data);

            return new ResponseBase<List<SolicitudBandejaSolicitudesDTOResponse>>(HttpStatusCode.OK, "OK", lista, lista.Count());
        }
        public async Task<ResponseBase<List<SolicitudBandejaSolicitudesDTOResponse>>> GetSolicitudesBandejaSubdirector(int? UsuarioAsignadoId)
        {

            var data = (_unitOfWork.GetSet<int,Solicitud>().FromSqlInterpolated($"EXEC ObtenerSolicitudesBandejaSubdirector {UsuarioAsignadoId}")).ToList();
            //Falta poner el nombre de resultado de validación
            var lista = await MapToBandejaSolicitud(data);

            return new ResponseBase<List<SolicitudBandejaSolicitudesDTOResponse>>(HttpStatusCode.OK, "OK", lista, lista.Count());
        }

        public async Task<ResponseBase<object>> GetSolicitudById(int id)
        {
            return new ResponseBase<object>();
        }

        private async Task<List<SolicitudBandejaSolicitudesDTOResponse>> MapToBandejaSolicitud(List<Solicitud> data)
        {
            List<SolicitudBandejaSolicitudesDTOResponse> lista = new();

            foreach (var item in data)
            {
                lista.Add(new SolicitudBandejaSolicitudesDTOResponse
                {
                    IdSolicitud = item.IdSolicitud,
                    VcRadicado = item.VcRadicado,
                    VcNombreUsuario = item.VcNombreUsuario,
                    IntNumeroIdentificacionUsuario = item.IntNumeroIdentificacionUsuario,
                    VcTipoSolicitud = (await _parametroDetalleRepository.GetAsync(x => x.IdParametroDetalle == item.TipoSolicitudId)).VcNombre,
                    VcTipoSolicitante = item.VcTipoSolicitante,
                    DtFechaSolicitud = item.DtFechaSolicitud.ToString("dd/MM/yyyy"),
                    VcTipoEstado = $"{(await _estadoRepository.GetAsync(x => x.IdEstado == item.EstadoId)).VcTipoEstado}" +
                                    $" PONER NOMBRE DE RESULTADO DE VALIDACION",

                });
            }

            return lista;
        }
        private List<string> GetAccionesPermitidasByEstadoId(int EstadoId)
        {
            var lista = new List<string>();
            if (EstadoId == (int)EstadoEnum.Aprobado)
            {
                lista = new List<string> { "Descarga Resolución", "Generar Recurso" };
            }
            else if (EstadoId == (int)EstadoEnum.EnRevision || EstadoId == (int)EstadoEnum.EnVerificacion)
            {
                lista = new List<string> { "Ver detalle" };
            }
            else if (EstadoId == (int)EstadoEnum.EnSubsanacion)
            {
                lista = new List<string> { "Subsanar" };
            }
            else if (EstadoId == (int)EstadoEnum.Anulado)
            {
                lista = new List<string> { "Generar Recurso" };
            }
            return lista;
        }

    }
}
