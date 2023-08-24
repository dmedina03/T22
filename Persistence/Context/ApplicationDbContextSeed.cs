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
            CargarTipoSolicitud(context);
            CargarTipoIdentificacion(context);
            CargarConstantes(context);
            CargarResultadoValidacion(context);
            CargarDocumentosSolicitud(context);
            CargarCiudadanoFiltroPor(context);
            CargarFiltroPor(context);
            context.Commit();
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

            List<ParametroDetalle> listaTipoIdentificacion = new List<ParametroDetalle>();

            listaTipoIdentificacion.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Primera vez",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });

            listaTipoIdentificacion.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Renovación",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });

            listaTipoIdentificacion.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Modificación",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaTipoIdentificacion.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Recurso de reposición",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaTipoIdentificacion.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Cancelación",
                TxDescripcion = "",
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
                TxDescripcion = "Cédula ciudadanía",
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
                TxDescripcion = "Cédula extranjería",
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
                TxDescripcion = "Tarjeta de identidad",
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
                TxDescripcion = "Regsitro civil de nacimiento",
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
                TxDescripcion = "Tarjeta de extranjería",
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
                VcNombre = "Cancelar por incumplimiento",
                TxDescripcion = "Cancelación por incumplimiento",
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
        private static void CargarFiltroPor(IUnitOfWork context)
        {
            IQueryable<Parametro> query = context.GetSet<long, Parametro>().AsNoTracking();

            query = query.Where(prop => prop.VcCodigoInterno == "bFiltrarPor");

            Parametro parametroPuente = null;
            Parametro parametro = query.AsNoTracking().FirstOrDefault();

            if (parametro is null)
            {
                var parametroAguardar = new Parametro
                {
                    VcNombre = "Filtrar por",
                    VcCodigoInterno = "bFiltrarPor",
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


    }
}
