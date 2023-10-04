using Aplication.Mapping;
using Aplication.Services.Parametro;
using Aplication.Services.T22.CapacitacionCapacitadorSolicitudServices;
using Aplication.Services.T22.CapacitacionCapacitadorSolicitudServices.Validation;
using Aplication.Services.T22.CapacitadorSolicitudServices;
using Aplication.Services.T22.DocumentoSolicitudServices.Validation;
using Aplication.Services.T22.SolicitudServices;
using Aplication.Services.T22.SolicitudServices.Validation;
using Aplication.Services.T22.TipoCapacitacionServices;
using Aplication.Services.T22.ResolucionServices;
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
using Aplication.Services.T22.ReporteServices;
using Aplication.Services.T22.ReporteServices.Design;
using Aplication.Services.T22.ReporteServices.Reportes.ActosAdministrativos;
using Aplication.Services.T22.ReporteServices.Reportes.SeguimientoCapacitaciones;
using Aplication.Services.T22.ReporteServices.Reportes.AutorizacionesCanceladas;
using Aplication.Services.T22.ReporteServices.Reportes.CapacitadoresAutorizadosInvima;
using Aplication.Services.T22.ReporteServices.Reportes.CapacitadoresSuspendidosInvima;
using Aplication.Services.T22.ReporteServices.Validation;
using Aplication.Services.T22.RecursoSolicitudServices;
using Aplication.Services.T22.RecursoSolicitudServices.Validation;

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
			services.AddScoped<ICapacitadorSolicitudService, CapacitadorSolicitudService>();
			services.AddScoped<IResolucionService, ResolucionService>();
			services.AddScoped<IReporteServices, ReporteServices>();
			services.AddScoped<IActosAdministrativosGenerados, ActosAdministrativosGenerados > ();
			services.AddScoped<ISeguimientoCapacitaciones, SeguimientoCapacitaciones > ();
			services.AddScoped<IAutorizacionesCanceladas, AutorizacionesCanceladas > ();
			services.AddScoped<ICapacitadoresAutorizadosInvima, CapacitadoresAutorizadosInvima> ();
			services.AddScoped<ICapacitadoresSuspendidosInivima, CapacitadoresSuspendidosInvima> ();
			services.AddScoped<IRecursoSolicitudService, RecursoSolicitudService> ();
            services.AddScoped(typeof(ReporteDesign));

            #endregion

            #region Repositories
            services.AddScoped(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));
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
            services.AddScoped<IFormatoPlantillaRepository, FormatoPlantillaRepository>();

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
            services.AddScoped<IValidator<IEnumerable<DocumentoSolicitudDTORequest>>, DocumentoSolicitudEnumerableDTOValidator>();
            services.AddScoped<IValidator<DocumentoSolicitudDTORequest>, DocumentoSolicitudDTOValidator>();
            services.AddScoped<IValidator<SolicitudRevisionValidadorDTORequest>, SolicitudRevisionValidadorValidator>();
            services.AddScoped<IValidator<SolicitudRevisionCoordinadorDTORequest>, SolicitudRevisionCoordinadorValidator>();
            services.AddScoped<IValidator<SolicitudRevisionSubdirectorDTORequest>, SolicitudRevisionSubdirectorValidator>();
            services.AddScoped<IValidator<CapacitacionCapacitadorSolicitudDTORequest>, CapacitacionCapacitadorValidator>();
            services.AddScoped<IValidator<RevisionCapacitacionDTORequest>, CapacitacionCapacitadorRevisionValidator>();
            services.AddScoped<IValidator<RevisionRecursoSolicitudDTORequest>, RevisionRecursoSolicitudDTOValidator>();
            services.AddScoped<IValidator<VerificacionAprobacionRecursoSolicitudDTORequest>, VerificacionAprobacionRecursoSolicitudDTOValidator>();
            services.AddScoped<IValidator<ReportesDTORequest>, ReporteValidator>();

            return services;
        }

    }
}
