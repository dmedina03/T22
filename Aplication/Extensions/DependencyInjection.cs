using Aplication.Mapping;
using Aplication.Services.Parametro;
using Aplication.Services.T22.CapacitacionCapacitadorSolicitudServices;
using Aplication.Services.T22.DocumentoSolicitudServices.Validation;
using Aplication.Services.T22.SolicitudServices;
using Aplication.Services.T22.SolicitudServices.Validation;
using Aplication.Services.T22.TipoCapacitacionServices;
using Aplication.Utilities;
using AutoMapper;
using Domain.DTOs.Request.T22;
using Domain.Models.T22;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repository.IRepositories.Generic;
using Persistence.Repository.IRepositories.IBaseRepository;
using Persistence.Repository.IRepositories.IParametroRepository;
using Persistence.Repository.IRepositories.IT22;
using Persistence.Repository.Repositories.BaseRepository;
using Persistence.Repository.Repositories.ParametroRepository;
using Persistence.Repository.Repositories.T22;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Extensions
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Método para realizar la inyecccion de dependencias de los servicios y repositorios
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddInterfacesInjection(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, ApplicationDbContext>();
            #region Services

            services.AddScoped<IParametroDetalleService, ParametroDetalleService>();
            services.AddScoped<IParametroService, ParametroService>();
            services.AddScoped<ISolicitudService, SolicitudService>();
            services.AddScoped<ITipoCapacitacionService, TipoCapacitacionService>();
            services.AddScoped<ICapacitacionCapacitadorService, CapacitacionCapacitadorService>();

            #endregion

            #region Repositories
            services.AddScoped(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));
            services.AddScoped(typeof(StoredProcedure), typeof(StoredProcedure));
            services.AddScoped<IParametroDetalleRepository, ParametroDetalleRepository>();
            services.AddScoped<ISolicitudRespository, SolicitudRepository>();
            services.AddScoped<IParametroRepository, ParametroRepository>();
            services.AddScoped<ISolicitudRespository, SolicitudRepository>();
            services.AddScoped<ICapacitadorSolicitudRepository, CapacitadorSolicitudRepository>();
            services.AddScoped<IDocumentoSolicitudRepository, DocumentoSolicitudRepository>();
            services.AddScoped<ITipoCapacitacionRepository, TipoCapacitacionRepository>();
            services.AddScoped<IEstadoRepository, EstadoRepository>();
            services.AddScoped<ICapacitadorTipoCapacitacionRepository, CapacitadorTipoCapacitacionRepository>();
            services.AddScoped<ISubsanacionSolicitudRepository, SubsanacionSolicitudRepository>();
            services.AddScoped<ISeguimientoAuditoriaSolicitudRepository, SeguimientoAuditoriaSolicitudRepository>();
            services.AddScoped<IResolucionSolicitudRepository, ResolucionSolicitudRepository>();
            services.AddScoped<ICapacitacionCapacitadorRepository, CapacitacionCapacitadorRepository>();

            #endregion

            return services;
        }
        /// <summary>
        /// Método para realizar la inyeccion del AutoMapper
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddServiceDependency(this IServiceCollection services)
        {
            var mapperConfiguration = new MapperConfiguration(configurationExpression =>
            {
                configurationExpression.AddProfile(new MappingProfile());
            });
            services.AddSingleton(prop => mapperConfiguration.CreateMapper());
            return services;
        }
        /// <summary>
        /// Método para inyectar las clases validadoras *FluentValidation
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddServicesValidation(this IServiceCollection services)
        {

            services.AddScoped<IValidator<SolicitudDTORequest>, SolicitudValidator>();
            services.AddScoped<IValidator<IEnumerable<DocumentoSolicitud>>, DocumentoSolicitudValidator>();
            services.AddScoped<IValidator<SolicitudRevisionValidadorDTORequest>, SolicitudRevisionValidadorValidator>();
            services.AddScoped<IValidator<SolicitudRevisionCoordinadorSubdirectorDTORequest>, SolicitudRevisionCoordinadorSubdirectorValidator>();

            return services;
        }

    }
}
