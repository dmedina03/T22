using Aplication.Services.T22.ReporteServices.Reportes.ActosAdministrativos;
using Aplication.Services.T22.ReporteServices.Reportes.SeguimientoCapacitaciones;
using Aplication.Services.T22.ReporteServices.Reportes.AutorizacionesCanceladas;
using ClosedXML.Excel;
using Domain.DTOs.Request.T22;
using Dominio.DTOs.Response.ResponseBase;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Aplication.Services.T22.ReporteServices.Reportes.CapacitadoresAutorizadosInvima;
using Aplication.Services.T22.ReporteServices.Reportes.CapacitadoresSuspendidosInvima;
using FluentValidation;

namespace Aplication.Services.T22.ReporteServices
{
    public class ReporteServices : IReporteServices
    {
        private readonly IActosAdministrativosGenerados _actosAdministrativosGenerados;
        private readonly ISeguimientoCapacitaciones _seguimientoCapacitaciones;
        private readonly IAutorizacionesCanceladas _autorizacionesCanceladas;
        private readonly ICapacitadoresAutorizadosInvima _capacitadoresAutorizados;
        private readonly ICapacitadoresSuspendidosInivima _capacitadoresSuspendidos;
        private readonly IValidator<ReportesDtoRequest> _validator;


        public ReporteServices(IActosAdministrativosGenerados actosAdministrativosGenerados, ISeguimientoCapacitaciones seguimientoCapacitaciones,
            IAutorizacionesCanceladas autorizacionesCanceladas, ICapacitadoresAutorizadosInvima capacitadoresAutorizados, ICapacitadoresSuspendidosInivima capacitadoresSuspendidos,
            IValidator<ReportesDtoRequest> validator)
        {
            _actosAdministrativosGenerados = actosAdministrativosGenerados;
            _seguimientoCapacitaciones = seguimientoCapacitaciones;
            _autorizacionesCanceladas = autorizacionesCanceladas;
            _capacitadoresAutorizados = capacitadoresAutorizados;
            _capacitadoresSuspendidos = capacitadoresSuspendidos;
            _validator = validator;
        }

        public async Task<XLWorkbook> GetReporteActosAdministrativosGeneradosService(ReportesDtoRequest request)
        {

            var result = await _validator.ValidateAsync(request, opt => opt.IncludeAllRuleSets());
            if (!result.IsValid)
            {
                return null;
            }
            return await _actosAdministrativosGenerados.GetReporteActosAdministrativosGenerados(request);
            
        }

        public async Task<XLWorkbook> GetReporteSeguimientoCapacitacionesService(ReportesDtoRequest request)
        {
            var result = await _validator.ValidateAsync(request, opt => opt.IncludeAllRuleSets());
            if (!result.IsValid)
            {
                return null;
            }
            return await _seguimientoCapacitaciones.GetReporteActosAdministrativosGenerados(request);
        }

        public async Task<XLWorkbook> GetReporteAutorizacionesCanceladasService(ReportesDtoRequest request)
        {
            var result = await _validator.ValidateAsync(request, opt => opt.IncludeAllRuleSets());
            if (!result.IsValid)
            {
                return null;
            }
            return await _autorizacionesCanceladas.GetReporteAutorizacionesCanceladas(request);

        }
        public async Task<XLWorkbook> GetReporteCapacitadoresAutorizadosService(ReportesDtoRequest request)
        {
            var result = await _validator.ValidateAsync(request, opt => opt.IncludeAllRuleSets());
            if (!result.IsValid)
            {
                return null;
            }
            return await _capacitadoresAutorizados.GetReporteCapacitadoresAutorizados(request);

        }

        public async Task<XLWorkbook> GetReporteCapacitadoresSuspendidosService(ReportesDtoRequest request)
        {
            var result = await _validator.ValidateAsync(request, opt => opt.IncludeAllRuleSets());
            if (!result.IsValid)
            {
                return null;
            }
            return await _capacitadoresSuspendidos.GetReporteCapacitadoresSuspendidos(request);
        }
    }
}
