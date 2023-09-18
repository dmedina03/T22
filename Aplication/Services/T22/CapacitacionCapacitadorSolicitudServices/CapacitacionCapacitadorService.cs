using Aplication.Utilities;
using Aplication.Utilities.Enum;
using AutoMapper;
using Azure;
using Domain.DTOs.Request.T22;
using Domain.DTOs.Response.T22;
using Domain.Models.T22;
using Dominio.DTOs.Response.ResponseBase;
using FluentValidation;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Repository.IRepositories.Generic;
using Persistence.Repository.IRepositories.IParametroRepository;
using Persistence.Repository.IRepositories.IT22;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services.T22.CapacitacionCapacitadorSolicitudServices
{
    public class CapacitacionCapacitadorService : ICapacitacionCapacitadorService
    {

        private readonly ICapacitacionCapacitadorRepository _capacitacionCapacitadorRepository;
        private readonly ISolicitudRespository _solicitudRespository;
        private readonly IParametroDetalleRepository _parametroDetalleRepository;
        private readonly IDocumentoSolicitudRepository _documentoSolicitudRepository;
        private readonly ICapacitadorSolicitudRepository _capacitadorSolicitudRepository;
        private readonly IResolucionSolicitudRepository _resolucionSolicitudRepository;
        private readonly IValidator<CapacitacionCapacitadorSolicitudDTORequest> _validatorCapacitacionCapacitadorSolicitud;
        private readonly IValidator<RevisionCapacitacionDTORequest> _validatorRevisionCapacitacion;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CapacitacionCapacitadorService(ICapacitacionCapacitadorRepository capacitacionCapacitadorRepository, ISolicitudRespository solicitudRespository,
            IParametroDetalleRepository parametroDetalleRepository, IDocumentoSolicitudRepository documentoSolicitudRepository,
            IValidator<CapacitacionCapacitadorSolicitudDTORequest> validatorCapacitacionCapacitadorSolicitud, IMapper mapper, IUnitOfWork unitOfWork,
            ICapacitadorSolicitudRepository capacitadorSolicitudRepository, IResolucionSolicitudRepository resolucionSolicitudRepository, 
            IValidator<RevisionCapacitacionDTORequest> validatorRevisionCapacitacion)
        {
            _capacitacionCapacitadorRepository = capacitacionCapacitadorRepository;
            _solicitudRespository = solicitudRespository;
            _parametroDetalleRepository = parametroDetalleRepository;
            _documentoSolicitudRepository = documentoSolicitudRepository;
            _validatorCapacitacionCapacitadorSolicitud = validatorCapacitacionCapacitadorSolicitud;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _capacitadorSolicitudRepository = capacitadorSolicitudRepository;
            _resolucionSolicitudRepository = resolucionSolicitudRepository;
            _validatorRevisionCapacitacion = validatorRevisionCapacitacion;
        }

        public async Task<ResponseBase<bool>> CreateAsync(CapacitacionCapacitadorSolicitudDTORequest request)
        {
            var result = await _validatorCapacitacionCapacitadorSolicitud.ValidateAsync(request, opt => opt.IncludeRuleSets("Any"));

            if (!result.IsValid)
            {
                return new ResponseBase<bool>(HttpStatusCode.BadRequest, "Error de validación !", result.ToDictionary());
            }

            var Capacitacion = _mapper.Map<CapacitacionCapacitadorSolicitud>(request);

            await _capacitacionCapacitadorRepository.AddAsync(Capacitacion);
            await _unitOfWork.CommitAsync();

            return new ResponseBase<bool>(HttpStatusCode.Created, "OK", true, 1);

        }


        public async Task<ResponseBase<List<BandejaResgistrarCapacitacionesDTOResponse>>> GetBandejaRegistrarCapacitaciones()
        {

            var Solicitudes = (await _solicitudRespository.GetAllAsync(x => x.EstadoId == (int)EnumEstado.Aprobado, null, x => x.Include(p => p.ResolucionSolicitud))).ToList();

            Solicitudes = Solicitudes.OrderByDescending(x => x.DtFechaSolicitud).ToList();

            List<BandejaResgistrarCapacitacionesDTOResponse> list = new List<BandejaResgistrarCapacitacionesDTOResponse>();

            if (Solicitudes is null || Solicitudes.Count == 0)
            {
                return new ResponseBase<List<BandejaResgistrarCapacitacionesDTOResponse>>(HttpStatusCode.NoContent, "La solicitud respondío OK, pero sin datos", list, list.Count);
            }

            foreach (var solicitud in Solicitudes)
            {
                foreach (var resolucion in solicitud.ResolucionSolicitud)
                {
                    //valida si la solicitud esta activa o no, realiza la respectiva actualizacion
                    await _resolucionSolicitudRepository.UpdateIsValid(resolucion.IdResolucionSolicitud);

                    list.Add(new BandejaResgistrarCapacitacionesDTOResponse
                    {
                        IdSolicitud = solicitud.IdSolicitud,
                        IdResolucionSolicitud = resolucion.IdResolucionSolicitud,
                        IntNumeroResolucion = resolucion.IntNumeroResolucion.ToString("00000"),
                        FechaResolucion = resolucion.FechaResolucion.ToString("dd/MM/yyyy"),
                        TipoSolicitudId = solicitud.TipoSolicitudId,
                        VcNombre = await _parametroDetalleRepository.VcNombre(solicitud.TipoSolicitudId),
                        BEstado = resolucion.BlActiva,
                        IdDocumento = resolucion.DocumentoSolicitudId,
                        VcPath = (await _documentoSolicitudRepository.GetAsync(x => x.IdDocumento == resolucion.DocumentoSolicitudId)).VcPath
                    });
                }

            }
            list = list.OrderBy(x => x.FechaResolucion).ToList();
            return new ResponseBase<List<BandejaResgistrarCapacitacionesDTOResponse>>(HttpStatusCode.OK, "OK", list, list.Count);
        }

        public async Task<ResponseBase<List<BandejaSeguimientoCapacitacionDTOResponse>>> GetBandejaSeguimientoCapacitaciones()
        {
            var capacitaciones = (await _capacitacionCapacitadorRepository.GetAllAsync(null, x => x.OrderBy(p => p.DtFechaCreacionCapacitacion))).ToList();

            capacitaciones = capacitaciones.OrderByDescending(x => x.DtFechaCreacionCapacitacion).ToList();

            List<BandejaSeguimientoCapacitacionDTOResponse> list = new();

            if (capacitaciones is null || capacitaciones.Count == 0)
            {
                return new ResponseBase<List<BandejaSeguimientoCapacitacionDTOResponse>>(HttpStatusCode.NoContent, "La solicitud respondio OK, pero sin datos", list, list.Count);
            }

            foreach (var cap in capacitaciones)
            {

                var capacitador = await _capacitadorSolicitudRepository.GetAsync(x => x.IdCapacitadorSolicitud == cap.CapacitadorId);
                var solicitud = await _solicitudRespository.GetAsync(x => x.IdSolicitud == capacitador.SolicitudId, null, null, "ResolucionSolicitud");

                foreach (var resolucion in solicitud.ResolucionSolicitud)
                {

                    if (resolucion.TipoResolucionId == (int)EnumTipoResolucion.ResolucionAprobacion)
                    {
                        //valida si la solicitud esta activa o no, realiza la respectiva actualizacion
                        await _resolucionSolicitudRepository.UpdateIsValid(resolucion.IdResolucionSolicitud);

                        var documento = await _documentoSolicitudRepository.GetAsync(x => x.IdDocumento == resolucion.DocumentoSolicitudId);

                        list.Add(new BandejaSeguimientoCapacitacionDTOResponse
                        {
                            IdResolucionSolicitud = resolucion.IdResolucionSolicitud,
                            IntNumeroResolucion = resolucion.IntNumeroResolucion.ToString("00000"),
                            IdSolicitud = solicitud.IdSolicitud,
                            NombreCiudadanoEntidad = solicitud.VcNombreUsuario,
                            IntNumeroIdentificacion = solicitud.IntNumeroIdentificacionUsuario,
                            DtFechaResolucion = resolucion.FechaResolucion.ToString("dd/MM/yyyy"),
                            BlEstado = resolucion.BlActiva,
                            IdDocumentoSolictud = documento.IdDocumento,
                            VcPath = documento.VcPath
                        });
                    }

                }

            }

            return new ResponseBase<List<BandejaSeguimientoCapacitacionDTOResponse>>(HttpStatusCode.OK, default, list, list.Count);

        }

        public async Task<ResponseBase<CapacitacionCapacitadorDTOResponse>> GetById(int Id)
        {
            var capacitacion = await _capacitacionCapacitadorRepository.GetAsync(x => x.IdCapacitacionSolicitud == Id, null, null, "HorariosCapacitacionSolicitud");

            if (capacitacion is null)
            {
                return new ResponseBase<CapacitacionCapacitadorDTOResponse>(HttpStatusCode.NoContent, "La solicitud respondio OK, pero sin datos", null, 0);
            }

            int i = 1;
            CapacitacionCapacitadorDTOResponse response = new CapacitacionCapacitadorDTOResponse()
            {
                VcNombreCapacitador = await _capacitadorSolicitudRepository.GetNombreCapacitador(capacitacion.CapacitadorId.ToString()),
                VcPublicoObjetivo = capacitacion.VcPublicoObjetivo,
                IntNumeroAsistentes = capacitacion.IntNumeroAsistentes,
                VcTemaCapacitacon = capacitacion.VcTemaCapacitacion,
                VcMetodologiaCapacitacion = capacitacion.VcMetodologiaCapacitacion,
                VcDireccion = capacitacion.VcDireccion,
                VcInformacionAdicional = capacitacion.VcInformacionAdicional,
                DepartamentoId = capacitacion.DepartamentoId,
                CiudadId = capacitacion.CiudadId,
                HorariosCapacitacion = capacitacion.HorariosCapacitacionSolicitud.OrderBy(x => x.DtFechaCapacitacion).Select(p => new HorariosCapacitacionSolcitudDTOResponse
                {
                    Numero = i++,
                    FechaCapacitacion = p.DtFechaCapacitacion.ToString("dd/MM/yyyy"),
                    HoraInicio = p.HoraInicio,
                    HoraFin = p.HoraFin
                }).ToList()
            };

            return new ResponseBase<CapacitacionCapacitadorDTOResponse>(HttpStatusCode.OK, "OK", response, 1);
        }

        public async Task<ResponseBase<bool>> CreateRevisionCapacitacion(RevisionCapacitacionDTORequest request)
        {

            var result = await _validatorRevisionCapacitacion.ValidateAsync(request, opt => opt.IncludeRuleSets("Any"));

            if (!result.IsValid)
            {
                return new ResponseBase<bool>(HttpStatusCode.BadRequest, "Error de validación !", result.ToDictionary());
            }

            var capacitacion = await _capacitacionCapacitadorRepository.GetAsync(x => x.IdCapacitacionSolicitud == request.CapacitacionId, null, null, "CapacitadorSolicitud");

            capacitacion.UsuarioRevisionId = Guid.Parse(request.UsuarioSeguimientoId);
            capacitacion.BlSeguimiento = request.BlSeguimiento;

            await _capacitacionCapacitadorRepository.UpdateAsync(capacitacion);

            List<DocumentoSolicitud> documentoSolicitudes = new List<DocumentoSolicitud>();

            foreach (var doc in request.Documentos)
            {
                documentoSolicitudes.Add(new DocumentoSolicitud
                {
                    IdDocumento = doc.IdDocumento,
                    SolicitudId = capacitacion.CapacitadorSolicitud.SolicitudId,
                    UsuarioId = Guid.Parse(request.UsuarioSeguimientoId),
                    TipoDocumentoId = doc.TipoDocumentoId,
                    VcNombreDocumento = doc.VcNombreDocumento,
                    DtFechaCargue = doc.DtFechaCargue,
                    VcPath = doc.VcPath,
                    IntVersion = doc.IntVersion,
                    BlUsuarioVentanilla = true,
                    BlIsValid = true
                });
            }

            await _documentoSolicitudRepository.AddRangeAsync(documentoSolicitudes);

            await _unitOfWork.CommitAsync();

            return new ResponseBase<bool>(HttpStatusCode.OK, "OK", true, 1);

        }


        public Task<ResponseBase<List<CapacitacionCapacitadorDTOResponse>>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
