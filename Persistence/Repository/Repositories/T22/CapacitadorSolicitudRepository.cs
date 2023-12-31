﻿using Domain.Models.T22;
using Persistence.Repository.IRepositories.Generic;
using Persistence.Repository.IRepositories.IBaseRepository;
using Persistence.Repository.IRepositories.IT22;
using Persistence.Repository.Repositories.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository.Repositories.T22
{
    public class CapacitadorSolicitudRepository : BaseRepository<int, CapacitadorSolicitud>, ICapacitadorSolicitudRepository
    {
        public CapacitadorSolicitudRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }


        public async Task<string> GetNombreCapacitador(string IdCapacitador)
        {
            var capacitador = await GetAsync(x => x.IdCapacitadorSolicitud == Guid.Parse(IdCapacitador));

            var nombre = $"{capacitador.VcPrimerNombre} {capacitador.VcSegundoNombre} {capacitador.VcPrimerApellido} {capacitador.VcSegundoApellido}";
            return nombre;
        }

    }
}
