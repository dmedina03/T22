using Aplication.Services.T22.CapacitadorSolicitudServices.Validation;
using Aplication.Services.T22.DocumentoSolicitudServices.Validation;
using Domain.DTOs.Request.T22;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services.T22.RecursoSolicitudServices.Validation
{
    public class RevisionRecursoSolicitudDtoValidator : AbstractValidator<RevisionRecursoSolicitudDtoRequest>
    {
        public RevisionRecursoSolicitudDtoValidator()
        {
            RuleSet("Any", () =>
            {
                RuleFor(p => p.SolicitudId)
                .NotEqual(0)
                .WithMessage("{PropertyName} no puede ser 0.")
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} no puede ser nulo o vacío.");

                When(P => P.RespuestaRecurso is not null, () =>
                {
#pragma warning disable // El tipo no se puede usar como parámetro de tipo en el tipo o método genérico. La nulabilidad del argumento de tipo no coincide con el tipo de restricción
                    RuleFor(p => p.RespuestaRecurso).SetValidator(p => new DocumentoSolicitudDtoValidator(), "Any");
                });


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
                    
                    RuleFor(p => p.SeguimientoAuditoriaSolicitud.VcNombreUsuario)
                        .NotEmpty()
                        .NotNull()
                        .WithMessage("{PropertyName} no puede ser nulo o vacio.");
                });

            });
        }
    }
}
