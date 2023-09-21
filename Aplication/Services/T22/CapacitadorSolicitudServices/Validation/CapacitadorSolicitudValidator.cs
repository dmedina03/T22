using Aplication.Services.T22.DocumentoSolicitudServices.Validation;
using Domain.DTOs.Request.T22;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services.T22.CapacitadorSolicitudServices.Validation
{
    public class CapacitadorSolicitudValidator : AbstractValidator<IEnumerable<CapacitadorSolicitudDTORequest>>
    {
        public CapacitadorSolicitudValidator()
        {

            RuleSet("Create", () =>
            {
                RuleForEach(x => x)
                    .Cascade(CascadeMode.Continue)
                    .ChildRules(property =>
                    {

                        property.RuleFor(x => x.SolicitudId)
                            .Equal(0)
                            .WithMessage("{PropertyName} no puede ser 0.")
                            .NotEmpty().NotNull()
                            .WithMessage("{PropertyName} no puede ser nulo o vacío.");

                        property.RuleFor(x => x.DocumentoSolicitud.Count())
                            .GreaterThanOrEqualTo(8)
                            .WithMessage("Faltan documentos obligatorios por cargar.")
                            .NotEmpty()
                            .WithMessage("Debe cargar los documentos requeridos.")
                            .NotNull()
                            .WithMessage("Debe cargar los documentos requeridos.");


                        property.RuleFor(x => x.DocumentoSolicitud)
                            .SetValidator(x => new DocumentoSolicitudEnumerableDTOValidator(), "Create");
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

                        property.RuleFor(x => x.VcPrimerNombre).MaximumLength(20)
                            .WithMessage("{PropertyName} supera el máximo de caracteres.")
                            .NotEmpty().NotNull()
                            .WithMessage("{PropertyName} no puede ser nulo o vacío.");

                        property.RuleFor(x => x.VcSegundoNombre).MaximumLength(20)
                            .WithMessage("{PropertyName} supera el máximo de caracteres.");

                        property.RuleFor(x => x.VcPrimerApellido).MaximumLength(20)
                            .WithMessage("{PropertyName} supera el máximo de caracteres.")
                            .NotEmpty().NotNull()
                            .WithMessage("{PropertyName} no puede ser nulo o vacío.");

                        property.RuleFor(x => x.VcSegundoApellido).MaximumLength(20)
                            .WithMessage("{PropertyName} supera el máximo de caracteres.");

                        property.RuleFor(x => x.TipoIdentificacionId)
                            .NotEqual(0)
                            .WithMessage("{PropertyName} no puede ser 0.")
                            .NotEmpty().NotNull()
                            .WithMessage("{PropertyName} no puede ser nulo o vacío.");

                        property.RuleFor(x => x.IntNumeroIdentificacion)
                            .NotEqual(0)
                            .WithMessage("{PropertyName} no puede ser 0.")
                            .NotEmpty().NotNull()
                            .WithMessage("{PropertyName} no puede ser nulo o vacío.");

                        property.RuleFor(x => x.VcTituloProfesional)
                            .NotEmpty().NotNull()
                            .WithMessage("{PropertyName} no puede ser nulo o vacío.");

                        property.RuleFor(x => x.vcNumeroTarjetaProfesional)
                            .NotEmpty().NotNull()
                            .WithMessage("{PropertyName} no puede ser nulo o vacío.");

                        property.RuleFor(x => x.IntTelefono)
                            .NotEmpty().NotNull()
                            .WithMessage("{PropertyName} no puede ser nulo o vacío.");

                        property.RuleFor(x => x.VcEmail)
                            .NotEmpty().NotNull()
                            .WithMessage("{PropertyName} no puede ser nulo o vacío.");

                        property.RuleFor(x => x.DocumentoSolicitud)
                            .SetValidator(x => new DocumentoSolicitudEnumerableDTOValidator(), "Any");

                    });

            });

            
        }
    }
}
