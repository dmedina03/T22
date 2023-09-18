using Domain.Models.T22;
using Persistence.Repository.IRepositories.Generic;
using Persistence.Repository.IRepositories.IT22;
using Persistence.Repository.Repositories.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository.Repositories.T22
{
    public class CapacitadorTipoCapacitacionRepository : BaseRepository<int, CapacitadorTipoCapacitacion>, ICapacitadorTipoCapacitacionRepository
    {
        public CapacitadorTipoCapacitacionRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

    }
}
