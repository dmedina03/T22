using Aplication.Services.T22.DocumentoSolicitudServices.Validation;
using Domain.DTOs.Request.T22;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services.T22.CapacitacionCapacitadorSolicitudServices.Validation
{
    public class CapacitacionCapacitadorRevisionValidator : AbstractValidator<RevisionCapacitacionDTORequest>
    {

        public CapacitacionCapacitadorRevisionValidator()
        {
            RuleSet("Any", () =>
            {
                RuleFor(x => x.CapacitacionId)
                .NotEmpty()
                .NotEqual(0)
                .NotNull()
                .WithMessage("{Property Name} no puede ser 0 o vacío.");

                RuleFor(x => x.BlSeguimiento)
                .NotEmpty()
                .NotNull()
                .WithMessage("{Property Name} no puede ser vacío.");

                RuleFor(x => x.UsuarioSeguimientoId)
                .NotEmpty()
                .NotNull()
                .WithMessage("{Property Name} no puede ser vacío.");

                When(x => x.Documentos.Count > 0, () =>
                {

                    RuleFor(x => x.Documentos)
                       .SetValidator(x => new DocumentoSolicitudEnumerableDTOValidator(), "Create");

                }).Otherwise(() =>
                {
                    RuleFor(x => x.Documentos.Count)
                    .NotEmpty()
                    .NotNull()
                    .NotEqual(0)
                    .WithMessage("Error, debe adjuntar al menos un {Property Name}");
                });

            });
        }

    }
}
