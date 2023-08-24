using Dominio.DTOs.Response.ResponseBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services.Interfaces
{
    public interface IGetService<T>
    {

        public Task<ResponseBase<T>> GetById(int Id);
        public Task<ResponseBase<List<T>>> GetAll();

    }
}
