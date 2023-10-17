using Domain.DTOs.Request.T22;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services.T22.ReporteServices.Validation
{
    public class ReporteValidator : AbstractValidator<ReportesDtoRequest>
    {
        public ReporteValidator()
        {

            RuleSet("Any", () =>
            {

                RuleFor(x => Convert.ToDateTime(x.FechaHasta))
                    .GreaterThan(x => Convert.ToDateTime(x.FechaDesde))
                    .WithMessage("La Fecha inicial no puede ser mayor a la fecha final");
                    
                  

            });
            
        }
    }
}
