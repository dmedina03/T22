using Domain.DTOs.Request.T22;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services.T22.SolicitudServices.Validation
{
    public class SolicitudRevisionValidadorValidator : AbstractValidator<SolicitudRevisionValidadorDtoRequest>
    {
        public SolicitudRevisionValidadorValidator()
        {

            RuleSet("Any", () =>
            {

                RuleFor(x => x.IdSolicitud)
                    .NotEqual(0)
                    .WithMessage("{PropertyName} no puede ser 0.")
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("{PropertyName} no puede ser nulo o vacio.");

                RuleFor(x => x.CapacitadorSolicitud.Count)
                    .NotEqual(0)
                    .WithMessage("No existe ningun capacitador asignado a la solicitud")
                    .NotNull()
                    .NotEmpty()
                    .WithMessage("El campo 'Capacitador solicitud' no puede ser nulo");

                When(x => x.UsuarioAsignadoId is null, () =>
                {

                    RuleFor(p => p.ResultadoValidacionId)
                        .NotEqual(0)
                        .WithMessage("{PropertyName} no puede ser 0.")
                        .NotEmpty()
                        .NotNull()
                        .WithMessage("{PropertyName} no puede ser nulo o vacio.");

                    RuleFor(p => p.DocumentoSolicitud.Count)
                    //Se multiplica por 8, ya que son los documentos minimos requeridos 
                        .GreaterThanOrEqualTo(x => x.CapacitadorSolicitud.Count * 8)
                        .WithMessage("{PropertyName} debe validar todos los documentos.");
#pragma warning disable // Desreferencia de una referencia posiblemente NULL.

                    When(x => x.SeguimientoAuditoriaSolicitud is not null, () =>
                    {
                        RuleFor(p => p.SeguimientoAuditoriaSolicitud.VcObservacion)
                            .NotEmpty()
                            .NotNull()
                            .WithMessage("{PropertyName} no puede ser nulo o vacio.");

                        RuleFor(p => p.SeguimientoAuditoriaSolicitud.UsuarioId)
                            .NotEmpty()
                            .NotNull()
                            .WithMessage("{PropertyName} no puede ser nulo o vacio.");
                    });

                    When(x => x.SubsanacionSolicitud is not null, () =>
                    {
                        RuleFor(p => p.SubsanacionSolicitud.VcSubsanacion)
                            .NotEmpty()
                            .NotNull()
                            .WithMessage("{PropertyName} no puede ser nulo o vacio.");

                        RuleFor(p => p.SubsanacionSolicitud.UsuarioId)
                            .NotEmpty()
                            .NotNull()
                            .WithMessage("{PropertyName} no puede ser nulo o vacio.");
                    });

                }).Otherwise(() =>
                {

                    RuleFor(x => x.UsuarioAsignadoId)
                        .NotEmpty()
                        .NotNull()
                        .WithMessage("{PropertyName} no puede ser nulo o vacio.");
                });

                When(x => x.CancelacionSolicitud is not null, () =>
                {
                    RuleFor(x => x.CancelacionSolicitud.VcCancelacion)
                        .NotEmpty()
                        .NotNull()
                        .WithMessage("El campo motivo de cancelacion esta vacio.");
                });
            });
            
        }
    }
}
