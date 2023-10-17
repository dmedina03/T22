using Domain.Models.Parametro;
using Microsoft.EntityFrameworkCore;
using Persistence.Repository.IRepositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public static class ApplicationDbContextSeed
    {
        public static void EnsureSeed(this IUnitOfWork context)
        {
#pragma warning disable // Desreferencia de una referencia posiblemente NULL.

            CargarTipoResolucion(context);
            CargarResultadoValidacion(context);
            CargarTipoSolicitud(context);
            CargarReportes(context);

            CargarTipoIdentificacion(context);
            CargarConstantes(context);
            CargarDocumentosSolicitud(context);
            CargarCiudadanoFiltroPor(context);
            CargarFuncionarioFiltroPor(context);
            CargarFuncionarioSeguimientoCapacitacionFiltroPor(context);
            CargarCiudadanoSeguimientoCapacitacionFiltroPor(context);
            CargarDireccionViaPrincipal(context);
            CargarDireccionCardinalidad(context);

            context.Commit();
        }

        private static void CargarTipoResolucion(IUnitOfWork context)
        {
            IQueryable<Parametro> query = context.GetSet<long, Parametro>().AsNoTracking();

            query = query.Where(prop => prop.VcCodigoInterno == "bTipoResolucion");

            Parametro parametroPuente = null;
            Parametro parametro = query.AsNoTracking().FirstOrDefault();

            if (parametro is null)
            {
                var parametroAguardar = new Parametro
                {
                    //IdParametro = 1,
                    VcNombre = "Tipo resolución",
                    VcCodigoInterno = "bTipoResolucion",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now,
                    DtFechaActualizacion = DateTime.Now
                };

                context.GetSet<long, Parametro>().Add(parametroAguardar);
                context.Commit();

                parametroPuente = parametroAguardar;
            }
            else
            {
                parametroPuente = parametro;
            }

            List<ParametroDetalle> listaTipoResolucion = new List<ParametroDetalle>();

            listaTipoResolucion.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,

                //IdParametroDetalle = 1,
                //ParametroId = 1,
                VcNombre = "Resolución de aprobación",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });

            listaTipoResolucion.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,

                //IdParametroDetalle = 2,
                //ParametroId = 1,
                VcNombre = "Resolución de cancelación",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });

            listaTipoResolucion.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,

                //IdParametroDetalle = 3,
                //ParametroId = 1,
                VcNombre = "Resolución de negación",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaTipoResolucion.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,

                //IdParametroDetalle = 4,
                //ParametroId = 1,
                VcNombre = "Resolución de modificación",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaTipoResolucion.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,

                //IdParametroDetalle = 5,
                //ParametroId = 1,
                VcNombre = "Resolución de cancelación por incumplimiento",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });


            foreach (ParametroDetalle item in listaTipoResolucion)
            {
                //Se genera la validacion con el ParametroId, para que se puedan insertar Detalles con el mismo nombre 
                if (!context.GetSet<long, ParametroDetalle>().Any(prop => prop.VcNombre.ToUpper() == item.VcNombre.ToUpper() && prop.ParametroId.Equals(item.ParametroId)))
                {
                    context.GetSet<long, ParametroDetalle>().Add(item);
                }
            }

        }

        private static void CargarResultadoValidacion(IUnitOfWork context)
        {
            IQueryable<Parametro> query = context.GetSet<long, Parametro>().AsNoTracking();

            query = query.Where(prop => prop.VcCodigoInterno == "bResultadoValidacion");

            Parametro parametroPuente = null;
            Parametro parametro = query.AsNoTracking().FirstOrDefault();

            if (parametro is null)
            {
                var parametroAguardar = new Parametro
                {
                    //IdParametro = 2,
                    VcNombre = "Resultado de la validación",
                    VcCodigoInterno = "bResultadoValidacion",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now,
                    DtFechaActualizacion = DateTime.Now
                };

                context.GetSet<long, Parametro>().Add(parametroAguardar);
                context.Commit();

                parametroPuente = parametroAguardar;
            }
            else
            {
                parametroPuente = parametro;
            }

            List<ParametroDetalle> listaResultadoValidacion = new List<ParametroDetalle>();

            listaResultadoValidacion.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,

                //IdParametroDetalle = 6,
                //ParametroId = 2,
                VcNombre = "Aprobar solicitud",
                TxDescripcion = "Aprobación",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });

            listaResultadoValidacion.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,

                //IdParametroDetalle = 7,
                //ParametroId = 2,
                VcNombre = "Cancelar solicitud",
                TxDescripcion = "Cancelación",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });

            listaResultadoValidacion.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,

                //IdParametroDetalle = 8,
                //ParametroId = 2,
                VcNombre = "Negar solicitud",
                TxDescripcion = "Negación",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaResultadoValidacion.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,

                //IdParametroDetalle = 9,
                //ParametroId = 2,
                VcNombre = "Para Subsanación",
                TxDescripcion = "Subsanación",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaResultadoValidacion.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,

                //IdParametroDetalle = 10,
                //ParametroId = 2,
                VcNombre = "Cancelar por incumplimiento",
                TxDescripcion = "Cancelación por incumplimiento",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaResultadoValidacion.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,

                //IdParametroDetalle = 11,
                //ParametroId = 2,
                VcNombre = "Recurso",
                TxDescripcion = "Recurso",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });


            foreach (ParametroDetalle item in listaResultadoValidacion)
            {
                //Se genera la validacion con el ParametroId, para que se puedan insertar Detalles con el mismo nombre 
                if (!context.GetSet<long, ParametroDetalle>().Any(prop => prop.VcNombre.ToUpper() == item.VcNombre.ToUpper() && prop.ParametroId.Equals(item.ParametroId)))
                {
                    context.GetSet<long, ParametroDetalle>().Add(item);
                }
            }

        }

        private static void CargarTipoSolicitud(IUnitOfWork context)
        {
            IQueryable<Parametro> query = context.GetSet<long, Parametro>().AsNoTracking();

            query = query.Where(prop => prop.VcCodigoInterno == "bTipoSolicitud");

            Parametro parametroPuente = null;
            Parametro parametro = query.AsNoTracking().FirstOrDefault();

            if (parametro is null)
            {
                var parametroAguardar = new Parametro
                {
                    //Tipo de Solicitud
                    //IdParametro = 3,
                    VcNombre = "Tipo de solicitud",
                    VcCodigoInterno = "bTipoSolicitud",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now,
                    DtFechaActualizacion = DateTime.Now
                };

                context.GetSet<long, Parametro>().Add(parametroAguardar);
                context.Commit();

                parametroPuente = parametroAguardar;
            }
            else
            {
                parametroPuente = parametro;
            }

            List<ParametroDetalle> listaTipoSolicitud = new List<ParametroDetalle>();

            listaTipoSolicitud.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,

                //IdParametroDetalle = 12,
                //ParametroId = 3,
                VcNombre = "Primera vez",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });

            listaTipoSolicitud.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,

                //IdParametroDetalle = 13,
                //ParametroId = 3,
                VcNombre = "Renovación",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });

            listaTipoSolicitud.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,

                //IdParametroDetalle = 14,
                //ParametroId = 3,
                VcNombre = "Modificación",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaTipoSolicitud.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,

                //IdParametroDetalle = 15,
                //ParametroId = 3,
                VcNombre = "Recurso de reposición",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaTipoSolicitud.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,

                //IdParametroDetalle = 16,
                //ParametroId = 3,
                VcNombre = "Cancelación",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });

            foreach (ParametroDetalle item in listaTipoSolicitud)
            {
                //Se genera la validacion con el ParametroId, para que se puedan insertar Detalles con el mismo nombre 
                if (!context.GetSet<long, ParametroDetalle>().Any(prop => prop.VcNombre.ToUpper() == item.VcNombre.ToUpper() && prop.ParametroId.Equals(item.ParametroId)))
                {
                    context.GetSet<long, ParametroDetalle>().Add(item);
                }
            }

        }
        private static void CargarReportes(IUnitOfWork context)
        {
            IQueryable<Parametro> query = context.GetSet<long, Parametro>().AsNoTracking();

            query = query.Where(prop => prop.VcCodigoInterno == "bReportes");

            Parametro parametroPuente = null;
            Parametro parametro = query.AsNoTracking().FirstOrDefault();

            if (parametro is null)
            {
                var parametroAguardar = new Parametro
                {
                    //Reportes
                    //IdParametro = 4,
                    VcNombre = "Reportes",
                    VcCodigoInterno = "bReportes",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now,
                    DtFechaActualizacion = DateTime.Now
                };

                context.GetSet<long, Parametro>().Add(parametroAguardar);
                context.Commit();

                parametroPuente = parametroAguardar;
            }
            else
            {
                parametroPuente = parametro;
            }

            List<ParametroDetalle> listaReportes = new List<ParametroDetalle>();

            listaReportes.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,

                //IdParametroDetalle = 17,
                //ParametroId = 4,
                VcNombre = "Actos administrativos generados",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });

            listaReportes.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,

                //IdParametroDetalle = 18,
                //ParametroId = 4,
                VcNombre = "Autorizaciones canceladas",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });

            listaReportes.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,

                //IdParametroDetalle = 19,
                //ParametroId = 4,
                VcNombre = "Seguimiento capacitaciones",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaReportes.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,

                //IdParametroDetalle = 20,
                //ParametroId = 4,
                VcNombre = "Listado de capacitadores autorizados INVIMA",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaReportes.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                //IdParametroDetalle = 21,
                //ParametroId = 4,
                VcNombre = "Listado de capacitadores suspendidos INVIMA",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });


            foreach (ParametroDetalle item in listaReportes)
            {
                //Se genera la validacion con el ParametroId, para que se puedan insertar Detalles con el mismo nombre 
                if (!context.GetSet<long, ParametroDetalle>().Any(prop => prop.VcNombre.ToUpper() == item.VcNombre.ToUpper() && prop.ParametroId.Equals(item.ParametroId)))
                {
                    context.GetSet<long, ParametroDetalle>().Add(item);
                }
            }

        }
        private static void CargarTipoIdentificacion(IUnitOfWork context)
        {
            IQueryable<Parametro> query = context.GetSet<long, Parametro>().AsNoTracking();

            query = query.Where(prop => prop.VcCodigoInterno == "bTipoIdentificacion");

            Parametro parametroPuente = null;
            Parametro parametro = query.AsNoTracking().FirstOrDefault();

            if (parametro is null)
            {
                var parametroAguardar = new Parametro
                {
                    VcNombre = "Tipo de Identificacion",
                    VcCodigoInterno = "bTipoIdentificacion",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now,
                    DtFechaActualizacion = DateTime.Now
                };

                context.GetSet<long, Parametro>().Add(parametroAguardar);
                context.Commit();

                parametroPuente = parametroAguardar;
            }
            else
            {
                parametroPuente = parametro;
            }

            List<ParametroDetalle> listaTipoIdentificacion = new List<ParametroDetalle>();

            listaTipoIdentificacion.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "CC",
                TxDescripcion = "Cédula de Ciudadanía",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });

            listaTipoIdentificacion.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "CE",
                TxDescripcion = "Cédula de Extranjería",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });

            listaTipoIdentificacion.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "TI",
                TxDescripcion = "Tarjeta de Identidad",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaTipoIdentificacion.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "RC",
                TxDescripcion = "Regisitro Civil de Nacimiento",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaTipoIdentificacion.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "NUIP",
                TxDescripcion = "Número único de identificación personal",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaTipoIdentificacion.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "PA",
                TxDescripcion = "Pasaporte",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaTipoIdentificacion.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "TE",
                TxDescripcion = "Tarjeta de Extranjería",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });


            foreach (ParametroDetalle item in listaTipoIdentificacion)
            {
                //Se genera la validacion con el ParametroId, para que se puedan insertar Detalles con el mismo nombre 
                if (!context.GetSet<long, ParametroDetalle>().Any(prop => prop.VcNombre.ToUpper() == item.VcNombre.ToUpper() && prop.ParametroId.Equals(item.ParametroId)))
                {
                    context.GetSet<long, ParametroDetalle>().Add(item);
                }
            }

        }
        private static void CargarConstantes(IUnitOfWork context)
        {
            IQueryable<Parametro> query = context.GetSet<long, Parametro>().AsNoTracking();

            query = query.Where(prop => prop.VcCodigoInterno == "bConstantes");

            Parametro parametroPuente = null;
            Parametro parametro = query.AsNoTracking().FirstOrDefault();

            if (parametro is null)
            {
                var parametroAguardar = new Parametro
                {
                    VcNombre = "Constantes",
                    VcCodigoInterno = "bConstantes",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now,
                    DtFechaActualizacion = DateTime.Now
                };

                context.GetSet<long, Parametro>().Add(parametroAguardar);
                context.Commit();

                parametroPuente = parametroAguardar;
            }
            else
            {
                parametroPuente = parametro;
            }

            var infoConstantes = new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Inicio de solicitud",
                TxDescripcion = "HU 01",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            };

            if (!context.GetSet<long, ParametroDetalle>().Any(prop => prop.VcNombre.ToUpper() == infoConstantes.VcNombre.ToUpper() && prop.ParametroId.Equals(infoConstantes.ParametroId)))
            {
                context.GetSet<long, ParametroDetalle>().Add(infoConstantes);
            }

            context.Commit();

            List<ParametroDetalle> listaConstantes = new List<ParametroDetalle>();

            listaConstantes.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                IdPadre = infoConstantes.IdParametroDetalle,
                VcNombre = "Autorización para capacitadores de manipulación de alimentos",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaConstantes.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                IdPadre = infoConstantes.IdParametroDetalle,
                VcNombre = "Autorización para desarrollar programas de educación sanitaria, que permite capacitar al personal que manipula, " +
                        "procesa y expende alimentos y productos cárnicos comestibles, alimentos comercializados en vía pública, leche cruda para consumo" +
                        " humano directo comercializada de manera ambulante, y objetos, envases, materiales y equipamientos en contacto con alimentos.",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });

            infoConstantes = new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Registro existoso de solicitud",
                TxDescripcion = "HU 04",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            };

            if (!context.GetSet<long, ParametroDetalle>().Any(prop => prop.VcNombre.ToUpper() == infoConstantes.VcNombre.ToUpper() && prop.ParametroId.Equals(infoConstantes.ParametroId)))
            {
                context.GetSet<long, ParametroDetalle>().Add(infoConstantes);
            }

            context.Commit();

            listaConstantes.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                IdPadre = infoConstantes.IdParametroDetalle,
                VcNombre = "Por favor verifique su mensaje de confirmación en su correo electrónico, para hacerle seguimiento a " +
                            "este trámite no olvide anotar el ID del ticket descrito a continuación. Muchas gracias por utilizar los " +
                            "servicios en línea de la Secretaría Distrital de Salud.",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });


            foreach (ParametroDetalle item in listaConstantes)
            {
                //Se genera la validacion con el ParametroId, para que se puedan insertar Detalles con el mismo nombre 
                if (!context.GetSet<long, ParametroDetalle>().Any(prop => prop.VcNombre.ToUpper() == item.VcNombre.ToUpper() && prop.ParametroId.Equals(item.ParametroId)))
                {
                    context.GetSet<long, ParametroDetalle>().Add(item);
                }
            }
            context.Commit();
        }
        private static void CargarDocumentosSolicitud(IUnitOfWork context)
        {
            IQueryable<Parametro> query = context.GetSet<long, Parametro>().AsNoTracking();

            query = query.Where(prop => prop.VcCodigoInterno == "bDocumentosSolicitud");

            Parametro parametroPuente = null;
            Parametro parametro = query.AsNoTracking().FirstOrDefault();

            if (parametro is null)
            {
                var parametroAguardar = new Parametro
                {
                    VcNombre = "Documentos de la solicitud",
                    VcCodigoInterno = "bDocumentosSolicitud",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now,
                    DtFechaActualizacion = DateTime.Now
                };

                context.GetSet<long, Parametro>().Add(parametroAguardar);
                context.Commit();

                parametroPuente = parametroAguardar;
            }
            else
            {
                parametroPuente = parametro;
            }

            List<ParametroDetalle> listaDocumentos = new List<ParametroDetalle>();

            listaDocumentos.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Cédula de ciudadanía",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });

            listaDocumentos.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Carta de solicitud",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });

            listaDocumentos.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Hoja de vida",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaDocumentos.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Descripción detallada del curso",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaDocumentos.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Pensum de pregrado",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaDocumentos.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Diploma profesional / tecnólogo",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaDocumentos.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Tarjeta profesional",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaDocumentos.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Resumen didáctico del curso",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaDocumentos.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Memorias ilustradas",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaDocumentos.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Resolución",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaDocumentos.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Revisión capacitación",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaDocumentos.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Recurso",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaDocumentos.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Respuesta Recurso",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });

            foreach (ParametroDetalle item in listaDocumentos)
            {
                //Se genera la validacion con el ParametroId, para que se puedan insertar Detalles con el mismo nombre 
                if (!context.GetSet<long, ParametroDetalle>().Any(prop => prop.VcNombre.ToUpper() == item.VcNombre.ToUpper() && prop.ParametroId.Equals(item.ParametroId)))
                {
                    context.GetSet<long, ParametroDetalle>().Add(item);
                }
            }

        }
        private static void CargarCiudadanoFiltroPor(IUnitOfWork context)
        {
            IQueryable<Parametro> query = context.GetSet<long, Parametro>().AsNoTracking();

            query = query.Where(prop => prop.VcCodigoInterno == "bCiudadanoFiltrarPor");

            Parametro parametroPuente = null;
            Parametro parametro = query.AsNoTracking().FirstOrDefault();

            if (parametro is null)
            {
                var parametroAguardar = new Parametro
                {
                    VcNombre = "Ciudanano Filtrar por",
                    VcCodigoInterno = "bCiudadanoFiltrarPor",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now,
                    DtFechaActualizacion = DateTime.Now
                };

                context.GetSet<long, Parametro>().Add(parametroAguardar);
                context.Commit();

                parametroPuente = parametroAguardar;
            }
            else
            {
                parametroPuente = parametro;
            }

            List<ParametroDetalle> listaDocumentos = new List<ParametroDetalle>();

            listaDocumentos.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "ID de Solicitud",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });

            listaDocumentos.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Estado",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });

            listaDocumentos.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Fecha de solicitud",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            
            foreach (ParametroDetalle item in listaDocumentos)
            {
                //Se genera la validacion con el ParametroId, para que se puedan insertar Detalles con el mismo nombre 
                if (!context.GetSet<long, ParametroDetalle>().Any(prop => prop.VcNombre.ToUpper() == item.VcNombre.ToUpper() && prop.ParametroId.Equals(item.ParametroId)))
                {
                    context.GetSet<long, ParametroDetalle>().Add(item);
                }
            }

        }
        private static void CargarFuncionarioFiltroPor(IUnitOfWork context)
        {
            IQueryable<Parametro> query = context.GetSet<long, Parametro>().AsNoTracking();

            query = query.Where(prop => prop.VcCodigoInterno == "bFuncionarioFiltrarPor");

            Parametro parametroPuente = null;
            Parametro parametro = query.AsNoTracking().FirstOrDefault();

            if (parametro is null)
            {
                var parametroAguardar = new Parametro
                {
                    VcNombre = "Funcionario Filtrar por",
                    VcCodigoInterno = "bFuncionarioFiltrarPor",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now,
                    DtFechaActualizacion = DateTime.Now
                };

                context.GetSet<long, Parametro>().Add(parametroAguardar);
                context.Commit();

                parametroPuente = parametroAguardar;
            }
            else
            {
                parametroPuente = parametro;
            }

            List<ParametroDetalle> listaFiltrarPor = new List<ParametroDetalle>();

            listaFiltrarPor.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "ID Solicitud",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });

            listaFiltrarPor.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Solicitante",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });

            listaFiltrarPor.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "No. Identificación",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaFiltrarPor.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Tipo de solicitud",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaFiltrarPor.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Tipo de Solicitante",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaFiltrarPor.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Fecha de solicitud",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaFiltrarPor.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Acciones permitidas",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaFiltrarPor.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Tiempo de atención restante",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            
            foreach (ParametroDetalle item in listaFiltrarPor)
            {
                //Se genera la validacion con el ParametroId, para que se puedan insertar Detalles con el mismo nombre 
                if (!context.GetSet<long, ParametroDetalle>().Any(prop => prop.VcNombre.ToUpper() == item.VcNombre.ToUpper() && prop.ParametroId.Equals(item.ParametroId)))
                {
                    context.GetSet<long, ParametroDetalle>().Add(item);
                }
            }

        }
        private static void CargarFuncionarioSeguimientoCapacitacionFiltroPor(IUnitOfWork context)
        {
            IQueryable<Parametro> query = context.GetSet<long, Parametro>().AsNoTracking();

            query = query.Where(prop => prop.VcCodigoInterno == "bFuncionarioSeguimientoCapacitacionFiltrarPor");

            Parametro parametroPuente = null;
            Parametro parametro = query.AsNoTracking().FirstOrDefault();

            if (parametro is null)
            {
                var parametroAguardar = new Parametro
                {
                    VcNombre = "Funciorario Seguimiento Capacitacion Filtrar por",
                    VcCodigoInterno = "bFuncionarioSeguimientoCapacitacionFiltrarPor",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now,
                    DtFechaActualizacion = DateTime.Now
                };

                context.GetSet<long, Parametro>().Add(parametroAguardar);
                context.Commit();

                parametroPuente = parametroAguardar;
            }
            else
            {
                parametroPuente = parametro;
            }

            List<ParametroDetalle> listaFiltrarPor = new List<ParametroDetalle>();

            listaFiltrarPor.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Número de resolución",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });

            listaFiltrarPor.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Nombre del ciudadano / entidad",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });

            listaFiltrarPor.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Identificación",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            
            foreach (ParametroDetalle item in listaFiltrarPor)
            {
                //Se genera la validacion con el ParametroId, para que se puedan insertar Detalles con el mismo nombre 
                if (!context.GetSet<long, ParametroDetalle>().Any(prop => prop.VcNombre.ToUpper() == item.VcNombre.ToUpper() && prop.ParametroId.Equals(item.ParametroId)))
                {
                    context.GetSet<long, ParametroDetalle>().Add(item);
                }
            }

        }
        private static void CargarCiudadanoSeguimientoCapacitacionFiltroPor(IUnitOfWork context)
        {
            IQueryable<Parametro> query = context.GetSet<long, Parametro>().AsNoTracking();

            query = query.Where(prop => prop.VcCodigoInterno == "bCiudadanoSeguimientoCapacitacionFiltrarPor");

            Parametro parametroPuente = null;
            Parametro parametro = query.AsNoTracking().FirstOrDefault();

            if (parametro is null)
            {
                var parametroAguardar = new Parametro
                {
                    VcNombre = "Ciudadano Seguimiento Capacitacion Filtrar por",
                    VcCodigoInterno = "bCiudadanoSeguimientoCapacitacionFiltrarPor",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now,
                    DtFechaActualizacion = DateTime.Now
                };

                context.GetSet<long, Parametro>().Add(parametroAguardar);
                context.Commit();

                parametroPuente = parametroAguardar;
            }
            else
            {
                parametroPuente = parametro;
            }

            List<ParametroDetalle> listaFiltrarPor = new List<ParametroDetalle>();

            listaFiltrarPor.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Número de resolución",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });

            listaFiltrarPor.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Fecha de resolución",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });

            listaFiltrarPor.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Tipo de autorización",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaFiltrarPor.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Estado de autorización",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            
            foreach (ParametroDetalle item in listaFiltrarPor)
            {
                //Se genera la validacion con el ParametroId, para que se puedan insertar Detalles con el mismo nombre 
                if (!context.GetSet<long, ParametroDetalle>().Any(prop => prop.VcNombre.ToUpper() == item.VcNombre.ToUpper() && prop.ParametroId.Equals(item.ParametroId)))
                {
                    context.GetSet<long, ParametroDetalle>().Add(item);
                }
            }

        }
        private static void CargarDireccionViaPrincipal(IUnitOfWork context)
        {
            IQueryable<Parametro> query = context.GetSet<long, Parametro>().AsNoTracking();

            query = query.Where(prop => prop.VcCodigoInterno == "bDireccionViaPpl");

            Parametro parametroPuente = null;
            Parametro parametro = query.AsNoTracking().FirstOrDefault();

            if (parametro is null)
            {
                var parametroAguardar = new Parametro
                {
                    VcNombre = "Vía",
                    VcCodigoInterno = "bDireccionViaPpl",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now,
                    DtFechaActualizacion = DateTime.Now
                    
                };

                context.GetSet<long, Parametro>().Add(parametroAguardar);
                context.Commit();

                parametroPuente = parametroAguardar;
            }
            else
            {
                parametroPuente = parametro;
            }

            List<ParametroDetalle> listaViaPpl = new List<ParametroDetalle>();

            listaViaPpl.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "CL",
                TxDescripcion = "Calle",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });

            listaViaPpl.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "DG",
                TxDescripcion = "Diagonal",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });

            listaViaPpl.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "AC",
                TxDescripcion = "Avenida Calle",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaViaPpl.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "KR",
                TxDescripcion = "Carrera",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaViaPpl.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "TV",
                TxDescripcion = "Transversal",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaViaPpl.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "AK",
                TxDescripcion = "Avenida Carrera",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaViaPpl.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "AV",
                TxDescripcion = "Avenida",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            
            foreach (ParametroDetalle item in listaViaPpl)
            {
                //Se genera la validacion con el ParametroId, para que se puedan insertar Detalles con el mismo nombre 
                if (!context.GetSet<long, ParametroDetalle>().Any(prop => prop.VcNombre.ToUpper() == item.VcNombre.ToUpper() && prop.ParametroId.Equals(item.ParametroId)))
                {
                    context.GetSet<long, ParametroDetalle>().Add(item);
                }
            }

        }
        private static void CargarDireccionCardinalidad(IUnitOfWork context)
        {
            IQueryable<Parametro> query = context.GetSet<long, Parametro>().AsNoTracking();

            query = query.Where(prop => prop.VcCodigoInterno == "bDireccionCardinalidad");

            Parametro parametroPuente = null;
            Parametro parametro = query.AsNoTracking().FirstOrDefault();

            if (parametro is null)
            {
                var parametroAguardar = new Parametro
                {
                    VcNombre = "Dirección Cardinalidad",
                    VcCodigoInterno = "bDireccionCardinalidad",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now,
                    DtFechaActualizacion = DateTime.Now
                    
                };

                context.GetSet<long, Parametro>().Add(parametroAguardar);
                context.Commit();

                parametroPuente = parametroAguardar;
            }
            else
            {
                parametroPuente = parametro;
            }

            List<ParametroDetalle> listaCardinalidad = new List<ParametroDetalle>();

            listaCardinalidad.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Este",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });

            listaCardinalidad.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Oeste",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });

            listaCardinalidad.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Sur",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaCardinalidad.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Norte",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            
            foreach (ParametroDetalle item in listaCardinalidad)
            {
                //Se genera la validacion con el ParametroId, para que se puedan insertar Detalles con el mismo nombre 
                if (!context.GetSet<long, ParametroDetalle>().Any(prop => prop.VcNombre.ToUpper() == item.VcNombre.ToUpper() && prop.ParametroId.Equals(item.ParametroId)))
                {
                    context.GetSet<long, ParametroDetalle>().Add(item);
                }
            }

        }
        

    }
}
