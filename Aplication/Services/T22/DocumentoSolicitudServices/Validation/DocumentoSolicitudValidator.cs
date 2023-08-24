using Domain.Models.T22;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services.T22.DocumentoSolicitudServices.Validation
{
    public class DocumentoSolicitudValidator : AbstractValidator<IEnumerable<DocumentoSolicitud>>
    {
        public DocumentoSolicitudValidator()
        {

            RuleSet("Any", () =>
            {
                RuleForEach(x => x)
                    .Cascade(CascadeMode.Stop)
                    .ChildRules(property =>
                    {
                        property.RuleFor(x => x.SolicitudId)
                            .NotEqual(0)
                            .WithMessage("{PropertyName} no puede ser 0.")
                            .NotEmpty().NotNull()
                            .WithMessage("{PropertyName} no puede ser nulo o vacío.");

                        property.RuleFor(x => x.UsuarioId)
                            .NotEqual(0)
                            .WithMessage("{PropertyName} no puede ser 0.")
                            .NotEmpty().NotNull()
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

                        property.RuleFor(x => x.BlIsValid)
                            .NotEmpty().NotNull()
                            .WithMessage("{PropertyName} no puede ser nulo o vacío.");

                        property.RuleFor(x => x.BlUsuarioVentanilla)
                            .NotEmpty().NotNull()
                            .WithMessage("{PropertyName} no puede ser nulo o vacío.");


                    });
            });

        }
    }
}
