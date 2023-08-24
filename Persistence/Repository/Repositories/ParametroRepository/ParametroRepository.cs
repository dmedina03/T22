using Domain.Models.Parametro;
using Persistence.Repository.IRepositories.Generic;
using Persistence.Repository.IRepositories.IParametroRepository;
using Persistence.Repository.Repositories.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository.Repositories.ParametroRepository
{
    public class ParametroRepository : BaseRepository<int, Parametro>, IParametroRepository
    {
        public ParametroRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
