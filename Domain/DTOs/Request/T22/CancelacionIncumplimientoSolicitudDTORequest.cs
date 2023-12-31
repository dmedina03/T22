﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.DTOs.Request.T22
{
    public class CancelacionIncumplimientoSolicitudDtoRequest
    {
        public int IdCancelacion { get; set; }
        [JsonIgnore]
        public int SolicitudId { get; set; }
        [JsonIgnore]
        public DateTime DtFechaCancelacion { get; set; } = DateTime.UtcNow.AddHours(-5);
        public string VcCancelacion { get; set; } = string.Empty;
        /// <summary>
        /// Usuario quien realiza la cancelacion por incumplimiento
        /// </summary>
        public string UsuarioId { get; set; } = string.Empty;
        public string VcNombreUsuario { get; set; } = string.Empty;

        /// <summary>
        /// Estado en el cual se encuentra la solicitud cuando generan la cancelacion por incumplimiento
        /// </summary>
        [JsonIgnore]
        public int EstadoId { get; set; }
    }
}
