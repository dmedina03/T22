using Domain.Models.Parametro;
using Persistence.Repository.IRepositories.IBaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository.IRepositories.IParametroRepository
{
    public interface IParametroDetalleRepository : IBaseRepository<int,ParametroDetalle>
    {
        Task<string> VcNombre(int IdParametroDetalle);

    }
}
