using Domain.Models.T22;
using Persistence.Repository.IRepositories.IBaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository.IRepositories.IT22
{
    public interface IEstadoRepository : IBaseRepository<int, Estado>
    {
    }
}
