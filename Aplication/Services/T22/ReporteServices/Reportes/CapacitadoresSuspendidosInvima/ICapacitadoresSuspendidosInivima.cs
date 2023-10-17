﻿using ClosedXML.Excel;
using Domain.DTOs.Request.T22;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services.T22.ReporteServices.Reportes.CapacitadoresSuspendidosInvima
{
    public interface ICapacitadoresSuspendidosInivima
    {
        Task<XLWorkbook> GetReporteCapacitadoresSuspendidos(ReportesDtoRequest request);

    }
}
