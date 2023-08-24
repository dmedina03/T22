using Dominio.DTOs.Response.ResponseBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services.Interfaces
{
    public interface ICreateService<T> where T : class
    {
        /// <summary>
        /// Método para crear un registro de la entidad en la BD
        /// </summary>
        /// <param name="request">Objeto, puede ser un DTO o una Entidad</param>
        /// <returns>True si fue exitoso, false si algo fallo</returns>
        Task<ResponseBase<bool>> CreateAsync(T request);

    }
}
