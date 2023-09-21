using Aplication.Utilities.Enum;
using AutoMapper;
using Domain.DTOs.Request.T22;
using Domain.DTOs.Response.T22;
using Domain.Models.T22;
using Dominio.DTOs.Response.ResponseBase;
using FluentValidation;
using iText.Html2pdf.Attach.Impl.Tags;
using Persistence.Repository.IRepositories.Generic;
using Persistence.Repository.IRepositories.IT22;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services.T22.RecursoSolicitudServices
{
    public class RecursoSolicitudService : IRecursoSolicitudService
    {
        private readonly IDocumentoSolicitudRepository _documentoSolicitudRepository;
        private readonly ISeguimientoAuditoriaSolicitudRepository _seguimientoAuditoriaSolicitudRepository;
        private readonly ISolicitudRespository _solicitudRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<DocumentoSolicitudDTORequest> _validatorDocumento;
        private readonly IValidator<RevisionRecursoSolicitudDTORequest> _validatorRevisionRecursoSolicitud;
        private readonly IValidator<VerificacionAprobacionRecursoSolicitudDTORequest> _validatorVerificacionAprobacionRecursoSolicitud;
        private readonly IUnitOfWork _unitOfWork;
        public RecursoSolicitudService(IDocumentoSolicitudRepository documentoSolicitudRepository, IMapper mapper,
            IValidator<DocumentoSolicitudDTORequest> validatorDocumento, IValidator<RevisionRecursoSolicitudDTORequest> validatorRevisionRecursoSolicitud,
            IUnitOfWork unitOfWork, ISolicitudRespository solicitudRepository, ISeguimientoAuditoriaSolicitudRepository seguimientoAuditoriaSolicitudRepository, 
            IValidator<VerificacionAprobacionRecursoSolicitudDTORequest> validatorVerificacionAprobacionRecursoSolicitud)
        {
            _documentoSolicitudRepository = documentoSolicitudRepository;
            _solicitudRepository = solicitudRepository;
            _seguimientoAuditoriaSolicitudRepository = seguimientoAuditoriaSolicitudRepository;
            _mapper = mapper;
            _validatorDocumento = validatorDocumento;
            _validatorRevisionRecursoSolicitud = validatorRevisionRecursoSolicitud;
            _unitOfWork = unitOfWork;
            _validatorVerificacionAprobacionRecursoSolicitud = validatorVerificacionAprobacionRecursoSolicitud;
        }

        //public async Task<ResponseBase<SolicitudDTOResponse>>

        /// <summary>
        /// Creación de la generación del recurso
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ResponseBase<bool>> CreateAsync(DocumentoSolicitudDTORequest request)
        {

            var result = await _validatorDocumento.ValidateAsync(request, opt => opt.IncludeRuleSets("Any"));

            if (!result.IsValid)
            {
                return new ResponseBase<bool>(HttpStatusCode.BadRequest, message: "Ocurrio un error de validacion, verifique nuevamente.", result.ToDictionary());
            }

            var solicitud = await _solicitudRepository.GetAsync(x => x.IdSolicitud == request.SolicitudId);

            if (solicitud.EstadoId != (int)EnumEstado.Cancelado || solicitud.EstadoId != (int)EnumEstado.CanceladoPorInclumplimiento || solicitud.EstadoId != (int)EnumEstado.Negado )
            {
                return new ResponseBase<bool>(HttpStatusCode.BadRequest, message: "No es posible generar recurso a la solicitud, ya que su estado no lo permite.", result.ToDictionary());
            }

            //Se mapea el documento recurso que adjunta el ciudadano
            var documento = _mapper.Map<DocumentoSolicitud>(request);
            documento.SolicitudId = solicitud.IdSolicitud;
            documento.BlUsuarioVentanilla = true;
            documento.BlIsValid = true;
            
            //Se actualiza el resultado de la validacion a rescurso
            solicitud.ResultadoValidacionId = (int)EnumResultadoValidacion.Recurso;
            //se actualiza el estado de la solicitud
            solicitud.EstadoId = (int)EnumEstado.EnRevision;

            await _documentoSolicitudRepository.AddAsync(documento);

            await _solicitudRepository.UpdateAsync(solicitud);

            await _unitOfWork.CommitAsync();

            return new ResponseBase<bool>(HttpStatusCode.Created,"OK",true, 1);
        }

        public async Task<ResponseBase<bool>> CreateRevisionRecursoValidador(RevisionRecursoSolicitudDTORequest request)
        {
            var result = await _validatorRevisionRecursoSolicitud.ValidateAsync(request, opt => opt.IncludeRuleSets("Any"));

            if (!result.IsValid)
            {
                return new ResponseBase<bool>(HttpStatusCode.BadRequest, message: "Ocurrio un error de validacion, verifique nuevamente.", result.ToDictionary());
            }

            var solicitud = await _solicitudRepository.GetAsync(x => x.IdSolicitud == request.SolicitudId);

            //Se mapea el documento respuesta a recurso cargado por el validador
            var documento = _mapper.Map<DocumentoSolicitud>(request.RespuestaRecurso);
            documento.SolicitudId = solicitud.IdSolicitud;
            documento.BlUsuarioVentanilla = true;
            documento.BlIsValid = true;

            SeguimientoAuditoriaSolicitud seguimientoAuditoria = new SeguimientoAuditoriaSolicitud();

            if (request.SeguimientoAuditoriaSolicitud is not null)
            {
                seguimientoAuditoria = _mapper.Map<SeguimientoAuditoriaSolicitud>(request.SeguimientoAuditoriaSolicitud);
                seguimientoAuditoria.SolicitudId = solicitud.IdSolicitud;
                seguimientoAuditoria.EstadoId = solicitud.EstadoId;
                await _seguimientoAuditoriaSolicitudRepository.AddAsync(seguimientoAuditoria);
            }

            //Se asigna el nuevo estado de la solicitud
            solicitud.EstadoId = (int)EnumEstado.EnVerificacion;

            await _solicitudRepository.UpdateAsync(solicitud);

            await _documentoSolicitudRepository.AddAsync(documento);

            await _unitOfWork.CommitAsync();

            return new ResponseBase<bool>(HttpStatusCode.Created, "OK", true, 1);

        }

        public async Task<ResponseBase<bool>> CreateVerificacionRecursoCoordinador(VerificacionAprobacionRecursoSolicitudDTORequest request)
        {
            var result = await _validatorVerificacionAprobacionRecursoSolicitud.ValidateAsync(request, opt => opt.IncludeRuleSets("Any"));

            if (!result.IsValid)
            {
                return new ResponseBase<bool>(HttpStatusCode.BadRequest, message: "Ocurrio un error de validacion, verifique nuevamente.", result.ToDictionary());
            }

            var solicitud = await _solicitudRepository.GetAsync(x => x.IdSolicitud == request.SolicitudId);

            DocumentoSolicitud documento = new DocumentoSolicitud();

            //Se valida si se aprueba el resultado de la validacion
            if (request.ResultadoValidacion is true)
            {
                //Se determina el nuevo estado de la solicitud
                solicitud.EstadoId = (int)EnumEstado.ParaFirma;
            }
            else
            {
                //Se determina el estado de la solicitud
                solicitud.EstadoId = (int)EnumEstado.DevueltaPorCoordinador;
            }

            //Si la respuesta de recurso no es nula, quiere decir que el coordinador carga un nuevo recurso
            if (request.RespuestaRecurso is not null)
            {
                //asi que se elimina el recurso que cargo el validador
                await _documentoSolicitudRepository.DeleteAsync(request.DocumentoRespuestaRecursoId);

                documento = _mapper.Map<DocumentoSolicitud>(request.RespuestaRecurso);
                documento.SolicitudId = solicitud.IdSolicitud;
                documento.BlUsuarioVentanilla = true;
                documento.BlIsValid = true;

                await _documentoSolicitudRepository.AddAsync(documento);
            }


            SeguimientoAuditoriaSolicitud seguimientoAuditoria = new SeguimientoAuditoriaSolicitud();

            if (request.SeguimientoAuditoriaSolicitud is not null)
            {
                seguimientoAuditoria = _mapper.Map<SeguimientoAuditoriaSolicitud>(request.SeguimientoAuditoriaSolicitud);
                seguimientoAuditoria.SolicitudId = solicitud.IdSolicitud;
                seguimientoAuditoria.EstadoId = solicitud.EstadoId;
                await _seguimientoAuditoriaSolicitudRepository.AddAsync(seguimientoAuditoria);
            }

            await _solicitudRepository.UpdateAsync(solicitud);

            await _unitOfWork.CommitAsync();

            return new ResponseBase<bool>(HttpStatusCode.Created, "OK", true, 1);

        }

        public async Task<ResponseBase<bool>> CreateAprobacionRecursoSubdirector(VerificacionAprobacionRecursoSolicitudDTORequest request)
        {
            var result = await _validatorVerificacionAprobacionRecursoSolicitud.ValidateAsync(request, opt => opt.IncludeRuleSets("Any"));

            if (!result.IsValid)
            {
                return new ResponseBase<bool>(HttpStatusCode.BadRequest, message: "Ocurrio un error de validacion, verifique nuevamente.", result.ToDictionary());
            }

            var solicitud = await _solicitudRepository.GetAsync(x => x.IdSolicitud == request.SolicitudId);

            DocumentoSolicitud documento = new DocumentoSolicitud();

            //Se valida si se aprueba el resultado de la validacion
            if (request.ResultadoValidacion is true)
            {
                //Se determina el nuevo estado de la solicitud
                solicitud.EstadoId = (int)EnumEstado.RecursoRespondido;
            }
            else
            {
                //Se determina el estado de la solicitud
                solicitud.EstadoId = (int)EnumEstado.DevueltaPorSubdirector;
            }

            //Si la respuesta de recurso no es nula, quiere decir que el subdirector carga un nuevo recurso
            if (request.RespuestaRecurso is not null)
            {
                //asi que se elimina el recurso que cargo el coordinador
                await _documentoSolicitudRepository.DeleteAsync(request.DocumentoRespuestaRecursoId);

                documento = _mapper.Map<DocumentoSolicitud>(request.RespuestaRecurso);
                documento.SolicitudId = solicitud.IdSolicitud;
                documento.BlUsuarioVentanilla = true;
                documento.BlIsValid = true;

                await _documentoSolicitudRepository.AddAsync(documento);
            }


            SeguimientoAuditoriaSolicitud seguimientoAuditoria = new SeguimientoAuditoriaSolicitud();

            if (request.SeguimientoAuditoriaSolicitud is not null)
            {
                seguimientoAuditoria = _mapper.Map<SeguimientoAuditoriaSolicitud>(request.SeguimientoAuditoriaSolicitud);
                seguimientoAuditoria.SolicitudId = solicitud.IdSolicitud;
                seguimientoAuditoria.EstadoId = solicitud.EstadoId;
                await _seguimientoAuditoriaSolicitudRepository.AddAsync(seguimientoAuditoria);
            }

            await _solicitudRepository.UpdateAsync(solicitud);

            await _unitOfWork.CommitAsync();

            return new ResponseBase<bool>(HttpStatusCode.Created, "OK", true, 1);

        }



    }
}
