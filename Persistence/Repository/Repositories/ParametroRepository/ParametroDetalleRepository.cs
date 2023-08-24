using Domain.Models.Parametro;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Persistence.Repository.IRepositories.Generic;
using Persistence.Repository.IRepositories.IBaseRepository;
using Persistence.Repository.IRepositories.IParametroRepository;
using Persistence.Repository.Repositories.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository.Repositories.ParametroRepository
{
    public class ParametroDetalleRepository : BaseRepository<int, ParametroDetalle>, IParametroDetalleRepository
    {
        public ParametroDetalleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
