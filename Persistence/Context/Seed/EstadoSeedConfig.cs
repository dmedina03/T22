using Domain.Models.T22;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context.Seed
{
    public class EstadoSeedConfig
    {
        public EstadoSeedConfig(EntityTypeBuilder<Estado> entity)
        {

            entity.HasData(
                new Estado
                {
                    IdEstado = 1,
                    
                    VcTipoEstado = "En Revisión",
                    VcDescripcion = "",
                    BlIsEnable = true
                },
                new Estado
                {
                    IdEstado = 2,
                    
                    VcTipoEstado = "En Verificación",
                    VcDescripcion = "",
                    BlIsEnable = true
                },
                new Estado
                {
                    IdEstado = 3,
                    
                    VcTipoEstado = "Para firma",
                    VcDescripcion = "",
                    BlIsEnable = true
                },
                new Estado
                {
                    IdEstado = 4,
                    
                    VcTipoEstado = "Devuelta por coordinador",
                    VcDescripcion = "",
                    BlIsEnable = true
                },
                new Estado
                {
                    IdEstado = 5,
                    
                    VcTipoEstado = "Devuelta por Subdirector",
                    VcDescripcion = "",
                    BlIsEnable = true
                },
                new Estado
                {
                    IdEstado = 6,
                    
                    VcTipoEstado = "Vencimiento de terminos",
                    VcDescripcion = "",
                    BlIsEnable = true
                },
                new Estado
                {
                    IdEstado = 7,
                    
                    VcTipoEstado = "Aprobado",
                    VcDescripcion = "",
                    BlIsEnable = true
                },
                new Estado
                {
                    IdEstado = 8,
                    
                    VcTipoEstado = "En Subsanación",
                    VcDescripcion = "",
                    BlIsEnable = true
                },
                new Estado
                {
                    IdEstado = 9,
                    
                    VcTipoEstado = "Cancelado",
                    VcDescripcion = "",
                    BlIsEnable = true
                },
                new Estado
                {
                    IdEstado = 10,
                    
                    VcTipoEstado = "Negado",
                    VcDescripcion = "",
                    BlIsEnable = true
                },
                new Estado
                {
                    IdEstado = 11,
                    
                    VcTipoEstado = "Cancelado por incumplimiento",
                    VcDescripcion = "",
                    BlIsEnable = true
                });
            
        }
    }
}
