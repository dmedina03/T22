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
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.IdentityModel.Tokens;
using Persistence.Repository.IRepositories.Generic;
using Persistence.Repository.IRepositories.IParametroRepository;
using Persistence.Repository.IRepositories.IT22;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Aplication.Services.T22.SolicitudServices
{
    public class SolicitudService : ISolicitudService
    {
        private readonly ISolicitudRespository _solicitudRespository;
        private readonly ICapacitadorSolicitudRepository _capacitadorSolicitudRespository;
        private readonly IEstadoRepository _estadoRepository;
        private readonly IDocumentoSolicitudRepository _documentoSolicitudRepository;
        private readonly IParametroDetalleRepository _parametroDetalleRepository;
        private readonly ITipoCapacitacionRepository _tipoCapacitacionRepository;
        private readonly ICapacitadorTipoCapacitacionRepository _capacitadorTipoCapacitacionRepository;
        private readonly ISeguimientoAuditoriaSolicitudRepository _seguimientoAuditoriaSolicitudRepository;
        private readonly ISubsanacionSolicitudRepository _subsanacionSolicitudRepository;
        private readonly IResolucionSolicitudRepository _resolucionSolicitudRepository;
        private readonly IValidator<SolicitudDTORequest> _validatorSolicitud;
        private readonly IValidator<IEnumerable<DocumentoSolicitud>> _validatorDocumento;
        private readonly IValidator<SolicitudRevisionValidadorDTORequest> _validatorSolicitudRevisionValidador;
        private readonly IValidator<SolicitudRevisionCoordinadorDTORequest> _validatorSolicitudRevisionCoordinador;
        private readonly IValidator<SolicitudRevisionSubdirectorDTORequest> _validatorSolicitudRevisionSubdirector;

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public SolicitudService(ISolicitudRespository solicitudRespository, IValidator<SolicitudDTORequest> validatorSolicitud, IMapper mapper,
            IUnitOfWork unitOfWork, ICapacitadorSolicitudRepository capacitadorSolicitudRespository, IDocumentoSolicitudRepository documentoSolicitudRepository,
            IValidator<IEnumerable<DocumentoSolicitud>> validatorDocumento, IEstadoRepository estadoRepository, IParametroDetalleRepository parametroDetalleRepository,
            ITipoCapacitacionRepository tipoCapacitacionRepository, ICapacitadorTipoCapacitacionRepository capacitadorTipoCapacitacionRepository,
            ISeguimientoAuditoriaSolicitudRepository seguimientoAuditoriaSolicitud, ISubsanacionSolicitudRepository subsanacionSolicitudRepository,
            IValidator<SolicitudRevisionValidadorDTORequest> validatorSolicitudRevisionValidador, IValidator<SolicitudRevisionCoordinadorDTORequest> validatorSolicitudRevisionCoordinadorSubdirector, 
            IResolucionSolicitudRepository resolucionSolicitudRepository, IValidator<SolicitudRevisionSubdirectorDTORequest> validatorSolicitudRevisionSubdirector)
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
            _tipoCapacitacionRepository = tipoCapacitacionRepository;
            _capacitadorTipoCapacitacionRepository = capacitadorTipoCapacitacionRepository;
            _subsanacionSolicitudRepository = subsanacionSolicitudRepository;
            _seguimientoAuditoriaSolicitudRepository = seguimientoAuditoriaSolicitud;
            _validatorSolicitudRevisionValidador = validatorSolicitudRevisionValidador;
            _validatorSolicitudRevisionCoordinador = validatorSolicitudRevisionCoordinadorSubdirector;
            _resolucionSolicitudRepository = resolucionSolicitudRepository;
            _validatorSolicitudRevisionSubdirector = validatorSolicitudRevisionSubdirector;
        }
        public async Task<ResponseBase<bool>> CreateAsync(SolicitudDTORequest request)
        {
            var result = await _validatorSolicitud.ValidateAsync(request, opt => opt.IncludeRuleSets("Create"));
            if (!result.IsValid)
            {
                return new ResponseBase<bool>(HttpStatusCode.BadRequest, message: "Ocurrio un error de validacion, verifique nuevamente.", result.ToDictionary());
            }

            var entitySolicitud = _mapper.Map<Solicitud>(request);

            await _solicitudRespository.AddAsync(entitySolicitud);

            if (entitySolicitud.CapacitadorSolicitud.Count() != request.CapacitadorSolicitud.Count())
            {
                return new ResponseBase<bool>(HttpStatusCode.BadRequest, message: "Ocurrio un error con la cantidad de capacitadores, verifique nuevamente", false);
            }
            //asignación de estado
            entitySolicitud.EstadoId = (int)EnumEstado.EnRevision;

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

            return new ResponseBase<bool>(HttpStatusCode.Created, "OK", true, default);


        }

        public async Task<ResponseBase<List<SolicitudBandejaCiudadanoDTOResponse>>> GetSolicitudesByRadicado(string usuarioId, string? radicado)
        {
            var query = (await _solicitudRespository.GetAllAsync(x => x.UsuarioId.ToString() == usuarioId));

            if (query is null)
            {
                return new ResponseBase<List<SolicitudBandejaCiudadanoDTOResponse>>(HttpStatusCode.NoContent,"La solicitud respondio bien, pero sin datos",null);
            }

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
                    VcNombreTramite = "Autorización para capacitadores de manipuladores de alimentos"
                });

            }

            return new ResponseBase<List<SolicitudBandejaCiudadanoDTOResponse>>(HttpStatusCode.OK, "OK", lista, lista.Count());

        }

        public async Task<ResponseBase<List<SolicitudBandejaSolicitudesDTOResponse>>> GetSolicitudesBandejaValidador(string? UsuarioAsignadoId)
        {

            var data = (_unitOfWork.GetSet<int, Solicitud>().FromSqlInterpolated($"EXEC manipalimentos.ObtenerSolicitudesBandejaValidador {UsuarioAsignadoId}")).ToList();

            if (data is null || data.Count == 0)
            {
                return new ResponseBase<List<SolicitudBandejaSolicitudesDTOResponse>>(HttpStatusCode.NoContent, "La solicitud respondio bien, pero sin datos", null);
            }

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
        public async Task<ResponseBase<List<SolicitudBandejaSolicitudesDTOResponse>>> GetSolicitudesBandejaCoordinador(string? UsuarioAsignadoId)
        {

            var data = (_unitOfWork.GetSet<int, Solicitud>().FromSqlInterpolated($"EXEC manipalimentos.ObtenerSolicitudesBandejaCoordinador {UsuarioAsignadoId}")).ToList();

            if (data is null || data.Count == 0)
            {
                return new ResponseBase<List<SolicitudBandejaSolicitudesDTOResponse>>(HttpStatusCode.NoContent, "La solicitud respondio bien, pero sin datos", null);
            }

            //Falta poner el nombre de resultado de validación
            var lista = await MapToBandejaSolicitud(data);

            return new ResponseBase<List<SolicitudBandejaSolicitudesDTOResponse>>(HttpStatusCode.OK, "OK", lista, lista.Count());
        }
        public async Task<ResponseBase<List<SolicitudBandejaSolicitudesDTOResponse>>> GetSolicitudesBandejaSubdirector(string? UsuarioAsignadoId)
        {

            var data = (_unitOfWork.GetSet<int, Solicitud>().FromSqlInterpolated($"EXEC manipalimentos.ObtenerSolicitudesBandejaSubdirector {UsuarioAsignadoId}")).ToList();

            if (data is null || data.Count == 0)
            {
                return new ResponseBase<List<SolicitudBandejaSolicitudesDTOResponse>>(HttpStatusCode.NoContent, "La solicitud respondio bien, pero sin datos", null);
            }

            //Falta poner el nombre de resultado de validación
            var lista = await MapToBandejaSolicitud(data);

            return new ResponseBase<List<SolicitudBandejaSolicitudesDTOResponse>>(HttpStatusCode.OK, "OK", lista, lista.Count());
        }

        public async Task<ResponseBase<SolicitudDTOResponse>> GetById(int SolicitudId)
        {
            var solicitud = await _solicitudRespository.GetAsync(x => x.IdSolicitud == SolicitudId, null, null, "CapacitadorSolicitud,SeguimientoAuditoriaSolicitud");
            
            if (solicitud is null)
            {
                return new ResponseBase<SolicitudDTOResponse>(HttpStatusCode.NoContent, "La solicitud respondio Ok pero sin datos", null, 0);

            }

            SolicitudDTOResponse solicitudDTOResponse = new SolicitudDTOResponse();

            solicitudDTOResponse.IdSolicitud = solicitud.IdSolicitud;
            solicitudDTOResponse.VcRadicado = solicitud.VcRadicado;
            solicitudDTOResponse.UsuarioId = solicitud.UsuarioId.ToString();
            solicitudDTOResponse.UsuarioAsignadoId = solicitud.UsuarioAsignadoId.ToString();
            solicitudDTOResponse.VcFechaSolicitud = solicitud.DtFechaSolicitud.ToString("yyyy-MM-dd");
            solicitudDTOResponse.VcEstado = (await _estadoRepository.GetAsync(x => x.IdEstado == solicitud.EstadoId)).VcTipoEstado;
            solicitudDTOResponse.VcTipoTramite = (await _parametroDetalleRepository.GetAsync(x => x.IdParametroDetalle == solicitud.TipoSolicitudId)).VcNombre;

            solicitudDTOResponse.CapacitadoresSolicitud = await GetCapacitadorSolicitudByCollection(solicitud.CapacitadorSolicitud);

            solicitudDTOResponse.SeguimientoAuditoriaSolicitud = await GetSeguimientoAuditoriaByCollection(solicitud.SeguimientoAuditoriaSolicitud);

            return new ResponseBase<SolicitudDTOResponse>(HttpStatusCode.OK,"OK",solicitudDTOResponse,1);
        }

        public async Task<ResponseBase<bool>> CreateRevisionValidador(SolicitudRevisionValidadorDTORequest request)
        {
            Solicitud solicitud = new Solicitud();
            //Valida el DTO
            var result = await _validatorSolicitudRevisionValidador.ValidateAsync(request, opt => opt.IncludeRuleSets("Any"));

            if (!result.IsValid)
            {
                return new ResponseBase<bool>(HttpStatusCode.BadRequest, "Errores de validación !",result.ToDictionary());
            }
            //consulta la solicitud en la BD para traer toda la informacion
            solicitud = await _solicitudRespository.GetAsync(x => x.IdSolicitud == request.IdSolicitud,null,null, "CapacitadorSolicitud");
            
            //Validad si existe o no la solicitud
            if (solicitud is null)
            {
                return new ResponseBase<bool>(HttpStatusCode.NoContent, "No existe una Solicitud relacionada a ese Id", true, 0);
            }
            //Valida si los capacitadores que esta validando dentro del DTO, sea la misma cantidad que los que estan en la BD
            if (solicitud.CapacitadorSolicitud.Count != request.CapacitadorSolicitud.Count)
            {
                return new ResponseBase<bool>(HttpStatusCode.BadRequest, "La cantidad de capacitadores en base de datos es diferente a la cantidad de capacitadores diligenciada.", null);
            }

            //Se valida que el estado de la solicitud sea el correcto para realizar la actualizacion de los campos
            if (solicitud.EstadoId != (int)EnumEstado.EnRevision && solicitud.EstadoId != (int)EnumEstado.DevueltaPorCoordinador && solicitud.EstadoId != (int)EnumEstado.Aprobado)
            {
                return new ResponseBase<bool>(HttpStatusCode.BadRequest, "La solicitud no se encuentra en el estado correcto, verifique nuevamente.", null);
            }

            if (request.UsuarioAsignadoId is not null)
            {
                solicitud.UsuarioAsignadoId = request.UsuarioAsignadoId;
                await _solicitudRespository.UpdateAsync(solicitud);
                await _unitOfWork.CommitAsync();
                return new ResponseBase<bool>(HttpStatusCode.OK, "Se ha asignado un nuevo usuario a la solicitud", true, 0);
            }
            else
            {
                solicitud.UsuarioAsignadoId = null;
            }


            //Estado actual de la solicitud
            var estadoId = solicitud.EstadoId;
            solicitud.ResultadoValidacionId = request.ResultadoValidacionId;

            if (estadoId == (int)EnumEstado.Aprobado)
            {
                if (request.CancelacionSolicitud is null)
                {
                    return new ResponseBase<bool>(HttpStatusCode.BadRequest, "El campo motivo de cancelacion no puede estar vacio",null);
                }
                else
                {

                    var cancelacion = _mapper.Map<CancelacionSolicitud>(request.CancelacionSolicitud);
                    cancelacion.EstadoId = estadoId;
                    //Asignacion de cancelacion por incumplimiento a la solicitud
                    solicitud.CancelacionIncumplimientoSolicitud = cancelacion;

                    //Asignacion de estado
                    solicitud.EstadoId = (int)EnumEstado.EnVerificacion;

                    await _solicitudRespository.UpdateAsync(solicitud);

                    await _unitOfWork.CommitAsync();

                    return new ResponseBase<bool>(HttpStatusCode.Created, "OK", true, 1);
                }
            }

            //Se da la validacion con respecto a los capacitadores
            foreach (var cap in request.CapacitadorSolicitud)
            {
                var capacitador = solicitud.CapacitadorSolicitud.Where(x => x.IdCapacitadorSolicitud.ToString().ToLower() == cap.IdCapacitadorSolicitud.ToLower() && x.SolicitudId == solicitud.IdSolicitud).FirstOrDefault();

                if (capacitador is null)
                {
                    return new ResponseBase<bool>(HttpStatusCode.BadRequest, "Error interno, comuniquese con el administrador del sistema.", null);
                }

                capacitador.BlIsValid = cap.BlIsValid;

            }

            List<SeguimientoAuditoriaSolicitud> listSeguimientoAuditoria = new List<SeguimientoAuditoriaSolicitud>();

            if (request.SeguimientoAuditoriaSolicitud is not null)
            {
                request.SeguimientoAuditoriaSolicitud.EstadoId = estadoId;
                SeguimientoAuditoriaSolicitud seguimientoAuditoriaSolicitud = _mapper.Map<SeguimientoAuditoriaSolicitud>(request.SeguimientoAuditoriaSolicitud);
                seguimientoAuditoriaSolicitud.SolicitudId = solicitud.IdSolicitud;

                //Asignacion de seguimiento y auditoria a la solicitud
                listSeguimientoAuditoria.Add(seguimientoAuditoriaSolicitud);
            }

            if (request.SubsanacionSolicitud is not null)
            {
                request.SubsanacionSolicitud.EstadoId = estadoId;
                SubsanacionSolicitud subsanacionSolicitud = _mapper.Map<SubsanacionSolicitud>(request.SubsanacionSolicitud);
                subsanacionSolicitud.SolicitudId = solicitud.IdSolicitud;

                //Asignacion de subsanacion a la solicitud
                solicitud.SubsanacionSolicitud = subsanacionSolicitud;
            }

            foreach (var docs in request.DocumentoSolicitud)
            {
                var documento = await _documentoSolicitudRepository.GetAsync(x => x.IdDocumento == docs.IdDocumento);
                documento.BlIsValid = docs.BlIsValid;

                //Actualizacion de los documentos en el campo isValid
                await _documentoSolicitudRepository.UpdateAsync(documento);
            }

            //Asignacion de estado
            solicitud.EstadoId = (int)EnumEstado.EnVerificacion;

            //Asignacion de auditoria seguimiento
            solicitud.SeguimientoAuditoriaSolicitud = listSeguimientoAuditoria;

            await _solicitudRespository.UpdateAsync(solicitud);
            await _unitOfWork.CommitAsync();

            return new ResponseBase<bool>(HttpStatusCode.Created, "OK", true, 1);

        }
        public async Task<ResponseBase<bool>> CreateRevisionCoordinador(SolicitudRevisionCoordinadorDTORequest request)
        {
            Solicitud solicitud = new Solicitud();

            //Valida el DTO
            var result = await _validatorSolicitudRevisionCoordinador.ValidateAsync(request, opt => opt.IncludeRuleSets("Any"));

            if (!result.IsValid)
            {
                return new ResponseBase<bool>(HttpStatusCode.BadRequest, "Errores de validación !",result.ToDictionary());
            }

            //consulta la solicitud en la BD para traer toda la informacion
            solicitud = await _solicitudRespository.GetAsync(x => x.IdSolicitud == request.IdSolicitud,null,null, "CapacitadorSolicitud");

            //Validad si existe o no la solicitud
            if (solicitud is null)
            {
                return new ResponseBase<bool>(HttpStatusCode.NoContent, "No existe una Solicitud relacionada a ese Id", true, 0);
            }

            //Valida si los capacitadores que esta validando dentro del DTO, sea la misma cantidad que los que estan en la BD
            if (solicitud.CapacitadorSolicitud.Count != request.CapacitadorSolicitud.Count)
            {
                return new ResponseBase<bool>(HttpStatusCode.BadRequest, "La cantidad de capacitadores en base de datos es diferente a la cantidad de capacitadores diligenciada.|", null);
            }

            //Se valida que el estado de la solicitud sea el correcto para realizar la actualizacion de los campos
            if (solicitud.EstadoId != (int)EnumEstado.EnVerificacion && solicitud.EstadoId != (int)EnumEstado.DevueltaPorSubdirector)
            {
                return new ResponseBase<bool>(HttpStatusCode.BadRequest, "La solicitud no se encuentra en el estado correcto, verifique nuevamente.", null);
            }

            //Si el usuario asignado no es nulo, se asigna al usuario correspondiente y se envia así la solicitud, aun en esta En Verficacion
            if (request.UsuarioAsignadoId is not null)
            {
                solicitud.UsuarioAsignadoId = request.UsuarioAsignadoId;
                await _solicitudRespository.UpdateAsync(solicitud);
                await _unitOfWork.CommitAsync();
                return new ResponseBase<bool>(HttpStatusCode.OK, "Se ha asignado un nuevo usuario a la solicitud", true, 0);
            }
            else
            {
                solicitud.UsuarioAsignadoId = null;
            }


            //Estado actual de la solicitud
            var estadoId = solicitud.EstadoId;

            //Se da la validacion con respecto a los capacitadores
            foreach (var cap in request.CapacitadorSolicitud)
            {
                var capacitador = solicitud.CapacitadorSolicitud.Where(x => x.IdCapacitadorSolicitud.ToString().ToLower() == cap.IdCapacitadorSolicitud.ToLower() && x.SolicitudId == solicitud.IdSolicitud).FirstOrDefault();

                if (capacitador is null)
                {
                    return new ResponseBase<bool>(HttpStatusCode.BadRequest, "Error interno, comuniquese con el administrador del sistema.", null);
                }

                capacitador.BlIsValid = cap.BlIsValid;

            }

            List<SeguimientoAuditoriaSolicitud> listSeguimientoAuditoria = new List<SeguimientoAuditoriaSolicitud>();
            if (request.SeguimientoAuditoriaSolicitud is not null)
            {
                request.SeguimientoAuditoriaSolicitud.EstadoId = estadoId;
                SeguimientoAuditoriaSolicitud seguimientoAuditoriaSolicitud = _mapper.Map<SeguimientoAuditoriaSolicitud>(request.SeguimientoAuditoriaSolicitud);
                seguimientoAuditoriaSolicitud.SolicitudId = solicitud.IdSolicitud;

                //Asignacion de seguimiento y auditoria a la solicitud
                listSeguimientoAuditoria.Add(seguimientoAuditoriaSolicitud);
            }

            //Se da la validacion a los documentos
            foreach (var docs in request.DocumentoSolicitud)
            {
                var documento = await _documentoSolicitudRepository.GetAsync(x => x.IdDocumento == docs.IdDocumento);

                documento.BlIsValid = docs.BlIsValid;

                await _documentoSolicitudRepository.UpdateAsync(documento);
            }

            //Asignacion de estado
            if (request.ResultadoValidacion)
            {
                solicitud.EstadoId = (int)EnumEstado.ParaFirma;
            }
            else
            {
                solicitud.EstadoId = (int)EnumEstado.DevueltaPorCoordinador;
            }

            //Asignacion de auditoria seguimiento
            solicitud.SeguimientoAuditoriaSolicitud = listSeguimientoAuditoria;

            await _solicitudRespository.UpdateAsync(solicitud);
            await _unitOfWork.CommitAsync();

            return new ResponseBase<bool>(HttpStatusCode.Created, "OK", true, 1);

        }
        public async Task<ResponseBase<bool>> CreateRevisionSubdirector(SolicitudRevisionSubdirectorDTORequest request)
        {
            Solicitud solicitud = new Solicitud();

            var result = await _validatorSolicitudRevisionSubdirector.ValidateAsync(request, opt => opt.IncludeRuleSets("Any"));

            if (!result.IsValid)
            {
                return new ResponseBase<bool>(HttpStatusCode.BadRequest, "Errores de validación !", result.ToDictionary());
            }

            solicitud = await _solicitudRespository.GetAsync(x => x.IdSolicitud == request.IdSolicitud,null,null, "CapacitadorSolicitud");

            if (solicitud.CapacitadorSolicitud.Count != request.CapacitadorSolicitud.Count)
            {
                return new ResponseBase<bool>(HttpStatusCode.BadRequest, "La cantidad de capacitadores en base de datos es diferente a la cantidad de capacitadores diligenciada.|", null);
            }

            //Se valida que el estado de la solicitud sea el correcto para realizar la actualizacion de los campos
            if (solicitud.EstadoId != (int)EnumEstado.ParaFirma)
            {
                return new ResponseBase<bool>(HttpStatusCode.BadRequest, "La solicitud no se encuentra en el estado correcto, verifique nuevamente.", null);
            }

            if (solicitud is null)
            {
                return new ResponseBase<bool>(HttpStatusCode.NoContent, "No existe una Solicitud relacionada a ese Id", true, 0);
            }

            if (request.UsuarioAsignadoId is not null)
            {
                solicitud.UsuarioAsignadoId = request.UsuarioAsignadoId;
                await _solicitudRespository.UpdateAsync(solicitud);
                await _unitOfWork.CommitAsync();
                return new ResponseBase<bool>(HttpStatusCode.OK, "Se ha asignado un nuevo usuario a la solicitud", true, 0);
            }
            else
            {
                solicitud.UsuarioAsignadoId = null;
            }

            //Estado actual de la solicitud
            var estadoId = solicitud.EstadoId;

            //asignacion de validacion a los capacitadores de la solicitud
            foreach (var cap in request.CapacitadorSolicitud)
            {
                var capacitador = solicitud.CapacitadorSolicitud.Where(x => x.IdCapacitadorSolicitud.ToString().ToLower() == cap.IdCapacitadorSolicitud.ToLower() && x.SolicitudId == solicitud.IdSolicitud).FirstOrDefault();

                if (capacitador is null)
                {
                    return new ResponseBase<bool>(HttpStatusCode.BadRequest, "Error interno, comuniquese con el administrador del sistema.", null);
                }

                capacitador.BlIsValid = cap.BlIsValid;

            }

            List<SeguimientoAuditoriaSolicitud> listSeguimientoAuditoria = new List<SeguimientoAuditoriaSolicitud>();
            if (request.SeguimientoAuditoriaSolicitud is not null)
            {
                request.SeguimientoAuditoriaSolicitud.EstadoId = estadoId;
                SeguimientoAuditoriaSolicitud seguimientoAuditoriaSolicitud = _mapper.Map<SeguimientoAuditoriaSolicitud>(request.SeguimientoAuditoriaSolicitud);
                seguimientoAuditoriaSolicitud.SolicitudId = solicitud.IdSolicitud;

                //Asignacion de seguimiento y auditoria a la solicitud
                listSeguimientoAuditoria.Add(seguimientoAuditoriaSolicitud);
            }

            foreach (var docs in request.DocumentoSolicitud)
            {
                var documento = await _documentoSolicitudRepository.GetAsync(x => x.IdDocumento == docs.IdDocumento);

                documento.BlIsValid = docs.BlIsValid;

                await _documentoSolicitudRepository.UpdateAsync(documento);
            }

            int TipoResolucion = 0;

            if (solicitud.TipoSolicitudId == (int)EnumTipoSolicitud.Modificacion && solicitud.ResultadoValidacionId == (int)EnumResultadoValidacion.Aprobación)
            {
                solicitud.EstadoId = (int)EnumEstado.Aprobado;
                TipoResolucion = (int)EnumTipoResolucion.ResolucionModificacion;
            }
            else
            {
                //Asignacion de estado
                if (request.ResultadoValidacion)
                {
                    if (solicitud.ResultadoValidacionId == (int)EnumResultadoValidacion.Aprobación)
                    {
                        solicitud.EstadoId = (int)EnumEstado.Aprobado;
                        TipoResolucion = (int)EnumTipoResolucion.ResolucionAprobacion;
                    }
                    else if (solicitud.ResultadoValidacionId == (int)EnumResultadoValidacion.Cancelación)
                    {
                        solicitud.EstadoId = (int)EnumEstado.Cancelado;
                        TipoResolucion = (int)EnumTipoResolucion.ResolucionCancelacion;

                    }
                    else if (solicitud.ResultadoValidacionId == (int)EnumResultadoValidacion.Negación)
                    {
                        solicitud.EstadoId = (int)EnumEstado.Negado;
                        TipoResolucion = (int)EnumTipoResolucion.ResolucionNegacion;

                    }
                    else if (solicitud.ResultadoValidacionId == (int)EnumResultadoValidacion.Subsanación)
                    {
                        solicitud.EstadoId = (int)EnumEstado.EnSubsanacion;
                    }
                    else if (solicitud.ResultadoValidacionId == (int)EnumResultadoValidacion.CancelaciónIncumplimiento)
                    {
                        solicitud.EstadoId = (int)EnumEstado.CanceladoPorInclumplimiento;
                        TipoResolucion = (int)EnumTipoResolucion.ResolucionCancelacionPorInclumplimiento;

                    }
                }
                else
                {
                    solicitud.EstadoId = (int)EnumEstado.DevueltaPorSubdirector;
                }
            }

            
            //Asignacion de auditoria seguimiento
            solicitud.SeguimientoAuditoriaSolicitud = listSeguimientoAuditoria;

            ResolucionSolicitud resolucionSolicitud = new ResolucionSolicitud();
            List<ResolucionSolicitud> listResolucionSolicitud = new List<ResolucionSolicitud>();
            DocumentoSolicitud documentoSolicitudResolucion = new DocumentoSolicitud();

            if (request.ResolucionSolicitud is not null)
            {
                if (request.ResolucionSolicitud.DocumentoResolucion is not null)
                {
                    bool UsuarioVentanilla = true;

                    documentoSolicitudResolucion.SolicitudId = solicitud.IdSolicitud;
                    documentoSolicitudResolucion.UsuarioId = Guid.Parse(request.ResolucionSolicitud.DocumentoResolucion.UsuarioId);
                    documentoSolicitudResolucion.TipoDocumentoId = request.ResolucionSolicitud.DocumentoResolucion.TipoDocumentoId;
                    documentoSolicitudResolucion.VcNombreDocumento = request.ResolucionSolicitud.DocumentoResolucion.VcNombreDocumento;
                    documentoSolicitudResolucion.DtFechaCargue = request.ResolucionSolicitud.DocumentoResolucion.DtFechaCargue;
                    documentoSolicitudResolucion.VcPath = request.ResolucionSolicitud.DocumentoResolucion.VcPath;
                    documentoSolicitudResolucion.IntVersion = request.ResolucionSolicitud.DocumentoResolucion.IntVersion;
                    
                    //El campo es true, por que el usuario generador del documento, es usuario ventanilla
                    documentoSolicitudResolucion.BlUsuarioVentanilla = UsuarioVentanilla;

                    //Es valido por defecto, ya que el documento no necesita revisión
                    documentoSolicitudResolucion.BlIsValid = true;

                }
                else
                {
                    return new ResponseBase<bool>(HttpStatusCode.BadRequest, "La información del documento generado por la solicitud es obligatoria", null);
                }

                resolucionSolicitud.SolicitudId = solicitud.IdSolicitud;
                //revisar que tipo de resolucion se va a generar de acuerdo al resultado de validación otorgado
                resolucionSolicitud.TipoResolucionId = TipoResolucion;
                resolucionSolicitud.FechaResolucion = request.ResolucionSolicitud.FechaResolucion;
                //La resolución estara activa por defecto, tras pasar 1 año, ya quedará inactiva
                resolucionSolicitud.BlActiva = true;
                //Numero de resolucion
                resolucionSolicitud.IntNumeroResolucion = await GetNumeroResolucion();
            }

            //Se almacena la informacion del documento generado por la resolución
            await _documentoSolicitudRepository.AddAsync(documentoSolicitudResolucion);

            //Se almacena la informacion actualizada de la solicitud
            await _solicitudRespository.UpdateAsync(solicitud);

            //Se realizan cambios sobre todas las acciones
            await _unitOfWork.CommitAsync();

            //Asignacion del id del documento a la resolucion
            resolucionSolicitud.DocumentoSolicitudId = documentoSolicitudResolucion.IdDocumento;

            //Se almacena la informacion actualizada de la resolucion
            await _resolucionSolicitudRepository.AddAsync(resolucionSolicitud);

            //Se realizan cambios sobre todas las acciones
            await _unitOfWork.CommitAsync();


            return new ResponseBase<bool>(HttpStatusCode.Created, "OK", true, 1);

        }

        private async Task<List<DocumentosSolicitudDTOResponse>> GetDocumentosSolicitudByCapacitadorSolicitudId(string capacitadorSolicitudId)
        {
            bool isUsuarioVentanilla = false;
            var documentos = (await _documentoSolicitudRepository.GetAllAsync(x => x.UsuarioId.ToString() == capacitadorSolicitudId.ToString() && x.BlUsuarioVentanilla == isUsuarioVentanilla )).ToList();
            List<DocumentosSolicitudDTOResponse> lista = new();
            foreach (var documento in documentos)
            {
                lista.Add(new DocumentosSolicitudDTOResponse
                {

                    IdDocumento = documento.IdDocumento,
                    VcTipoDocumento = (await _parametroDetalleRepository.GetAsync(p => p.IdParametroDetalle == documento.TipoDocumentoId)).VcNombre,
                    VcPath = documento.VcPath,
                    BlIsValid = documento.BlIsValid
                });
            }
            return lista;
        }

        private async Task<List<CapacitadorSolicitudDTOResponse>> GetCapacitadorSolicitudByCollection(ICollection<CapacitadorSolicitud> capacitadores)
        {

            List<CapacitadorSolicitudDTOResponse> lista = new();

            foreach (var capacitador in capacitadores)
            {
                lista.Add(new CapacitadorSolicitudDTOResponse
                {
                    IdCapacitadorSolicitud = capacitador.IdCapacitadorSolicitud.ToString(),
                    SolicitudId = capacitador.SolicitudId,
                    VcPrimerNombre = capacitador.VcPrimerNombre,
                    VcSegundoNombre = capacitador.VcSegundoNombre,
                    VcPrimerApellido = capacitador.VcPrimerApellido,
                    VcSegundoApellido = capacitador.VcSegundoApellido,
                    VcTipoIdentificacion = (await _parametroDetalleRepository.GetAsync(p => p.IdParametroDetalle == capacitador.TipoIdentificacionId)).VcNombre,
                    IntNumeroIdentificacion = capacitador.IntNumeroIdentificacion,
                    VcTituloProfesional = capacitador.VcTituloProfesional,
                    vcNumeroTarjetaProfesional = capacitador.vcNumeroTarjetaProfesional,
                    IntTelefono = capacitador.IntTelefono,
                    VcEmail = capacitador.VcEmail,
                    CapacitadorTipoCapacitacion = await GetCapacitadorTipoCapacitacionByCapacitadorId(capacitador.IdCapacitadorSolicitud.ToString()),
                    DocumentosSolicitud = await GetDocumentosSolicitudByCapacitadorSolicitudId(capacitador.IdCapacitadorSolicitud.ToString())
                });
            }

            return lista;
        }
        private async Task<List<CapacitadorTipoCapacitacionDTOResponse>> GetCapacitadorTipoCapacitacionByCapacitadorId(string capacitadorId)
        {
            var collections = await _capacitadorTipoCapacitacionRepository.GetAllAsync(x => x.IdCapacitadorSolicitud == Guid.Parse(capacitadorId));

            List<CapacitadorTipoCapacitacionDTOResponse> lista = new();

            foreach (var item in collections)
            {
                lista.Add(new CapacitadorTipoCapacitacionDTOResponse
                {
                    VcTipoCapacitacion = (await _tipoCapacitacionRepository.GetAsync(c => c.IdTipoCapacitacion == item.IdTipoCapacitacion)).VcDescripcion,
                    IdCapacitadorSolicitud = item.IdCapacitadorSolicitud.ToString()
                });
            }
            return lista;
        }

        private async Task<List<SeguimientoAuditoriaSolicitudDTOResponse>> GetSeguimientoAuditoriaByCollection(ICollection<SeguimientoAuditoriaSolicitud> seguimientoAuditorias)
        {
            List<SeguimientoAuditoriaSolicitudDTOResponse> lista = new();
            foreach (var seguimiento in seguimientoAuditorias)
            {
                lista.Add(new SeguimientoAuditoriaSolicitudDTOResponse
                {
                    IdObservacion = seguimiento.IdObservacion,
                    UsuarioId = seguimiento.UsuarioId.ToString(),
                    VcNombreUsuario = seguimiento.VcNombreUsuario,
                    DtFechaObservacion = seguimiento.DtFechaObservacion.ToString("yyyy-MM-dd"),
                    VcEstado = (await _estadoRepository.GetAsync(p => p.IdEstado == seguimiento.EstadoId)).VcTipoEstado,
                    VcObservacion = seguimiento.VcObservacion
                });
            }
            return lista;
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
                                    $" - {(await _parametroDetalleRepository.GetAsync(x => x.IdParametroDetalle == item.ResultadoValidacionId)).TxDescripcion}"

                });
            }

            return lista;
        }
        private async Task<long> GetNumeroResolucion()
        {
            var year = DateTime.UtcNow.AddHours(-5).Year;

            long numeroResolucion = 0;

            var ultimoNumero = (await _resolucionSolicitudRepository.GetAllAsync(x => x.FechaResolucion.Year == year, 
                                x => x.OrderByDescending(p => p.IntNumeroResolucion))).FirstOrDefault();

            if (ultimoNumero is not null)
            {
                numeroResolucion = ultimoNumero.IntNumeroResolucion + 1;
            }
            else
            {
                numeroResolucion = 1;
            }

            return numeroResolucion;

        }
        public Task<ResponseBase<List<SolicitudDTOResponse>>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
