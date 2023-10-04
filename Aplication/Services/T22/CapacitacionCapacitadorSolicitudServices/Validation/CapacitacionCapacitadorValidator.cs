using Domain.DTOs.Request.T22;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services.T22.CapacitacionCapacitadorSolicitudServices.Validation
{
    public class CapacitacionCapacitadorValidator : AbstractValidator<CapacitacionCapacitadorSolicitudDTORequest>
    {
        public CapacitacionCapacitadorValidator()
        {

            RuleSet("Any", () =>
            {
                RuleFor(p => p.CapacitadorId)
                .NotNull()
                .WithMessage("{PropertyName} no puede ser vacio o nulo.");

                RuleFor(p => p.VcPublicoObjetivo)
                .MaximumLength(200)
                .WithMessage("Error, la propiedad {PropertyName} contiene más de 200 carácteres.")
                .NotEmpty()
                .NotNull()
                .WithMessage("{PropertyName} no puede ser vacio o nulo.");

                RuleFor(p => p.IntNumeroAsistentes)
                .NotEqual(0)
                .WithMessage("{PropertyName} no puede ser 0.")
                .NotEmpty()
                .NotNull()
                .WithMessage("{PropertyName} no puede ser vacio o nulo.");

                RuleFor(p => p.VcTemaCapacitacion)
                .NotEmpty()
                .NotNull()
                .WithMessage("{PropertyName} no puede ser vacio o nulo.");

                RuleFor(p => p.VcMetodologiaCapacitacion)
                .NotEmpty()
                .NotNull()
                .WithMessage("{PropertyName} no puede ser vacio o nulo.");


                RuleFor(p => p.HorariosCapacitacionSolicitud)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} no puede ser vacio o nulo.");


                When(p => p.HorariosCapacitacionSolicitud is not null, () =>
                {

                    RuleForEach(p => p.HorariosCapacitacionSolicitud)
                    .Cascade(CascadeMode.Continue)
                    .ChildRules(property =>
                    {

                        property.RuleFor(x => x.DtFechaCapacitacion)
                            .NotEmpty()
                            .NotNull()
                            .WithMessage("{PropertyName} no puede ser vacio o nulo.");
                        
                        property.RuleFor(x => x.HoraInicio)
                            .NotEmpty()
                            .NotNull()
                            .WithMessage("{PropertyName} no puede ser vacio o nulo.");
                        
                        property.RuleFor(x => x.HoraFin)
                            .NotEmpty()
                            .NotNull()
                            .WithMessage("{PropertyName} no puede ser vacio o nulo.");

                    });

                });

                RuleFor(p => p.VcDireccion)
                .NotEmpty()
                .NotNull()
                .WithMessage("{PropertyName} no puede ser vacio o nulo.");
                
                RuleFor(p => p.VcInformacionAdicional)
                .NotEmpty()
                .NotNull()
                .WithMessage("{PropertyName} no puede ser vacio o nulo.");

                

            });

        }

        private bool NotContainRestrictedCharacters(string campo)
        {
            // Define los caracteres que no deben estar presentes en el campo.
            char[] caracteresRestringidos = { 'O', 'E', 'S', 'Ñ' };

            // Verifica si alguno de los caracteres restringidos está presente en el campo.
            return !campo.Any(c => caracteresRestringidos.Contains(c));
        }
    }
}
