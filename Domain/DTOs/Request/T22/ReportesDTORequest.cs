using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Request.T22
{
    public class ReportesDtoRequest
    {

        //[DataType(DataType.Date)]
        public string FechaDesde { get; set; } = string.Empty;
        //[DataType(DataType.Date)]
        public string FechaHasta { get; set; } = string.Empty;

    }
}
