using Aplication.Services.Parametro;
using Aplication.Services.T22.DocumentoSolicitudServices.Validation;
using Aplication.Utilities.Enum;
using AutoMapper;
using Domain.DTOs.Request.T22;
using Domain.DTOs.Response.Parametro;
using Domain.DTOs.Response.T22;
using Domain.Models;
using Domain.Models.Parametro;
using Domain.Models.T22;
using Dominio.DTOs.Response.ResponseBase;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.IdentityModel.Tokens;
using Persistence.Context;
using Persistence.Repository.IRepositories.Generic;
using Persistence.Repository.IRepositories.IParametroRepository;
using Persistence.Repository.IRepositories.IT22;
using Persistence.Repository.Repositories.ParametroRepository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Aplication.Services.T22.SolicitudServices
{
    public class SolicitudService : ISolicitudService
    {
#pragma warning disable
        private readonly ISolicitudRespository _solicitudRespository;
        private readonly IEstadoRepository _estadoRepository;
        private readonly IDocumentoSolicitudRepository _documentoSolicitudRepository;
        private readonly IParametroDetalleRepository _parametroDetalleRepository;
        private readonly IParametroDetalleService _parametroService;
        private readonly ITipoCapacitacionRepository _tipoCapacitacionRepository;
        private readonly ICapacitadorTipoCapacitacionRepository _capacitadorTipoCapacitacionRepository;
        private readonly IResolucionSolicitudRepository _resolucionSolicitudRepository;
        private readonly IValidator<SolicitudDtoRequest> _validatorSolicitud;
        private readonly IValidator<IEnumerable<DocumentoSolicitud>> _validatorDocumento;
        private readonly IValidator<IEnumerable<DocumentoSolicitudDtoRequest>> _validatorIenumerableDocumento;
        private readonly IValidator<SolicitudRevisionValidadorDtoRequest> _validatorSolicitudRevisionValidador;
        private readonly IValidator<SolicitudRevisionCoordinadorDtoRequest> _validatorSolicitudRevisionCoordinador;
        private readonly IValidator<SolicitudRevisionSubdirectorDtoRequest> _validatorSolicitudRevisionSubdirector;

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _context;

        public SolicitudService(ISolicitudRespository solicitudRespository, IValidator<SolicitudDtoRequest> validatorSolicitud, IMapper mapper,
            IUnitOfWork unitOfWork, IDocumentoSolicitudRepository documentoSolicitudRepository,
            IValidator<IEnumerable<DocumentoSolicitud>> validatorDocumento, IEstadoRepository estadoRepository, IParametroDetalleRepository parametroDetalleRepository,
            ITipoCapacitacionRepository tipoCapacitacionRepository, ICapacitadorTipoCapacitacionRepository capacitadorTipoCapacitacionRepository,
            IValidator<SolicitudRevisionValidadorDtoRequest> validatorSolicitudRevisionValidador, IValidator<SolicitudRevisionCoordinadorDtoRequest> validatorSolicitudRevisionCoordinadorSubdirector, 
            IResolucionSolicitudRepository resolucionSolicitudRepository, IValidator<SolicitudRevisionSubdirectorDtoRequest> validatorSolicitudRevisionSubdirector,
            IParametroDetalleService parametroService, IValidator<IEnumerable<DocumentoSolicitudDtoRequest>> validatorIenumerableDocumento, ApplicationDbContext context)
        {
            _solicitudRespository = solicitudRespository;
            _validatorSolicitud = validatorSolicitud;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _documentoSolicitudRepository = documentoSolicitudRepository;
            _validatorDocumento = validatorDocumento;
            _estadoRepository = estadoRepository;
            _parametroDetalleRepository = parametroDetalleRepository;
            _tipoCapacitacionRepository = tipoCapacitacionRepository;
            _capacitadorTipoCapacitacionRepository = capacitadorTipoCapacitacionRepository;
            _validatorSolicitudRevisionValidador = validatorSolicitudRevisionValidador;
            _validatorSolicitudRevisionCoordinador = validatorSolicitudRevisionCoordinadorSubdirector;
            _resolucionSolicitudRepository = resolucionSolicitudRepository;
            _validatorSolicitudRevisionSubdirector = validatorSolicitudRevisionSubdirector;
            _parametroService = parametroService;
            _validatorIenumerableDocumento = validatorIenumerableDocumento;
            _context = context;
        }
        public async Task<ResponseBase<bool>> CreateAsync(SolicitudDtoRequest request)
        {
            var result = await _validatorSolicitud.ValidateAsync(request, opt => opt.IncludeRuleSets("Create"));
            if (!result.IsValid)
            {
                return new ResponseBase<bool>(HttpStatusCode.BadRequest, message: "Ocurrio un error de validacion, verifique nuevamente.", result.ToDictionary());
            }

            var entitySolicitud = _mapper.Map<Solicitud>(request);

            await _solicitudRespository.AddAsync(entitySolicitud);

            if (entitySolicitud.CapacitadorSolicitud.Count != request.CapacitadorSolicitud.Count())
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

        public async Task<ResponseBase<List<SolicitudBandejaCiudadanoDtoResponse>>> GetSolicitudesByRadicado(string usuarioId, string? radicado)
        {
            var query = (await _solicitudRespository.GetAllAsync(x => x.UsuarioId.ToString() == usuarioId));

            if (query is null)
            {
                return new ResponseBase<List<SolicitudBandejaCiudadanoDtoResponse>>(HttpStatusCode.NoContent,"La solicitud respondio bien, pero sin datos",null);
            }

            if (radicado != null)
            {
                query = query.Where(x => x.VcRadicado == radicado).ToList();
            }

            List<SolicitudBandejaCiudadanoDtoResponse> lista = new();

            foreach (var item in query)
            {

                lista.Add(new SolicitudBandejaCiudadanoDtoResponse
                {
#pragma warning disable // Desreferencia de una referencia posiblemente NULL.
                    IdSolcitud = item.IdSolicitud,
                    VcRadicado = item.VcRadicado,
                    VcEstado = (await _estadoRepository.GetAsync(x => x.IdEstado == item.EstadoId)).VcTipoEstado,
                    DtFechaSolicitud = item.DtFechaSolicitud.ToString("dd/MM/yyyy"),
                    VcNombreTramite = "Autorización para capacitadores de manipuladores de alimentos"
                });

            }

            return new ResponseBase<List<SolicitudBandejaCiudadanoDtoResponse>>(HttpStatusCode.OK, "OK", lista, lista.Count);

        }

        public async Task<ResponseBase<List<SpBandejaFuncionarioDto>>> GetSolicitudesBandejaValidador(string? UsuarioAsignadoId)
        {

            var spNuevo = (_unitOfWork.GetSet<int, SpBandejaFuncionarioDto>().FromSqlInterpolated($"EXEC manipalimentos.ObtenerSolicitudesBandejaValidador {UsuarioAsignadoId}")).ToList();

            if (spNuevo is null || spNuevo.Count == 0)
            {
                return new ResponseBase<List<SpBandejaFuncionarioDto>>(HttpStatusCode.NoContent, "La solicitud respondio bien, pero sin datos", null);
            }

            return new ResponseBase<List<SpBandejaFuncionarioDto>>(HttpStatusCode.OK, "OK", spNuevo, spNuevo.Count);
        }
        public async Task<ResponseBase<List<SpBandejaFuncionarioDto>>> GetSolicitudesBandejaCoordinador(string? UsuarioAsignadoId)
        {

            var spNuevo = (_unitOfWork.GetSet<int, SpBandejaFuncionarioDto>().FromSqlInterpolated($"EXEC manipalimentos.ObtenerSolicitudesBandejaCoordinador {UsuarioAsignadoId}")).ToList();

            if (spNuevo is null || spNuevo.Count == 0)
            {
                return new ResponseBase<List<SpBandejaFuncionarioDto>>(HttpStatusCode.NoContent, "La solicitud respondio bien, pero sin datos", null);
            }

            foreach (var item in spNuevo)
            {
                var solicitudResuladoValidacion = (await _solicitudRespository.GetAsync(x => x.IdSolicitud == item.IdSolicitud)).ResultadoValidacionId;

                item.VcTipoEstado = $"{item.VcTipoEstado}" +
                                    $" - {(await _parametroDetalleRepository.GetAsync(x => x.IdParametroDetalle == solicitudResuladoValidacion)).TxDescripcion}";
                
            }

            return new ResponseBase<List<SpBandejaFuncionarioDto>>(HttpStatusCode.OK, "OK", spNuevo, spNuevo.Count);
        }
        public async Task<ResponseBase<List<SpBandejaFuncionarioDto>>> GetSolicitudesBandejaSubdirector(string? UsuarioAsignadoId)
        {
            var spNuevo = (_unitOfWork.GetSet<int, SpBandejaFuncionarioDto>().FromSqlInterpolated($"EXEC manipalimentos.ObtenerSolicitudesBandejaSubdirector {UsuarioAsignadoId}")).ToList();

            if (spNuevo is null || spNuevo.Count == 0)
            {
                return new ResponseBase<List<SpBandejaFuncionarioDto>>(HttpStatusCode.NoContent, "La solicitud respondio bien, pero sin datos", null);
            }

            foreach (var item in spNuevo)
            {
                var solicitudResuladoValidacion = (await _solicitudRespository.GetAsync(x => x.IdSolicitud == item.IdSolicitud)).ResultadoValidacionId;

                item.VcTipoEstado = $"{item.VcTipoEstado}" +
                                    $" - {(await _parametroDetalleRepository.GetAsync(x => x.IdParametroDetalle == solicitudResuladoValidacion)).TxDescripcion}";

            }

            return new ResponseBase<List<SpBandejaFuncionarioDto>>(HttpStatusCode.OK, "OK", spNuevo, spNuevo.Count);
        }

        public async Task<ResponseBase<SolicitudDtoResponse>> GetById(int Id)
        {
            var solicitud = await _solicitudRespository.GetAsync(x => x.IdSolicitud == Id, null, null, "CapacitadorSolicitud,SeguimientoAuditoriaSolicitud,ResolucionSolicitud");
            
            if (solicitud is null)
            {
                return new ResponseBase<SolicitudDtoResponse>(HttpStatusCode.NoContent, "La solicitud respondio Ok pero sin datos", null, 0);

            }

            SolicitudDtoResponse solicitudDTOResponse = new SolicitudDtoResponse();

            solicitudDTOResponse.IdSolicitud = solicitud.IdSolicitud;
            solicitudDTOResponse.VcRadicado = solicitud.VcRadicado;
            solicitudDTOResponse.UsuarioId = solicitud.UsuarioId.ToString();
            solicitudDTOResponse.UsuarioAsignadoValidadorId = solicitud.UsuarioAsignadoValidadorId.ToString();
            solicitudDTOResponse.UsuarioAsignadoCoordinadorId = solicitud.UsuarioAsignadoCoordinadorId.ToString();
            solicitudDTOResponse.UsuarioAsignadoSubdirectorId = solicitud.UsuarioAsignadoSubdirectorId.ToString();
            solicitudDTOResponse.VcFechaSolicitud = solicitud.DtFechaSolicitud.ToString("yyyy-MM-dd");
            solicitudDTOResponse.VcEstado = (await _estadoRepository.GetAsync(x => x.IdEstado == solicitud.EstadoId)).VcTipoEstado;
            solicitudDTOResponse.VcTipoTramite = (await _parametroDetalleRepository.GetAsync(x => x.IdParametroDetalle == solicitud.TipoSolicitudId)).VcNombre;

            solicitudDTOResponse.CapacitadoresSolicitud = await GetCapacitadorSolicitudByCollection(solicitud.CapacitadorSolicitud);

            solicitudDTOResponse.ResolucionSolicitudes = await GetResolucionSolicitudesByCollection(solicitud.ResolucionSolicitud);

            solicitudDTOResponse.SeguimientoAuditoriaSolicitud = await GetSeguimientoAuditoriaByCollection(solicitud.SeguimientoAuditoriaSolicitud);
            solicitudDTOResponse.DocumentosRecursoReposicion = await GetDocumentoRecursosSolicitud(solicitud.IdSolicitud);

            return new ResponseBase<SolicitudDtoResponse>(HttpStatusCode.OK,"OK",solicitudDTOResponse,1);
        }

        public async Task<ResponseBase<bool>> CreateRevisionValidador(SolicitudRevisionValidadorDtoRequest request)
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

            if (request.Asignado)
            {
                solicitud.UsuarioAsignadoValidadorId = request.UsuarioAsignadoId;
                await _solicitudRespository.UpdateAsync(solicitud);
                await _unitOfWork.CommitAsync();
                return new ResponseBase<bool>(HttpStatusCode.OK, "Se ha asignado un nuevo usuario a la solicitud", true, 0);
            }
            else
            {
                solicitud.UsuarioAsignadoValidadorId = request.UsuarioAsignadoId;
            }


            //Estado actual de la solicitud
            var estadoId = solicitud.EstadoId;
            solicitud.ResultadoValidacionId = request.ResultadoValidacionId;


            List<SeguimientoAuditoriaSolicitud> listSeguimientoAuditoria = new List<SeguimientoAuditoriaSolicitud>();

            if (request.SeguimientoAuditoriaSolicitud is not null)
            {
                request.SeguimientoAuditoriaSolicitud.EstadoId = estadoId;
                SeguimientoAuditoriaSolicitud seguimientoAuditoriaSolicitud = _mapper.Map<SeguimientoAuditoriaSolicitud>(request.SeguimientoAuditoriaSolicitud);
                seguimientoAuditoriaSolicitud.SolicitudId = solicitud.IdSolicitud;

                //Asignacion de seguimiento y auditoria a la solicitud
                listSeguimientoAuditoria.Add(seguimientoAuditoriaSolicitud);

                //Asignacion de auditoria seguimiento
                solicitud.SeguimientoAuditoriaSolicitud = listSeguimientoAuditoria;
            }

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


            await _solicitudRespository.UpdateAsync(solicitud);
            await _unitOfWork.CommitAsync();

            return new ResponseBase<bool>(HttpStatusCode.Created, "OK", true, 1);

        }
        public async Task<ResponseBase<bool>> CreateRevisionCoordinador(SolicitudRevisionCoordinadorDtoRequest request)
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
            if (request.Asignado)
            {
                solicitud.UsuarioAsignadoCoordinadorId = request.UsuarioAsignadoId;
                await _solicitudRespository.UpdateAsync(solicitud);
                await _unitOfWork.CommitAsync();
                return new ResponseBase<bool>(HttpStatusCode.OK, "Se ha asignado un nuevo usuario a la solicitud", true, 0);
            }
            else
            {
                solicitud.UsuarioAsignadoCoordinadorId = request.UsuarioAsignadoId;
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
        public async Task<ResponseBase<bool>> CreateRevisionSubdirector(SolicitudRevisionSubdirectorDtoRequest request)
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

            if (request.Asignado)
            {
                solicitud.UsuarioAsignadoSubdirectorId = request.UsuarioAsignadoId;
                await _solicitudRespository.UpdateAsync(solicitud);
                await _unitOfWork.CommitAsync();
                return new ResponseBase<bool>(HttpStatusCode.OK, "Se ha asignado un nuevo usuario a la solicitud", true, 0);
            }
            else
            {
                solicitud.UsuarioAsignadoSubdirectorId = request.UsuarioAsignadoId;
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
                resolucionSolicitud.VcNumeroResolucion = await GetNumeroResolucion();
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

        private async Task<List<DocumentosSolicitudDtoResponse>> GetDocumentosSolicitudByCapacitadorSolicitudId(string capacitadorSolicitudId)
        {
            bool isUsuarioVentanilla = false;
            var documentos = (await _documentoSolicitudRepository.GetAllAsync(x => x.UsuarioId.ToString() == capacitadorSolicitudId.ToString() && x.BlUsuarioVentanilla == isUsuarioVentanilla )).ToList();
            List<DocumentosSolicitudDtoResponse> lista = new();
            foreach (var documento in documentos)
            {
                lista.Add(new DocumentosSolicitudDtoResponse
                {

                    IdDocumento = documento.IdDocumento,
                    VcTipoDocumento = (await _parametroDetalleRepository.GetAsync(p => p.IdParametroDetalle == documento.TipoDocumentoId)).VcNombre,
                    VcPath = documento.VcPath,
                    BlIsValid = documento.BlIsValid
                });
            }
            return lista;
        }

        private async Task<List<ResolucionSolicitudesDTOResponse>> GetResolucionSolicitudesByCollection(ICollection<ResolucionSolicitud> resoluciones)
        {

            List<ResolucionSolicitudesDTOResponse> lista = new();

            foreach (var resolucion in resoluciones)
            {
                lista.Add(new ResolucionSolicitudesDTOResponse
                {

                    IdResolucionSolicitud = resolucion.IdResolucionSolicitud,
                    SolicitudId = resolucion.SolicitudId,
                    DocumentoSolicitudId = resolucion.DocumentoSolicitudId,
                    TipoResolucionId = resolucion.TipoResolucionId,
                    FechaResolucion = resolucion.FechaResolucion,
                    VcNumeroResolucion = resolucion.VcNumeroResolucion,
                    BlActiva = resolucion.BlActiva
                });
            }

            return lista;
        }
        private async Task<List<CapacitadorSolicitudDtoResponse>> GetCapacitadorSolicitudByCollection(ICollection<CapacitadorSolicitud> capacitadores)
        {

            List<CapacitadorSolicitudDtoResponse> lista = new();

            foreach (var capacitador in capacitadores)
            {
                lista.Add(new CapacitadorSolicitudDtoResponse
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
                    VcNumeroTarjetaProfesional = capacitador.vcNumeroTarjetaProfesional,
                    IntTelefono = capacitador.IntTelefono,
                    VcEmail = capacitador.VcEmail,
                    CapacitadorTipoCapacitacion = await GetCapacitadorTipoCapacitacionByCapacitadorId(capacitador.IdCapacitadorSolicitud.ToString()),
                    DocumentosSolicitud = await GetDocumentosSolicitudByCapacitadorSolicitudId(capacitador.IdCapacitadorSolicitud.ToString())
                });
            }

            return lista;
        }
        private async Task<List<CapacitadorTipoCapacitacionDtoResponse>> GetCapacitadorTipoCapacitacionByCapacitadorId(string capacitadorId)
        {
            var collections = await _capacitadorTipoCapacitacionRepository.GetAllAsync(x => x.IdCapacitadorSolicitud == Guid.Parse(capacitadorId));

            List<CapacitadorTipoCapacitacionDtoResponse> lista = new();

            foreach (var item in collections)
            {
                lista.Add(new CapacitadorTipoCapacitacionDtoResponse
                {
                    VcTipoCapacitacion = (await _tipoCapacitacionRepository.GetAsync(c => c.IdTipoCapacitacion == item.IdTipoCapacitacion)).VcDescripcion,
                    IdCapacitadorSolicitud = item.IdCapacitadorSolicitud.ToString()
                });
            }
            return lista;
        }

        private async Task<List<SeguimientoAuditoriaSolicitudDtoResponse>> GetSeguimientoAuditoriaByCollection(ICollection<SeguimientoAuditoriaSolicitud> seguimientoAuditorias)
        {
            List<SeguimientoAuditoriaSolicitudDtoResponse> lista = new();
            foreach (var seguimiento in seguimientoAuditorias)
            {
                lista.Add(new SeguimientoAuditoriaSolicitudDtoResponse
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
        
        private async Task<List<SolicitudBandejaSolicitudesDtoResponse>> MapToBandejaSolicitud(List<Solicitud> data)
        {
            List<SolicitudBandejaSolicitudesDtoResponse> lista = new();

            foreach (var item in data)
            {
                lista.Add(new SolicitudBandejaSolicitudesDtoResponse
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

        private async Task<List<DocumentosSolicitudDtoResponse>> GetDocumentoRecursosSolicitud(int solicitudId)
        {
            string codigoInterno = "bDocumentosSolicitud";
            string nombre = "Recurso";
            var resultQueryParamento = (await _parametroService.listarPorCodigoInterno(codigoInterno)).Data;

            List<DocumentosSolicitudDtoResponse> resultado = new();

            if (resultQueryParamento != null)
            {
                foreach (var item in resultQueryParamento)
                {
                    if (item.VcNombre.Contains(nombre))
                    {
                        var documentosSolicitud = await _documentoSolicitudRepository.GetAsync(x => x.SolicitudId == solicitudId && x.TipoDocumentoId == item.IdParametroDetalle);
                        if (documentosSolicitud is not null)
                        {
                            resultado.Add(new DocumentosSolicitudDtoResponse
                            {
                                IdDocumento = documentosSolicitud.IdDocumento,
                                VcTipoDocumento = (await _parametroDetalleRepository.GetAsync(p => p.IdParametroDetalle == documentosSolicitud.TipoDocumentoId)).VcNombre,
                                VcPath = documentosSolicitud.VcPath,
                                BlIsValid = documentosSolicitud.BlIsValid
                            });
                        }

                    }
                }
            }
            
            return resultado;

        }
        private async Task<string> GetNumeroResolucion()
        {
            var year = DateTime.UtcNow.AddHours(-5).Year;

            long numeroResolucion = 0;

            var ultimoNumero = (await _resolucionSolicitudRepository.GetAllAsync(x => x.FechaResolucion.Year == year, 
                                x => x.OrderByDescending(p => p.VcNumeroResolucion))).FirstOrDefault();

            if (ultimoNumero is not null)
            {
                numeroResolucion = Convert.ToInt32(ultimoNumero.VcNumeroResolucion) + 1;
            }
            else
            {
                numeroResolucion = 1;
            }

            return numeroResolucion.ToString("00000");

        }
        public Task<ResponseBase<List<SolicitudDtoResponse>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseBase<bool>> UpdateDocumentosSolicitud(int idSolicitud, List<DocumentoSolicitudDtoRequest> request)
        {
            var result = await _validatorIenumerableDocumento.ValidateAsync(request, opt => opt.IncludeRuleSets("Any"));

            if (!result.IsValid)
            {
                return new ResponseBase<bool>(HttpStatusCode.BadRequest, "Errores de validación !", result.ToDictionary());
            }

            var entities = _mapper.Map<List<DocumentoSolicitud>>(request);

            foreach (var entity in entities)
            {
                var doc = await _documentoSolicitudRepository.GetAsync(x => x.IdDocumento == entity.IdDocumento);
                entity.SolicitudId = idSolicitud;
                entity.IntVersion = doc.IntVersion + 1;
                entity.BlIsValid = doc.BlIsValid;
                entity.BlUsuarioVentanilla = doc.BlUsuarioVentanilla;
            }


            await _documentoSolicitudRepository.UpdateRangeAsync(entities);

            await _unitOfWork.CommitAsync();

            return new ResponseBase<bool>(HttpStatusCode.OK,"OK",true,entities.Count);

        }
    }
}
