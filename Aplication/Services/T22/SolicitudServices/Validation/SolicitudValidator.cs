using Aplication.Services.T22.CapacitadorSolicitudServices.Validation;
using Aplication.Services.T22.DocumentoSolicitudServices.Validation;
using Domain.DTOs.Request.T22;
using FluentValidation;
using Persistence.Repository.IRepositories.IT22;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services.T22.SolicitudServices.Validation
{
    public class SolicitudValidator : AbstractValidator<SolicitudDTORequest>
    {
        private readonly ISolicitudRespository _solicitudRespository;

        public SolicitudValidator(ISolicitudRespository solicitudRespository)
        {
            _solicitudRespository = solicitudRespository;

            RuleSet("Create", () =>
            {

                RuleFor(x => x.IdSolicitud).Equal(0).WithMessage("El Id de la solicitud debe ser 0.");

                RuleFor(x => x.UsuarioId).NotEmpty().WithMessage("El campo {PropertyName} es obligatorio.");

                RuleFor(x => x.TipoSolicitudId).NotEqual(0).NotEmpty().WithMessage("El campo {PropertyName} es obligatorio.");

                RuleFor(x => x.VcTipoSolicitante).NotEmpty().WithMessage("El campo {PropertyName} es obligatorio.");

                RuleFor(x => x.VcRadicado)
                    .MustAsync(async (radicado, id) =>
                    {
                        return !await _solicitudRespository.ExistsAsync(x => x.VcRadicado == radicado);
                    })
                    .WithMessage("Ya existe una solicitud con un radicado igual");

                RuleFor(x => x.CapacitadorSolicitud).SetValidator(x => new CapacitadorSolicitudValidator(),"Any", "Create");
            });

            RuleSet("Any", () =>
            {

                RuleFor(x => x.UsuarioId).NotEmpty().WithMessage("El campo UsuarioId es obligatorio.");

                RuleFor(x => x.TipoSolicitudId).NotEqual(0).NotEmpty().WithMessage("El campo TipoSolicitudId es obligatorio.");

                RuleFor(x => x.VcTipoSolicitante).NotEmpty().WithMessage("El campo TipoSolicitanteId es obligatorio.");

                RuleFor(x => x.EstadoId).NotEqual(0).NotEmpty().WithMessage("El campo {PropertyName} es obligatorio.");


            });
        }

    }
}
