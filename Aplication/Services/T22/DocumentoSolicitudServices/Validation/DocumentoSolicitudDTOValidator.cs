using Domain.DTOs.Request.T22;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services.T22.DocumentoSolicitudServices.Validation
{
    public class DocumentoSolicitudDTOValidator : AbstractValidator<IEnumerable<DocumentoSolicitudDTORequest>>
    {
        public DocumentoSolicitudDTOValidator()
        {

            RuleSet("Create", () =>
            {

                RuleForEach(x => x)
                    .Cascade(CascadeMode.Continue)
                    .ChildRules(property =>
                    {

                        property.RuleFor(x => x.SolicitudId)
                            .Equal(0)
                            .WithMessage("{PropertyName} debe ser 0.")
                            .NotEmpty().NotNull()
                            .WithMessage("{PropertyName} no puede ser nulo o vacío.");

                        property.RuleFor(x => x.UsuarioId)
                            .NotNull()
                            .WithMessage("{PropertyName} no puede ser nulo o vacío.");

                        property.RuleFor(x => x.VcNombreDocumento)
                            .MaximumLength(150)
                            .NotEmpty().NotNull()
                            .WithMessage("{PropertyName} no puede ser nulo o vacío.");

                        property.RuleFor(x => x.TipoDocumentoId)
                            .NotEqual(0)
                            .WithMessage("{PropertyName} no puede ser 0.")
                            .NotEmpty().NotNull()
                            .WithMessage("{PropertyName} no puede ser nulo o vacío.");

                        property.RuleFor(x => x.VcPath)
                            .NotEmpty().NotNull()
                            .WithMessage("{PropertyName} no puede ser nulo o vacío.");
                    });
            });

            RuleSet("Any", () =>
            {
                RuleForEach(x => x)
                    .Cascade(CascadeMode.Stop)
                    .ChildRules(property =>
                    {
                        property.RuleFor(x => x.SolicitudId)
                            .NotEmpty().NotNull()
                            .WithMessage("{PropertyName} no puede ser nulo o vacío.");

                        property.RuleFor(x => x.UsuarioId)
                            .NotNull()
                            .WithMessage("{PropertyName} no puede ser nulo o vacío.");

                        property.RuleFor(x => x.TipoDocumentoId)
                            .NotEqual(0)
                            .WithMessage("{PropertyName} no puede ser 0.")
                            .NotEmpty().NotNull()
                            .WithMessage("{PropertyName} no puede ser nulo o vacío.");

                        property.RuleFor(x => x.VcNombreDocumento)
                            .MaximumLength(150)
                            .NotEmpty().NotNull()
                            .WithMessage("{PropertyName} no puede ser nulo o vacío.");

                        property.RuleFor(x => x.DtFechaCargue)
                            .NotEmpty().NotNull()
                            .WithMessage("{PropertyName} no puede ser nulo o vacío.");

                        property.RuleFor(x => x.VcPath)
                            .NotEmpty().NotNull()
                            .WithMessage("{PropertyName} no puede ser nulo o vacío.");

                        property.RuleFor(x => x.IntVersion)
                            .NotEqual(0)
                            .WithMessage("{PropertyName} no puede ser 0.")
                            .NotEmpty().NotNull()
                            .WithMessage("{PropertyName} no puede ser nulo o vacío.");

                    });

            });

        }
    }
}
