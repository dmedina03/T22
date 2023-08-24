using AutoMapper;
using Domain.DTOs.Response.T22;
using Domain.Models.T22;
using Dominio.DTOs.Response.ResponseBase;
using Persistence.Repository.IRepositories.IT22;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Aplication.Services.T22.TipoCapacitacionServices
{
    public class TipoCapacitacionService : ITipoCapacitacionService
    {
        private readonly ITipoCapacitacionRepository _tipoCapacitacinoRepository;
        private readonly IMapper _mapper;

        public TipoCapacitacionService(ITipoCapacitacionRepository tipoCapacitacinoRepository, IMapper mapper)
        {
            _tipoCapacitacinoRepository = tipoCapacitacinoRepository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<List<TipoCapacitacionDTOResponse>>> GetAll()
        {
            bool isEnable = true;
            var data = (await _tipoCapacitacinoRepository.GetAllAsync(x => x.BlIsEnable == isEnable)).ToList();
            
            var lista = _mapper.Map<List<TipoCapacitacionDTOResponse>>(data);

            if (lista == null || lista.Count() == 0)
            {
                return new ResponseBase<List<TipoCapacitacionDTOResponse>>(HttpStatusCode.OK,"El servicio respondio OK, pero sin datos.",lista,lista.Count());
            }
            return new ResponseBase<List<TipoCapacitacionDTOResponse>>(HttpStatusCode.OK, "OK", lista, lista.Count());
        }

        public async Task<ResponseBase<TipoCapacitacionDTOResponse>> GetById(int Id)
        {
            bool isEnable = true;
            var data = await _tipoCapacitacinoRepository.GetAsync(x => x.IdTipoCapacitacion == Id && x.BlIsEnable == isEnable);

            var entity = _mapper.Map<TipoCapacitacionDTOResponse>(data);

            if (entity == null)
            {
                return new ResponseBase<TipoCapacitacionDTOResponse>(HttpStatusCode.OK, "No existe un Tipo capacitación con ese Id", entity, 1);
            }
            return new ResponseBase<TipoCapacitacionDTOResponse>(HttpStatusCode.OK, "OK", entity, 1);
        }
    }
}
